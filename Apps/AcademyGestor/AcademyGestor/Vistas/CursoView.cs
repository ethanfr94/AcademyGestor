using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AcademyGestor.ApiService;
using AcademyGestor.Modelos;

namespace AcademyGestor.Vistas
{
    public partial class CursoView : Form
    {
        private CtrlCursos ctrlCursos;
        private CtrlProfesores ctrlProfesores;
        private CtrlProfesoresCurso ctrlProfs_curso;
        private CtrlTipos ctrlTipos;

        private List<Profesor_Curso> profs_curso;
        private List<Profesor> profesores;
        private List<Tipo> tipos;

        private Curso curso;
        private Tipo tipo;

        public CursoView()
        {
            InitializeComponent();
            this.Text = "Nuevo Curso";
            ctrlProfesores = new CtrlProfesores();
            ctrlCursos = new CtrlCursos();
            ctrlProfs_curso = new CtrlProfesoresCurso();
            ctrlTipos = new CtrlTipos();

            cargaProfesores();
            cargaTipos();
        }

        public CursoView(Curso curso)
        {
            InitializeComponent();
            this.Text = "Modificar Curso";
            this.curso = curso;

            ctrlCursos = new CtrlCursos();
            ctrlProfs_curso = new CtrlProfesoresCurso();
            ctrlTipos = new CtrlTipos();
            ctrlProfesores = new CtrlProfesores();

            cargaProfesores();
            cargaTipos();
            cargaDatos();
        }

        private void cargaDatos()
        {
            if (curso != null)
            {
                txtNombre.Text = curso.nombre;
                txtDescripcion.Text = curso.descripcion;
                txtCodCurso.Text = curso.cod_curso;
                txtHorario.Text = curso.horario;
                chkActivo.Checked = (curso.activo == 1) ? true : false;
            }
        }

        private async void cargaTipos()
        {
            tipos = await ctrlTipos.getTipos();
            if (tipos != null)
            {
                cmbTipo.Items.Clear();
                foreach (Tipo tipo in tipos)
                {
                    cmbTipo.Items.Add(tipo.nombre);
                }
            }
            if (curso != null)
            {
                foreach (Tipo tipo in tipos)
                {
                    if (tipo.id == curso.tipo.id)
                    {
                        cmbTipo.SelectedItem = tipo.nombre;
                        break;
                    }
                }
            }
        }

        private async void cargaProfesores()
        {
            profesores = await ctrlProfesores.getProfesores();
            if (curso != null)
            {
                int id = (int)curso.id;
                profs_curso = await ctrlProfs_curso.getProfesoresByCurso(id);
            }

            if (profesores != null)
            {
                cmbCoordinador.Items.Clear();
                foreach (Profesor profesor in profesores)
                {
                    cmbCoordinador.Items.Add(profesor.nombre_completo);
                }
            }


            if (profs_curso != null)
            {
                foreach (Profesor_Curso prof_curso in profs_curso)
                {
                    if (prof_curso.coordinador == 1)
                    {
                        foreach (Profesor profesor in profesores)
                        {
                            if (profesor.id == prof_curso.profesor.id)
                            {
                                cmbCoordinador.SelectedItem = profesor.nombre_completo;
                                break;
                            }
                        }
                        break;
                    }
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!validarCampos())
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (curso == null)
            {
                if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtDescripcion.Text) || string.IsNullOrEmpty(txtCodCurso.Text) || string.IsNullOrEmpty(txtHorario.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cmbTipo.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, seleccione un tipo de curso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                curso = new Curso();
                curso.nombre = txtNombre.Text;
                curso.descripcion = txtDescripcion.Text;
                curso.cod_curso = txtCodCurso.Text;
                curso.horario = txtHorario.Text;
                curso.activo = (byte)1;
                curso.tipo = tipo;

                try
                {
                    bool insertado = await ctrlCursos.addCurso(curso);

                    if (!insertado)
                    {
                        MessageBox.Show("Error al insertar el curso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al insertar el curso: ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                curso.nombre = txtNombre.Text;
                curso.descripcion = txtDescripcion.Text;
                curso.cod_curso = txtCodCurso.Text;
                curso.horario = txtHorario.Text;
                curso.activo = (chkActivo.Checked) ? (byte)1 : (byte)0;
                curso.tipo = tipo;

                bool actualizado = await ctrlCursos.updateCurso(curso);
                if (!actualizado)
                {
                    MessageBox.Show("Error al actualizar el curso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {                    
                    this.Close();
                }

            }
        }

        private void cmbTipo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbTipo.SelectedItem != null)
            {
                foreach (Tipo tipo in tipos)
                {
                    if (tipo.nombre == cmbTipo.SelectedItem.ToString())
                    {
                        this.tipo = tipo;
                        break;
                    }
                }
            }
        }

        private bool validarCampos()
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Por favor, complete el campo Nombre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                MessageBox.Show("Por favor, complete el campo Descripción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtCodCurso.Text))
            {
                MessageBox.Show("Por favor, complete el campo Código de Curso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtHorario.Text))
            {
                MessageBox.Show("Por favor, complete el campo Horario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cmbTipo.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un tipo de curso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

    }
}

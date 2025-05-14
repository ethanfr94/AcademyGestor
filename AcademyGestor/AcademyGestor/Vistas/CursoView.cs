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

        public CursoView()
        {
            InitializeComponent();
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
                profs_curso = await ctrlProfs_curso.getProfesoresByCurso(curso.id);
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
            if (curso == null)
            {
                if(string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtDescripcion.Text) || string.IsNullOrEmpty(txtCodCurso.Text) || string.IsNullOrEmpty(txtHorario.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos.", "Insertar Curso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if(cmbTipo.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, seleccione un tipo de curso.", "Insertar Curso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cmbCoordinador.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, seleccione un coordinador.", "Insertar Curso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                curso = new Curso();
                curso.nombre = txtNombre.Text;
                curso.descripcion = txtDescripcion.Text;
                curso.cod_curso = txtCodCurso.Text;
                curso.horario = txtHorario.Text;
                curso.activo = (chkActivo.Checked) ? (byte)1 : (byte)0;
                curso.tipo = cmbTipo.SelectedItem as Tipo;
                try
                {
                    bool insertado = await ctrlCursos.addCurso(curso);

                    if (!insertado)
                    {
                        MessageBox.Show("Error al insertar el curso.", "Insertar Curso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Curso insertado correctamente.", "Insertar Curso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al insertar el curso: " + ex.Message, "Insertar Curso", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                curso.tipo = cmbTipo.SelectedItem as Tipo;
                try
                {
                    bool actualizado = await ctrlCursos.updateCurso(curso);
                    if (!actualizado)
                    {
                        MessageBox.Show("Error al actualizar el curso.", "Actualizar Curso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Curso actualizado correctamente.", "Actualizar Curso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar el curso: " + ex.Message, "Actualizar Curso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
    }
}

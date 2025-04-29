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
            
            txtNombre.Text = curso.nombre;
            txtDescripcion.Text = curso.descripcion;
            txtCodCurso.Text = curso.cod_curso;
            txtHorario.Text = curso.horario;
            cmbTipo.SelectedItem = curso.tipo.nombre;

            chkActivo.Checked = curso.activo == 1 ? true : false;

            
            
        }

        private void cargaDatos()
        {
            if (curso != null)
            {
                txtNombre.Text = curso.nombre;
                txtDescripcion.Text = curso.descripcion;
                txtCodCurso.Text = curso.cod_curso;
                txtHorario.Text = curso.horario;

                if(curso.tipo.nombre.Equals(cmbTipo.Text))
                {
                    cmbTipo.SelectedItem = curso.tipo.nombre;
                }
                else
                {
                    cmbTipo.SelectedItem = curso.tipo.nombre;
                }
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
        }

        private async void cargaProfesores()
        {
            profesores = await ctrlProfesores.getProfesores();
            if (profesores != null)
            {
                cmbCoordinador.Items.Clear();
                foreach (Profesor profesor in profesores)
                {
                    cmbCoordinador.Items.Add(profesor.nombre);
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using AcademyGestor.ApiService;
using AcademyGestor.Modelos;

namespace AcademyGestor.Vistas
{
    public partial class ProfesoresCursoView : Form
    {
        private CtrlProfesoresCurso ctrlProfesoresCurso;
        private CtrlProfesores ctrlProfesores;

        private List<Profesor> profesores;
        private List<Profesor_Curso> profesoresCurso;
        private Curso curso;
        private Profesor seleccionado;
        private Profesor_Curso coordinador;
        private Profesor select;

        private DataGridViewRow selectedRow;
        public ProfesoresCursoView(Curso curso)
        {
            InitializeComponent();
            this.curso = curso;
            lblCurso.Text = curso.nombre;
            ctrlProfesoresCurso = new CtrlProfesoresCurso();
            ctrlProfesores = new CtrlProfesores();

            profesores = new List<Profesor>();
            profesoresCurso = new List<Profesor_Curso>();

            cargaCoordinador();
            cargaProfesores();
        }

        private async void cargaCoordinador()
        {

            profesoresCurso = await ctrlProfesoresCurso.getProfesoresByCurso(curso.id);

            if (profesoresCurso != null)
            {
                dgvParticipantes.Columns.Clear();
                dgvParticipantes.Columns.Add("Participantes", "Participantes");
                foreach (Profesor_Curso profesorCurso in profesoresCurso)
                {
                    DataGridViewRow row = dgvParticipantes.Rows[dgvParticipantes.Rows.Add(profesorCurso.profesor.nombre_completo)];
                    row.Tag = profesorCurso.profesor;
                }
                dgvParticipantes.CurrentCell = null;

                foreach (Profesor_Curso profesorCurso in profesoresCurso)
                {
                    if (profesorCurso.coordinador == 1)
                    {
                        lblCoordinador.Text = profesorCurso.profesor.nombre_completo;
                        coordinador = profesorCurso;
                    }
                }

            }
        }

        private async void cargaProfesores()
        {
            profesores = await ctrlProfesores.getProfesores();
            profesoresCurso = await ctrlProfesoresCurso.getProfesoresByCurso(curso.id);

            List<Profesor> profesoresCursoList = new List<Profesor>();
            List<Profesor> participantes = new List<Profesor>();

            foreach (Profesor profesor in profesores)
            {

                bool existe = false;
                foreach (Profesor_Curso profesorCurso in profesoresCurso)
                {
                    if (profesor.id == profesorCurso.profesor.id)
                    {
                        existe = true;
                    }
                }
                if (!existe)
                {
                    profesoresCursoList.Add(profesor);
                }

            }

            dgvProfs.Columns.Clear();

            dgvProfs.Columns.Add("Profesores", "Profesores");

            foreach (Profesor item in profesoresCursoList)
            {
                DataGridViewRow row = dgvProfs.Rows[dgvProfs.Rows.Add(item.nombre_completo)];
                row.Tag = item;
            }
            dgvProfs.CurrentCell = null;


        }

        private void dgvProfs_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProfs.SelectedRows.Count > 0)
            {
                btnDesasignar.Enabled = false;
                btnAsignar.Enabled = true;
                selectedRow = dgvProfs.SelectedRows[0];

                if (selectedRow.Tag != null)
                {
                    seleccionado = (Profesor)selectedRow.Tag;
                }

            }
        }

        private void dgvParticipantes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvParticipantes.SelectedRows.Count > 0)
            {
                btnAsignar.Enabled = false;
                btnDesasignar.Enabled = true;
                btnCoordinador.Enabled = true;

                selectedRow = dgvParticipantes.SelectedRows[0];

                if (selectedRow.Tag != null)
                {
                    seleccionado = (Profesor)selectedRow.Tag;
                }

            }
        }

        private async void btnAsignar_Click(object sender, EventArgs e)
        {
            if (seleccionado != null)
            {
                Profesor_Curso profesorCurso = new Profesor_Curso();
                profesorCurso.profesor = seleccionado;
                profesorCurso.curso = curso;
                profesorCurso.coordinador = 0;

                bool exito = await ctrlProfesoresCurso.addProfesorCurso(profesorCurso);

                if (exito)
                {
                    cargaProfesores();
                    cargaCoordinador();
                }
                else
                {
                    MessageBox.Show("Error al asignar el profesor");
                }
            }
            else
            {
                MessageBox.Show("Selecciona un profesor");
            }
        }

        private async void btnDesasignar_Click(object sender, EventArgs e)
        {
            if (seleccionado != null)
            {
                int id = (int)seleccionado.id;

                bool exito = await ctrlProfesoresCurso.deleteProfesorCursoByCursoYProfesor(curso.id, id);

                if (exito)
                {
                    cargaCoordinador();
                    cargaProfesores();
                }
                else
                {
                    MessageBox.Show("Error al desasignar el profesor");
                }
            }
            else
            {
                MessageBox.Show("Selecciona un profesor");
            }
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnCoordinador_Click(object sender, EventArgs e)
        {
            if (seleccionado != null && coordinador != null)
            {
                int idCoord = (int)coordinador.id;
                int idNuevo = (int)seleccionado.id;

                if (idCoord != idNuevo)
                {
                    bool exito = await ctrlProfesoresCurso.updateCoordinador(coordinador);
                    if (exito)
                    {
                        Profesor_Curso pc = await ctrlProfesoresCurso.getByProfesoresByCurso(curso.id, idNuevo);
                        if (pc != null)
                        {
                            exito = await ctrlProfesoresCurso.updateCoordinador(pc);
                            if (exito)
                            {
                                MessageBox.Show("Coordinador asignado correctamente","Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cargaCoordinador();
                                cargaProfesores();
                            }
                            else
                            {
                                MessageBox.Show("Error al asignar el coordinador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("El profesor no esta en el curso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error al desasignar el coordinador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("El profesor ya es el coordinador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        

        private async Task<bool> updateCoord(Profesor_Curso pc)
        {
            bool exito = false;
            try
            {
                exito = await ctrlProfesoresCurso.updateCoordinador(pc);
            }
            catch (HttpRequestException e)
            {
                MessageBox.Show("Error: " + e.Message);
                exito = false;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
                exito = false;
            }
            return exito;
        }
    }
}
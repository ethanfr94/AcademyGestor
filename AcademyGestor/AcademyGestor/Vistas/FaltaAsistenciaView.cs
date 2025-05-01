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
    public partial class FaltaAsistenciaView : Form
    {
        private CtrlFaltas ctrlFaltas;
        private List<Falta_Asistencia> faltas;
        private Alumno alumno;
        private int faltasMes = 0;
        public FaltaAsistenciaView(Alumno alumno)
        {
            InitializeComponent();

            this.Text = "Faltas de asistencia de " + alumno.nombre + " " + alumno.apellido1 + " " + alumno.apellido2;
            ctrlFaltas = new CtrlFaltas();
            faltas = new List<Falta_Asistencia>();
            cargarFaltas(alumno.id);
        }

        private async void cargarFaltas(int? alumnoId)
        {
            try
            {
                if (alumnoId != null)
                {

                    faltas = await ctrlFaltas.getFaltasAlumno((int)alumnoId);

                    if (faltas != null)
                    {
                        var faltasAlumno = faltas.Where(f => f.alumno.id == alumnoId).ToList();

                        if (faltasAlumno.Count > 0)
                        {
                            dgvFaltas.Columns.Add("Fecha", "Fecha");
                            dgvFaltas.Columns.Add("Alumno", "Alumno");
                            dgvFaltas.Columns.Add("Curso", "Curso");

                            foreach (var falta in faltasAlumno)
                            {
                                DataGridViewRow row = dgvFaltas.Rows[dgvFaltas.Rows.Add(
                                    falta.fecha.ToString("dd/MM/yyyy"),
                                    falta.alumno.nombre + " " + falta.alumno.apellido1 + " " + falta.alumno.apellido2,
                                    falta.curso.nombre
                                 )];
                                row.Tag = falta;

                                if (falta.fecha >= DateTime.Now.AddDays(-30))
                                {
                                    faltasMes++;
                                }
                            }
                            dgvFaltas.CurrentCell = null;
                        }
                        else
                        {
                            MessageBox.Show("No se han encontrado faltas para el alumno.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se han encontrado faltas para el alumno.");
                        this.Close();
                    }

                    lblFaltasMes.Text = "- Faltas de asistencia ultimo mes: " + faltasMes.ToString();
                    lblFaltasTotales.Text = "- Faltas de asistencia totales: " + faltas.Count.ToString();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las faltas: " + ex.Message);
            }
        }

    }
}

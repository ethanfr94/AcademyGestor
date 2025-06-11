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

        public FaltaAsistenciaView()
        {
            InitializeComponent();

            this.Text = "Faltas de asistencia";
            ctrlFaltas = new CtrlFaltas();
            faltas = new List<Falta_Asistencia>();
            cargarFaltas();
        }
        

        
        private async void cargarFaltas()
        {
            try
            {
                faltas = await ctrlFaltas.getFaltas();

                if (faltas != null && faltas.Count > 0)
                {
                    dgvFaltas.Columns.Add("Fecha", "Fecha");
                    dgvFaltas.Columns.Add("Alumno", "Alumno");
                    dgvFaltas.Columns.Add("Curso", "Curso");

                    foreach (var falta in faltas)
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

                    lblFaltasMes.Text += faltasMes.ToString();
                    lblFaltasTotales.Text += faltas.Count.ToString();

                }
                else
                {
                    MessageBox.Show("No se han encontrado faltas de sistencia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las faltas: ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Estás seguro de que quieres eliminar la falta seleccionada?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (dgvFaltas.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgvFaltas.SelectedRows[0];
                    if (selectedRow.Tag is Falta_Asistencia falta)
                    {
                        try
                        {
                            int id = (int)falta.id;
                            bool eliminado = await ctrlFaltas.deleteFalta(id);
                            if (eliminado)
                            {
                                dgvFaltas.Rows.Remove(selectedRow);
                                MessageBox.Show("Falta eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Error al eliminar la falta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al eliminar la falta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.ToLower();

            if (string.IsNullOrWhiteSpace(filtro)) // Si el filtro está vacío
            {
                dgvFaltas.Rows.Clear(); // Limpiar el DataGridView
                ActualizarDgv(faltas); // Mostrar todas las faltas
            }
            var faltasFiltradas = faltas.Where(f =>
            f.fecha.ToString().ToLower().Contains(filtro) ||
            f.alumno.nombre.ToLower().Contains(filtro) ||
            f.alumno.apellido1.ToLower().Contains(filtro) ||
            f.alumno.apellido2.ToLower().Contains(filtro) ||
            f.curso.nombre.ToLower().Contains(filtro)).ToList();

            ActualizarDgv(faltasFiltradas);            
        }

        private void ActualizarDgv(List<Falta_Asistencia> datos)
        {
            dgvFaltas.Columns.Clear();

            dgvFaltas.Columns.Add("Fecha", "Fecha");
            dgvFaltas.Columns.Add("Alumno", "Alumno");
            dgvFaltas.Columns.Add("Curso", "Curso");            

            dgvFaltas.Rows.Clear();

            // Agregar filas dinámicamente según los datos
            foreach (var item in datos)
            {
                Falta_Asistencia falta = item as Falta_Asistencia;
                DataGridViewRow row = dgvFaltas.Rows[dgvFaltas.Rows.Add(
                    falta.fecha.ToString("dd/MM/yyyy"),
                    falta.alumno.nombre + " " + falta.alumno.apellido1 + " " + falta.alumno.apellido2,
                    falta.curso.nombre
                )];     
                row.Tag = falta; // Asignar el objeto Falta_Asistencia a la fila
            }

            dgvFaltas.CurrentCell = null; 
        }

        
    }
} 
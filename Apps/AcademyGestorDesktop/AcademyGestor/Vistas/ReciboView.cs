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
    public partial class ReciboView : Form
    {
        private CtrlRecibos ctrlRecibos;

        private List<Recibo> recibos;

        private Empresa empresa;
        private Matricula matricula;
        private Recibo recibo;
        public ReciboView(Matricula matricula, Empresa empresa)
        {
            InitializeComponent();
            this.Text = "Recibos de la matricula: " + matricula.id;
            ctrlRecibos = new CtrlRecibos();
            recibos = new List<Recibo>();
            this.matricula = matricula;
            this.empresa = empresa;

            cargaRecibos();
        }

        public ReciboView()
        {
            InitializeComponent();
            ctrlRecibos = new CtrlRecibos();
            recibos = new List<Recibo>();
            this.matricula = matricula;
            this.empresa = empresa;

            cargaTodosRecibos();
        }

        private async Task cargaTodosRecibos()
        {
            recibos = await ctrlRecibos.getRecibos();

            dgvRecibos.Columns.Clear();
            dgvRecibos.Columns.Add("fecha", "Fecha");
            dgvRecibos.Columns.Add("alumno", "Alumno");
            dgvRecibos.Columns.Add("curso", "Curso");
            dgvRecibos.Columns.Add("importe", "Importe");
            dgvRecibos.Columns.Add("pagado", "Pagado");
            foreach (var item in recibos)
            {

                DataGridViewRow row = dgvRecibos.Rows[dgvRecibos.Rows.Add(
                                    item.fecha?.ToString("dd/MM/yyyy"),
                                    item.matricula.alumno.nombre + " " + item.matricula.alumno.apellido1 + " " + item.matricula.alumno.apellido2,
                                    item.matricula.curso.nombre,
                                    item.importe,
                                    item.pagado == 1 ? "si" : "no"
                                    )];
                row.Tag = item;

            }
            dgvRecibos.CurrentCell = null;
        }

        private async Task cargaRecibos()
        {
            recibos = await ctrlRecibos.getRecibos();

            dgvRecibos.Columns.Clear();
            dgvRecibos.Columns.Add("fecha", "Fecha");
            dgvRecibos.Columns.Add("alumno", "Alumno");
            dgvRecibos.Columns.Add("curso", "Curso");
            dgvRecibos.Columns.Add("importe", "Importe");
            dgvRecibos.Columns.Add("pagado", "Pagado");
            foreach (var item in recibos)
            {
                if (item.matricula.id == matricula.id)
                {
                    DataGridViewRow row = dgvRecibos.Rows[dgvRecibos.Rows.Add(
                                        item.fecha?.ToString("dd/MM/yyyy"),
                                        item.matricula.alumno.nombre + " " + item.matricula.alumno.apellido1 + " " + item.matricula.alumno.apellido2,
                                        item.matricula.curso.nombre,
                                        item.importe,
                                        item.pagado == 1 ? "si" : "no"
                                        )];
                    row.Tag = item;
                }
            }
            dgvRecibos.CurrentCell = null;
        }

        private void dgvRecibos_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvRecibos.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvRecibos.SelectedRows[0];
                if (selectedRow.Tag is Recibo recibo)
                {
                    Double imp = Convert.ToDouble(recibo.importe);

                    if (recibo.descuento == 1)
                    {
                        imp = imp * 0.8;
                    }

                    txtDetalle.Text = recibo.detalle;
                    txtImporte.Text = imp.ToString();
                    chkDescuento.Checked = recibo.descuento == 1;
                    chkPagado.Checked = recibo.pagado == 1;
                    dtpFecha.Value = (DateTime)recibo.fecha;

                    this.recibo = recibo;
                }
            }
        }

        private void chkDescuento_CheckedChanged(object sender, EventArgs e)
        {

        }

        private async void btnCobrar_Click(object sender, EventArgs e)
        {
            if (recibo != null)
            {
                bool pagado = await ctrlRecibos.cobrar(recibo);
                if (pagado)
                {
                    MessageBox.Show("Recibo cobrado", "Registro de cobro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargaRecibos();
                }
                else
                {
                    MessageBox.Show("Error al cobrar el recibo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No hay recibo seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRecibo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidad en desarrollo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.ToLower();

            if (string.IsNullOrWhiteSpace(filtro)) // Si el filtro está vacío
            {
                dgvRecibos.Rows.Clear(); // Limpiar el DataGridView
                ActualizarDgv(recibos); // Mostrar todas las faltas
            }
            var recibosFiltrados = recibos.Where(r =>
            r.fecha.ToString().ToLower().Contains(filtro) ||
            r.matricula.alumno.nombre.ToLower().Contains(filtro) ||
            r.matricula.alumno.apellido1.ToLower().Contains(filtro) ||
            r.matricula.alumno.apellido2.ToLower().Contains(filtro) ||
            r.matricula.curso.nombre.ToLower().Contains(filtro) ||
            r.importe.ToString().ToLower().Contains(filtro) ||
            (r.pagado == 1 ? "si" : "no").Contains(filtro)).ToList();


            ActualizarDgv(recibosFiltrados);
        }

        private void ActualizarDgv(List<Recibo> datos)
        {
            dgvRecibos.Columns.Clear();

            dgvRecibos.Columns.Add("fecha", "Fecha");
            dgvRecibos.Columns.Add("alumno", "Alumno");
            dgvRecibos.Columns.Add("curso", "Curso");
            dgvRecibos.Columns.Add("importe", "Importe");
            dgvRecibos.Columns.Add("pagado", "Pagado");

            dgvRecibos.Rows.Clear();

            // Agregar filas dinámicamente según los datos
            foreach (var item in datos)
            {
                Recibo recibo = item as Recibo;
                DataGridViewRow row = dgvRecibos.Rows[dgvRecibos.Rows.Add(
                                        item.fecha?.ToString("dd/MM/yyyy"),
                                        item.matricula.alumno.nombre + " " + item.matricula.alumno.apellido1 + " " + item.matricula.alumno.apellido2,
                                        item.matricula.curso.nombre,
                                        item.importe,
                                        item.pagado == 1 ? "si" : "no"
                                        )];
                row.Tag = item;
            }

            dgvRecibos.CurrentCell = null;
        }
    }
}

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
    public partial class TutorView : Form
    {
        private CtrlTutores ctrlTutores;
        private List<Tutor> tutores;
        private Tutor tutor;
        public TutorView()
        {
            InitializeComponent();
            ctrlTutores = new CtrlTutores();
            tutores = new List<Tutor>();
            cargarTutores();
        }

        private async void cargarTutores()
        {
            tutores = await ctrlTutores.getTutores();
            if (tutores != null)
            {
                dgvTutores.Columns.Add("nombre", "Nombre");
                dgvTutores.Columns.Add("apellido1", "Primer apellido");
                dgvTutores.Columns.Add("apellido2", "Segundo apellido");

                foreach (var item in tutores)
                {
                    DataGridViewRow row = dgvTutores.Rows[dgvTutores.Rows.Add(
                        item.nombre,
                        item.apellido1,
                        item.apellido2
                    )];
                    row.Tag = item;
                }

            }
            dgvTutores.CurrentCell = null;
        }

        private void dgvTutores_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTutores.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvTutores.SelectedRows[0];

                if (selectedRow.Tag is Tutor tutor)
                {
                    this.tutor = tutor;

                    txtNombre.Text = tutor.nombre ?? string.Empty;
                    txtApe1.Text = tutor.apellido1 ?? string.Empty;
                    txtApe2.Text = tutor.apellido2 ?? string.Empty;
                    txtDni.Text = tutor.dni ?? string.Empty;
                    txtDireccion.Text = tutor.direccion ?? string.Empty;
                    txtLocalidad.Text = tutor.localidad ?? string.Empty;
                    txtEmail.Text = tutor.email ?? string.Empty;
                    txtTlfn.Text = tutor.telefono ?? string.Empty;
                }
                else
                {
                    LimpiarCampos();
                }
            }
            else
            {
                LimpiarCampos();
            }

        }

        private void LimpiarCampos()
        {
            txtNombre.Text = string.Empty;
            txtApe1.Text = string.Empty;
            txtApe2.Text = string.Empty;
            txtDni.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtLocalidad.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtTlfn.Text = string.Empty;

            dgvTutores.ClearSelection();
        }

        private void chkEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEdit.Checked)
            {
                if (dgvTutores.CurrentRow != null)
                {
                    txtNombre.Enabled = true;
                    txtApe1.Enabled = true;
                    txtApe2.Enabled = true;
                    txtEmail.Enabled = true;
                    txtDireccion.Enabled = true;
                    txtLocalidad.Enabled = true;
                    txtTlfn.Enabled = true;

                    btnGuardar.Enabled = true;
                }
            }
            else
            {
                txtNombre.Enabled = false;
                txtApe1.Enabled = false;
                txtApe2.Enabled = false;
                txtEmail.Enabled = false;
                txtDni.Enabled = false;
                txtDireccion.Enabled = false;
                txtLocalidad.Enabled = false;
                txtTlfn.Enabled = false;

                btnGuardar.Enabled = false;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                Tutor t = await ctrlTutores.getTutorByDni(this.tutor.dni);

                if (t != null)
                {
                    t.nombre = txtNombre.Text;
                    t.apellido1 = txtApe1.Text;
                    t.apellido2 = txtApe2.Text;
                    t.direccion = txtDireccion.Text;
                    t.localidad = txtLocalidad.Text;
                    t.email = txtEmail.Text;
                    t.telefono = txtTlfn.Text;
                    if (await ctrlTutores.updateTutor(t))
                    {
                        MessageBox.Show("Tutor actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarCampos();
                        cargarTutores();
                        chkEdit.Checked = false;
                    }
                }
                else
                {
                    MessageBox.Show("No se ha encontrado el tutor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            this.DialogResult = DialogResult.OK;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApe1.Text) ||
                string.IsNullOrWhiteSpace(txtApe2.Text) ||
                string.IsNullOrWhiteSpace(txtDni.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtTlfn.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                string.IsNullOrWhiteSpace(txtLocalidad.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            /*
            if (!ValidarDni(txtDniTutor.Text))
            {
                MessageBox.Show("El DNI del tutor no tiene un formato válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!ValidarEmail(txtEmailTutor.Text))
            {
                MessageBox.Show("El email del tutor no tiene un formato válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!ValidarTelefono(txtTlfnTutor.Text))
            {
                MessageBox.Show("El teléfono del tutor no tiene un formato válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }*/

            return true;
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("¿Está seguro de que desea eliminar el tutor?", "Eliminar tutor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                if (tutor != null)
                {
                    int id = (int)tutor.id;

                    bool eliminado = await ctrlTutores.deleteTutor(id);

                    if (eliminado)
                    {
                        MessageBox.Show("Tutor eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarCampos();
                        cargarTutores();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el tutor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            this.DialogResult = DialogResult.OK;
        }
    }

}


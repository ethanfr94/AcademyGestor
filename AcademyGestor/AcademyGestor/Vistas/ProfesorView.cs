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
    public partial class ProfesorView : Form
    {
        private Profesor profesor;
        private CtrlProfesores ctrlProfesores;
        public ProfesorView()
        {
            InitializeComponent();
            this.ctrlProfesores = new CtrlProfesores();
        }

        public ProfesorView(Profesor profesor)
        {
            InitializeComponent();
            this.profesor = profesor;
            this.ctrlProfesores = new CtrlProfesores();
            cargaDatos();
        }

        private void cargaDatos()
        {
            txtNombre.Text = profesor.nombre;
            txtApe1.Text = profesor.apellido1;
            txtApe2.Text = profesor.apellido2;
            txtEmail.Text = profesor.email;
            txtDni.Text = profesor.dni;
            txtDireccion.Text = profesor.direccion;
            txtLocalidad.Text = profesor.localidad;
            txtTlfn.Text = profesor.telefono;
            chkActivo.Checked = profesor.activo == 1 ? true : false;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (this.profesor != null)
            {
                profesor.nombre = txtNombre.Text;
                profesor.apellido1 = txtApe1.Text;
                profesor.apellido2 = txtApe2.Text;
                profesor.email = txtEmail.Text;
                profesor.dni = txtDni.Text;
                profesor.direccion = txtDireccion.Text;
                profesor.localidad = txtLocalidad.Text;
                profesor.telefono = txtTlfn.Text;
                profesor.activo = chkActivo.Checked ? (byte)1 : (byte)0;

                bool ok = await ctrlProfesores.updateProfesor(profesor);

                if (ok)
                {
                    MessageBox.Show("Profesor actualizado correctamente");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al actualizar el profesor");
                }
            }
            else
            {
                profesor = new Profesor();

                profesor.nombre = txtNombre.Text;
                profesor.apellido1 = txtApe1.Text;
                profesor.apellido2 = txtApe2.Text;
                profesor.email = txtEmail.Text;
                profesor.dni = txtDni.Text;
                profesor.direccion = txtDireccion.Text;
                profesor.localidad = txtLocalidad.Text;
                profesor.telefono = txtTlfn.Text;
                profesor.activo = 1;

                bool ok = await ctrlProfesores.addProfesor(profesor);

                if (ok)
                {
                    MessageBox.Show("Profesor guardado correctamente");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al guardar el profesor");
                }
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar este profesor?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                bool eliminado = await ctrlProfesores.deleteProfesor((int)profesor.id);
                if (eliminado)
                {
                    MessageBox.Show("Profesor eliminado correctamente");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el profesor");
                }
            }
        }
    }
}

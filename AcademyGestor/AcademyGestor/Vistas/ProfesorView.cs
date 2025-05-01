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
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
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
}

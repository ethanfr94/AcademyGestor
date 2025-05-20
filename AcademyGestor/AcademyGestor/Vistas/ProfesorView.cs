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
            this.Text = "Nuevo Profesor";
            this.ctrlProfesores = new CtrlProfesores();
        }

        public ProfesorView(Profesor profesor)
        {
            InitializeComponent();
            this.Text = "Modificar Profesor";
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
            if (!validarCampos())
            {
                MessageBox.Show("Por favor, rellene todos los campos.", "Campos obligatorios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
                    MessageBox.Show("Profesor actualizado correctamente", "Profesor actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al actualizar el profesor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Profesor guardado correctamente", "Profesor guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al guardar el profesor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Profesor eliminado correctamente", "Profesor eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el profesor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool validarCampos()
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("El campo Nombre es obligatorio.", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtApe1.Text))
            {
                MessageBox.Show("El campo Apellido 1 es obligatorio.", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("El campo Email es obligatorio.", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!ValidarEmail(txtEmail.Text))
            {
                MessageBox.Show("El campo Email es inválido.", "Campo inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtDni.Text))
            {
                MessageBox.Show("El campo DNI es obligatorio.", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!ValidarDni(txtDni.Text))
            {
                MessageBox.Show("El campo DNI es inválido.", "Campo inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                MessageBox.Show("El campo Dirección es obligatorio.", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtLocalidad.Text))
            {
                MessageBox.Show("El campo Localidad es obligatorio.", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtTlfn.Text))
            {
                MessageBox.Show("El campo Teléfono es obligatorio.", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtTlfn.Text.Length < 9)
            {
                if(!ValidarTelefono(txtTlfn.Text))
                {
                    MessageBox.Show("El campo Teléfono debe contener 9 dígitos.", "Campo inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        private bool ValidarTelefono(string telefono)
        {
            return telefono.All(char.IsDigit) && telefono.Length == 9;
        }
        private bool ValidarDni(string dniNie)
        {
            if (string.IsNullOrWhiteSpace(dniNie) || dniNie.Length != 9)
                return false;

            dniNie = dniNie.ToUpper();

            // Validar NIE (comienza con X, Y o Z)
            if (dniNie[0] == 'X' || dniNie[0] == 'Y' || dniNie[0] == 'Z')
            {
                // Reemplazar la letra inicial por un número para tratarlo como un DNI
                char primeraLetra = dniNie[0];
                string numeros = dniNie.Substring(1, 7);
                char letra = dniNie[8];

                if (!int.TryParse(numeros, out _))
                    return false;

                // Convertir la letra inicial del NIE a un número
                switch (primeraLetra)
                {
                    case 'X': numeros = "0" + numeros; break;
                    case 'Y': numeros = "1" + numeros; break;
                    case 'Z': numeros = "2" + numeros; break;
                }

                return ValidarLetraDni(numeros, letra);
            }
            // Validar DNI (8 dígitos seguidos de una letra)
            else
            {
                string numeros = dniNie.Substring(0, 8);
                char letra = dniNie[8];

                if (!int.TryParse(numeros, out _))
                    return false;

                return ValidarLetraDni(numeros, letra);
            }
        }

        private bool ValidarLetraDni(string numeros, char letra)
        {
            // Letras válidas para el DNI según el módulo 23
            string letrasValidas = "TRWAGMYFPDXBNJZSQVHLCKE";

            // Calcular la posición de la letra
            int numero = int.Parse(numeros);
            int posicion = numero % 23;

            // Comparar la letra calculada con la letra proporcionada
            return letrasValidas[posicion] == letra;
        }

        private bool ValidarEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            // Expresión regular para validar el formato del correo electrónico
            string patron = @"^[^@\s]+@[^@\s]+\.[a-zA-Z]{2,}$";
            return System.Text.RegularExpressions.Regex.IsMatch(email, patron);
        }
    }
}

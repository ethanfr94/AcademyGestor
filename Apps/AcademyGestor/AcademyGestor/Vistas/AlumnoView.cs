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
    public partial class AlumnoView : Form
    {
        CtrlAlumnos ctrlAlumnos;
        private CtrlTutores ctrlTutores;
        private List<Tutor> tutores;
        private Alumno alumno;
        private Tutor tutor;
        private Tutor nuevo = null;


        public AlumnoView()
        {
            InitializeComponent();
            this.Text = "Nuevo Alumno";
            ctrlAlumnos = new CtrlAlumnos();
            ctrlTutores = new CtrlTutores();
            cargarTutores();
            dtpFecha_nac_ValueChanged(null, null);
        }

        public AlumnoView(Alumno alumno)
        {
            InitializeComponent();
            this.Text = "Modificar Alumno";
            this.alumno = alumno;
            this.tutor = alumno.tutor;
            this.Text = "Datos del Alumno " + alumno.nombre + " " + alumno.apellido1 + " " + alumno.apellido2;
            ctrlTutores = new CtrlTutores();
            ctrlAlumnos = new CtrlAlumnos();
            cargarTutores();
            dtpFecha_nac_ValueChanged(null, null);
            cargarAlumno();


        }

        private void cargarAlumno()
        {

            txtNombre.Text = alumno.nombre;
            txtApe1.Text = alumno.apellido1;
            txtApe2.Text = alumno.apellido2;
            txtEmail.Text = alumno.email;
            txtDni.Text = alumno.dni;
            txtDireccion.Text = alumno.direccion;
            txtLocalidad.Text = alumno.localidad;
            txtTlfn.Text = alumno.telefono;
            dtpFecha_nac.Value = alumno.fechaNac;
            chkProt_datos.Checked = (alumno.proteccionDatos == 1);
            chkWhatsapp.Checked = (alumno.grupoWhatsapp == 1);
            chkComerc.Checked = (alumno.comunicacionesComerciales == 1);


        }


        private async void cargarTutores()
        {
            tutores = await ctrlTutores.getTutores();
            if (tutores != null)
            {
                cmbTutor.DataSource = tutores;
                cmbTutor.DisplayMember = "nombreCompleto";
                cmbTutor.SelectedIndex = -1;

                limpiarCamposTutor();
            }
            else
            {
                MessageBox.Show("Error al cargar los tutores", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (tutor != null)
            {
                foreach (var item in cmbTutor.Items)
                {
                    if (item is Tutor t && t.id == tutor.id)
                    {
                        cmbTutor.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        private void cmbTutor_SelectedValueChanged(object sender, EventArgs e)
        {
            Tutor tutorSeleccionado = cmbTutor.SelectedItem as Tutor;

            if (tutorSeleccionado != null)
            {
                txtNombreTutor.Text = tutorSeleccionado.nombre;
                txtApe1Tutor.Text = tutorSeleccionado.apellido1;
                txtApe2Tutor.Text = tutorSeleccionado.apellido2;
                txtEmailTutor.Text = tutorSeleccionado.email;
                txtDniTutor.Text = tutorSeleccionado.dni;
                txtDireccionTutor.Text = tutorSeleccionado.direccion;
                txtLocalidadTutor.Text = tutorSeleccionado.localidad;
                txtTlfnTutor.Text = tutorSeleccionado.telefono;
            }

        }

        private void chkNuevoTutor_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNuevoTutor.Checked)
            {
                cmbTutor.Enabled = false;
                txtNombreTutor.Enabled = true;
                txtApe1Tutor.Enabled = true;
                txtApe2Tutor.Enabled = true;
                txtEmailTutor.Enabled = true;
                txtDniTutor.Enabled = true;
                txtDireccionTutor.Enabled = true;
                txtLocalidadTutor.Enabled = true;
                txtTlfnTutor.Enabled = true;

                limpiarCamposTutor();
            }
            else
            {
                cmbTutor.Enabled = true;
                txtNombreTutor.Enabled = false;
                txtApe1Tutor.Enabled = false;
                txtApe2Tutor.Enabled = false;
                txtEmailTutor.Enabled = false;
                txtDniTutor.Enabled = false;
                txtDireccionTutor.Enabled = false;
                txtLocalidadTutor.Enabled = false;
                txtTlfnTutor.Enabled = false;          
            }
        }

        private void limpiarCamposTutor()
        {
            txtNombreTutor.Text = "";
            txtApe1Tutor.Text = "";
            txtApe2Tutor.Text = "";
            txtEmailTutor.Text = "";
            txtDniTutor.Text = "";
            txtDireccionTutor.Text = "";
            txtLocalidadTutor.Text = "";
            txtTlfnTutor.Text = "";

            cmbTutor.SelectedIndex = -1; // Limpiar la selección del ComboBox
        }

        private int CalcularEdad(DateTime fechaNacimiento)
        {
            int edad = DateTime.Now.Year - fechaNacimiento.Year;
            if (DateTime.Now < fechaNacimiento.AddYears(edad)) // Si aún no ha cumplido años este año
            {
                edad--;
            }
            return edad;
        }

        private void dtpFecha_nac_ValueChanged(object sender, EventArgs e)
        {
            int edad = CalcularEdad(dtpFecha_nac.Value);

            if (edad < 18)
            {
                gbTutor.Enabled = true; // Habilitar el GroupBox si es menor de 18 años
            }
            else
            {
                gbTutor.Enabled = false; // Deshabilitar el GroupBox si es mayor o igual a 18 años
                chkNuevoTutor.Checked = false; // Desmarcar la opción de nuevo tutor
                cmbTutor.SelectedItem = null; // Limpiar la selección del ComboBox
                limpiarCamposTutor(); // Limpiar los campos del tutor

            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {            
            if (!ValidarCampos())
            {
                return;
            }

            if (alumno == null)
            {
                alumno = new Alumno();

                alumno.nombre = txtNombre.Text;
                alumno.apellido1 = txtApe1.Text;
                alumno.apellido2 = txtApe2.Text;
                alumno.email = txtEmail.Text;
                alumno.dni = txtDni.Text;
                alumno.direccion = txtDireccion.Text;
                alumno.localidad = txtLocalidad.Text;
                alumno.telefono = txtTlfn.Text;
                alumno.fechaNac = dtpFecha_nac.Value;
                alumno.proteccionDatos = (byte)(chkProt_datos.Checked ? 1 : 0);
                alumno.grupoWhatsapp = (byte)(chkWhatsapp.Checked ? 1 : 0);
                alumno.comunicacionesComerciales = (byte)(chkComerc.Checked ? 1 : 0);

                if (chkNuevoTutor.Checked)
                {
                    nuevo = new Tutor();

                    nuevo.nombre = txtNombreTutor.Text;
                    nuevo.apellido1 = txtApe1Tutor.Text;
                    nuevo.apellido2 = txtApe2Tutor.Text;
                    nuevo.email = txtEmailTutor.Text;
                    nuevo.dni = txtDniTutor.Text;
                    nuevo.direccion = txtDireccionTutor.Text;
                    nuevo.localidad = txtLocalidadTutor.Text;
                    nuevo.telefono = txtTlfnTutor.Text;


                    // Verificar si el tutor ya existe en la base de datos
                    Tutor tutorExistente = await ctrlTutores.getTutorByDni(nuevo.dni);

                    if (tutorExistente == null)
                    {
                        // Si no existe, crear un nuevo tutor
                        bool tutorCreado = await ctrlTutores.addTutor(nuevo);
                        if (!tutorCreado)
                        {
                            MessageBox.Show("Error al crear el tutor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Tutor creado correctamente.", "Tutor creado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        nuevo = await ctrlTutores.getTutorByDni(nuevo.dni);
                        alumno.tutor = nuevo;
                    }
                    else
                    {
                        MessageBox.Show("El tutor ya existe. Revise los datos o seleccionelo de la lista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {

                    nuevo = cmbTutor.SelectedItem as Tutor;
                    if (nuevo != null)
                    {
                        alumno.tutor = nuevo;
                    }
                }

                bool creado = await ctrlAlumnos.addAlumno(alumno);
                if (!creado)
                {
                    MessageBox.Show("Error al crear el alumno.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("Alumno creado correctamente.", "Alumno creado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }

            }
            else
            {
                alumno.nombre = txtNombre.Text;
                alumno.apellido1 = txtApe1.Text;
                alumno.apellido2 = txtApe2.Text;
                alumno.email = txtEmail.Text;
                alumno.dni = txtDni.Text;
                alumno.direccion = txtDireccion.Text;
                alumno.localidad = txtLocalidad.Text;
                alumno.telefono = txtTlfn.Text;
                alumno.fechaNac = dtpFecha_nac.Value;
                alumno.proteccionDatos = (byte)(chkProt_datos.Checked ? 1 : 0);
                alumno.grupoWhatsapp = (byte)(chkWhatsapp.Checked ? 1 : 0);
                alumno.comunicacionesComerciales = (byte)(chkComerc.Checked ? 1 : 0);

                if (chkNuevoTutor.Checked)
                {
                    nuevo = new Tutor();

                    nuevo.nombre = txtNombreTutor.Text;
                    nuevo.apellido1 = txtApe1Tutor.Text;
                    nuevo.apellido2 = txtApe2Tutor.Text;
                    nuevo.email = txtEmailTutor.Text;
                    nuevo.dni = txtDniTutor.Text;
                    nuevo.direccion = txtDireccionTutor.Text;
                    nuevo.localidad = txtLocalidadTutor.Text;
                    nuevo.telefono = txtTlfnTutor.Text;


                    // Verificar si el tutor ya existe en la base de datos
                    Tutor tutorExistente = await ctrlTutores.getTutorByDni(nuevo.dni);

                    if (tutorExistente == null)
                    {
                        // Si no existe, crear un nuevo tutor
                        bool tutorCreado = await ctrlTutores.addTutor(nuevo);
                        if (!tutorCreado)
                        {
                            MessageBox.Show("Error al crear el tutor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Tutor creado correctamente.", "Tutor creado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        nuevo = await ctrlTutores.getTutorByDni(nuevo.dni);
                        alumno.tutor = nuevo;
                    }
                    else
                    {
                        MessageBox.Show("El tutor ya existe. Revise los datos o seleccionelo de la lista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    nuevo = cmbTutor.SelectedItem as Tutor;
                    if (nuevo != null)
                    {
                        alumno.tutor = nuevo;
                    }
                }
                if (CalcularEdad(alumno.fechaNac) >= 18)
                {
                    alumno.tutor = null;
                }
                else
                {
                    if (nuevo != null)
                    {
                        alumno.tutor = nuevo;
                    }
                }
                bool actualizado = await ctrlAlumnos.updateAlumno(alumno);
                if (!actualizado)
                {
                    MessageBox.Show("Error al actualizar el alumno.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    MessageBox.Show("Alumno actualizado correctamente.", "Alumno actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                if (alumno.tutor == null)
                {
                    MessageBox.Show("El tutor del alumno ha sido eliminado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        private bool ValidarCampos()
        {
            // Validar campos obligatorios del alumno
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El campo 'Nombre del Alumno' es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtApe1.Text))
            {
                MessageBox.Show("El campo 'Primer Apellido del Alumno' es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDni.Text))
            {
                MessageBox.Show("El campo 'DNI del Alumno' es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!ValidarDni(txtDni.Text))
            {
                MessageBox.Show("El DNI del alumno no tiene un formato válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!ValidarEmail(txtEmail.Text))
            {
                MessageBox.Show("El email del alumno no tiene un formato válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validar teléfono solo si no está vacío
            if (!string.IsNullOrWhiteSpace(txtTlfn.Text) && !ValidarTelefono(txtTlfn.Text))
            {
                MessageBox.Show("El teléfono del alumno no tiene un formato válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validar consentimiento de protección de datos
            if (!chkProt_datos.Checked)
            {
                MessageBox.Show("Debe aceptar la política de protección de datos para continuar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validar campos del tutor si el alumno es menor de edad
            int edad = CalcularEdad(dtpFecha_nac.Value);
            if (edad < 18)
            {
                if (chkNuevoTutor.Checked) // Si se está creando un nuevo tutor
                {
                    if (string.IsNullOrWhiteSpace(txtNombreTutor.Text) ||
                        string.IsNullOrWhiteSpace(txtApe1Tutor.Text) ||
                        string.IsNullOrWhiteSpace(txtDniTutor.Text) ||
                        string.IsNullOrWhiteSpace(txtEmailTutor.Text) ||
                        string.IsNullOrWhiteSpace(txtTlfnTutor.Text))
                    {
                        MessageBox.Show("Todos los campos del tutor son obligatorios para alumnos menores de edad.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    
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
                    }
                }
                else if (cmbTutor.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un tutor para alumnos menores de edad.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

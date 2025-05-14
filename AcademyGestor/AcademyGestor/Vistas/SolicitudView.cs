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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace AcademyGestor.Vistas
{
    public partial class SolicitudView : Form
    {
        private CtrlSolicitudes ctrlSolicitudes;
        private CtrlAlumnos ctrlAlumnos;
        private CtrlTutores ctrlTutores;
        private CtrlMatriculas ctrlMatriculas;

        private Tutor tutor;
        private Solicitud solicitud;
        private Curso curso;
        public SolicitudView()
        {
            InitializeComponent();
        }

        public SolicitudView(Solicitud solicitud)
        {
            InitializeComponent();

            this.solicitud = solicitud;
            this.curso = solicitud.curso;
            this.ctrlSolicitudes = new CtrlSolicitudes();
            this.ctrlAlumnos = new CtrlAlumnos();
            this.ctrlTutores = new CtrlTutores();
            this.ctrlMatriculas = new CtrlMatriculas();

            cargaDatos();
        }

        async private void cargaDatos()
        {
            if (solicitud.tutor != null)
            {
                tutor = await ctrlTutores.getTutorByDni(solicitud.tutor.dni);
            }

            txtCurso.Text = solicitud.curso.nombre;

            dtpFecha.Text = solicitud.fecha.ToShortDateString();
            txtNombre.Text = this.solicitud.nombre;
            txtApe1.Text = this.solicitud.apellido1;
            txtApe2.Text = this.solicitud.apellido2;
            txtDni.Text = this.solicitud.dni;
            dtpFecha_nac.Text = this.solicitud.fechaNac.ToShortDateString();
            txtDireccion.Text = this.solicitud.direccion;
            txtLocalidad.Text = this.solicitud.localidad;
            txtEmail.Text = this.solicitud.email;
            txtTlfn.Text = this.solicitud.telefono;
            if (tutor != null)
            {
                txtDniTutor.Text = tutor.dni;
                txtNombreTutor.Text = tutor.nombre;
                txtApe1Tutor.Text = tutor.apellido1;
                txtApe2Tutor.Text = tutor.apellido2;
                txtDireccionTutor.Text = tutor.direccion;
                txtLocalidadTutor.Text = tutor.localidad;
                txtEmailTutor.Text = tutor.email;
                txtTlfnTutor.Text = tutor.telefono;
            }
            chkProt_datos.Checked = this.solicitud.proteccionDatos == 1;
            chkFotos.Checked = this.solicitud.autorizacionFotos == 1;
            chkWhatsapp.Checked = this.solicitud.grupoWhatsapp == 1;
            chkComerc.Checked = this.solicitud.comunicacionesComerciales == 1;
            chkBeca.Checked = this.solicitud.beca == 1;


        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar la solicitud?", "Eliminar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                bool eliminado = await ctrlSolicitudes.deleteSolicitud((int)solicitud.id);
                if (!eliminado)
                {
                    MessageBox.Show("Error al eliminar la solicitud.", "Eliminar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("Solicitud eliminada correctamente.", "Eliminar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            Alumno alumno = await ctrlAlumnos.getAlumnoByDni(solicitud.dni);

            if (alumno == null)
            {
                alumno = new Alumno();
                alumno.nombre = txtNombre.Text;
                alumno.apellido1 = txtApe1.Text;
                alumno.apellido2 = txtApe2.Text;
                alumno.dni = txtDni.Text;
                alumno.fechaNac = dtpFecha_nac.Value;
                alumno.direccion = txtDireccion.Text;
                alumno.localidad = txtLocalidad.Text;
                alumno.email = txtEmail.Text;
                alumno.telefono = txtTlfn.Text;


                if (CalcularEdad(dtpFecha_nac.Value) < 18)
                {
                    if (tutor == null)
                    {
                        alumno.tutor = null;
                    }
                    else
                    {
                        alumno.tutor = tutor;
                    }
                }

                bool insertado = await ctrlAlumnos.addAlumno(alumno);

                if (!insertado)
                {
                    MessageBox.Show("Error al insertar el alumno.", "Matricula", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("Alumno insertado correctamente.", "Matricula", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                alumno = await ctrlAlumnos.getAlumnoByDni(alumno.dni);

                Matricula matricula = new Matricula();
                matricula.alumno = alumno;
                matricula.curso = curso;
                matricula.beca = solicitud.beca;
                matricula.autorizacionFotos = solicitud.autorizacionFotos;

                bool insertado = await ctrlMatriculas.addMatricula(matricula);
                if (!insertado)
                {
                    MessageBox.Show("Error al insertar la matricula.", "Matricula", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("Matricula insertada correctamente.", "Matricula", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
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



    }
}

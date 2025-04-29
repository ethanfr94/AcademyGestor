using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AcademyGestor.ApiService;
using AcademyGestor.Modelos;
using AcademyGestor.Vistas;

namespace AcademyGestor
{
    public partial class Main : Form
    {
        private CtrlAlumnos ctrlAlumnos;
        private CtrlCursos ctrlCursos;
        private CtrlSolicitudes ctrlSolicitudes;
        private CtrlMatriculas ctrlMatriculas;
        private CtrlProfesores ctrlProfesores;
        private CtrlRecibos ctrlRecibos;
        private CtrlPublicaciones ctrlPublicaciones;
        private CtrlProfesoresCurso ctrlProfesoresCurso;

        private List<Alumno> alumnos;
        private List<Curso> cursos;
        private List<Solicitud> solicitudes;
        private List<Matricula> matriculas;
        private List<Profesor> profesores;
        private List<Recibo> recibos;
        private List<Publicacion> publicaciones;
        private List<Profesor_Curso> profesoresCurso;




        public Main()
        {
            InitializeComponent();
            ctrlAlumnos = new CtrlAlumnos();
            ctrlCursos = new CtrlCursos();
            ctrlSolicitudes = new CtrlSolicitudes();
            ctrlMatriculas = new CtrlMatriculas();
            ctrlProfesores = new CtrlProfesores();
            ctrlRecibos = new CtrlRecibos();
            ctrlPublicaciones = new CtrlPublicaciones();
            ctrlProfesoresCurso = new CtrlProfesoresCurso();

            alumnos = new List<Alumno>();
            cursos = new List<Curso>();
            solicitudes = new List<Solicitud>();
            matriculas = new List<Matricula>();
            profesores = new List<Profesor>();
            recibos = new List<Recibo>();
            publicaciones = new List<Publicacion>();
            profesoresCurso = new List<Profesor_Curso>();
        }



        private async void cargaAlumnos()
        {
            alumnos = await ctrlAlumnos.getAlumnos();

            btnFaltas.Visible = true;

            dgvDatos.Columns.Clear();

            dgvDatos.Columns.Add("nombre", "Nombre");
            dgvDatos.Columns.Add("apellidos", "Apellidos");
            dgvDatos.Columns.Add("email", "Email");
            dgvDatos.Columns.Add("telefono", "Telefono");
            dgvDatos.Columns.Add("tutor", "Tutor");
            dgvDatos.Columns.Add("prot_datos", "Proteccion de datos");
            dgvDatos.Columns.Add("whatsapp", "Whatsapp");
            dgvDatos.Columns.Add("com_comerciales", "Comunicaciones comerciales");


            foreach (var item in alumnos)
            {
                if (item.tutor == null)
                {
                    item.tutor = new Tutor();
                    item.tutor.nombre = "Sin tutor";
                    item.tutor.apellido1 = "";
                    item.tutor.apellido2 = "";
                }

                DataGridViewRow row = dgvDatos.Rows[dgvDatos.Rows.Add(
                    item.nombre,
                    item.apellido1 + " " + item.apellido2,
                    item.email,
                    item.telefono,
                    item.tutor.nombre + " " + item.tutor.apellido1 + " " + item.tutor.apellido2,
                    item.proteccionDatos == 1? "si" : "no",
                    item.grupoWhatsapp == 1? "si" : "no",
                    item.comunicacionesComerciales == 1? "si" : "no"
                )];
                row.Tag = item;
            }
            dgvDatos.CurrentCell = null;
        }

        private async void cargaProfesores()
        {
            profesores = await ctrlProfesores.getProfesores();

            dgvDatos.Columns.Clear();

            dgvDatos.Columns.Add("nombre", "Nombre");
            dgvDatos.Columns.Add("apellidos", "Apellidos");
            dgvDatos.Columns.Add("email", "Email");
            dgvDatos.Columns.Add("telefono", "Telefono");
            dgvDatos.Columns.Add("activo", "Activo");

            foreach (var item in profesores)
            {
                DataGridViewRow row = dgvDatos.Rows[dgvDatos.Rows.Add(
                    item.nombre,
                    item.apellido1 + " " + item.apellido2,
                    item.email, item.telefono,
                    item.activo ? "si" : "no"
                )];
                row.Tag = item;
            }
            dgvDatos.CurrentCell = null;
        }

        private async void cargaCursos()
        {
            cursos = await ctrlCursos.getCursos();

            dgvDatos.Columns.Clear();

            dgvDatos.Columns.Add("codigo", "Codigo");
            dgvDatos.Columns.Add("nombre", "Nombre");
            dgvDatos.Columns.Add("tipo", "Tipo");
            dgvDatos.Columns.Add("activo", "Activo");

            foreach (var item in cursos)
            {
                DataGridViewRow row = dgvDatos.Rows[dgvDatos.Rows.Add(
                    item.cod_curso, 
                    item.nombre, 
                    item.tipo.nombre, 
                    item.activo == 1 ? "si" : "no"
                )];
                row.Tag = item;
            }
            dgvDatos.CurrentCell = null;
        }

        private async void cargaSolicitudes()
        {
            solicitudes = await ctrlSolicitudes.getSolicitudes();

            dgvDatos.Columns.Clear();
            dgvDatos.Columns.Add("fecha", "Fecha");
            dgvDatos.Columns.Add("curso", "Curso");
            dgvDatos.Columns.Add("alumno", "Alumno");
            dgvDatos.Columns.Add("proteccion de datos", "Proteccion de datos");
            dgvDatos.Columns.Add("aut_fotos", "Autorizacion de fotos");
            dgvDatos.Columns.Add("whatsapp", "Grupo de whatsapp");
            dgvDatos.Columns.Add("comunicaciones comerciales", "Comunicaciones comerciales");

            foreach (var item in solicitudes)
            {
                DataGridViewRow row = dgvDatos.Rows[dgvDatos.Rows.Add(
                    item.fecha.ToString("dd/MM/yyyy"), 
                    item.curso.cod_curso + " " + item.curso.nombre, 
                    item.nombre + " " + item.apellido1 + " " + item.apellido2, 
                    item.prot_datos ? "si" : "no", 
                    item.aut_fotos ? "si" : "no", 
                    item.whatsapp ? "si" : "no",
                    item.com_comerciales ? "si" : "no"
                    )];
                row.Tag = item;
            }
            dgvDatos.CurrentCell = null;
        }

        private async void cargaMatriculas()
        {
            matriculas = await ctrlMatriculas.getMatriculas();
            dgvDatos.Columns.Clear();
            dgvDatos.Columns.Add("alumno", "Alumno");
            dgvDatos.Columns.Add("curso", "Curso");
            dgvDatos.Columns.Add("fecha_alta", "Fecha alta");
            dgvDatos.Columns.Add("fecha_baja", "Fecha baja");
            dgvDatos.Columns.Add("aut_fotos", "Autorizacion de fotos");
            dgvDatos.Columns.Add("beca", "Beca");

            foreach (var item in matriculas)
            {
                DataGridViewRow row;
                if (item.fechBaja == null)
                {
                    row = dgvDatos.Rows[dgvDatos.Rows.Add(
                        item.alumno.nombre + " " + item.alumno.apellido1 + " " + item.alumno.apellido2,
                        item.curso.nombre,
                        item.fechAlta.ToString("dd/MM/yyyy"),
                        "",
                        item.autorizacionFotos ? "si" : "no",
                        item.beca ? "si" : "no"
                        )];
                    row.Tag = item;
                }
                row = dgvDatos.Rows[dgvDatos.Rows.Add(
                        item.alumno.nombre + " " + item.alumno.apellido1 + " " + item.alumno.apellido2,
                        item.curso.nombre,
                        item.fechAlta.ToString("dd/MM/yyyy"),
                        item.fechBaja.ToString("dd/MM/yyyy"),
                        item.autorizacionFotos ? "si" : "no",
                        item.beca ? "si" : "no"
                        )];
                row.Tag = item;                
            }
            dgvDatos.CurrentCell = null;
        }

        private async void cargaRecibos()
        {
            recibos = await ctrlRecibos.getRecibos();
            dgvDatos.Columns.Clear();
            dgvDatos.Columns.Add("fecha", "Fecha");
            dgvDatos.Columns.Add("alumno", "Alumno");
            dgvDatos.Columns.Add("curso", "Curso");
            dgvDatos.Columns.Add("importe", "Importe");
            dgvDatos.Columns.Add("pagado", "Pagado");
            foreach (var item in recibos)
            {
                DataGridViewRow row = dgvDatos.Rows[dgvDatos.Rows.Add(
                    item.fecha.ToString("dd/MM/yyyy"), 
                    item.matricula.alumno.nombre + " " + item.matricula.alumno.apellido1 + " " + item.matricula.alumno.apellido2, 
                    item.matricula.curso.nombre, 
                    item.importe, 
                    item.pagado ? "si" : "no"
                    )];
                row.Tag = item;
            }
            dgvDatos.CurrentCell = null;
        }

        private async void cargaPublicaciones()
        {
            publicaciones = await ctrlPublicaciones.getPublicaciones();
            dgvDatos.Columns.Clear();
            dgvDatos.Columns.Add("fecha", "Fecha");
            dgvDatos.Columns.Add("titulo", "Titulo");
            dgvDatos.Columns.Add("contenido", "Contenido");
            foreach (var item in publicaciones)
            {
                DataGridViewRow row = dgvDatos.Rows[dgvDatos.Rows.Add(
                    item.timeStamp.ToString("dd/MM/yyyy"), 
                    item.titulo, 
                    item.tipo
                    )];
                row.Tag = item;
            }
            dgvDatos.CurrentCell = null;
        }

        private void btnCarga_Click(object sender, EventArgs e)
        {
            
            if (cmbSelect.SelectedItem == null)
            {
                MessageBox.Show("Selecciona una opción");
                return;
            }
            dgvDatos.Visible = true;
            txtDatos.Visible = true;
            txtDatos.Clear();
            txtDatos.Text = "Seleccione un elemento para visualizar los datos";

            if (cmbSelect.SelectedItem.ToString() == "Alumnos")
            {
                cargaAlumnos();
            }
            else if (cmbSelect.SelectedItem.ToString() == "Profesores")
            {
                cargaProfesores();
            }
            else if (cmbSelect.SelectedItem.ToString() == "Solicitudes")
            {
                cargaSolicitudes();
            }
            else if (cmbSelect.SelectedItem.ToString() == "Matriculas")
            {
                cargaMatriculas();
            }
            else if (cmbSelect.SelectedItem.ToString() == "Cursos")
            {
                cargaCursos();
            }
            else if (cmbSelect.SelectedItem.ToString() == "Recibos")
            {
                cargaRecibos();
            }
            else if (cmbSelect.SelectedItem.ToString() == "Publicaciones")
            {
                cargaPublicaciones();
            }
        }

        private async void dgvDatos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
               DataGridViewRow selectedRow = dgvDatos.SelectedRows[0];

                if (selectedRow.Tag is Alumno alumno)
                {
                    txtDatos.Text = "- Nombre: " + alumno.nombre + "\t\t" + "- Apellidos: " + alumno.apellido1 + " " + alumno.apellido2 + "\n" +
                                    "- DNI: " + alumno.dni + "\t\t" + "- Fecha de nacimiento: " + alumno.fechaNac.ToString("dd/MM/yyyy") + "\n" +
                                    "- Direccion: " + alumno.direccion + "\n" + "- Localidad: " + alumno.localidad + "\n" +
                                    "- Email: " + alumno.email + "\n" + "- Telefono: " + alumno.telefono + "\n\n" +
                                    "- Proteccion de datos: " + (alumno.proteccionDatos == 1 ? "si" : "no") + "\t" +
                                    "- Grupo de Whatsapp: " + (alumno.grupoWhatsapp == 1 ? "si" : "no") + "\t\t" +
                                    "- Comunicaciones comerciales: " + (alumno.comunicacionesComerciales == 1 ? "si" : "no") + "\n\n" +
                                    "- Tutor: " + alumno.tutor.nombreCompleto + "\n" +
                                    "- DNI: " + alumno.tutor.dni + "\n" +
                                    "- Direccion: " + alumno.tutor.direccion + "\n" + "- Localidad: " + alumno.tutor.localidad + "\n" +
                                    "- Email: " + alumno.tutor.email + "\n" + "- Telefono: " + alumno.tutor.telefono;

                    ;
                }
                else if (selectedRow.Tag is Profesor profesor)
                {
                    txtDatos.Text = "- Nombre: " + profesor.nombre + "\t" + "- Apellidos: " + profesor.apellido1 + " " + profesor.apellido2 + "\n\n" +
                                    "- DNI: " + profesor.dni + "\n\n" +
                                    "- Email: " + profesor.email + "\t" + "- Telefono: " + profesor.telefono + "\n\n" +
                                    "- Direccion: " + profesor.direccion + "\n" + "- Localidad: " + profesor.localidad + "\n\n" +
                                    "- Activo: " + (profesor.activo ? "si" : "no");
                }
                else if (selectedRow.Tag is Curso curso)
                {
                    List<Profesor_Curso> profs = await ctrlProfesoresCurso.getProfesoresByCurso(curso.id);

                    Profesor pr = null;

                    foreach (var item in profs)
                    {
                        if (item.coordinador)
                        {
                            pr = item.profesor;
                            break;
                        }
                    }

                    txtDatos.Text = "- Codigo: " + curso.cod_curso + "\t\t" + "Nombre: " + curso.nombre + "\n" +
                                    "- Descripcion: " + curso.descripcion + "\n\n" +
                                    "- Horario: " + curso.horario + "\n\n" +                                   
                                    "- Tipo: " + curso.tipo.nombre + "\n\n" +
                                    "- Activo: " + (curso.activo == 1 ? "si" : "no") + "\n\n" +
                                    "- Coordinador: " + (pr != null ? pr.nombre + " " + pr.apellido1 + " " + pr.apellido2 : "") ;
                }
                else if (selectedRow.Tag is Solicitud solicitud)
                {
                    txtDatos.Text = "- Fecha: " + solicitud.fecha.ToString("dd/MM/yyyy") + "\n\n" +
                                    "- Curso: " + solicitud.curso.cod_curso + " - " + solicitud.curso.nombre + "\n\n" +
                                    "- Alumno: " + solicitud.nombre + " " + solicitud.apellido1 + " " + solicitud.apellido2 + "\n\n" +
                                    "- DNI: " + solicitud.dni + "\n\n" +
                                    "- Fecha de nacimiento: " + solicitud.fecha_nac.ToString("dd/MM/yyyy") + "\n\n" +
                                    "- Direccion: " + solicitud.direccion + "\n\n" +
                                    "- Localidad: " + solicitud.localidad + "\n\n" +
                                    "- Email: " + solicitud.email + "\t\t" + "- Telefono: " + solicitud.telefono + "\n\n" +
                                    "- Tutor: " + solicitud.tutor.nombre + " " + solicitud.tutor.apellido1 + " " + solicitud.tutor.apellido2 + "\n\n" +
                                    "- DNI: " + solicitud.tutor.dni + "\n\n" +
                                    "- Direccion: " + solicitud.tutor.direccion + "\n\n" +
                                    "- Localidad: " + solicitud.tutor.localidad + "\n\n" +
                                    "- Email: " + solicitud.tutor.email + "\t\t" + "- Telefono: " + solicitud.tutor.telefono + "\n\n" +
                                    "- Proteccion de datos: " + (solicitud.prot_datos ? "si" : "no") + "\t" +
                                    "- Autorizacion de fotos: " + (solicitud.aut_fotos ? "si" : "no") + "\t" +
                                    "- Grupo de Whatsapp: " + (solicitud.whatsapp ? "si" : "no") + "\n" +
                                    "- Comunicaciones comerciales: " + (solicitud.com_comerciales ? "si" : "no") + "\t" +
                                    "- Beca: " + (solicitud.beca ? "si" : "no") + "\n\n";
                }
                else if (selectedRow.Tag is Matricula matricula)
                {
                    txtDatos.Text = "- Alumno: " + matricula.alumno.nombre + " " + matricula.alumno.apellido1 + " " + matricula.alumno.apellido2 + "\n\n" +
                                    "- Curso: " + matricula.curso.nombre + "\n\n" +
                                    "- Fecha alta: " + matricula.fechAlta.ToString("dd/MM/yyyy") + "\n" +
                                    "- Fecha baja: " + (matricula.fechBaja != null ? matricula.fechBaja.ToString() : "") + "\n\n" +
                                    "- Autorizacion de fotos: " + (matricula.autorizacionFotos ? "si" : "no") + "\t" + "- Beca: " + (matricula.beca ? "si" : "no"); 
                }
                else if (selectedRow.Tag is Recibo recibo)
                {
                    txtDatos.Text = "Fecha: " + recibo.fecha.ToString("dd/MM/yyyy") + "\n\n" +
                                    "Alumno: " + recibo.matricula.alumno.nombre + " " + recibo.matricula.alumno.apellido1 + " " + recibo.matricula.alumno.apellido2 + "\n\n" +
                                    "Curso: " + recibo.matricula.curso.nombre + "\n\n" +
                                    "Detalle: " + recibo.detalle + "\n\n" +
                                    "Importe: " + recibo.importe + "\n\n" +
                                    "Pagado: " + (recibo.pagado ? "si" : "no");
                }
                else if (selectedRow.Tag is Publicacion publicacion)
                {
                    txtDatos.Text = "- Fecha/Hora: " + publicacion.timeStamp.ToString("dd/MM/yyyy") + "\n\n" +
                                    "Titulo: " + publicacion.titulo + "\n" +
                                    "Descripcion: " + publicacion.descripcion + "\n" +
                                    "Tipo: " + publicacion.tipo + "\n" +
                                    "Url: " + publicacion.url + "\n" +
                                    "Profesor: " + publicacion.profesor.nombre + " " + publicacion.profesor.apellido1 + " " + publicacion.profesor.apellido2;


                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(cmbSelect.SelectedItem == null)
            {
                MessageBox.Show("Selecciona una opción");
                return;
            }
            if (cmbSelect.SelectedItem.ToString() == "Alumnos")
            {
                AlumnoView formAlumno = new AlumnoView();
                formAlumno.ShowDialog();
                cargaAlumnos();
            }
            else if (cmbSelect.SelectedItem.ToString() == "Profesores")
            {
                ProfesorView formProfesor = new ProfesorView();
                formProfesor.ShowDialog();
                cargaProfesores();
            }
            else if (cmbSelect.SelectedItem.ToString() == "Solicitudes")
            {
                SolicitudView formSolicitud = new SolicitudView();
                formSolicitud.ShowDialog();
                cargaSolicitudes();
            }
            else if (cmbSelect.SelectedItem.ToString() == "Matriculas")
            {
                MatriculaView formMatricula = new MatriculaView();
                formMatricula.ShowDialog();
                cargaMatriculas();
            }
            else if (cmbSelect.SelectedItem.ToString() == "Cursos")
            {
                CursoView formCurso = new CursoView();
                formCurso.ShowDialog();
                cargaCursos();
            }
            else if (cmbSelect.SelectedItem.ToString() == "Recibos")
            {
                ReciboView formRecibo = new ReciboView();
                formRecibo.ShowDialog();
                cargaRecibos();
            }
        }

        private void btnFaltas_Click(object sender, EventArgs e)
        {
            if(dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvDatos.SelectedRows[0];
                if (selectedRow.Tag is Alumno alumno)
                {
                    FaltaAsistenciaView formFaltas = new FaltaAsistenciaView(alumno);
                    formFaltas.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Selecciona un alumno", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(cmbSelect.SelectedItem == null)
            {
                MessageBox.Show("Selecciona una opción");
                return;
            }
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvDatos.SelectedRows[0];
                if (selectedRow.Tag is Alumno alumno)
                {
                    AlumnoView formAlumno = new AlumnoView(alumno);
                    formAlumno.ShowDialog();
                    cargaAlumnos();
                }
                else if (selectedRow.Tag is Curso curso)
                {
                    CursoView formCurso = new CursoView(curso);
                    formCurso.ShowDialog();
                    cargaCursos();
                }
                else if (selectedRow.Tag is Profesor profesor)
                {
                    ProfesorView formProfesor = new ProfesorView(profesor);
                    formProfesor.ShowDialog();
                    cargaProfesores();
                }
                else if (selectedRow.Tag is Solicitud solicitud)
                {
                    SolicitudView formSolicitud = new SolicitudView(solicitud);
                    formSolicitud.ShowDialog();
                    cargaSolicitudes();
                }
                else if (selectedRow.Tag is Matricula matricula)
                {
                    MatriculaView formMatricula = new MatriculaView(matricula);
                    formMatricula.ShowDialog();
                    cargaMatriculas();
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AcademyGestor.ApiService;
using AcademyGestor.Modelos;
using AcademyGestor.Vistas;
using Newtonsoft.Json;

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
        private CtrlEmpresa ctrlEmpresa;

        private List<Alumno> alumnos;
        private List<Curso> cursos;
        private List<Solicitud> solicitudes;
        private List<Matricula> matriculas;
        private List<Profesor> profesores;
        private List<Recibo> recibos;
        private List<Publicacion> publicaciones;
        private List<Profesor_Curso> profesoresCurso;
        private Empresa empresa;




        public Main()
        {
            InitializeComponent();

            txtBuscar.TextChanged += txtBuscar_TextChanged;

            ctrlAlumnos = new CtrlAlumnos();
            ctrlCursos = new CtrlCursos();
            ctrlSolicitudes = new CtrlSolicitudes();
            ctrlMatriculas = new CtrlMatriculas();
            ctrlProfesores = new CtrlProfesores();
            ctrlRecibos = new CtrlRecibos();
            ctrlPublicaciones = new CtrlPublicaciones();
            ctrlProfesoresCurso = new CtrlProfesoresCurso();
            ctrlEmpresa = new CtrlEmpresa();

            empresa = new Empresa();
            alumnos = new List<Alumno>();
            cursos = new List<Curso>();
            solicitudes = new List<Solicitud>();
            matriculas = new List<Matricula>();
            profesores = new List<Profesor>();
            recibos = new List<Recibo>();
            publicaciones = new List<Publicacion>();
            profesoresCurso = new List<Profesor_Curso>();

            cargaEmpresa();
        }

        private async void cargaEmpresa()
        {
            empresa = await ctrlEmpresa.getEmpresa();
        }

        private async void cargaAlumnos()
        {
            alumnos = await ctrlAlumnos.getAlumnos();

            dgvDatos.Columns.Clear();

            dgvDatos.Columns.Add("nombre", "Nombre");
            dgvDatos.Columns.Add("apellidos", "Apellidos");
            dgvDatos.Columns.Add("email", "Email");
            dgvDatos.Columns.Add("telefono", "Telefono");
            dgvDatos.Columns.Add("tutor", "Tutor");


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
                    item.tutor.nombre + " " + item.tutor.apellido1 + " " + item.tutor.apellido2
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
                    item.activo == 1 ? "si" : "no"
                )];
                row.Tag = item;
            }
            dgvDatos.CurrentCell = null;
        }

        protected async void cargaCursos()
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

            foreach (var item in solicitudes)
            {
                DataGridViewRow row = dgvDatos.Rows[dgvDatos.Rows.Add(
                    item.fecha.ToString("dd/MM/yyyy"),
                    item.curso.cod_curso + " " + item.curso.nombre,
                    item.nombre + " " + item.apellido1 + " " + item.apellido2
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

            foreach (Matricula item in matriculas)
            {
                DataGridViewRow row;
                if (item.fechBaja == null)
                {
                    row = dgvDatos.Rows[dgvDatos.Rows.Add(
                        item.alumno.nombre + " " + item.alumno.apellido1 + " " + item.alumno.apellido2,
                        item.curso.nombre,
                        item.fechAlta.Value.ToString("dd/MM/yyyy"),
                        "",
                        item.autorizacionFotos == 1 ? "si" : "no",
                        item.beca == 1 ? "si" : "no"
                        )];
                    row.Tag = item;
                }
                else
                {
                    row = dgvDatos.Rows[dgvDatos.Rows.Add(
                        item.alumno.nombre + " " + item.alumno.apellido1 + " " + item.alumno.apellido2,
                        item.curso.nombre,
                        item.fechAlta.Value.ToString("dd/MM/yyyy"),
                        item.fechBaja.HasValue ? item.fechBaja.Value.ToString("dd/MM/yyyy") : "",
                        item.autorizacionFotos == 1 ? "si" : "no",
                        item.beca == 1 ? "si" : "no"
                        )];
                    row.Tag = item;
                }

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
                    item.pagado == 1 ? "si" : "no"
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

            cmbSelect.Visible = true;
            btnRefr.Enabled = true;
            btnRefr.Visible = true;
            dgvDatos.Visible = true;
            txtDatos.Visible = true;
            pnlMain.Visible = false;
            btnAdd.Visible = true;
            btnEdit.Visible = true;
            txtBuscar.Visible = true;
            lblBuscar.Visible = true;
            txtDatos.Clear();
            txtDatos.Text = "Seleccione un elemento para visualizar los datos";

            if (cmbSelect.SelectedItem.ToString() == "Alumnos")
            {
                cargaAlumnos();
                btnMulti2.Visible = true;
                btnMulti2.Enabled = true;
                btnMulti2.Text = "Administrar tutores";
                btnEdit.Enabled = false;
                btnAdd.Enabled = false;
                btnMulti.Text = "Faltas de asistencia";
                btnMulti.Visible = true;
            }
            else if (cmbSelect.SelectedItem.ToString() == "Profesores")
            {
                cargaProfesores();
                btnEdit.Enabled = false;
                btnMulti2.Visible = false;
                btnAdd.Enabled = true;
                btnMulti.Visible = false;
            }
            else if (cmbSelect.SelectedItem.ToString() == "Solicitudes")
            {
                cargaSolicitudes();
                btnAdd.Enabled = false;
                btnMulti2.Visible = false;
                btnEdit.Enabled = false;
                btnMulti.Text = "Ver solicitud";
                btnMulti.Visible = true;
            }
            else if (cmbSelect.SelectedItem.ToString() == "Matriculas")
            {
                cargaMatriculas();
                btnMulti.Text = "Dar de baja";
                btnMulti2.Text = "Ver recibos";
                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                btnMulti2.Visible = true;
                btnMulti.Visible = true;
            }
            else if (cmbSelect.SelectedItem.ToString() == "Cursos")
            {
                cargaCursos();
                btnEdit.Enabled = false;
                btnAdd.Enabled = true;
                btnMulti2.Visible = false;
                btnMulti.Text = "Administrar profesores";
                btnMulti.Visible = true;
            }
            else if (cmbSelect.SelectedItem.ToString() == "Recibos")
            {
                cargaRecibos();
                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                btnMulti2.Visible = false;
                btnMulti.Text = "Ver recibo";
                btnMulti.Visible = true;
            }
            else if (cmbSelect.SelectedItem.ToString() == "Publicaciones")
            {
                cargaPublicaciones();
                btnAdd.Enabled = false;
                btnMulti2.Visible = false;
                btnEdit.Enabled = false;
                btnMulti.Visible = false;
            }
        }

        private async void dgvDatos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvDatos.SelectedRows[0];

                if (selectedRow.Tag is Alumno alumno)
                {
                    btnEdit.Enabled = true;
                    if (alumno.tutor.nombre == "Sin tutor")
                    {
                        txtDatos.Text = "- Nombre: " + alumno.nombre + "\t\t" + "- Apellidos: " + alumno.apellido1 + " " + alumno.apellido2 + "\n" +
                           "- DNI: " + alumno.dni + "\t\t" + "- Fecha de nacimiento: " + alumno.fechaNac.ToString("dd/MM/yyyy") + "\n" +
                           "- Direccion: " + alumno.direccion + "\n" + "- Localidad: " + alumno.localidad + "\n" +
                           "- Email: " + alumno.email + "\n" + "- Telefono: " + alumno.telefono + "\n\n" +
                           "- Proteccion de datos: " + (alumno.proteccionDatos == 1 ? "si" : "no") + "\t" +
                           "- Grupo de Whatsapp: " + (alumno.grupoWhatsapp == 1 ? "si" : "no") + "\t\t" +
                           "- Comunicaciones comerciales: " + (alumno.comunicacionesComerciales == 1 ? "si" : "no") + "\n\n" +
                            "- Tutor: " + alumno.tutor.nombre;
                    }
                    else
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
                    }
                }
                else if (selectedRow.Tag is Profesor profesor)
                {
                    btnEdit.Enabled = true;
                    txtDatos.Text = "- Nombre: " + profesor.nombre + "\t" + "- Apellidos: " + profesor.apellido1 + " " + profesor.apellido2 + "\n\n" +
                                    "- DNI: " + profesor.dni + "\n\n" +
                                    "- Email: " + profesor.email + "\t" + "- Telefono: " + profesor.telefono + "\n\n" +
                                    "- Direccion: " + profesor.direccion + "\n" + "- Localidad: " + profesor.localidad + "\n\n" +
                                    "- Activo: " + (profesor.activo == 1 ? "si" : "no");
                }
                else if (selectedRow.Tag is Curso curso)
                {
                    btnEdit.Enabled = true;
                    int id = (int)curso.id;
                    List<Profesor_Curso> profs = await ctrlProfesoresCurso.getProfesoresByCurso(id);

                    Profesor pr = null;

                    foreach (var item in profs)
                    {
                        if (item.coordinador == 1)
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
                                    "- Coordinador: " + (pr != null ? pr.nombre + " " + pr.apellido1 + " " + pr.apellido2 : "");
                }
                else if (selectedRow.Tag is Solicitud solicitud)
                {
                    btnMulti.Enabled = true;
                    if (solicitud.tutor == null)
                    {
                        txtDatos.Text = "- Fecha: " + solicitud.fecha.ToString("dd/MM/yyyy") + "\n\n" +
                                    "- Curso: " + solicitud.curso.cod_curso + " - " + solicitud.curso.nombre + "\n\n" +
                                    "- Alumno: " + solicitud.nombre + " " + solicitud.apellido1 + " " + solicitud.apellido2 + "\n\n" +
                                    "- DNI: " + solicitud.dni + "\n\n" +
                                    "- Fecha de nacimiento: " + solicitud.fechaNac.ToString("dd/MM/yyyy") + "\n\n" +
                                    "- Direccion: " + solicitud.direccion + "\n\n" +
                                    "- Localidad: " + solicitud.localidad + "\n\n" +
                                    "- Email: " + solicitud.email + "\t\t" + "- Telefono: " + solicitud.telefono + "\n\n" +
                                    "- Proteccion de datos: " + (solicitud.proteccionDatos == 1 ? "si" : "no") + "\t" +
                                    "- Autorizacion de fotos: " + (solicitud.autorizacionFotos == 1 ? "si" : "no") + "\t" +
                                    "- Grupo de Whatsapp: " + (solicitud.grupoWhatsapp == 1 ? "si" : "no") + "\n" +
                                    "- Comunicaciones comerciales: " + (solicitud.comunicacionesComerciales == 1 ? "si" : "no") + "\t" +
                                    "- Beca: " + (solicitud.beca == 1 ? "si" : "no") + "\n\n";
                    }
                    else
                    {
                        txtDatos.Text = "- Fecha: " + solicitud.fecha.ToString("dd/MM/yyyy") + "\n\n" +
                                        "- Curso: " + solicitud.curso.cod_curso + " - " + solicitud.curso.nombre + "\n\n" +
                                        "- Alumno: " + solicitud.nombre + " " + solicitud.apellido1 + " " + solicitud.apellido2 + "\n\n" +
                                        "- DNI: " + solicitud.dni + "\n\n" +
                                        "- Fecha de nacimiento: " + solicitud.fechaNac.ToString("dd/MM/yyyy") + "\n\n" +
                                        "- Direccion: " + solicitud.direccion + "\n\n" +
                                        "- Localidad: " + solicitud.localidad + "\n\n" +
                                        "- Email: " + solicitud.email + "\t\t" + "- Telefono: " + solicitud.telefono + "\n\n" +
                                        "- Tutor: " + solicitud.tutor.nombre + " " + solicitud.tutor.apellido1 + " " + solicitud.tutor.apellido2 + "\n\n" +
                                        "- DNI: " + solicitud.tutor.dni + "\n\n" +
                                        "- Direccion: " + solicitud.tutor.direccion + "\n\n" +
                                        "- Localidad: " + solicitud.tutor.localidad + "\n\n" +
                                        "- Email: " + solicitud.tutor.email + "\t\t" + "- Telefono: " + solicitud.tutor.telefono + "\n\n" +
                                        "- Proteccion de datos: " + (solicitud.proteccionDatos == 1 ? "si" : "no") + "\t" +
                                        "- Autorizacion de fotos: " + (solicitud.autorizacionFotos == 1 ? "si" : "no") + "\t" +
                                        "- Grupo de Whatsapp: " + (solicitud.grupoWhatsapp == 1 ? "si" : "no") + "\n" +
                                        "- Comunicaciones comerciales: " + (solicitud.comunicacionesComerciales == 1 ? "si" : "no") + "\t" +
                                        "- Beca: " + (solicitud.beca == 1 ? "si" : "no") + "\n\n";
                    }
                }
                else if (selectedRow.Tag is Matricula matricula)
                {
                    if(matricula.fechBaja == null)
                    {
                        btnMulti.Enabled = true;
                    }
                    else
                    {
                        btnMulti.Enabled = false;
                    }
                    txtDatos.Text = "- Alumno: " + matricula.alumno.nombre + " " + matricula.alumno.apellido1 + " " + matricula.alumno.apellido2 + "\n\n" +
                                    "- Curso: " + matricula.curso.nombre + "\n\n" +
                                    "- Fecha alta: " + matricula.fechAlta.Value.ToString("dd/MM/yyyy") + "\n" +
                                    "- Fecha baja: " + (matricula.fechBaja != null ? matricula.fechBaja.Value.ToString("dd/MM/yyyy") : "") + "\n\n" +
                                    "- Autorizacion de fotos: " + (matricula.autorizacionFotos == 1 ? "si" : "no") + "\t" + "- Beca: " + (matricula.beca == 1 ? "si" : "no");
                }
                
                else if (selectedRow.Tag is Publicacion publicacion)
                {
                    btnEdit.Enabled = true;
                    txtDatos.Text = "- Fecha/Hora: " + publicacion.timeStamp.ToString("dd/MM/yyyy") + "\n\n" +
                                    "- Titulo: " + publicacion.titulo + "\n" +
                                    "- Descripcion: \n" + publicacion.descripcion + "\n\n" +
                                    "- Tipo: " + publicacion.tipo + "\n\n" +
                                    "- Url: " + publicacion.url + "\n\n" +
                                    "- Profesor: " + publicacion.profesor.nombre + " " + publicacion.profesor.apellido1 + " " + publicacion.profesor.apellido2;


                }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            switch(cmbSelect.SelectedItem.ToString())
            {
                case "Profesores":
                    ProfesorView formProfesor = new ProfesorView();
                    formProfesor.ShowDialog();
                    cargaProfesores();
                    break;
                case "Cursos":                    
                    CursoView formCurso = new CursoView();
                    formCurso.ShowDialog();
                    cargaCursos();
                    break;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {           
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvDatos.SelectedRows[0];
                switch(cmbSelect.SelectedItem.ToString())
                {
                    case "Alumnos":
                        if (selectedRow.Tag is Alumno alumno)
                        {
                            AlumnoView formAlumno = new AlumnoView(alumno);
                            formAlumno.ShowDialog();
                            cargaAlumnos();
                        }
                        break;
                    case "Profesores":
                        if (selectedRow.Tag is Profesor profesor)
                        {
                            ProfesorView formProfesor = new ProfesorView(profesor);
                            DialogResult result = formProfesor.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                cargaProfesores();
                            }
                        }
                        break;
                    case "Cursos":
                        if (selectedRow.Tag is Curso curso)
                        {
                            CursoView formCurso = new CursoView(curso);
                            formCurso.ShowDialog();
                            cargaCursos();
                        }
                        break;
                    case "Solicitudes":
                        if (selectedRow.Tag is Solicitud solicitud)
                        {
                            SolicitudView formSolicitud = new SolicitudView(solicitud);
                            formSolicitud.ShowDialog();
                            cargaSolicitudes();
                        }
                        break;
                    case "Publicaciones":
                        if (selectedRow.Tag is Publicacion publicacion)
                        {
                            PublicacionView formPublicacion = new PublicacionView(publicacion);
                            formPublicacion.ShowDialog();
                            cargaPublicaciones();
                        }
                        break;
                }
            }
        }

        private async void btnMulti_Click(object sender, EventArgs e)
        {
            if (cmbSelect.SelectedItem.ToString() == "Alumnos")
            {
                if (dgvDatos.SelectedRows.Count > 0)
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
            else if (cmbSelect.SelectedItem.ToString() == "Cursos")
            {
                if (dgvDatos.SelectedRows.Count > 0)
                {
                    ProfesoresCursoView pcView = new ProfesoresCursoView((Curso)dgvDatos.SelectedRows[0].Tag);
                    pcView.Show();
                    this.Enabled = false;
                    pcView.FormClosed += (s, args) => this.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Selecciona un curso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (cmbSelect.SelectedItem.ToString() == "Solicitudes")
            {
                if (dgvDatos.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgvDatos.SelectedRows[0];
                    if (selectedRow.Tag is Solicitud solicitud)
                    {
                        SolicitudView solicitudView = new SolicitudView(solicitud);
                        solicitudView.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Selecciona una solicitud", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (cmbSelect.SelectedItem.ToString() == "Matriculas")
            {
                if (dgvDatos.SelectedRows.Count > 0)
                {
                    DialogResult result = MessageBox.Show("¿Esta seguro que quiere dar de baja esta matricula?", "Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        DataGridViewRow selectedRow = dgvDatos.SelectedRows[0];
                        if (selectedRow.Tag is Matricula matricula)
                        {
                            bool exito = await ctrlMatriculas.bajaMatricula(matricula);
                            if (exito)
                            {
                                MessageBox.Show("Matricula dada de baja correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cargaMatriculas();
                            }
                            else
                            {
                                MessageBox.Show("Error al dar de baja la matricula", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Selecciona una matricula", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnAlumnos_Click(object sender, EventArgs e)
        {
            cmbSelect.SelectedItem = "Alumnos";
            btnCarga_Click(sender, e);
        }

        private void btnCursos_Click(object sender, EventArgs e)
        {
            cmbSelect.SelectedItem = "Cursos";
            btnCarga_Click(sender, e);
        }

        private void btnMatriculas_Click(object sender, EventArgs e)
        {
            cmbSelect.SelectedItem = "Matriculas";
            btnCarga_Click(sender, e);
        }

        private void btnProfesores_Click(object sender, EventArgs e)
        {
            cmbSelect.SelectedItem = "Profesores";
            btnCarga_Click(sender, e);
        }

        private void btnPublicaciones_Click(object sender, EventArgs e)
        {
            cmbSelect.SelectedItem = "Publicaciones";
            btnCarga_Click(sender, e);
        }

        private void btnRecibos_Click(object sender, EventArgs e)
        {
            cmbSelect.SelectedItem = "Recibos";
            btnCarga_Click(sender, e);
        }

        private void btnSolicitudes_Click(object sender, EventArgs e)
        {
            cmbSelect.SelectedItem = "Solicitudes";
            btnCarga_Click(sender, e);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.ToLower();

            if (string.IsNullOrWhiteSpace(filtro)) // Si el filtro está vacío
            {
                // Cargar todos los datos originales según la selección actual
                if (cmbSelect.SelectedItem.ToString() == "Alumnos")
                {
                    cargaAlumnos(); // Cargar todos los alumnos
                }
                else if (cmbSelect.SelectedItem.ToString() == "Profesores")
                {
                    cargaProfesores(); // Cargar todos los profesores
                }
                else if (cmbSelect.SelectedItem.ToString() == "Cursos")
                {
                    cargaCursos(); // Cargar todos los cursos
                }
                else if (cmbSelect.SelectedItem.ToString() == "Solicitudes")
                {
                    cargaSolicitudes(); // Cargar todas las solicitudes
                }
                else if (cmbSelect.SelectedItem.ToString() == "Matriculas")
                {
                    cargaMatriculas(); // Cargar todas las matrículas
                }
                else if (cmbSelect.SelectedItem.ToString() == "Recibos")
                {
                    cargaRecibos(); // Cargar todos los recibos
                }
                else if (cmbSelect.SelectedItem.ToString() == "Publicaciones")
                {
                    cargaPublicaciones(); // Cargar todas las publicaciones
                }
                return; // Salir del método para evitar aplicar filtros
            }

            // Aplicar filtro si el texto no está vacío
            if (cmbSelect.SelectedItem.ToString() == "Alumnos")
            {
                var alumnosFiltrados = alumnos.Where(a =>
                    a.nombre.ToLower().Contains(filtro) ||
                    a.apellido1.ToLower().Contains(filtro) ||
                    a.apellido2.ToLower().Contains(filtro) ||
                    a.email.ToLower().Contains(filtro) ||
                    a.telefono.ToLower().Contains(filtro)).ToList();

                ActualizarDgv(alumnosFiltrados); // Llamar al método con la lista filtrada
            }
            else if (cmbSelect.SelectedItem.ToString() == "Profesores")
            {
                var profesoresFiltrados = profesores.Where(p =>
                    p.nombre.ToLower().Contains(filtro) ||
                    p.apellido1.ToLower().Contains(filtro) ||
                    p.apellido2.ToLower().Contains(filtro) ||
                    p.email.ToLower().Contains(filtro) ||
                    p.telefono.ToLower().Contains(filtro)).ToList();

                ActualizarDgv(profesoresFiltrados); // Llamar al método con la lista filtrada
            }
            else if (cmbSelect.SelectedItem.ToString() == "Cursos")
            {
                var cursosFiltrados = cursos.Where(c =>
                    c.cod_curso.ToLower().Contains(filtro) ||
                    c.nombre.ToLower().Contains(filtro) ||
                    c.tipo.nombre.ToLower().Contains(filtro)).ToList();

                ActualizarDgv(cursosFiltrados); // Llamar al método con la lista filtrada
            }
            else if (cmbSelect.SelectedItem.ToString() == "Solicitudes")
            {
                var solicitudesFiltradas = solicitudes.Where(s =>
                    s.nombre.ToLower().Contains(filtro) ||
                    s.apellido1.ToLower().Contains(filtro) ||
                    s.apellido2.ToLower().Contains(filtro)).ToList();

                ActualizarDgv(solicitudesFiltradas); // Llamar al método con la lista filtrada
            }
            else if (cmbSelect.SelectedItem.ToString() == "Matriculas")
            {
                var matriculasFiltradas = matriculas.Where(m =>
                    m.alumno.nombre.ToLower().Contains(filtro) ||
                    m.alumno.apellido1.ToLower().Contains(filtro) ||
                    m.alumno.apellido2.ToLower().Contains(filtro) ||
                    m.curso.nombre.ToLower().Contains(filtro)).ToList();

                ActualizarDgv(matriculasFiltradas); // Llamar al método con la lista filtrada
            }
            else if (cmbSelect.SelectedItem.ToString() == "Recibos")
            {
                var recibosFiltrados = recibos.Where(r =>
                    r.matricula.alumno.nombre.ToLower().Contains(filtro) ||
                    r.matricula.alumno.apellido1.ToLower().Contains(filtro) ||
                    r.matricula.alumno.apellido2.ToLower().Contains(filtro)).ToList();

                ActualizarDgv(recibosFiltrados); // Llamar al método con la lista filtrada
            }
            else if (cmbSelect.SelectedItem.ToString() == "Publicaciones")
            {
                var publicacionesFiltradas = publicaciones.Where(p =>
                    p.titulo.ToLower().Contains(filtro) ||
                    p.descripcion.ToLower().Contains(filtro)).ToList();

                ActualizarDgv(publicacionesFiltradas); // Llamar al método con la lista filtrada
            }
        }

        private void ActualizarDgv<T>(List<T> datos)
        {
            dgvDatos.Columns.Clear(); // Limpiar columnas existentes

            if (cmbSelect.SelectedItem.ToString() == "Alumnos")
            {
                dgvDatos.Columns.Add("nombre", "Nombre");
                dgvDatos.Columns.Add("apellidos", "Apellidos");
                dgvDatos.Columns.Add("email", "Email");
                dgvDatos.Columns.Add("telefono", "Telefono");
                dgvDatos.Columns.Add("tutor", "Tutor");
            }
            else if (cmbSelect.SelectedItem.ToString() == "Profesores")
            {
                dgvDatos.Columns.Add("nombre", "Nombre");
                dgvDatos.Columns.Add("apellidos", "Apellidos");
                dgvDatos.Columns.Add("email", "Email");
                dgvDatos.Columns.Add("telefono", "Telefono");
                dgvDatos.Columns.Add("activo", "Activo");
            }
            else if (cmbSelect.SelectedItem.ToString() == "Cursos")
            {
                dgvDatos.Columns.Add("codigo", "Codigo");
                dgvDatos.Columns.Add("nombre", "Nombre");
                dgvDatos.Columns.Add("tipo", "Tipo");
                dgvDatos.Columns.Add("activo", "Activo");
            }
            else if (cmbSelect.SelectedItem.ToString() == "Solicitudes")
            {
                dgvDatos.Columns.Add("fecha", "Fecha");
                dgvDatos.Columns.Add("curso", "Curso");
                dgvDatos.Columns.Add("alumno", "Alumno");
            }
            else if (cmbSelect.SelectedItem.ToString() == "Matriculas")
            {
                dgvDatos.Columns.Add("alumno", "Alumno");
                dgvDatos.Columns.Add("curso", "Curso");
                dgvDatos.Columns.Add("fecha_alta", "Fecha alta");
                dgvDatos.Columns.Add("fecha_baja", "Fecha baja");
                dgvDatos.Columns.Add("aut_fotos", "Autorizacion de fotos");
                dgvDatos.Columns.Add("beca", "Beca");
            }
            else if (cmbSelect.SelectedItem.ToString() == "Recibos")
            {
                dgvDatos.Columns.Add("fecha", "Fecha");
                dgvDatos.Columns.Add("alumno", "Alumno");
                dgvDatos.Columns.Add("curso", "Curso");
                dgvDatos.Columns.Add("importe", "Importe");
                dgvDatos.Columns.Add("pagado", "Pagado");
            }
            else if (cmbSelect.SelectedItem.ToString() == "Publicaciones")
            {
                dgvDatos.Columns.Add("fecha", "Fecha");
                dgvDatos.Columns.Add("titulo", "Titulo");
                dgvDatos.Columns.Add("contenido", "Contenido");
            }

            dgvDatos.Rows.Clear(); // Limpiar filas existentes

            // Agregar filas dinámicamente según los datos
            foreach (var item in datos)
            {
                if (cmbSelect.SelectedItem.ToString() == "Alumnos")
                {
                    Alumno a = item as Alumno;
                    if (a.tutor == null)
                    {
                        a.tutor = new Tutor();
                        a.tutor.nombre = "Sin tutor";
                        a.tutor.apellido1 = "";
                        a.tutor.apellido2 = "";
                    }

                    DataGridViewRow row = dgvDatos.Rows[dgvDatos.Rows.Add(
                        a.nombre,
                        a.apellido1 + " " + a.apellido2,
                        a.email,
                        a.telefono,
                        a.tutor.nombre + " " + a.tutor.apellido1 + " " + a.tutor.apellido2
                        )];
                    row.Tag = a;
                }
                else if (cmbSelect.SelectedItem.ToString() == "Profesores")
                {
                    Profesor p = item as Profesor;
                    DataGridViewRow row = dgvDatos.Rows[dgvDatos.Rows.Add(
                    p.nombre,
                    p.apellido1 + " " + p.apellido2,
                    p.email, p.telefono,
                    p.activo == 1 ? "si" : "no"
                    )];
                    row.Tag = p;
                }
                else if (cmbSelect.SelectedItem.ToString() == "Cursos")
                {
                    Curso c = item as Curso;
                    DataGridViewRow row = dgvDatos.Rows[dgvDatos.Rows.Add(
                   c.cod_curso,
                   c.nombre,
                   c.tipo.nombre,
                   c.activo == 1 ? "si" : "no"
                   )];
                    row.Tag = c;

                }
                else if (cmbSelect.SelectedItem.ToString() == "Solicitudes")
                {
                    Solicitud s = item as Solicitud;
                    DataGridViewRow row = dgvDatos.Rows[dgvDatos.Rows.Add(
                    s.fecha.ToString("dd/MM/yyyy"),
                    s.curso.cod_curso + " " + s.curso.nombre,
                    s.nombre + " " + s.apellido1 + " " + s.apellido2
                    )];
                    row.Tag = s;
                }
                else if (cmbSelect.SelectedItem.ToString() == "Matriculas")
                {
                    Matricula m = item as Matricula;
                    DataGridViewRow row;
                    if (m.fechBaja == null)
                    {
                        row = dgvDatos.Rows[dgvDatos.Rows.Add(
                            m.alumno.nombre + " " + m.alumno.apellido1 + " " + m.alumno.apellido2,
                            m.curso.nombre,
                            m.fechAlta.Value.ToString("dd/MM/yyyy"),
                            "",
                            m.autorizacionFotos == 1 ? "si" : "no",
                            m.beca == 1 ? "si" : "no"
                            )];
                        row.Tag = m;
                    }
                    else
                    {

                        row = dgvDatos.Rows[dgvDatos.Rows.Add(
                                                   m.alumno.nombre + " " + m.alumno.apellido1 + " " + m.alumno.apellido2,
                                                   m.curso.nombre,
                                                   m.fechAlta.Value.ToString("dd/MM/yyyy"),
                                                   m.fechBaja.Value.ToString("dd/MM/yyyy"),
                                                   m.autorizacionFotos == 1 ? "si" : "no",
                                                   m.beca == 1 ? "si" : "no"
                                                   )];
                        row.Tag = m;
                    }


                }
                else if (cmbSelect.SelectedItem.ToString() == "Recibos")
                {
                    Recibo r = item as Recibo;
                    DataGridViewRow row = dgvDatos.Rows[dgvDatos.Rows.Add(
                        r.fecha.ToString("dd/MM/yyyy"),
                        r.matricula.alumno.nombre + " " + r.matricula.alumno.apellido1 + " " + r.matricula.alumno.apellido2,
                        r.matricula.curso.nombre,
                        r.importe,
                        r.pagado == 1 ? "si" : "no"
                        )];
                    row.Tag = r;
                }
                else if (cmbSelect.SelectedItem.ToString() == "Publicaciones")
                {
                    Publicacion p = item as Publicacion;
                    DataGridViewRow row = dgvDatos.Rows[dgvDatos.Rows.Add(
                        p.timeStamp.ToString("dd/MM/yyyy"),
                        p.titulo,
                        p.tipo
                        )];
                    row.Tag = p;
                }
            }

            dgvDatos.CurrentCell = null; // Deseleccionar la celda actual
        }

        private void btnMulti2_Click(object sender, EventArgs e)
        {
            if (cmbSelect.SelectedItem.ToString() == "Alumnos")
            {
                TutorView tutorView = new TutorView();
                tutorView.ShowDialog();
            }
            else if (cmbSelect.SelectedItem.ToString() == "Matriculas")
            {
                if (dgvDatos.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgvDatos.SelectedRows[0];
                    if (selectedRow.Tag is Matricula matricula)
                    {
                        ReciboView reciboView = new ReciboView(matricula, empresa);
                        reciboView.ShowDialog();
                    }
                }
                else
                {
                    ReciboView reciboView = new ReciboView();
                    reciboView.ShowDialog();
                }
            }
        }

        private void tsmiLogout_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Esta seguro que quiere cerrar sesion?", "Cerrar sesion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (res == DialogResult.Yes)
            {
                Thread loggin = new Thread(() =>
            {
                Application.Run(new Loggin());
            });

                loggin.SetApartmentState(ApartmentState.STA);
                loggin.Start();
                this.Close();
            }

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Seleccionar imagen";
            openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string rutaImagen = openFileDialog.FileName;

                Publicacion publicacion = new Publicacion();
                publicacion.titulo = "Imagen subida por el administrador";
                publicacion.descripcion = "Imagen subida por el administrador";
                publicacion.url = rutaImagen;
                publicacion.tipo = TipoPublicacion.Foto;
                publicacion.profesor = await ctrlProfesores.getProfesor(1);

                CtrlPublicaciones ctrlPublicaciones = new CtrlPublicaciones();
                bool exito = await ctrlPublicaciones.AddPublicacionAsync(publicacion, rutaImagen);
                if (exito)
                {
                    MessageBox.Show("Imagen subida correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargaPublicaciones();
                }
                else
                {
                    MessageBox.Show("Error al subir la imagen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }


        }



        private void btnRefr_Click(object sender, EventArgs e)
        {
            btnCarga_Click(sender, e);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnAlumnos.Visible = true;
            btnCursos.Visible = true;
            btnMatriculas.Visible = true;
            btnProfesores.Visible = true;
            btnPublicaciones.Visible = true;
            btnSolicitudes.Visible = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.tsmiLogout_Click(sender, e);
        }
    }
}

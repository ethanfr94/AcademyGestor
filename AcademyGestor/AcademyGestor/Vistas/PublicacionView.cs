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
    public partial class PublicacionView : Form
    {
        private CtrlPublicaciones ctrlPublicaciones;
        private CtrlProfesores ctrlProfesores;
        private Publicacion publicacion;
        private List<Profesor> profesores;
        private Profesor profesor;

        public PublicacionView(Publicacion publicacion)
        {
            InitializeComponent();
            ctrlPublicaciones = new CtrlPublicaciones();
            ctrlProfesores = new CtrlProfesores();
            this.publicacion = publicacion;

            cargaDatos();
        }

        private void cargaDatos()
        {
            if (publicacion != null)
            {
                txtTimeStamp.Text = publicacion.timeStamp.ToString();
                txtTitulo.Text = publicacion.titulo;
                txtDescripcion.Text = publicacion.descripcion;
                cargaProfesores();

            }
        }

        

        private async void cargaProfesores()
        {
            profesores = await ctrlProfesores.getProfesores();
            if (profesores != null)
            {
                foreach (Profesor profesor in profesores)
                {
                    cmbProfesor.Items.Add(profesor.nombre_completo);
                }
                if (publicacion != null)
                {
                    foreach (Profesor profesor in profesores)
                    {
                        if (profesor.id == publicacion.profesor.id)
                        {
                            cmbProfesor.SelectedItem = profesor.nombre_completo;
                            this.profesor = profesor;
                            break;
                        }
                    }
                }
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de que desea guardar los cambios?", "Confirmar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.publicacion.timeStamp = this.publicacion.timeStamp;
                this.publicacion.titulo = txtTitulo.Text;
                this.publicacion.descripcion = txtDescripcion.Text;

                Profesor profesor = await ctrlProfesores.getProfesor((int)this.profesor.id);
                if (profesor != null)
                {
                    this.publicacion.profesor = profesor;
                }

                bool res = await ctrlPublicaciones.updatePublicacion(publicacion);

                if (res)
                {
                    MessageBox.Show("Publicación actualizada correctamente");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al actualizar la publicación");
                }
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar la publicación?", "Confirmar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                bool res = await ctrlPublicaciones.deletePublicacion(publicacion.id);
                if (res)
                {
                    MessageBox.Show("Publicación eliminada correctamente");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al eliminar la publicación");
                }
            }
        }

    }
}

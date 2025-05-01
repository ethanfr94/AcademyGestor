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
        private Publicacion publicacion;
        public PublicacionView()
        {
            InitializeComponent();
        }

        public PublicacionView(Publicacion publicacion)
        {
            InitializeComponent();
            this.publicacion = publicacion;
        }


    }
}

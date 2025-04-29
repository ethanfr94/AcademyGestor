using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AcademyGestor.Modelos;

namespace AcademyGestor.Vistas
{
    public partial class SolicitudView : Form
    {
        private Solicitud solicitud;
        public SolicitudView()
        {
            InitializeComponent();
        }

        public SolicitudView(Solicitud solicitud)
        {
            InitializeComponent();
            this.solicitud = solicitud;
        }


    }
}

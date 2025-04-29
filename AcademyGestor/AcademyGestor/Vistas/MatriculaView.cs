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
    public partial class MatriculaView : Form
    {
        private Matricula matricula;
        public MatriculaView()
        {
            InitializeComponent();
        }

        public MatriculaView(Matricula matricula)
        {
            InitializeComponent();
            this.matricula = matricula;
        }
    }
}

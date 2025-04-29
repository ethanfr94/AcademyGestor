using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcademyGestor
{
    public partial class Loggin : Form
    {
        public Loggin()
        {
            InitializeComponent();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            Thread mainThread = new Thread(() =>
            {
                Application.Run(new Main()); 
            });

            mainThread.SetApartmentState(ApartmentState.STA); 
            mainThread.Start(); 

            this.Close();
        }
    }
}

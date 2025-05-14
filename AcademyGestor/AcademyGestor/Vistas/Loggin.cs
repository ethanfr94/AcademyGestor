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
using AcademyGestor.ApiService;
using AcademyGestor.Modelos;
using System.Security.Cryptography;
using System.IO;

namespace AcademyGestor
{
    public partial class Loggin : Form
    {
        private const string EncryptionKey = "ProyectoFinalDAM";

        CtrlUsuarios ctrlUsuarios;
        private Usuario usuario;
        private string user;
        private string pass;
        public Loggin()
        {
            InitializeComponent();
            ctrlUsuarios = new CtrlUsuarios();

            if (Properties.Settings.Default.Username != string.Empty && Properties.Settings.Default.Password != string.Empty && Properties.Settings.Default.Remember)
            {
                chkRecordar.Checked = true;  
                txtUser.Text = Properties.Settings.Default.Username;
                txtPass.Text = Decrypt(Properties.Settings.Default.Password, EncryptionKey);
            }
            this.ActiveControl = btnLog;
        }

        private async void btnLog_Click(object sender, EventArgs e)
        {
            user = txtUser.Text;
            pass = txtPass.Text;

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Por favor, introduce un nombre de usuario y una contraseña.");
                return;
            }

            usuario = await ctrlUsuarios.login(user, pass);

            if (usuario == null)
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
                return;
            }
            if (chkRecordar.Checked)
            {
                Properties.Settings.Default.Username = user;
                Properties.Settings.Default.Password = Encrypt(pass, EncryptionKey);
                Properties.Settings.Default.Remember = true;
                Properties.Settings.Default.Save();
            }

            Thread mainThread = new Thread(() =>
            {
                Application.Run(new Main()); 
            });

            mainThread.SetApartmentState(ApartmentState.STA); 
            mainThread.Start(); 

            this.Close();
        }

        private string Encrypt(string plainText, string key)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key.PadRight(32).Substring(0, 32)); // Clave de 256 bits
            byte[] iv = new byte[16]; // Vector de inicialización (16 bytes para AES)
            using (Aes aes = Aes.Create())
            {
                aes.Key = keyBytes;
                aes.IV = iv;
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
                        cs.Write(plainBytes, 0, plainBytes.Length);
                        cs.FlushFinalBlock();
                        return Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
        }

        private string Decrypt(string encryptedText, string key)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key.PadRight(32).Substring(0, 32)); // Clave de 256 bits
            byte[] iv = new byte[16]; // Vector de inicialización (16 bytes para AES)
            using (Aes aes = Aes.Create())
            {
                aes.Key = keyBytes;
                aes.IV = iv;
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
                        cs.Write(encryptedBytes, 0, encryptedBytes.Length);
                        cs.FlushFinalBlock();
                        return Encoding.UTF8.GetString(ms.ToArray());
                    }
                }
            }
        }

        

        private void chkRecordar_CheckedChanged(object sender, EventArgs e)
        {
            if(chkRecordar.Checked)
            {
                Properties.Settings.Default.Remember = true;
            }
            else
            {
                DialogResult res = MessageBox.Show("¿Esta seguro que quiere olvidar sus credenciales?", "Olvidar credenciales", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (res == DialogResult.Yes)
                {
                    Properties.Settings.Default.Remember = false;
                    Properties.Settings.Default.Username = string.Empty;
                    Properties.Settings.Default.Password = string.Empty;
                    Properties.Settings.Default.Save();
                    txtUser.Text = string.Empty;
                    txtPass.Text = string.Empty;
                }

            }
        }
    }
}

namespace AcademyGestor.Vistas
{
    partial class MatriculaView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbAlumno = new System.Windows.Forms.ComboBox();
            this.cmbCurso = new System.Windows.Forms.ComboBox();
            this.dtpFechaAlta = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaBaja = new System.Windows.Forms.DateTimePicker();
            this.chkFotos = new System.Windows.Forms.CheckBox();
            this.chkBeca = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.btnMatricular = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbAlumno
            // 
            this.cmbAlumno.FormattingEnabled = true;
            this.cmbAlumno.Location = new System.Drawing.Point(95, 12);
            this.cmbAlumno.Name = "cmbAlumno";
            this.cmbAlumno.Size = new System.Drawing.Size(255, 21);
            this.cmbAlumno.TabIndex = 0;
            // 
            // cmbCurso
            // 
            this.cmbCurso.FormattingEnabled = true;
            this.cmbCurso.Location = new System.Drawing.Point(95, 39);
            this.cmbCurso.Name = "cmbCurso";
            this.cmbCurso.Size = new System.Drawing.Size(255, 21);
            this.cmbCurso.TabIndex = 1;
            // 
            // dtpFechaAlta
            // 
            this.dtpFechaAlta.Enabled = false;
            this.dtpFechaAlta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaAlta.Location = new System.Drawing.Point(95, 67);
            this.dtpFechaAlta.Name = "dtpFechaAlta";
            this.dtpFechaAlta.Size = new System.Drawing.Size(255, 20);
            this.dtpFechaAlta.TabIndex = 2;
            // 
            // dtpFechaBaja
            // 
            this.dtpFechaBaja.Enabled = false;
            this.dtpFechaBaja.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaBaja.Location = new System.Drawing.Point(95, 93);
            this.dtpFechaBaja.Name = "dtpFechaBaja";
            this.dtpFechaBaja.Size = new System.Drawing.Size(255, 20);
            this.dtpFechaBaja.TabIndex = 3;
            // 
            // chkFotos
            // 
            this.chkFotos.AutoSize = true;
            this.chkFotos.Location = new System.Drawing.Point(12, 129);
            this.chkFotos.Name = "chkFotos";
            this.chkFotos.Size = new System.Drawing.Size(90, 17);
            this.chkFotos.TabIndex = 4;
            this.chkFotos.Text = "Autoriza fotos";
            this.chkFotos.UseVisualStyleBackColor = true;
            // 
            // chkBeca
            // 
            this.chkBeca.AutoSize = true;
            this.chkBeca.Location = new System.Drawing.Point(121, 129);
            this.chkBeca.Name = "chkBeca";
            this.chkBeca.Size = new System.Drawing.Size(51, 17);
            this.chkBeca.TabIndex = 5;
            this.chkBeca.Text = "Beca";
            this.chkBeca.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Alumno";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Curso";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Fecha de alta";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Fecha de baja";
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.Location = new System.Drawing.Point(275, 162);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFinalizar.Location = new System.Drawing.Point(47, 162);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(108, 23);
            this.btnFinalizar.TabIndex = 7;
            this.btnFinalizar.Text = "Dar de baja";
            this.btnFinalizar.UseVisualStyleBackColor = true;
            // 
            // btnMatricular
            // 
            this.btnMatricular.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnMatricular.Location = new System.Drawing.Point(161, 162);
            this.btnMatricular.Name = "btnMatricular";
            this.btnMatricular.Size = new System.Drawing.Size(108, 23);
            this.btnMatricular.TabIndex = 10;
            this.btnMatricular.Text = "Matricular";
            this.btnMatricular.UseVisualStyleBackColor = true;
            // 
            // MatriculaView
            // 
            this.AcceptButton = this.btnMatricular;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnMatricular;
            this.ClientSize = new System.Drawing.Size(362, 203);
            this.Controls.Add(this.btnMatricular);
            this.Controls.Add(this.btnFinalizar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkBeca);
            this.Controls.Add(this.chkFotos);
            this.Controls.Add(this.dtpFechaBaja);
            this.Controls.Add(this.dtpFechaAlta);
            this.Controls.Add(this.cmbCurso);
            this.Controls.Add(this.cmbAlumno);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MatriculaView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Detalle de matricula";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbAlumno;
        private System.Windows.Forms.ComboBox cmbCurso;
        private System.Windows.Forms.DateTimePicker dtpFechaAlta;
        private System.Windows.Forms.DateTimePicker dtpFechaBaja;
        private System.Windows.Forms.CheckBox chkFotos;
        private System.Windows.Forms.CheckBox chkBeca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.Button btnMatricular;
    }
}
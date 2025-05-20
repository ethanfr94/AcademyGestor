namespace AcademyGestor
{
    partial class Main
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.cmbSelect = new System.Windows.Forms.ComboBox();
            this.txtDatos = new System.Windows.Forms.RichTextBox();
            this.btnMulti = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMain = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnMulti2 = new System.Windows.Forms.Button();
            this.btnSolicitudes = new System.Windows.Forms.Button();
            this.btnPublicaciones = new System.Windows.Forms.Button();
            this.btnProfesores = new System.Windows.Forms.Button();
            this.btnMatriculas = new System.Windows.Forms.Button();
            this.btnCursos = new System.Windows.Forms.Button();
            this.btnAlumnos = new System.Windows.Forms.Button();
            this.btnRefr = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.AllowUserToResizeRows = false;
            this.dgvDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDatos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDatos.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvDatos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvDatos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Location = new System.Drawing.Point(157, 55);
            this.dgvDatos.MultiSelect = false;
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.RowHeadersVisible = false;
            this.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatos.Size = new System.Drawing.Size(726, 214);
            this.dgvDatos.TabIndex = 10;
            this.dgvDatos.Visible = false;
            this.dgvDatos.SelectionChanged += new System.EventHandler(this.dgvDatos_SelectionChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAdd.Location = new System.Drawing.Point(724, 11);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(160, 21);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Añadir";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Visible = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnEdit.Location = new System.Drawing.Point(724, 504);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(160, 21);
            this.btnEdit.TabIndex = 12;
            this.btnEdit.Text = "Editar";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Visible = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // cmbSelect
            // 
            this.cmbSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cmbSelect.Enabled = false;
            this.cmbSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSelect.FormattingEnabled = true;
            this.cmbSelect.Items.AddRange(new object[] {
            "Alumnos",
            "Cursos",
            "Matriculas",
            "Profesores",
            "Publicaciones",
            "Recibos",
            "Solicitudes"});
            this.cmbSelect.Location = new System.Drawing.Point(8, 12);
            this.cmbSelect.Name = "cmbSelect";
            this.cmbSelect.Size = new System.Drawing.Size(227, 21);
            this.cmbSelect.TabIndex = 0;
            this.cmbSelect.Visible = false;
            // 
            // txtDatos
            // 
            this.txtDatos.BackColor = System.Drawing.Color.White;
            this.txtDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDatos.Location = new System.Drawing.Point(157, 275);
            this.txtDatos.Name = "txtDatos";
            this.txtDatos.ReadOnly = true;
            this.txtDatos.Size = new System.Drawing.Size(726, 223);
            this.txtDatos.TabIndex = 11;
            this.txtDatos.Text = "";
            this.txtDatos.Visible = false;
            // 
            // btnMulti
            // 
            this.btnMulti.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnMulti.Location = new System.Drawing.Point(558, 504);
            this.btnMulti.Name = "btnMulti";
            this.btnMulti.Size = new System.Drawing.Size(160, 21);
            this.btnMulti.TabIndex = 13;
            this.btnMulti.Text = "Faltas de asistencia";
            this.btnMulti.UseVisualStyleBackColor = true;
            this.btnMulti.Visible = false;
            this.btnMulti.Click += new System.EventHandler(this.btnMulti_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.Transparent;
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.lblMain);
            this.pnlMain.Controls.Add(this.pictureBox1);
            this.pnlMain.Location = new System.Drawing.Point(157, 117);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(602, 283);
            this.pnlMain.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(72, 242);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Pulse el logo para comenzar";
            // 
            // lblMain
            // 
            this.lblMain.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMain.Location = new System.Drawing.Point(247, 54);
            this.lblMain.Name = "lblMain";
            this.lblMain.Size = new System.Drawing.Size(352, 238);
            this.lblMain.TabIndex = 8;
            this.lblMain.Text = resources.GetString("lblMain.Text");
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(0, 64);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(250, 179);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(286, 14);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(40, 13);
            this.lblBuscar.TabIndex = 24;
            this.lblBuscar.Text = "Buscar";
            this.lblBuscar.Visible = false;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(332, 12);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(300, 20);
            this.txtBuscar.TabIndex = 2;
            this.txtBuscar.Visible = false;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // btnMulti2
            // 
            this.btnMulti2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnMulti2.Location = new System.Drawing.Point(392, 504);
            this.btnMulti2.Name = "btnMulti2";
            this.btnMulti2.Size = new System.Drawing.Size(160, 21);
            this.btnMulti2.TabIndex = 14;
            this.btnMulti2.Text = "Administrar tutores";
            this.btnMulti2.UseVisualStyleBackColor = true;
            this.btnMulti2.Visible = false;
            this.btnMulti2.Click += new System.EventHandler(this.btnMulti2_Click);
            // 
            // btnSolicitudes
            // 
            this.btnSolicitudes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSolicitudes.Location = new System.Drawing.Point(8, 355);
            this.btnSolicitudes.Name = "btnSolicitudes";
            this.btnSolicitudes.Size = new System.Drawing.Size(120, 36);
            this.btnSolicitudes.TabIndex = 9;
            this.btnSolicitudes.Text = "Solicitudes";
            this.btnSolicitudes.UseVisualStyleBackColor = true;
            this.btnSolicitudes.Visible = false;
            this.btnSolicitudes.Click += new System.EventHandler(this.btnSolicitudes_Click);
            // 
            // btnPublicaciones
            // 
            this.btnPublicaciones.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnPublicaciones.Location = new System.Drawing.Point(8, 313);
            this.btnPublicaciones.Name = "btnPublicaciones";
            this.btnPublicaciones.Size = new System.Drawing.Size(120, 36);
            this.btnPublicaciones.TabIndex = 8;
            this.btnPublicaciones.Text = "Publicaciones";
            this.btnPublicaciones.UseVisualStyleBackColor = true;
            this.btnPublicaciones.Visible = false;
            this.btnPublicaciones.Click += new System.EventHandler(this.btnPublicaciones_Click);
            // 
            // btnProfesores
            // 
            this.btnProfesores.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnProfesores.Location = new System.Drawing.Point(8, 271);
            this.btnProfesores.Name = "btnProfesores";
            this.btnProfesores.Size = new System.Drawing.Size(120, 36);
            this.btnProfesores.TabIndex = 7;
            this.btnProfesores.Text = "Profesores";
            this.btnProfesores.UseVisualStyleBackColor = true;
            this.btnProfesores.Visible = false;
            this.btnProfesores.Click += new System.EventHandler(this.btnProfesores_Click);
            // 
            // btnMatriculas
            // 
            this.btnMatriculas.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnMatriculas.Location = new System.Drawing.Point(8, 229);
            this.btnMatriculas.Name = "btnMatriculas";
            this.btnMatriculas.Size = new System.Drawing.Size(120, 36);
            this.btnMatriculas.TabIndex = 6;
            this.btnMatriculas.Text = "Matriculas";
            this.btnMatriculas.UseVisualStyleBackColor = true;
            this.btnMatriculas.Visible = false;
            this.btnMatriculas.Click += new System.EventHandler(this.btnMatriculas_Click);
            // 
            // btnCursos
            // 
            this.btnCursos.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCursos.Location = new System.Drawing.Point(8, 187);
            this.btnCursos.Name = "btnCursos";
            this.btnCursos.Size = new System.Drawing.Size(120, 36);
            this.btnCursos.TabIndex = 5;
            this.btnCursos.Text = "Cursos";
            this.btnCursos.UseVisualStyleBackColor = true;
            this.btnCursos.Visible = false;
            this.btnCursos.Click += new System.EventHandler(this.btnCursos_Click);
            // 
            // btnAlumnos
            // 
            this.btnAlumnos.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAlumnos.Location = new System.Drawing.Point(8, 145);
            this.btnAlumnos.Name = "btnAlumnos";
            this.btnAlumnos.Size = new System.Drawing.Size(120, 36);
            this.btnAlumnos.TabIndex = 4;
            this.btnAlumnos.Text = "Alumnos";
            this.btnAlumnos.UseVisualStyleBackColor = true;
            this.btnAlumnos.Visible = false;
            this.btnAlumnos.Click += new System.EventHandler(this.btnAlumnos_Click);
            // 
            // btnRefr
            // 
            this.btnRefr.Enabled = false;
            this.btnRefr.Image = ((System.Drawing.Image)(resources.GetObject("btnRefr.Image")));
            this.btnRefr.Location = new System.Drawing.Point(197, 11);
            this.btnRefr.Name = "btnRefr";
            this.btnRefr.Size = new System.Drawing.Size(38, 22);
            this.btnRefr.TabIndex = 1;
            this.btnRefr.UseVisualStyleBackColor = true;
            this.btnRefr.Visible = false;
            this.btnRefr.Click += new System.EventHandler(this.btnRefr_Click);
            // 
            // btnStart
            // 
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(889, 265);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(11, 21);
            this.btnStart.TabIndex = 36;
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Visible = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.InitialImage = null;
            this.pictureBox2.Location = new System.Drawing.Point(8, 506);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(25, 25);
            this.pictureBox2.TabIndex = 37;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // Main
            // 
            this.AcceptButton = this.btnStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(896, 537);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnRefr);
            this.Controls.Add(this.btnSolicitudes);
            this.Controls.Add(this.btnPublicaciones);
            this.Controls.Add(this.btnProfesores);
            this.Controls.Add(this.btnMatriculas);
            this.Controls.Add(this.btnCursos);
            this.Controls.Add(this.btnAlumnos);
            this.Controls.Add(this.btnMulti2);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.btnMulti);
            this.Controls.Add(this.txtDatos);
            this.Controls.Add(this.cmbSelect);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvDatos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(909, 576);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AcademyGestor";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ComboBox cmbSelect;
        private System.Windows.Forms.RichTextBox txtDatos;
        private System.Windows.Forms.Button btnMulti;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblMain;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnMulti2;
        private System.Windows.Forms.Button btnSolicitudes;
        private System.Windows.Forms.Button btnPublicaciones;
        private System.Windows.Forms.Button btnProfesores;
        private System.Windows.Forms.Button btnMatriculas;
        private System.Windows.Forms.Button btnCursos;
        private System.Windows.Forms.Button btnAlumnos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRefr;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}


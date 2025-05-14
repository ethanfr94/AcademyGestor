namespace AcademyGestor.Vistas
{
    partial class ProfesoresCursoView
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
            this.dgvProfs = new System.Windows.Forms.DataGridView();
            this.lblCurso = new System.Windows.Forms.Label();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.dgvParticipantes = new System.Windows.Forms.DataGridView();
            this.btnDesasignar = new System.Windows.Forms.Button();
            this.btnCoordinador = new System.Windows.Forms.Button();
            this.lblCoordinador = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProfs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParticipantes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProfs
            // 
            this.dgvProfs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProfs.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvProfs.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvProfs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvProfs.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvProfs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProfs.Location = new System.Drawing.Point(12, 46);
            this.dgvProfs.MultiSelect = false;
            this.dgvProfs.Name = "dgvProfs";
            this.dgvProfs.ReadOnly = true;
            this.dgvProfs.RowHeadersVisible = false;
            this.dgvProfs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProfs.Size = new System.Drawing.Size(194, 140);
            this.dgvProfs.TabIndex = 1;
            this.dgvProfs.SelectionChanged += new System.EventHandler(this.dgvProfs_SelectionChanged);
            // 
            // lblCurso
            // 
            this.lblCurso.BackColor = System.Drawing.Color.White;
            this.lblCurso.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCurso.Location = new System.Drawing.Point(12, 13);
            this.lblCurso.Name = "lblCurso";
            this.lblCurso.Size = new System.Drawing.Size(194, 21);
            this.lblCurso.TabIndex = 2;
            this.lblCurso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAsignar
            // 
            this.btnAsignar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAsignar.Enabled = false;
            this.btnAsignar.Location = new System.Drawing.Point(212, 72);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(40, 23);
            this.btnAsignar.TabIndex = 84;
            this.btnAsignar.Text = "Asignar";
            this.btnAsignar.UseVisualStyleBackColor = true;
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.Location = new System.Drawing.Point(376, 192);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(76, 23);
            this.btnSalir.TabIndex = 83;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // dgvParticipantes
            // 
            this.dgvParticipantes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvParticipantes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvParticipantes.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvParticipantes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvParticipantes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvParticipantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParticipantes.Location = new System.Drawing.Point(258, 46);
            this.dgvParticipantes.MultiSelect = false;
            this.dgvParticipantes.Name = "dgvParticipantes";
            this.dgvParticipantes.ReadOnly = true;
            this.dgvParticipantes.RowHeadersVisible = false;
            this.dgvParticipantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvParticipantes.Size = new System.Drawing.Size(194, 140);
            this.dgvParticipantes.TabIndex = 86;
            this.dgvParticipantes.SelectionChanged += new System.EventHandler(this.dgvParticipantes_SelectionChanged);
            // 
            // btnDesasignar
            // 
            this.btnDesasignar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDesasignar.Enabled = false;
            this.btnDesasignar.Location = new System.Drawing.Point(212, 102);
            this.btnDesasignar.Name = "btnDesasignar";
            this.btnDesasignar.Size = new System.Drawing.Size(40, 23);
            this.btnDesasignar.TabIndex = 87;
            this.btnDesasignar.Text = "Desasignar";
            this.btnDesasignar.UseVisualStyleBackColor = true;
            this.btnDesasignar.Click += new System.EventHandler(this.btnDesasignar_Click);
            // 
            // btnCoordinador
            // 
            this.btnCoordinador.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCoordinador.Enabled = false;
            this.btnCoordinador.Location = new System.Drawing.Point(212, 152);
            this.btnCoordinador.Name = "btnCoordinador";
            this.btnCoordinador.Size = new System.Drawing.Size(40, 23);
            this.btnCoordinador.TabIndex = 88;
            this.btnCoordinador.Text = "Coordinador";
            this.btnCoordinador.UseVisualStyleBackColor = true;
            this.btnCoordinador.Click += new System.EventHandler(this.btnCoordinador_Click);
            // 
            // lblCoordinador
            // 
            this.lblCoordinador.BackColor = System.Drawing.Color.White;
            this.lblCoordinador.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCoordinador.Location = new System.Drawing.Point(258, 13);
            this.lblCoordinador.Name = "lblCoordinador";
            this.lblCoordinador.Size = new System.Drawing.Size(194, 21);
            this.lblCoordinador.TabIndex = 89;
            this.lblCoordinador.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProfesoresCursoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 227);
            this.Controls.Add(this.lblCoordinador);
            this.Controls.Add(this.btnCoordinador);
            this.Controls.Add(this.btnDesasignar);
            this.Controls.Add(this.dgvParticipantes);
            this.Controls.Add(this.btnAsignar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lblCurso);
            this.Controls.Add(this.dgvProfs);
            this.Name = "ProfesoresCursoView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProfesoresCursoView";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProfs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParticipantes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProfs;
        private System.Windows.Forms.Label lblCurso;
        private System.Windows.Forms.Button btnAsignar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridView dgvParticipantes;
        private System.Windows.Forms.Button btnDesasignar;
        private System.Windows.Forms.Button btnCoordinador;
        private System.Windows.Forms.Label lblCoordinador;
    }
}
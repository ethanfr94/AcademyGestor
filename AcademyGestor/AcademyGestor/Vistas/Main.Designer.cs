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
            this.pTablas = new System.Windows.Forms.Panel();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.cmbSelect = new System.Windows.Forms.ComboBox();
            this.btnCarga = new System.Windows.Forms.Button();
            this.txtDatos = new System.Windows.Forms.RichTextBox();
            this.btnFaltas = new System.Windows.Forms.Button();
            this.pTablas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // pTablas
            // 
            this.pTablas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pTablas.Controls.Add(this.dgvDatos);
            this.pTablas.Location = new System.Drawing.Point(8, 40);
            this.pTablas.Name = "pTablas";
            this.pTablas.Size = new System.Drawing.Size(887, 256);
            this.pTablas.TabIndex = 1;
            // 
            // dgvDatos
            // 
            this.dgvDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDatos.Location = new System.Drawing.Point(0, 0);
            this.dgvDatos.MultiSelect = false;
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatos.Size = new System.Drawing.Size(887, 256);
            this.dgvDatos.TabIndex = 0;
            this.dgvDatos.Visible = false;
            this.dgvDatos.SelectionChanged += new System.EventHandler(this.dgvDatos_SelectionChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(736, 505);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(160, 21);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Añadir";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(570, 505);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(160, 21);
            this.btnEdit.TabIndex = 8;
            this.btnEdit.Text = "Editar";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // cmbSelect
            // 
            this.cmbSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.cmbSelect.TabIndex = 9;
            // 
            // btnCarga
            // 
            this.btnCarga.Location = new System.Drawing.Point(241, 12);
            this.btnCarga.Name = "btnCarga";
            this.btnCarga.Size = new System.Drawing.Size(160, 22);
            this.btnCarga.TabIndex = 10;
            this.btnCarga.Text = "Cargar";
            this.btnCarga.UseVisualStyleBackColor = true;
            this.btnCarga.Click += new System.EventHandler(this.btnCarga_Click);
            // 
            // txtDatos
            // 
            this.txtDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDatos.Location = new System.Drawing.Point(8, 302);
            this.txtDatos.Name = "txtDatos";
            this.txtDatos.ReadOnly = true;
            this.txtDatos.Size = new System.Drawing.Size(888, 180);
            this.txtDatos.TabIndex = 12;
            this.txtDatos.Text = "";
            this.txtDatos.Visible = false;
            // 
            // btnFaltas
            // 
            this.btnFaltas.Location = new System.Drawing.Point(404, 505);
            this.btnFaltas.Name = "btnFaltas";
            this.btnFaltas.Size = new System.Drawing.Size(160, 21);
            this.btnFaltas.TabIndex = 13;
            this.btnFaltas.Text = "Faltas de asistencia";
            this.btnFaltas.UseVisualStyleBackColor = true;
            this.btnFaltas.Visible = false;
            this.btnFaltas.Click += new System.EventHandler(this.btnFaltas_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 537);
            this.Controls.Add(this.btnFaltas);
            this.Controls.Add(this.txtDatos);
            this.Controls.Add(this.btnCarga);
            this.Controls.Add(this.cmbSelect);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.pTablas);
            this.MinimumSize = new System.Drawing.Size(909, 576);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AcademyGestor";
            this.pTablas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pTablas;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ComboBox cmbSelect;
        private System.Windows.Forms.Button btnCarga;
        private System.Windows.Forms.RichTextBox txtDatos;
        private System.Windows.Forms.Button btnFaltas;
    }
}


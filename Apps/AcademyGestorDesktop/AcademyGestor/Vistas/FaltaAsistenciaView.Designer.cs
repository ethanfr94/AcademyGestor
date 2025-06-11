namespace AcademyGestor.Vistas
{
    partial class FaltaAsistenciaView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FaltaAsistenciaView));
            this.lblFaltasMes = new System.Windows.Forms.Label();
            this.lblFaltasTotales = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.dgvFaltas = new System.Windows.Forms.DataGridView();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaltas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFaltasMes
            // 
            this.lblFaltasMes.AutoSize = true;
            this.lblFaltasMes.Location = new System.Drawing.Point(10, 228);
            this.lblFaltasMes.Name = "lblFaltasMes";
            this.lblFaltasMes.Size = new System.Drawing.Size(164, 13);
            this.lblFaltasMes.TabIndex = 1;
            this.lblFaltasMes.Text = "- Faltas de asistencia ultimo mes: ";
            // 
            // lblFaltasTotales
            // 
            this.lblFaltasTotales.AutoSize = true;
            this.lblFaltasTotales.Location = new System.Drawing.Point(301, 228);
            this.lblFaltasTotales.Name = "lblFaltasTotales";
            this.lblFaltasTotales.Size = new System.Drawing.Size(146, 13);
            this.lblFaltasTotales.TabIndex = 2;
            this.lblFaltasTotales.Text = "- Faltas de asistencia totales: ";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(607, 223);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 0;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // dgvFaltas
            // 
            this.dgvFaltas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFaltas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvFaltas.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvFaltas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvFaltas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvFaltas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFaltas.Location = new System.Drawing.Point(13, 40);
            this.dgvFaltas.MultiSelect = false;
            this.dgvFaltas.Name = "dgvFaltas";
            this.dgvFaltas.ReadOnly = true;
            this.dgvFaltas.RowHeadersVisible = false;
            this.dgvFaltas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFaltas.Size = new System.Drawing.Size(669, 177);
            this.dgvFaltas.TabIndex = 13;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(526, 223);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 14;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(57, 12);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(300, 20);
            this.txtBuscar.TabIndex = 25;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(11, 14);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(40, 13);
            this.lblBuscar.TabIndex = 26;
            this.lblBuscar.Text = "Buscar";
            this.lblBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // FaltaAsistenciaView
            // 
            this.AcceptButton = this.btnSalir;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 254);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.dgvFaltas);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lblFaltasTotales);
            this.Controls.Add(this.lblFaltasMes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FaltaAsistenciaView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaltas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblFaltasMes;
        private System.Windows.Forms.Label lblFaltasTotales;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridView dgvFaltas;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
    }
}
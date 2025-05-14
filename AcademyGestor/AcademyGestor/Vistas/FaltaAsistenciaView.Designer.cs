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
            this.lblFaltasMes = new System.Windows.Forms.Label();
            this.lblFaltasTotales = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.dgvRecibos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecibos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFaltasMes
            // 
            this.lblFaltasMes.AutoSize = true;
            this.lblFaltasMes.Location = new System.Drawing.Point(12, 200);
            this.lblFaltasMes.Name = "lblFaltasMes";
            this.lblFaltasMes.Size = new System.Drawing.Size(164, 13);
            this.lblFaltasMes.TabIndex = 1;
            this.lblFaltasMes.Text = "- Faltas de asistencia ultimo mes: ";
            // 
            // lblFaltasTotales
            // 
            this.lblFaltasTotales.AutoSize = true;
            this.lblFaltasTotales.Location = new System.Drawing.Point(303, 200);
            this.lblFaltasTotales.Name = "lblFaltasTotales";
            this.lblFaltasTotales.Size = new System.Drawing.Size(146, 13);
            this.lblFaltasTotales.TabIndex = 2;
            this.lblFaltasTotales.Text = "- Faltas de asistencia totales: ";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(609, 195);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // dgvRecibos
            // 
            this.dgvRecibos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecibos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvRecibos.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvRecibos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvRecibos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvRecibos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecibos.Location = new System.Drawing.Point(15, 12);
            this.dgvRecibos.MultiSelect = false;
            this.dgvRecibos.Name = "dgvRecibos";
            this.dgvRecibos.ReadOnly = true;
            this.dgvRecibos.RowHeadersVisible = false;
            this.dgvRecibos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecibos.Size = new System.Drawing.Size(669, 177);
            this.dgvRecibos.TabIndex = 13;
            // 
            // FaltaAsistenciaView
            // 
            this.AcceptButton = this.btnSalir;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 226);
            this.Controls.Add(this.dgvRecibos);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lblFaltasTotales);
            this.Controls.Add(this.lblFaltasMes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FaltaAsistenciaView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecibos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblFaltasMes;
        private System.Windows.Forms.Label lblFaltasTotales;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridView dgvRecibos;
    }
}
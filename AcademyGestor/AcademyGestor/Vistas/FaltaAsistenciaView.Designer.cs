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
            this.dgvFaltas = new System.Windows.Forms.DataGridView();
            this.lblFaltasMes = new System.Windows.Forms.Label();
            this.lblFaltasTotales = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaltas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFaltas
            // 
            this.dgvFaltas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFaltas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFaltas.Location = new System.Drawing.Point(12, 12);
            this.dgvFaltas.MultiSelect = false;
            this.dgvFaltas.Name = "dgvFaltas";
            this.dgvFaltas.Size = new System.Drawing.Size(672, 176);
            this.dgvFaltas.TabIndex = 0;
            // 
            // lblFaltasMes
            // 
            this.lblFaltasMes.AutoSize = true;
            this.lblFaltasMes.Location = new System.Drawing.Point(12, 200);
            this.lblFaltasMes.Name = "lblFaltasMes";
            this.lblFaltasMes.Size = new System.Drawing.Size(0, 13);
            this.lblFaltasMes.TabIndex = 1;
            // 
            // lblFaltasTotales
            // 
            this.lblFaltasTotales.AutoSize = true;
            this.lblFaltasTotales.Location = new System.Drawing.Point(303, 200);
            this.lblFaltasTotales.Name = "lblFaltasTotales";
            this.lblFaltasTotales.Size = new System.Drawing.Size(0, 13);
            this.lblFaltasTotales.TabIndex = 2;
            // 
            // FaltaAsistenciaView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 226);
            this.Controls.Add(this.lblFaltasTotales);
            this.Controls.Add(this.lblFaltasMes);
            this.Controls.Add(this.dgvFaltas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FaltaAsistenciaView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaltas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFaltas;
        private System.Windows.Forms.Label lblFaltasMes;
        private System.Windows.Forms.Label lblFaltasTotales;
    }
}
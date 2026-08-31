namespace SistemaReservasSalas.Formularios
{
    partial class FormReportes
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el diseñador de Windows Forms

        private void InitializeComponent()
        {
            lblReporte = new Label();
            cmbReporte = new ComboBox();
            lblFecha = new Label();
            dtpFecha = new DateTimePicker();
            btnGenerar = new Button();
            grid = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)grid).BeginInit();
            SuspendLayout();
            // 
            // lblReporte
            // 
            lblReporte.AutoSize = true;
            lblReporte.Location = new Point(10, 15);
            lblReporte.Name = "lblReporte";
            lblReporte.Size = new Size(51, 15);
            lblReporte.TabIndex = 5;
            lblReporte.Text = "Reporte:";
            // 
            // cmbReporte
            // 
            cmbReporte.Items.AddRange(new object[] { "Reservas del día", "Uso por sala", "Ranking de salas más solicitadas" });
            cmbReporte.Location = new Point(80, 12);
            cmbReporte.Name = "cmbReporte";
            cmbReporte.Size = new Size(260, 23);
            cmbReporte.TabIndex = 0;
            cmbReporte.Text = "Reservas del día";
            cmbReporte.SelectedIndexChanged += cmbReporte_SelectedIndexChanged;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(360, 15);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(41, 15);
            lblFecha.TabIndex = 4;
            lblFecha.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(410, 12);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(150, 23);
            dtpFecha.TabIndex = 1;
            // 
            // btnGenerar
            // 
            btnGenerar.Location = new Point(580, 11);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(140, 25);
            btnGenerar.TabIndex = 2;
            btnGenerar.Text = "Generar";
            btnGenerar.UseVisualStyleBackColor = true;
            btnGenerar.Click += btnGenerar_Click;
            // 
            // grid
            // 
            grid.AllowUserToAddRows = false;
            grid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.Location = new Point(10, 50);
            grid.Name = "grid";
            grid.ReadOnly = true;
            grid.Size = new Size(720, 460);
            grid.TabIndex = 3;
            // 
            // FormReportes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(750, 550);
            Controls.Add(grid);
            Controls.Add(btnGenerar);
            Controls.Add(dtpFecha);
            Controls.Add(lblFecha);
            Controls.Add(cmbReporte);
            Controls.Add(lblReporte);
            Name = "FormReportes";
            Text = "Reportes";
            ((System.ComponentModel.ISupportInitialize)grid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblReporte;
        private System.Windows.Forms.ComboBox cmbReporte;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.DataGridView grid;
    }
}

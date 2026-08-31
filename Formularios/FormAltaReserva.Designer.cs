namespace SistemaReservasSalas.Formularios
{
    partial class FormAltaReserva
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
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblSala = new System.Windows.Forms.Label();
            this.cmbSala = new System.Windows.Forms.ComboBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblHoraInicio = new System.Windows.Forms.Label();
            this.dtpHoraInicio = new System.Windows.Forms.DateTimePicker();
            this.lblHoraFin = new System.Windows.Forms.Label();
            this.dtpHoraFin = new System.Windows.Forms.DateTimePicker();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.lblLimite = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblId
            //
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(20, 20);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(83, 15);
            this.lblId.Text = "Id de reserva:";
            //
            // txtId
            //
            this.txtId.Location = new System.Drawing.Point(160, 17);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(280, 23);
            this.txtId.TabIndex = 0;
            //
            // lblSala
            //
            this.lblSala.AutoSize = true;
            this.lblSala.Location = new System.Drawing.Point(20, 55);
            this.lblSala.Name = "lblSala";
            this.lblSala.Size = new System.Drawing.Size(32, 15);
            this.lblSala.Text = "Sala:";
            //
            // cmbSala
            //
            this.cmbSala.DisplayMember = "Nombre";
            this.cmbSala.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSala.Location = new System.Drawing.Point(160, 52);
            this.cmbSala.Name = "cmbSala";
            this.cmbSala.Size = new System.Drawing.Size(280, 23);
            this.cmbSala.TabIndex = 1;
            //
            // lblFecha
            //
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(20, 90);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(41, 15);
            this.lblFecha.Text = "Fecha:";
            //
            // dtpFecha
            //
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(160, 87);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(280, 23);
            this.dtpFecha.TabIndex = 2;
            //
            // lblHoraInicio
            //
            this.lblHoraInicio.AutoSize = true;
            this.lblHoraInicio.Location = new System.Drawing.Point(20, 125);
            this.lblHoraInicio.Name = "lblHoraInicio";
            this.lblHoraInicio.Size = new System.Drawing.Size(66, 15);
            this.lblHoraInicio.Text = "Hora inicio:";
            //
            // dtpHoraInicio
            //
            this.dtpHoraInicio.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraInicio.Location = new System.Drawing.Point(160, 122);
            this.dtpHoraInicio.Name = "dtpHoraInicio";
            this.dtpHoraInicio.ShowUpDown = true;
            this.dtpHoraInicio.Size = new System.Drawing.Size(280, 23);
            this.dtpHoraInicio.TabIndex = 3;
            //
            // lblHoraFin
            //
            this.lblHoraFin.AutoSize = true;
            this.lblHoraFin.Location = new System.Drawing.Point(20, 160);
            this.lblHoraFin.Name = "lblHoraFin";
            this.lblHoraFin.Size = new System.Drawing.Size(55, 15);
            this.lblHoraFin.Text = "Hora fin:";
            //
            // dtpHoraFin
            //
            this.dtpHoraFin.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraFin.Location = new System.Drawing.Point(160, 157);
            this.dtpHoraFin.Name = "dtpHoraFin";
            this.dtpHoraFin.ShowUpDown = true;
            this.dtpHoraFin.Size = new System.Drawing.Size(280, 23);
            this.dtpHoraFin.TabIndex = 4;
            //
            // lblMotivo
            //
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Location = new System.Drawing.Point(20, 195);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(50, 15);
            this.lblMotivo.Text = "Motivo:";
            //
            // txtMotivo
            //
            this.txtMotivo.Location = new System.Drawing.Point(160, 192);
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(280, 23);
            this.txtMotivo.TabIndex = 5;
            //
            // lblLimite
            //
            this.lblLimite.AutoSize = true;
            this.lblLimite.ForeColor = System.Drawing.Color.DimGray;
            this.lblLimite.Location = new System.Drawing.Point(20, 230);
            this.lblLimite.Name = "lblLimite";
            this.lblLimite.Size = new System.Drawing.Size(120, 15);
            this.lblLimite.Text = "Límite semanal: -";
            //
            // btnConfirmar
            //
            this.btnConfirmar.Location = new System.Drawing.Point(160, 270);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(180, 34);
            this.btnConfirmar.TabIndex = 6;
            this.btnConfirmar.Text = "Confirmar reserva";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            //
            // FormAltaReserva
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 360);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.lblLimite);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.lblMotivo);
            this.Controls.Add(this.dtpHoraFin);
            this.Controls.Add(this.lblHoraFin);
            this.Controls.Add(this.dtpHoraInicio);
            this.Controls.Add(this.lblHoraInicio);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.cmbSala);
            this.Controls.Add(this.lblSala);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblId);
            this.Name = "FormAltaReserva";
            this.Text = "Nueva Reserva";
            this.Load += new System.EventHandler(this.FormAltaReserva_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormAltaReserva_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblSala;
        private System.Windows.Forms.ComboBox cmbSala;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblHoraInicio;
        private System.Windows.Forms.DateTimePicker dtpHoraInicio;
        private System.Windows.Forms.Label lblHoraFin;
        private System.Windows.Forms.DateTimePicker dtpHoraFin;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Label lblLimite;
        private System.Windows.Forms.Button btnConfirmar;
    }
}

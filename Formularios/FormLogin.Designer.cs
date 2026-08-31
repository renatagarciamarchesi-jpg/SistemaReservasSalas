namespace SistemaReservasSalas.Formularios
{
    partial class FormLogin
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
            lblTitulo = new Label();
            lblInstruccion = new Label();
            cmbUsuarios = new ComboBox();
            btnIngresar = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitulo.Location = new Point(10, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(400, 40);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Sistema de Reservas de Salas de Reuniones";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblInstruccion
            // 
            lblInstruccion.AutoSize = true;
            lblInstruccion.Location = new Point(20, 70);
            lblInstruccion.Name = "lblInstruccion";
            lblInstruccion.Size = new Size(194, 15);
            lblInstruccion.TabIndex = 1;
            lblInstruccion.Text = "Seleccione su usuario para ingresar:";
            // 
            // cmbUsuarios
            // 
            cmbUsuarios.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUsuarios.FormattingEnabled = true;
            cmbUsuarios.ImeMode = ImeMode.On;
            cmbUsuarios.Location = new Point(20, 95);
            cmbUsuarios.Name = "cmbUsuarios";
            cmbUsuarios.Size = new Size(380, 23);
            cmbUsuarios.TabIndex = 2;
            cmbUsuarios.Format += cmbUsuarios_Format;
            // 
            // btnIngresar
            // 
            btnIngresar.Location = new Point(150, 140);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(120, 32);
            btnIngresar.TabIndex = 3;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // FormLogin
            // 
            AcceptButton = btnIngresar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 200);
            Controls.Add(btnIngresar);
            Controls.Add(cmbUsuarios);
            Controls.Add(lblInstruccion);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema de Reservas de Salas - Inicio de Sesión";
            Load += FormLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblInstruccion;
        private System.Windows.Forms.ComboBox cmbUsuarios;
        private System.Windows.Forms.Button btnIngresar;
    }
}

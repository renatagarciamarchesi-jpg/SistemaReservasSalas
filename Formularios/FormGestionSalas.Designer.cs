namespace SistemaReservasSalas.Formularios
{
    partial class FormGestionSalas
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
            panelDatos = new GroupBox();
            lblId = new Label();
            txtId = new TextBox();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblUbicacion = new Label();
            txtUbicacion = new TextBox();
            lblCapacidad = new Label();
            txtCapacidad = new TextBox();
            lblEquipamiento = new Label();
            txtEquipamiento = new TextBox();
            btnAgregar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            grid = new DataGridView();
            panelDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grid).BeginInit();
            SuspendLayout();
            // 
            // panelDatos
            // 
            panelDatos.Controls.Add(lblId);
            panelDatos.Controls.Add(txtId);
            panelDatos.Controls.Add(lblNombre);
            panelDatos.Controls.Add(txtNombre);
            panelDatos.Controls.Add(lblUbicacion);
            panelDatos.Controls.Add(txtUbicacion);
            panelDatos.Controls.Add(lblCapacidad);
            panelDatos.Controls.Add(txtCapacidad);
            panelDatos.Controls.Add(lblEquipamiento);
            panelDatos.Controls.Add(txtEquipamiento);
            panelDatos.Controls.Add(btnAgregar);
            panelDatos.Controls.Add(btnModificar);
            panelDatos.Controls.Add(btnEliminar);
            panelDatos.Controls.Add(btnLimpiar);
            panelDatos.Location = new Point(10, 10);
            panelDatos.Name = "panelDatos";
            panelDatos.Size = new Size(870, 130);
            panelDatos.TabIndex = 0;
            panelDatos.TabStop = false;
            panelDatos.Text = "Datos de la sala";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(10, 25);
            lblId.Name = "lblId";
            lblId.Size = new Size(20, 15);
            lblId.TabIndex = 0;
            lblId.Text = "Id:";
            // 
            // txtId
            // 
            txtId.Location = new Point(90, 22);
            txtId.Name = "txtId";
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 0;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(210, 25);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(54, 15);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(290, 22);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(200, 23);
            txtNombre.TabIndex = 1;
            // 
            // lblUbicacion
            // 
            lblUbicacion.AutoSize = true;
            lblUbicacion.Location = new Point(510, 25);
            lblUbicacion.Name = "lblUbicacion";
            lblUbicacion.Size = new Size(96, 15);
            lblUbicacion.TabIndex = 2;
            lblUbicacion.Text = "Ubicación / piso:";
            // 
            // txtUbicacion
            // 
            txtUbicacion.Location = new Point(620, 22);
            txtUbicacion.Name = "txtUbicacion";
            txtUbicacion.Size = new Size(220, 23);
            txtUbicacion.TabIndex = 2;
            // 
            // lblCapacidad
            // 
            lblCapacidad.AutoSize = true;
            lblCapacidad.Location = new Point(10, 60);
            lblCapacidad.Name = "lblCapacidad";
            lblCapacidad.Size = new Size(66, 15);
            lblCapacidad.TabIndex = 3;
            lblCapacidad.Text = "Capacidad:";
            // 
            // txtCapacidad
            // 
            txtCapacidad.Location = new Point(90, 57);
            txtCapacidad.Name = "txtCapacidad";
            txtCapacidad.Size = new Size(100, 23);
            txtCapacidad.TabIndex = 3;
            // 
            // lblEquipamiento
            // 
            lblEquipamiento.AutoSize = true;
            lblEquipamiento.Location = new Point(210, 60);
            lblEquipamiento.Name = "lblEquipamiento";
            lblEquipamiento.Size = new Size(202, 15);
            lblEquipamiento.TabIndex = 4;
            lblEquipamiento.Text = "Equipamiento (separado por comas):";
            // 
            // txtEquipamiento
            // 
            txtEquipamiento.Location = new Point(432, 60);
            txtEquipamiento.Name = "txtEquipamiento";
            txtEquipamiento.Size = new Size(408, 23);
            txtEquipamiento.TabIndex = 4;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(90, 95);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(100, 28);
            btnAgregar.TabIndex = 5;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(698, 96);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(80, 28);
            btnModificar.TabIndex = 6;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(784, 96);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(80, 28);
            btnEliminar.TabIndex = 7;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(612, 96);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(80, 28);
            btnLimpiar.TabIndex = 8;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // grid
            // 
            grid.AllowUserToAddRows = false;
            grid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.Location = new Point(10, 150);
            grid.MultiSelect = false;
            grid.Name = "grid";
            grid.ReadOnly = true;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.Size = new Size(870, 380);
            grid.TabIndex = 1;
            grid.CellClick += grid_CellClick;
            // 
            // FormGestionSalas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 550);
            Controls.Add(grid);
            Controls.Add(panelDatos);
            Name = "FormGestionSalas";
            Text = "Gestión de Salas de Reuniones";
            Load += FormGestionSalas_Load;
            panelDatos.ResumeLayout(false);
            panelDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox panelDatos;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblUbicacion;
        private System.Windows.Forms.TextBox txtUbicacion;
        private System.Windows.Forms.Label lblCapacidad;
        private System.Windows.Forms.TextBox txtCapacidad;
        private System.Windows.Forms.Label lblEquipamiento;
        private System.Windows.Forms.TextBox txtEquipamiento;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataGridView grid;
    }
}

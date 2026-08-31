using System;
using System.Linq;
using System.Windows.Forms;
using SistemaReservasSalas.Modelos;
using SistemaReservasSalas.Servicios;

namespace SistemaReservasSalas.Formularios
{
    public partial class FormGestionUsuarios : Form
    {
        public FormGestionUsuarios()
        {
            InitializeComponent();
        }

        private void FormGestionUsuarios_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            grid.DataSource = null;
            grid.DataSource = ContextoDatos.RepoUsuarios.Listar()
                .Select(u => new
                {
                    u.Id,
                    u.Nombre,
                    u.Email,
                    Rol = u.RolDescripcion,
                    LimiteSemanal = u.ObtenerLimiteReservasSemanales() == int.MaxValue ? "Sin límite" : u.ObtenerLimiteReservasSemanales().ToString()
                }).ToList();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text) || string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Id y Nombre son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Usuario nuevoUsuario = cmbRol.SelectedItem?.ToString() switch
                {
                    "Administrador" => new Administrador(txtId.Text.Trim(), txtNombre.Text.Trim(), txtEmail.Text.Trim()),
                    "Gerente" => new Gerente(txtId.Text.Trim(), txtNombre.Text.Trim(), txtEmail.Text.Trim()),
                    _ => new Empleado(txtId.Text.Trim(), txtNombre.Text.Trim(), txtEmail.Text.Trim())
                };

                ContextoDatos.RepoUsuarios.Agregar(nuevoUsuario);
                CargarGrilla();
                txtId.Text = txtNombre.Text = txtEmail.Text = "";
                MessageBox.Show("Usuario agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al agregar usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

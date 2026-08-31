using System;
using System.Windows.Forms;
using SistemaReservasSalas.Modelos;
using SistemaReservasSalas.Servicios;

namespace SistemaReservasSalas.Formularios
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            try
            {
                var usuarios = ContextoDatos.RepoUsuarios.Listar();
                cmbUsuarios.Items.Clear();
                foreach (var u in usuarios)
                    cmbUsuarios.Items.Add(u);

                if (cmbUsuarios.Items.Count > 0)
                    cmbUsuarios.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudieron cargar los usuarios:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbUsuarios_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is Usuario usuario)
                e.Value = $"{usuario.Id} - {usuario.Nombre} ({usuario.RolDescripcion})";
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (cmbUsuarios.SelectedItem is not Usuario usuarioSeleccionado)
            {
                MessageBox.Show("Debe seleccionar un usuario.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var principal = new FormPrincipal(usuarioSeleccionado);
            principal.FormClosed += FormPrincipal_FormClosed;
            principal.Show();
            Hide();
        }

        private void FormPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }
    }
}

using System;
using System.Windows.Forms;
using SistemaReservasSalas.Modelos;

namespace SistemaReservasSalas.Formularios
{
    public partial class FormPrincipal : Form
    {
        private Usuario _usuarioActual;

        // Constructor sin parámetros: solo lo usa el diseñador de Visual Studio para
        // poder abrir la vista de diseño (el form real siempre se abre pasando un usuario).
        public FormPrincipal() : this(null)
        {
        }

        public FormPrincipal(Usuario usuarioActual)
        {
            _usuarioActual = usuarioActual;
            InitializeComponent();
            ConfigurarMenuSegunRol();
        }

        // El menú se arma según el rol del usuario logueado: solo el Administrador ve
        // Gestión de salas y Gestión de usuarios. Como depende de una condición, esto
        // no puede vivir en InitializeComponent (el diseñador no admite lógica ahí).
        private void ConfigurarMenuSegunRol()
        {
            if (_usuarioActual == null)
            {
                lblUsuarioActual.Text = "Usuario: (vista de diseño, sin sesión iniciada)";
                return;
            }

            if (_usuarioActual is Administrador)
            {
                var miSalas = new ToolStripMenuItem("&Salas");
                miSalas.DropDownItems.Add("Gestión de salas", null, MiGestionSalas_Click);
                menuPrincipal.Items.Add(miSalas);

                var miUsuarios = new ToolStripMenuItem("&Usuarios");
                miUsuarios.DropDownItems.Add("Gestión de usuarios", null, MiGestionUsuarios_Click);
                menuPrincipal.Items.Add(miUsuarios);
            }

            var miReservas = new ToolStripMenuItem("&Reservas");
            miReservas.DropDownItems.Add("Grilla / calendario de reservas", null, MiGrillaReservas_Click);
            miReservas.DropDownItems.Add("Nueva reserva", null, MiAltaReserva_Click);
            miReservas.DropDownItems.Add("Cancelar reserva", null, MiCancelarReserva_Click);
            menuPrincipal.Items.Add(miReservas);

            var miReportes = new ToolStripMenuItem("Re&portes");
            miReportes.DropDownItems.Add("Ver reportes", null, MiReportes_Click);
            menuPrincipal.Items.Add(miReportes);

            var miSesion = new ToolStripMenuItem("&Sesión");
            miSesion.DropDownItems.Add("Cerrar sesión", null, MiCerrarSesion_Click);
            menuPrincipal.Items.Add(miSesion);

            lblUsuarioActual.Text =
                $"Usuario: {_usuarioActual.Nombre}  |  Rol: {_usuarioActual.RolDescripcion}  |  Límite semanal de reservas: " +
                (_usuarioActual.ObtenerLimiteReservasSemanales() == int.MaxValue ? "sin límite" : _usuarioActual.ObtenerLimiteReservasSemanales().ToString());
        }

        private void MiGestionSalas_Click(object sender, EventArgs e)
        {
            AbrirHijo(new FormGestionSalas());
        }

        private void MiGestionUsuarios_Click(object sender, EventArgs e)
        {
            AbrirHijo(new FormGestionUsuarios());
        }

        private void MiGrillaReservas_Click(object sender, EventArgs e)
        {
            AbrirHijo(new FormGrillaReservas());
        }

        private void MiAltaReserva_Click(object sender, EventArgs e)
        {
            AbrirHijo(new FormAltaReserva(_usuarioActual));
        }

        private void MiCancelarReserva_Click(object sender, EventArgs e)
        {
            AbrirHijo(new FormCancelarReserva(_usuarioActual));
        }

        private void MiReportes_Click(object sender, EventArgs e)
        {
            AbrirHijo(new FormReportes());
        }

        private void MiCerrarSesion_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AbrirHijo(Form hijo)
        {
            hijo.MdiParent = this;
            hijo.WindowState = FormWindowState.Maximized;
            hijo.Show();
        }
    }
}

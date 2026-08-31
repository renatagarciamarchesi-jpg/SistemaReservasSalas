using System;
using System.Linq;
using System.Windows.Forms;
using SistemaReservasSalas.Enums;
using SistemaReservasSalas.Modelos;
using SistemaReservasSalas.Servicios;

namespace SistemaReservasSalas.Formularios
{
    public partial class FormCancelarReserva : Form
    {
        private Usuario _usuarioActual;

        // Constructor sin parámetros: solo para que el diseñador de Visual Studio
        // pueda abrir la vista de diseño de este formulario.
        public FormCancelarReserva() : this(null)
        {
        }

        public FormCancelarReserva(Usuario usuarioActual)
        {
            _usuarioActual = usuarioActual;
            InitializeComponent();
        }

        private void FormCancelarReserva_Load(object sender, EventArgs e)
        {
            CargarGrilla();
            ContextoDatos.Servicio.ReservaCancelada += Servicio_ReservaCancelada;
        }

        private void FormCancelarReserva_FormClosed(object sender, FormClosedEventArgs e)
        {
            ContextoDatos.Servicio.ReservaCancelada -= Servicio_ReservaCancelada;
        }

        private void Servicio_ReservaCancelada(object sender, ReservaEventArgs e)
        {
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            if (_usuarioActual == null)
            {
                grid.DataSource = null;
                return;
            }

            // El Administrador ve todas las reservas activas; el resto de los roles
            // solo las propias, que es lo único que su rol les permite cancelar.
            var reservas = ContextoDatos.RepoReservas.Listar()
                .Where(r => r.Estado != EstadoReserva.Cancelada)
                .Where(r => _usuarioActual is Administrador || r.UsuarioId == _usuarioActual.Id)
                .OrderBy(r => r.Fecha).ThenBy(r => r.HoraInicio)
                .Select(r => new
                {
                    r.Id,
                    r.SalaId,
                    r.UsuarioId,
                    Fecha = r.Fecha.ToString("yyyy-MM-dd"),
                    Horario = $"{r.HoraInicio:hh\\:mm} - {r.HoraFin:hh\\:mm}",
                    r.Motivo,
                    r.Estado
                }).ToList();

            grid.DataSource = null;
            grid.DataSource = reservas;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una reserva de la grilla.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string reservaId = grid.CurrentRow.Cells["Id"].Value?.ToString();

            var confirmar = MessageBox.Show($"¿Confirma la cancelación de la reserva '{reservaId}'?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmar != DialogResult.Yes) return;

            try
            {
                ContextoDatos.Servicio.CancelarReserva(reservaId, _usuarioActual);
                MessageBox.Show("Reserva cancelada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message, "Permiso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cancelar la reserva", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarGrilla();
        }
    }
}

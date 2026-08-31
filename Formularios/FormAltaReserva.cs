using System;
using System.Windows.Forms;
using SistemaReservasSalas.Excepciones;
using SistemaReservasSalas.Modelos;
using SistemaReservasSalas.Servicios;

namespace SistemaReservasSalas.Formularios
{
    public partial class FormAltaReserva : Form
    {
        private Usuario _usuarioActual;

        // Constructor sin parámetros: solo para que el diseñador de Visual Studio
        // pueda abrir la vista de diseño de este formulario.
        public FormAltaReserva() : this(null)
        {
        }

        public FormAltaReserva(Usuario usuarioActual)
        {
            _usuarioActual = usuarioActual;
            InitializeComponent();
        }

        private void FormAltaReserva_Load(object sender, EventArgs e)
        {
            dtpHoraInicio.Value = DateTime.Today.AddHours(9);
            dtpHoraFin.Value = DateTime.Today.AddHours(10);
            dtpFecha.MinDate = DateTime.Today;

            CargarSalas();

            if (_usuarioActual != null)
            {
                lblLimite.Text = $"Límite semanal para {_usuarioActual.RolDescripcion}: " +
                    (_usuarioActual.ObtenerLimiteReservasSemanales() == int.MaxValue ? "sin límite" : _usuarioActual.ObtenerLimiteReservasSemanales().ToString());

                ContextoDatos.Servicio.ReservaCreada += Servicio_ReservaCreada;
            }
        }

        private void FormAltaReserva_FormClosed(object sender, FormClosedEventArgs e)
        {
            ContextoDatos.Servicio.ReservaCreada -= Servicio_ReservaCreada;
        }

        private void CargarSalas()
        {
            cmbSala.Items.Clear();
            foreach (var s in ContextoDatos.RepoSalas.Listar())
                cmbSala.Items.Add(s);
            if (cmbSala.Items.Count > 0)
                cmbSala.SelectedIndex = 0;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (_usuarioActual == null)
                return; // no debería poder llegar acá desde la vista de diseño

            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Debe indicar un Id para la reserva.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbSala.SelectedItem is not SalaReunion sala)
            {
                MessageBox.Show("Debe seleccionar una sala.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var horaInicio = dtpHoraInicio.Value.TimeOfDay;
            var horaFin = dtpHoraFin.Value.TimeOfDay;

            try
            {
                ContextoDatos.Servicio.CrearReserva(
                    txtId.Text.Trim(), sala.Id, _usuarioActual.Id, dtpFecha.Value,
                    horaInicio, horaFin, txtMotivo.Text.Trim());
            }
            catch (ReservaSolapadaException ex)
            {
                MessageBox.Show(ex.Message, "Horario no disponible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (SalaNoDisponibleException ex)
            {
                MessageBox.Show(ex.Message, "Sala no disponible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Límite alcanzado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al crear la reserva", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Servicio_ReservaCreada(object sender, ReservaEventArgs e)
        {
            MessageBox.Show(e.Mensaje, "Reserva confirmada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtId.Text = "";
            txtMotivo.Text = "";
        }
    }
}

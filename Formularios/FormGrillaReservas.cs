using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SistemaReservasSalas.Modelos;
using SistemaReservasSalas.Servicios;

namespace SistemaReservasSalas.Formularios
{
    public partial class FormGrillaReservas : Form
    {
        private static readonly TimeSpan HoraApertura = TimeSpan.FromHours(8);
        private static readonly TimeSpan HoraCierre = TimeSpan.FromHours(20);

        public FormGrillaReservas()
        {
            InitializeComponent();
        }

        private void FormGrillaReservas_Load(object sender, EventArgs e)
        {
            CargarSalas();
        }

        private void CargarSalas()
        {
            cmbSala.Items.Clear();
            foreach (var s in ContextoDatos.RepoSalas.Listar())
                cmbSala.Items.Add(s);
            if (cmbSala.Items.Count > 0)
                cmbSala.SelectedIndex = 0;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            grid.Rows.Clear();

            if (cmbSala.SelectedItem is not SalaReunion sala)
            {
                MessageBox.Show("No hay salas cargadas.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var reservasDelDia = ContextoDatos.Servicio.ConsultarDisponibilidad(sala.Id, dtpFecha.Value);

            for (var hora = HoraApertura; hora < HoraCierre; hora += TimeSpan.FromMinutes(30))
            {
                var finFranja = hora + TimeSpan.FromMinutes(30);
                var reservaEnFranja = reservasDelDia.FirstOrDefault(r => hora < r.HoraFin && r.HoraInicio < finFranja);

                string franjaTexto = $"{hora:hh\\:mm} - {finFranja:hh\\:mm}";
                string estado = reservaEnFranja != null ? "Ocupado" : "Libre";
                string detalle = reservaEnFranja != null
                    ? $"{reservaEnFranja.Motivo} (Usuario: {reservaEnFranja.UsuarioId}, Estado: {reservaEnFranja.Estado})"
                    : "";

                int fila = grid.Rows.Add(franjaTexto, estado, detalle);
                grid.Rows[fila].DefaultCellStyle.BackColor = reservaEnFranja != null
                    ? Color.MistyRose
                    : Color.Honeydew;
            }
        }
    }
}

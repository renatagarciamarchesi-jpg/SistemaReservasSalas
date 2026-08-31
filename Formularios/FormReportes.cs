using System;
using System.Linq;
using System.Windows.Forms;
using SistemaReservasSalas.Servicios;

namespace SistemaReservasSalas.Formularios
{
    public partial class FormReportes : Form
    {
        public FormReportes()
        {
            InitializeComponent();
        }

        private void cmbReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtpFecha.Enabled = cmbReporte.SelectedIndex == 0;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            grid.DataSource = null;

            switch (cmbReporte.SelectedIndex)
            {
                case 0: // Reservas del día
                    grid.DataSource = ContextoDatos.Servicio.ReservasDelDia(dtpFecha.Value)
                        .Select(r => new
                        {
                            r.Id,
                            r.SalaId,
                            r.UsuarioId,
                            Horario = $"{r.HoraInicio:hh\\:mm} - {r.HoraFin:hh\\:mm}",
                            r.Motivo,
                            r.Estado
                        }).ToList();
                    break;

                case 1: // Uso por sala (GroupBy)
                    grid.DataSource = ContextoDatos.Servicio.ReporteUsoPorSala()
                        .Select(g => new
                        {
                            Sala = g.SalaId,
                            NombreSala = ContextoDatos.RepoSalas.Obtener(g.SalaId)?.Nombre ?? "(sala eliminada)",
                            CantidadDeReservas = g.Cantidad
                        }).ToList();
                    break;

                case 2: // Ranking de salas
                    grid.DataSource = ContextoDatos.Servicio.RankingSalas()
                        .Select((g, i) => new
                        {
                            Puesto = i + 1,
                            Sala = g.SalaId,
                            NombreSala = ContextoDatos.RepoSalas.Obtener(g.SalaId)?.Nombre ?? "(sala eliminada)",
                            CantidadDeReservas = g.Cantidad
                        }).ToList();
                    break;
            }
        }
    }
}

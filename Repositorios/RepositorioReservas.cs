using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using SistemaReservasSalas.Enums;
using SistemaReservasSalas.Excepciones;
using SistemaReservasSalas.Modelos;

namespace SistemaReservasSalas.Repositorios
{
    // Formato de linea: Id|SalaId|UsuarioId|Fecha(yyyy-MM-dd)|HoraInicio(HH:mm)|HoraFin(HH:mm)|Motivo|Estado
    public class RepositorioReservas : RepositorioArchivo<Reserva>
    {
        //Constructor
        public RepositorioReservas(string rutaArchivo) : base(rutaArchivo)
        {

        }

        //Métodos
        protected override string ObtenerId(Reserva entidad)
        {
            return entidad.Id;
        }

        protected override string ConvertirALinea(Reserva r)
        {
            return r.Id + "|" + r.SalaId + "|" + r.UsuarioId + "|" + r.Fecha.ToString("yyyy-MM-dd") + "|"
                + r.HoraInicio.ToString(@"hh\:mm") + "|" + r.HoraFin.ToString(@"hh\:mm") + "|" + r.Motivo + "|" + r.Estado;
        }

        protected override Reserva MapearLinea(string linea)
        {
            var campos = linea.Split('|');
            if (campos.Length < 8)
            {
                throw new ArchivoDatosCorruptoException("La linea de reserva no tiene los 8 campos requeridos.");
            }

            if (!DateTime.TryParseExact(campos[3], "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var fecha))
            {
                throw new ArchivoDatosCorruptoException("Fecha invalida: '" + campos[3] + "'");
            }

            if (!TimeSpan.TryParse(campos[4], out var horaInicio))
            {
                throw new ArchivoDatosCorruptoException("Hora de inicio invalida: '" + campos[4] + "'");
            }

            if (!TimeSpan.TryParse(campos[5], out var horaFin))
            {
                throw new ArchivoDatosCorruptoException("Hora de fin invalida: '" + campos[5] + "'");
            }

            if (!Enum.TryParse<EstadoReserva>(campos[7], out var estado))
            {
                throw new ArchivoDatosCorruptoException("Estado de reserva invalido: '" + campos[7] + "'");
            }

            return new Reserva(campos[0], campos[1], campos[2], fecha, horaInicio, horaFin, campos[6], estado);
        }

        // Detección de solapamiento de horarios (LINQ)
        public bool ExisteSolapamiento(string salaId, DateTime fecha, TimeSpan horaInicio, TimeSpan horaFin)
        {
            return Listar().Any(r =>
                r.SalaId == salaId &&
                r.Fecha.Date == fecha.Date &&
                r.Estado != EstadoReserva.Cancelada &&
                horaInicio < r.HoraFin && r.HoraInicio < horaFin);
        }

        public List<Reserva> ReservasDelDia(DateTime fecha)
        {
            return Listar()
                .Where(r => r.Fecha.Date == fecha.Date && r.Estado != EstadoReserva.Cancelada)
                .OrderBy(r => r.HoraInicio)
                .ToList();
        }

        public List<Reserva> ReservasPorSalaYFecha(string salaId, DateTime fecha)
        {
            return Listar().Where(r => r.SalaId == salaId && r.Fecha.Date == fecha.Date && r.Estado != EstadoReserva.Cancelada).OrderBy(r => r.HoraInicio).ToList();
        }

        // Reporte con GroupBy: cantidad de reservas activas por sala
        public List<(string SalaId, int Cantidad)> ReporteUsoPorSala()
        {
            return Listar().Where(r => r.Estado != EstadoReserva.Cancelada).GroupBy(r => r.SalaId).Select(g => (SalaId: g.Key, Cantidad: g.Count())).OrderByDescending(g => g.Cantidad).ToList();
        }

        public List<(string SalaId, int Cantidad)> RankingSalasMasSolicitadas(int top = 5)
        {
            return ReporteUsoPorSala().Take(top).ToList();
        }

        public int ContarReservasSemanaUsuario(string usuarioId, DateTime fecha)
        {
            var inicioSemana = fecha.Date.AddDays(-(int)fecha.DayOfWeek);
            var finSemana = inicioSemana.AddDays(7);

            return Listar().Count(r => r.UsuarioId == usuarioId && r.Estado != EstadoReserva.Cancelada && r.Fecha.Date >= inicioSemana && r.Fecha.Date < finSemana);
        }
    }
}

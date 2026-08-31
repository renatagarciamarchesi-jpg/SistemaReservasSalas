using System;
using SistemaReservasSalas.Enums;

namespace SistemaReservasSalas.Modelos
{
    public class Reserva
    {
        //Propiedades
        public string Id { get; set; }
        public string SalaId { get; set; }
        public string UsuarioId { get; set; }
        public DateTime Fecha { get; set; }
        public string Motivo { get; set; }
        public EstadoReserva Estado { get; set; }

        //Validación horaria
        private TimeSpan horaInicio;
        private TimeSpan horaFin;
        private bool horaFinAsignada;

        public TimeSpan HoraInicio
        {
            get { return horaInicio; }
            set
            {
                if (horaFinAsignada && value >= horaFin)
                    throw new ArgumentException("La hora de inicio debe ser anterior a la hora de fin.");

                horaInicio = value;
            }
        }

        public TimeSpan HoraFin
        {
            get { return horaFin; }
            set
            {
                if (value <= horaInicio)
                    throw new ArgumentException("La hora de fin no puede ser anterior o igual a la hora de inicio.");

                horaFin = value;
                horaFinAsignada = true;
            }
        }

        //Propiedades calculadoras
        public TimeSpan DuracionReserva
        {
            get { return HoraFin - HoraInicio; }
        }

        public bool EstaVencida
        {
            get { return (Fecha.Date + HoraFin) < DateTime.Now; }
        }

        //Constructor completo (Con motivo)
        public Reserva(string id, string salaId, string usuarioId, DateTime fecha, TimeSpan horaInicio, TimeSpan horaFin, string motivo, EstadoReserva estado)
        {
            Id = id;
            SalaId = salaId;
            UsuarioId = usuarioId;
            Fecha = fecha;
            HoraInicio = horaInicio;
            HoraFin = horaFin;
            Motivo = motivo;
            Estado = estado;
        }

        //Constructor (Sin motivo), entonces llama al de arriba con un texto por defecto
        public Reserva(string id, string salaId, string usuarioId, DateTime fecha, TimeSpan horaInicio, TimeSpan horaFin, EstadoReserva estado) : this(id, salaId, usuarioId, fecha, horaInicio, horaFin, "(sin motivo especificado)", estado)
        {

        }
    }
}

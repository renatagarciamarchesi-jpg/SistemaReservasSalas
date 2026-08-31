using System;
using System.Collections.Generic;
using SistemaReservasSalas.Enums;
using SistemaReservasSalas.Excepciones;
using SistemaReservasSalas.Modelos;
using SistemaReservasSalas.Repositorios;

namespace SistemaReservasSalas.Servicios
{
    // Datos que viajan con los eventos de reserva creada/cancelada
    public class ReservaEventArgs : EventArgs
    {
        public Reserva Reserva { get; set; }
        public string Mensaje { get; set; }

        public ReservaEventArgs(Reserva reserva, string mensaje)
        {
            Reserva = reserva;
            Mensaje = mensaje;
        }
    }

    public delegate void ReservaEventHandler(object sender, ReservaEventArgs e);

    // Acá esta toda la logica de negocio (crear reserva, cancelar, reportes).
    // Los formularios no acceden a los repositorios directamente, pasan por acá.
    public class ServicioReservas
    {
        private RepositorioSalas repoSalas;
        private RepositorioUsuarios repoUsuarios;
        private RepositorioReservas repoReservas;

        // Eventos para avisarle a la pantalla que una reserva se creó o se canceló, sin que esta clase conozca nada de los formularios
        public event ReservaEventHandler ReservaCreada;
        public event ReservaEventHandler ReservaCancelada;

        //Constructor sobrecargado
        public ServicioReservas(RepositorioSalas repoSalas, RepositorioUsuarios repoUsuarios, RepositorioReservas repoReservas)
        {
            this.repoSalas = repoSalas;
            this.repoUsuarios = repoUsuarios;
            this.repoReservas = repoReservas;
        }

        //Métodos
        public void CrearReserva(string id, string salaId, string usuarioId, DateTime fecha, TimeSpan horaInicio, TimeSpan horaFin, string motivo)
        {
            // 1. Verificar si la sala existe
            var sala = repoSalas.Obtener(salaId);
            if (sala == null)
            {
                throw new SalaNoDisponibleException("La sala con ID '" + salaId + "' no existe.");
            }

            // 2. Verificar si el usuario existe
            var usuario = repoUsuarios.Obtener(usuarioId);
            if (usuario == null)
            {
                throw new ArgumentException("El usuario con ID '" + usuarioId + "' no existe.");
            }

            // 3. Verificar si el horario se solapa con otra reserva
            if (repoReservas.ExisteSolapamiento(salaId, fecha, horaInicio, horaFin))
            {
                throw new ReservaSolapadaException("La sala '" + salaId + "' ya se encuentra ocupada en ese horario.");
            }

            // 4. Verificar el limite de reservas semanales del usuario
            int reservasActuales = repoReservas.ContarReservasSemanaUsuario(usuarioId, fecha);
            if (reservasActuales >= usuario.ObtenerLimiteReservasSemanales())
            {
                throw new InvalidOperationException("El usuario ha alcanzado su limite de reservas para esta semana.");
            }

            // 5. Crear y guardar la reserva
            Reserva nuevaReserva;
            if (string.IsNullOrWhiteSpace(motivo))
                nuevaReserva = new Reserva(id, salaId, usuarioId, fecha, horaInicio, horaFin, EstadoReserva.Pendiente);
            else
                nuevaReserva = new Reserva(id, salaId, usuarioId, fecha, horaInicio, horaFin, motivo, EstadoReserva.Pendiente);

            repoReservas.Agregar(nuevaReserva);

            if (ReservaCreada != null)
                ReservaCreada(this, new ReservaEventArgs(nuevaReserva, "Reserva " + nuevaReserva.Id + " creada correctamente."));
        }

        public void CancelarReserva(string reservaId, Usuario usuarioSolicitante)
        {
            var reserva = repoReservas.Obtener(reservaId);
            if (reserva == null)
            {
                throw new ArgumentException("No se encontro la reserva con ID '" + reservaId + "'.");
            }

            // Validar si el usuario tiene permiso para cancelarla segun su rol
            if (!usuarioSolicitante.PuedeCancelar(reserva))
            {
                throw new UnauthorizedAccessException("No tiene permisos para cancelar esta reserva.");
            }

            reserva.Estado = EstadoReserva.Cancelada;
            repoReservas.Actualizar(reserva);

            if (ReservaCancelada != null)
                ReservaCancelada(this, new ReservaEventArgs(reserva, "Reserva " + reserva.Id + " cancelada correctamente."));
        }

        public List<Reserva> ReservasDelDia(DateTime fecha)
        {
            return repoReservas.ReservasDelDia(fecha);
        }

        public List<Reserva> ConsultarDisponibilidad(string salaId, DateTime fecha)
        {
            return repoReservas.ReservasPorSalaYFecha(salaId, fecha);
        }

        public List<(string SalaId, int Cantidad)> ReporteUsoPorSala()
        {
            return repoReservas.ReporteUsoPorSala();
        }

        public List<(string SalaId, int Cantidad)> RankingSalas(int top = 5)
        {
            return repoReservas.RankingSalasMasSolicitadas(top);
        }
    }
}

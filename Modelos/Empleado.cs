using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservasSalas.Modelos
{
    //Empleado hereda de usuario. Relación: Usuario
    public class Empleado : Usuario
    {
        //Constructor
        public Empleado(string id, string nombre, string email) : base(id, nombre, email)
        {

        }

        //Métodos
        public override int ObtenerLimiteReservasSemanales()
        {
            // Los empleados pueden hacer hasta 5 reservas por semana
            return 5;
        }

        public override bool PuedeCancelar(Reserva reserva)
        {
            // Un empleado puede cancelar la reserva si la hizo él mismo
            if (reserva == null)
            {
                return false;
            }

            return reserva.UsuarioId == this.Id;
        }
    }
}

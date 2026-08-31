using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservasSalas.Modelos
{
    //Administrador hereda de usuario. Relación: Usuario
    public class Administrador : Usuario
    {
        //Constructor
        public Administrador(string id, string nombre, string email) : base(id, nombre, email)
        {

        }

        //Métodos
        public override int ObtenerLimiteReservasSemanales()
        {
            // Un administrador no tiene limite de reservas semanales
            return int.MaxValue;
        }

        public override bool PuedeCancelar(Reserva reserva)
        {
            // Un administrador puede cancelar cualquier reserva
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservasSalas.Modelos
{
    //Gerente hereda de usuario. Relación: Usuario
    public class Gerente : Usuario
    {
        //Constructor
        public Gerente(string id, string nombre, string email) : base(id, nombre, email)
        {

        }

        //Métodos
        public override int ObtenerLimiteReservasSemanales()
        {
            //Un gerente puede hacer hasta 10 reservas por semana
            return 10;
        }

        public override bool PuedeCancelar(Reserva reserva)
        {
            // Solo puede cancelar sus propias reservas
            if (reserva == null)
            {
                return false;
            }

            return reserva.UsuarioId == this.Id;
        }
    }
}

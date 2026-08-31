using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservasSalas.Modelos
{
    public abstract class Usuario
    {
        //Propiedades
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }

        public string RolDescripcion
        {
            get { return this.GetType().Name; }
        }

        //Constructor sobrecargado
        protected Usuario(string id, string nombre, string email)
        {
            Id = id;
            Nombre = nombre;
            Email = email;
        }

        //Métodos
        public abstract int ObtenerLimiteReservasSemanales();

        public abstract bool PuedeCancelar(Reserva reserva);
    }
}

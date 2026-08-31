using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservasSalas.Excepciones
{
    // Se usa cuando una reserva nueva choca en horario con otra reserva de la misma sala
    public class ReservaSolapadaException : Exception
    {
        public ReservaSolapadaException()
        {

        }

        public ReservaSolapadaException(string mensaje) : base(mensaje)
        {

        }

        public ReservaSolapadaException(string mensaje, Exception errorOriginal) : base(mensaje, errorOriginal)
        {

        }
    }
}

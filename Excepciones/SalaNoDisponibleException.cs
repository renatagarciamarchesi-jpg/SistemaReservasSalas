using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SistemaReservasSalas.Excepciones
{
    // Se usa cuando se busca una sala que no existe o no se puede usar
    public class SalaNoDisponibleException : Exception
    {
        public SalaNoDisponibleException()
        {

        }

        public SalaNoDisponibleException(string mensaje) : base(mensaje)
        {

        }

        public SalaNoDisponibleException(string mensaje, Exception errorOriginal) : base(mensaje, errorOriginal)
        {

        }
    }
}

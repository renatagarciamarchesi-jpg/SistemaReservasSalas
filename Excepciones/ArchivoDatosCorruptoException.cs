using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservasSalas.Excepciones
{
    // Se usa cuando una linea de un archivo .txt no tiene el formato esperado
    public class ArchivoDatosCorruptoException : Exception
    {
        public ArchivoDatosCorruptoException()
        {

        }

        public ArchivoDatosCorruptoException(string mensaje) : base(mensaje)
        {

        }

        public ArchivoDatosCorruptoException(string mensaje, Exception errorOriginal) : base(mensaje, errorOriginal)
        {
        }
    }
}

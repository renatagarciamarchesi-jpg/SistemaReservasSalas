using System.Collections.Generic;
using System.Linq;
using SistemaReservasSalas.Excepciones;
using SistemaReservasSalas.Modelos;

namespace SistemaReservasSalas.Repositorios
{
    public class RepositorioSalas : RepositorioArchivo<SalaReunion>
    {
        //Constructor
        public RepositorioSalas(string rutaArchivo) : base(rutaArchivo)
        {
        }

        //Métodos
        protected override string ObtenerId(SalaReunion entidad)
        {
            return entidad.Id;
        }

        protected override string ConvertirALinea(SalaReunion s)
        {
            string equipo = s.Equipamiento != null ? string.Join(",", s.Equipamiento) : "";
            return s.Id + "|" + s.Nombre + "|" + s.Ubicacion + "|" + s.Capacidad + "|" + equipo;
        }

        protected override SalaReunion MapearLinea(string linea)
        {
            var campos = linea.Split('|');
            if (campos.Length < 5)
            {
                throw new ArchivoDatosCorruptoException("La linea de sala no tiene los 5 campos requeridos: Id|Nombre|Ubicacion|Capacidad|Equipamiento");
            }

            if (!int.TryParse(campos[3], out int capacidad))
            {
                throw new ArchivoDatosCorruptoException("Capacidad invalida en la sala: '" + campos[3] + "'");
            }

            var equipamiento = string.IsNullOrWhiteSpace(campos[4])
                ? new List<string>()
                : campos[4].Split(',').Select(e => e.Trim()).ToList();

            return new SalaReunion(campos[0], campos[1], campos[2], capacidad, equipamiento);
        }

        public bool ExisteSala(string salaId)
        {
            return Obtener(salaId) != null;
        }
    }
}

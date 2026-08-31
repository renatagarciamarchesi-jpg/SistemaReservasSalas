using SistemaReservasSalas.Excepciones;
using SistemaReservasSalas.Modelos;

namespace SistemaReservasSalas.Repositorios
{
    public class RepositorioUsuarios : RepositorioArchivo<Usuario>
    {
        //Constructor
        public RepositorioUsuarios(string rutaArchivo) : base(rutaArchivo)
        {
        }

        //Métodos
        protected override string ObtenerId(Usuario entidad)
        {
            return entidad.Id;
        }

        protected override string ConvertirALinea(Usuario u)
        {
            return u.Id + "|" + u.RolDescripcion + "|" + u.Nombre + "|" + u.Email;
        }

        protected override Usuario MapearLinea(string linea)
        {
            var campos = linea.Split('|');
            if (campos.Length < 4)
            {
                throw new ArchivoDatosCorruptoException("La linea de usuario no tiene los 4 campos requeridos: Id|TipoRol|Nombre|Email");
            }

            string id = campos[0];
            string tipoRol = campos[1];
            string nombre = campos[2];
            string email = campos[3];

            switch (tipoRol)
            {
                case "Administrador":

                    return new Administrador(id, nombre, email);

                case "Gerente":

                    return new Gerente(id, nombre, email);

                case "Empleado":

                    return new Empleado(id, nombre, email);

                default:

                    throw new ArchivoDatosCorruptoException("Tipo de rol desconocido en el archivo: '" + tipoRol + "'");
            }
        }
    }
}

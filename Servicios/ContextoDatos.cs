using System;
using System.IO;
using SistemaReservasSalas.Repositorios;

namespace SistemaReservasSalas.Servicios
{
    public static class ContextoDatos
    {
        //Propiedades
        public static RepositorioSalas RepoSalas { get; }
        public static RepositorioUsuarios RepoUsuarios { get; }
        public static RepositorioReservas RepoReservas { get; }
        public static ServicioReservas Servicio { get; }

        //Constructor estático
        static ContextoDatos()
        {
            string carpetaDatos = Path.Combine(AppContext.BaseDirectory, "Datos");

            RepoSalas = new RepositorioSalas(Path.Combine(carpetaDatos, "salas.txt"));
            RepoUsuarios = new RepositorioUsuarios(Path.Combine(carpetaDatos, "usuarios.txt"));
            RepoReservas = new RepositorioReservas(Path.Combine(carpetaDatos, "reservas.txt"));

            Servicio = new ServicioReservas(RepoSalas, RepoUsuarios, RepoReservas);
        }
    }
}

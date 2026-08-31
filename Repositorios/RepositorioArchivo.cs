using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SistemaReservasSalas.Excepciones;

namespace SistemaReservasSalas.Repositorios
{
    // Repositorio generico que guarda cualquier entidad en un archivo de texto.
    // Cada clase hija dice como convertir una linea de texto en un objeto y viceversa. Relación: IRepositorio e IDisposable
    public abstract class RepositorioArchivo<T> : IRepositorio<T>, IDisposable
    {
        protected string RutaArchivo;

        //Constructor
        protected RepositorioArchivo(string rutaArchivo)
        {
            RutaArchivo = rutaArchivo;

            // Nos aseguramos de que la carpeta y el archivo existan la primera vez que se usa
            string directorio = Path.GetDirectoryName(RutaArchivo);

            if (!string.IsNullOrEmpty(directorio) && !Directory.Exists(directorio))
            {
                Directory.CreateDirectory(directorio);
            }

            if (!File.Exists(RutaArchivo))
            {
                File.Create(RutaArchivo).Close();
            }
        }

        // Métodos
        protected abstract T MapearLinea(string linea);
        protected abstract string ConvertirALinea(T entidad);
        protected abstract string ObtenerId(T entidad);

        public virtual List<T> Listar()
        {
            var lista = new List<T>();
            int numeroLinea = 0;

            try
            {
                using (StreamReader lector = new StreamReader(RutaArchivo))
                {
                    string linea;

                    while ((linea = lector.ReadLine()) != null)
                    {
                        numeroLinea++;

                        if (string.IsNullOrWhiteSpace(linea))
                        {
                            continue;
                        }

                        var entidad = MapearLinea(linea);
                        lista.Add(entidad);
                    }
                }
            }
            catch (ArchivoDatosCorruptoException)
            {
                // ya viene con un mensaje claro desde MapearLinea, la dejamos pasar tal cual
                throw;
            }
            catch (Exception ex)
            {
                throw new ArchivoDatosCorruptoException($"Error al leer la linea {numeroLinea} del archivo {RutaArchivo}.");
            }

            return lista;
        }

        protected virtual void GuardarTodos(List<T> lista)
        {
            try
            {
                using (StreamWriter escritor = new StreamWriter(RutaArchivo, false))
                {
                    foreach (var item in lista)
                    {
                        escritor.WriteLine(ConvertirALinea(item));
                    }
                }
            }
            catch (IOException ex)
            {
                throw new ArchivoDatosCorruptoException("No se pudo escribir en el archivo '" + RutaArchivo + "'.", ex);
            }
        }

        public virtual void Agregar(T item)
        {
            var lista = Listar();
            var id = ObtenerId(item);

            if (lista.Any(x => ObtenerId(x) == id))
            {
                throw new ArgumentException("Ya existe un registro con el identificador '" + id + "'.");
            }

            lista.Add(item);
            GuardarTodos(lista);
        }

        public virtual T Obtener(string id)
        {
            return Listar().FirstOrDefault(x => ObtenerId(x) == id);
        }

        public virtual void Actualizar(T item)
        {
            var lista = Listar();
            var id = ObtenerId(item);
            int indice = lista.FindIndex(x => ObtenerId(x) == id);

            if (indice == -1)
            {
                throw new ArgumentException("No existe un registro con el identificador '" + id + "' para actualizar.");
            }

            lista[indice] = item;
            GuardarTodos(lista);
        }

        public virtual void Eliminar(string id)
        {
            var lista = Listar();
            int eliminados = lista.RemoveAll(x => ObtenerId(x) == id);

            if (eliminados == 0)
            {
                throw new ArgumentException("No existe un registro con el identificador '" + id + "' para eliminar.");
            }

            GuardarTodos(lista);
        }

        // Usamos métodos de IDisposable para asegurarnos de que liberamos correctamente los recursos
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        ~RepositorioArchivo()
        {
            Dispose();
        }
    }
}

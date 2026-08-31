using System.Collections.Generic;

namespace SistemaReservasSalas.Repositorios
{
    //Los repositorios heredarán de esta interfaz genérica para implementar los métodos CRUD.
    public interface IRepositorio<T>
    {
        //Métodos
        void Agregar(T item);
        T Obtener(string id);
        List<T> Listar();
        void Actualizar(T item);
        void Eliminar(string id);
    }
}

using System;
using System.Collections.Generic;

namespace SistemaReservasSalas.Modelos
{
    public class SalaReunion
    {
        //Propiedades
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }

        private int capacidad;
        public int Capacidad
        {
            get { return capacidad; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("La capacidad de la sala debe ser mayor a cero.");

                capacidad = value;
            }
        }

        public List<string> Equipamiento { get; set; }

        //Propiedad calculadora
        public string EquipamientoResumen
        {
            get
            {
                if (Equipamiento == null || Equipamiento.Count == 0)
                {
                    return "Sin equipamiento registrado";
                }

                return string.Join(", ", Equipamiento);
            }
        }

        //Constructor
        public SalaReunion()
        {
            Equipamiento = new List<string>();
        }

        //Constructor sobrecargado
        public SalaReunion(string id, string nombre, string ubicacion, int capacidad, List<string> equipamiento)
        {
            Id = id;
            Nombre = nombre;
            Ubicacion = ubicacion;
            Capacidad = capacidad;
            Equipamiento = equipamiento != null ? equipamiento : new List<string>();
        }
    }
}

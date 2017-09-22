using System;
using System.Collections.Generic;
using MedidoresDeAgua.Resultados;

namespace MedidoresDeAgua.Dominio
{
    public class Zona
    {
        public string Nombre { get; protected set; }
        public List<Propiedad> Propiedades { get; protected set; }

        public Zona(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
                throw new NotSupportedException("El nombre es requerido");

            Nombre = nombre;
            Propiedades = new List<Propiedad>();
        }

        public Zona(string nombre, Propiedad propiedad)
        {
            if (string.IsNullOrEmpty(nombre))
                throw new NotSupportedException("El nombre es requerido");

            if (propiedad == null)
                throw new NotSupportedException("La propiedad es requerida");

            Nombre = nombre;
            Propiedades = new List<Propiedad>() {propiedad};
        }

        public void AgregarPropiedad(Propiedad propiedad)
        {
            if (propiedad == null)
                throw new NotSupportedException("La propiedad es requerida");
            
            Propiedades.Add(propiedad);
        }

        public ConsumosPorCategoriaYZonaResultado ObtenerConsumosPeriodoPorCategoria(DateTime fechaInicio,
            DateTime fechaFin, List<string> categorias)
        {
            var consumosPorCategoria = new List<ConsumosPorCategoriaResultado>();

            foreach (var propiedad in Propiedades)
            {
                consumosPorCategoria.AddRange(propiedad.ObtenerConsumosPeriodoPorCategoria(fechaInicio, fechaFin, categorias));
            }

            return new ConsumosPorCategoriaYZonaResultado()
            {
                Zona = Nombre,
                ConsumosPorCategoria = consumosPorCategoria
            };
        }
    }
}

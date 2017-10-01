using System;
using System.Collections.Generic;
using System.Linq;
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
            var consumosSinPromediar = new List<ConsumosPorCategoriaResultado>();

            foreach (var propiedad in Propiedades)
            {
                consumosSinPromediar.AddRange(propiedad.ObtenerConsumosPeriodoPorCategoria(fechaInicio, fechaFin, categorias));
            }

            var consumosPromediados = new List<PromedioPorCategoriaResultado>();

            foreach (var categoria in categorias)
            {
                var consumosLista = consumosSinPromediar.Where(c => c.Categoria.Equals(categoria)).Select(c => c.Consumos).ToList();

                if (consumosLista.Count == 0)
                    continue;

                var consumos = new List<double>();

                foreach (var consumo in consumosLista)
                {
                    consumos.AddRange(consumo);
                }

                consumosPromediados.Add(new PromedioPorCategoriaResultado
                {
                    Categoria = categoria,
                    Promedio = consumos.Average()
                });
            }

            return new ConsumosPorCategoriaYZonaResultado()
            {
                Zona = Nombre,
                PromediosPorCategoria = consumosPromediados
            };
        }
    }
}

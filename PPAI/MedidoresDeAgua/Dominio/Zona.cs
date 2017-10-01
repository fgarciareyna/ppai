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

            foreach (var categoria in categorias)
            {
                consumosSinPromediar.Add(new ConsumosPorCategoriaResultado
                {
                    Categoria = categoria,
                    Consumos = new List<double>()
                });
            }

            foreach (var propiedad in Propiedades)
            {
                var consumos = propiedad.ObtenerConsumosPeriodoPorCategoria(fechaInicio, fechaFin, categorias);

                foreach (var consumo in consumos)
                {
                    consumosSinPromediar.Single(c => c.Categoria == consumo.Categoria)
                        .Consumos
                        .AddRange(consumo.Consumos);
                }
            }

            var consumosPromediados = consumosSinPromediar
                .Select(c => new PromedioPorCategoriaResultado
                {
                    Categoria = c.Categoria,
                    Promedio = c.Consumos.Count > 0 ? c.Consumos.Average() : 0
                }).ToList();

            return new ConsumosPorCategoriaYZonaResultado()
            {
                Zona = Nombre,
                PromediosPorCategoria = consumosPromediados
            };
        }
    }
}

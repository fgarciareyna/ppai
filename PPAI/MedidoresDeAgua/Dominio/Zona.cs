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

        public ConsumosPorCategoriaYZonaResultado ObtenerConsumosPorCategoria(DateTime fechaInicio,
            DateTime fechaFin, List<Categoria> categorias)
        {
            var consumosPorCategoria = new List<ConsumosPorCategoriaResultado>();

            foreach (var categoria in categorias)
            {
                consumosPorCategoria.Add(new ConsumosPorCategoriaResultado
                {
                    Categoria = categoria.Nombre,
                    Consumos = new List<double>()
                });
            }

            foreach (var propiedad in Propiedades)
            {
                var consumos = propiedad.ObtenerConsumosPorCategoria(fechaInicio, fechaFin, categorias);

                foreach (var consumo in consumos)
                {
                    consumosPorCategoria.Single(c => c.Categoria == consumo.Categoria)
                        .Consumos
                        .AddRange(consumo.Consumos);
                }
            }

            return new ConsumosPorCategoriaYZonaResultado()
            {
                Zona = Nombre,
                ConsumosPorCategoria = consumosPorCategoria
            };
        }

        public ConsumosPorCategoriaYZonaResultado ObtenerConsumosNormalizadosPorCategoria(DateTime fechaInicio,
            DateTime fechaFin, List<Categoria> categorias)
        {
            var consumosPorCategoria = new List<ConsumosPorCategoriaResultado>();

            foreach (var categoria in categorias)
            {
                consumosPorCategoria.Add(new ConsumosPorCategoriaResultado
                {
                    Categoria = categoria.Nombre,
                    Consumos = new List<double>()
                });
            }

            foreach (var propiedad in Propiedades)
            {
                var consumos = propiedad.ObtenerConsumosNormalizadosPorCategoria(fechaInicio, fechaFin, categorias);

                foreach (var consumo in consumos)
                {
                    consumosPorCategoria.Single(c => c.Categoria == consumo.Categoria)
                        .Consumos
                        .AddRange(consumo.Consumos);
                }
            }

            return new ConsumosPorCategoriaYZonaResultado()
            {
                Zona = Nombre,
                ConsumosPorCategoria = consumosPorCategoria
            };
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}

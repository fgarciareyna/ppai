using System;
using System.Collections.Generic;
using MedidoresDeAgua.Resultados;

namespace MedidoresDeAgua.Dominio
{
    public class Propiedad
    {
        public List<Servicio> Servicios { get; protected set; }

        public Propiedad()
        {
            Servicios = new List<Servicio>();
        }

        public Propiedad(Servicio servicio)
        {
            if (servicio == null)
                throw new NotSupportedException("El servicio es requerido");

            Servicios = new List<Servicio>() {servicio};
        }

        public void ContratarServicio(Servicio servicio)
        {
            if (servicio == null)
                throw new NotSupportedException("El servicio es requerido");

            Servicios.Add(servicio);
        }

        public List<ConsumosPorCategoriaResultado> ObtenerConsumosNormalizadosPorCategoria(DateTime fechaInicio, DateTime fechaFin,
            List<string> categorias)
        {
            var consumos = new List<ConsumosPorCategoriaResultado>();

            foreach (var categoria in categorias)
            {
                var consumo = new ConsumosPorCategoriaResultado
                {
                    Categoria = categoria,
                    Consumos = new List<double>()
                };

                foreach (var servicio in Servicios)
                {
                    if (servicio.EsDeCategoria(categoria) && servicio.EsServicioDePeriodo(fechaInicio, fechaFin))
                    {
                        var consumosPeriodo = servicio.ObtenerConsumosNormalizados(fechaInicio, fechaFin);

                        consumo.Consumos.AddRange(consumosPeriodo);
                    }
                }

                consumos.Add(consumo);
            }

            return consumos;
        }
    }
}

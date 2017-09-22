using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<ConsumosPorCategoriaResultado> ObtenerConsumosPeriodoPorCategoria(DateTime fechaInicio, DateTime fechaFin,
            List<string> categorias)
        {
            return (from categoria in categorias
                from servicio in Servicios
                where servicio.EsDeCategoria(categoria) && servicio.EsServicioDePeriodo(fechaInicio, fechaFin)
                let consumos = servicio.ObtenerConsumosPeriodo(fechaInicio, fechaFin)
                select new ConsumosPorCategoriaResultado()
                {
                    Categoria = categoria,
                    Consumos = consumos
                })
                .ToList();
        }
    }
}

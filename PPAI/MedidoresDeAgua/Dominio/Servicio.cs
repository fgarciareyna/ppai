using System;
using System.Collections.Generic;
using System.Linq;

namespace MedidoresDeAgua.Dominio
{
    public class Servicio
    {
        public Categoria Categoria { get; protected set; }
        public List<Factura> Facturas { get; protected set; }

        protected Servicio() { }

        public Servicio(Categoria categoria)
        {
            if (categoria == null)
                throw new NotSupportedException("La categoría es requerida");

            Categoria = categoria;
            Facturas = new List<Factura>();
        }

        public void Facturar(Factura factura)
        {
            if (factura == null)
                throw new NotSupportedException("La factura es requerida");

            Facturas.Add(factura);
        }

        public bool EsDeCategoria(Categoria categoria)
        {
            return Categoria.EsCategoria(categoria);
        }

        public bool EsServicioDePeriodo(DateTime fechaInicio, DateTime fechaFin)
        {
            return Facturas.Any(f => f.EsDePeriodo(fechaInicio, fechaFin));
        }

        public List<double> ObtenerConsumos(DateTime fechaInicio, DateTime fechaFin)
        {
            var consumos = (
                from factura in Facturas
                where factura.EsDePeriodo(fechaInicio, fechaFin)
                select factura.ObtenerConsumo())
                .ToList();

            return consumos;
        }

        public List<double> ObtenerConsumosNormalizados(DateTime fechaInicio, DateTime fechaFin)
        {
            var consumos = (
                from factura in Facturas
                where factura.EsDePeriodo(fechaInicio, fechaFin)
                select factura.ObtenerConsumoNormalizado())
                .ToList();

            return consumos;
        }
    }
}

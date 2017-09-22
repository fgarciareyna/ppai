using System;
using System.Collections.Generic;
using System.Linq;
using MedidoresDeAgua.Dominio;
using MedidoresDeAgua.Resultados;

namespace MedidoresDeAgua.EstrategiasEstadisticas
{
    public class SingletonEstrategiaPromedioNormalizado : IEstrategiaEstadistica
    {
        private static SingletonEstrategiaPromedioNormalizado _estrategia;

        private SingletonEstrategiaPromedioNormalizado() { }

        public static SingletonEstrategiaPromedioNormalizado GetInstancia()
        {
            return _estrategia ?? (_estrategia = new SingletonEstrategiaPromedioNormalizado());
        }

        public List<ConsumosPorCategoriaYZonaResultado> CalcularEstadisticas(DateTime fechaInicio, DateTime fechaFin,
            List<string> categorias, List<Zona> zonas)
        {
            return zonas.Select(
                zona => zona.ObtenerConsumosPeriodoPorCategoria(fechaInicio, fechaFin, categorias))
                .ToList();
        }
    }
}

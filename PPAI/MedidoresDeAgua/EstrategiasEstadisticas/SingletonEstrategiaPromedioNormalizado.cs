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
            var consumosPorZona = zonas.Select(
                zona => zona.ObtenerConsumosNormalizadosPorCategoria(fechaInicio, fechaFin, categorias))
                .ToList();

            foreach (var zona in consumosPorZona)
            {
                zona.ValoresPorCategoria = new List<ValoresPorCategoriaResultado>();

                foreach (var categoria in zona.ConsumosPorCategoria)
                {
                    zona.ValoresPorCategoria.Add(new ValoresPorCategoriaResultado
                    {
                        Categoria = categoria.Categoria,
                        Valores = new List<double>()
                        {
                            categoria.Consumos.Count > 0
                            ? categoria.Consumos.Average()
                            : 0
                        }
                    });
                }
            }

            return consumosPorZona;
        }
    }
}

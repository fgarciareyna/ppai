using System;
using System.Collections.Generic;
using System.Linq;
using MedidoresDeAgua.Dominio;
using MedidoresDeAgua.Resultados;

namespace MedidoresDeAgua.EstrategiasEstadisticas
{
    public class SingletonEstrategiaMediaDesvEst : IEstrategiaEstadistica
    {
        private static SingletonEstrategiaMediaDesvEst _estrategia;

        private SingletonEstrategiaMediaDesvEst() { }

        public static SingletonEstrategiaMediaDesvEst GetInstancia()
        {
            return _estrategia ?? (_estrategia = new SingletonEstrategiaMediaDesvEst());
        }

        public List<ConsumosPorCategoriaYZonaResultado> CalcularEstadisticas(DateTime fechaInicio, DateTime fechaFin,
            List<Categoria> categorias, List<Zona> zonas)
        {
            var consumosPorZona = zonas.Select(
                zona => zona.ObtenerConsumosPorCategoria(fechaInicio, fechaFin, categorias))
                .ToList();

            foreach (var zona in consumosPorZona)
            {
                foreach (var categoria in zona.ConsumosPorCategoria)
                {
                    categoria.Valores = new List<double>()
                    {
                        categoria.Consumos.Count > 0
                        ? categoria.Consumos.Average()
                        : 0
                    };

                    double diferenciaCuadrada = 0;

                    foreach (var consumo in categoria.Consumos)
                    {
                        diferenciaCuadrada += Math.Pow(consumo - categoria.Valores[0], 2);
                    }

                    var desvEst = Math.Sqrt(diferenciaCuadrada / categoria.Consumos.Count);

                    categoria.Valores.Add(desvEst);
                }
            }

            return consumosPorZona;
        }
    }
}

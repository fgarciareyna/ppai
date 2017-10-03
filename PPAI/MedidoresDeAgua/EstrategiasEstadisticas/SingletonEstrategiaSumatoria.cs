using System;
using System.Collections.Generic;
using System.Linq;
using MedidoresDeAgua.Dominio;
using MedidoresDeAgua.Resultados;

namespace MedidoresDeAgua.EstrategiasEstadisticas
{
    public class SingletonEstrategiaSumatoria : IEstrategiaEstadistica
    {
        private static SingletonEstrategiaSumatoria _estrategia;

        private SingletonEstrategiaSumatoria() { }

        public static SingletonEstrategiaSumatoria GetInstancia()
        {
            return _estrategia ?? (_estrategia = new SingletonEstrategiaSumatoria());
        }

        public EstadisticaResultado CalcularEstadisticas(DateTime fechaInicio, DateTime fechaFin,
            List<Categoria> categorias, List<Zona> zonas)
        {
            var estadistica = new EstadisticaResultado()
            {
                Parametros = new List<string>
                {
                    "Sumatoria"
                }
            };

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
                        ? categoria.Consumos.Sum()
                        : 0
                    };
                }
            }

            estadistica.ConsumosPorCategoriaYZona = consumosPorZona;

            return estadistica;
        }
    }
}

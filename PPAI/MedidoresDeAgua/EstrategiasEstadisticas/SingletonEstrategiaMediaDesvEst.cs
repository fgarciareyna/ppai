using System;
using System.Collections.Generic;
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
            List<string> categorias, List<Zona> zonas)
        {
            throw new NotImplementedException();
        }
    }
}

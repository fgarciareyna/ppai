using System;
using System.Collections.Generic;
using MedidoresDeAgua.Dominio;

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

        public IList<IList<string>> CalcularEstadisticas(DateTime fechaInicio, DateTime fechaFin, List<string> categorias, List<Zona> zonas)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using MedidoresDeAgua.Dominio;

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

        public IList<IList<string>> CalcularEstadisticas(DateTime fechaInicio, DateTime fechaFin, List<string> categorias, List<Zona> zonas)
        {
            throw new NotImplementedException();
        }
    }
}

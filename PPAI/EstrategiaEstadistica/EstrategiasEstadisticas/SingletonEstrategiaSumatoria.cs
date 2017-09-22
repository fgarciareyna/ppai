using System;
using System.Collections.Generic;
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

        public List<ConsumosPorCategoriaYZonaResultado> CalcularEstadisticas(DateTime fechaInicio, DateTime fechaFin,
            List<string> categorias, List<Zona> zonas)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using EstrategiaEstadistica.Dominio;

namespace EstrategiaEstadistica.EstrategiasEstadisticas
{
    public interface IEstrategiaEstadistica
    {
        IList<string[]> CalcularEstadisticas(DateTime fechaInicio, DateTime fechaFin, List<string> categorias, List<Zona> zonas);
    }
}

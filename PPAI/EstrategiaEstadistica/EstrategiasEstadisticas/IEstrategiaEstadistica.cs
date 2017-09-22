using System;
using System.Collections.Generic;
using MedidoresDeAgua.Dominio;

namespace MedidoresDeAgua.EstrategiasEstadisticas
{
    public interface IEstrategiaEstadistica
    {
        IList<IList<string>> CalcularEstadisticas(DateTime fechaInicio, DateTime fechaFin, List<string> categorias, List<Zona> zonas);
    }
}

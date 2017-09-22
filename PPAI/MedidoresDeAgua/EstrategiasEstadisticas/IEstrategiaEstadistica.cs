using System;
using System.Collections.Generic;
using MedidoresDeAgua.Dominio;
using MedidoresDeAgua.Resultados;

namespace MedidoresDeAgua.EstrategiasEstadisticas
{
    public interface IEstrategiaEstadistica
    {
        List<ConsumosPorCategoriaYZonaResultado> CalcularEstadisticas(DateTime fechaInicio, DateTime fechaFin, List<string> categorias, List<Zona> zonas);
    }
}

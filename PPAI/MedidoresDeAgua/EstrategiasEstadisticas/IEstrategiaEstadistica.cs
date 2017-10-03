using System;
using System.Collections.Generic;
using MedidoresDeAgua.Dominio;
using MedidoresDeAgua.Resultados;

namespace MedidoresDeAgua.EstrategiasEstadisticas
{
    public interface IEstrategiaEstadistica
    {
        EstadisticaResultado CalcularEstadisticas(DateTime fechaInicio, DateTime fechaFin, List<Categoria> categorias, List<Zona> zonas);
    }
}

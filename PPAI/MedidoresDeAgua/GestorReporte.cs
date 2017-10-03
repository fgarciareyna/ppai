using System;
using System.Collections.Generic;
using MedidoresDeAgua.Dominio;
using MedidoresDeAgua.EstrategiasEstadisticas;
using MedidoresDeAgua.Resultados;

namespace MedidoresDeAgua
{
    public class GestorReporte
    {
        public IEstrategiaEstadistica EstrategiaEstadistica { get; set; }
        public List<Zona> Zonas { get; set; }
        public List<Categoria> Categorias { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public GestorReporte(DateTime fechaInicio, DateTime fechaFin, List<Categoria> categorias,
            List<Zona> zonas)
        {
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            Categorias = categorias;
            Zonas = zonas;
        }

        public void TomarMetodoEstadistico(EnumEstrategiasEstadisticas metodoEstadistico)
        {
            switch (metodoEstadistico)
            {
                case EnumEstrategiasEstadisticas.Sumatoria:
                    EstrategiaEstadistica = SingletonEstrategiaSumatoria.GetInstancia();
                    break;
                case EnumEstrategiasEstadisticas.PromedioNormalizado:
                    EstrategiaEstadistica = SingletonEstrategiaPromedioNormalizado.GetInstancia();
                    break;
                case EnumEstrategiasEstadisticas.MediaDesvEst:
                    EstrategiaEstadistica = SingletonEstrategiaMediaDesvEst.GetInstancia();
                    break;
                default:
                    throw new NotSupportedException("Método estadístico no soportado");
            }
        }

        public EstadisticaResultado TomarConfirmacion()
        {
            return CalcularEstadisticas();
        }

        private EstadisticaResultado CalcularEstadisticas()
        {
            return EstrategiaEstadistica.CalcularEstadisticas(FechaInicio, FechaFin, Categorias, Zonas);
        }
    }
}

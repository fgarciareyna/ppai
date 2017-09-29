﻿using System;
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
        public List<string> Categorias { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public GestorReporte(DateTime fechaInicio, DateTime fechaFin, List<string> categorias,
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

        public List<ConsumosPorCategoriaYZonaResultado> TomarConfirmacion()
        {
            return CalcularEstadisticas();
        }

        private List<ConsumosPorCategoriaYZonaResultado> CalcularEstadisticas()
        {
            return EstrategiaEstadistica.CalcularEstadisticas(FechaInicio, FechaFin, Categorias, Zonas);
        }
    }
}

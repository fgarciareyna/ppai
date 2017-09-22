using System;

namespace MedidoresDeAgua.Dominio
{
    public class PeriodoFacturacion
    {
        public DateTime FechaInicio { get; protected set; }
        public DateTime FechaFin { get; protected set; }

        protected PeriodoFacturacion() { }

        public PeriodoFacturacion(DateTime fechaInicio, DateTime fechaFin)
        {
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
        }

        public bool EsDePeriodo(DateTime fechaInicio, DateTime fechaFin)
        {
            return FechaInicio >= fechaInicio && FechaFin <= fechaFin;
        }
    }
}

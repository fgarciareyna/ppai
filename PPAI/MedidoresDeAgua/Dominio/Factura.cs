using System;

namespace MedidoresDeAgua.Dominio
{
    public class Factura
    {
        public int DiasDeLecturaFacturados { get; protected set; }
        public double M3Consumidos { get; protected set; }
        public PeriodoFacturacion Periodo { get; protected set; }

        protected Factura() { }

        public Factura(int diasDeLecturaFacturados, double m3Consumidos, PeriodoFacturacion periodo)
        {
            if (diasDeLecturaFacturados <= 0)
                throw new NotSupportedException("Los días facturados deben ser un entero positivo");

            if (m3Consumidos < 0)
                throw new NotSupportedException("Los metros cúbicos consumidos no pueden ser negativos");

            if (periodo == null)
                throw new NotSupportedException("El período de facturación es requerido");

            DiasDeLecturaFacturados = diasDeLecturaFacturados;
            M3Consumidos = m3Consumidos;
            Periodo = periodo;
        }

        public bool EsDePeriodo(DateTime fechaInicio, DateTime fechaFin)
        {
            return Periodo.EsDePeriodo(fechaInicio, fechaFin);
        }

        public double ObtenerConsumo()
        {
            return M3Consumidos;
        }

        public double ObtenerConsumoNormalizado()
        {
            var consumoNormalizado = M3Consumidos / DiasDeLecturaFacturados * 30;

            return consumoNormalizado;
        }
    }
}

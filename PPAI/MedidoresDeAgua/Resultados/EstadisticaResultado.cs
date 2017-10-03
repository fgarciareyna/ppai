using System.Collections.Generic;

namespace MedidoresDeAgua.Resultados
{
    public class EstadisticaResultado
    {
        public List<ConsumosPorCategoriaYZonaResultado> ConsumosPorCategoriaYZona { get; set; }
        public List<string> Parametros { get; set; }
    }
}

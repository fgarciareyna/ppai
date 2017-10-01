using System.Collections.Generic;

namespace MedidoresDeAgua.Resultados
{
    public class ConsumosPorCategoriaYZonaResultado
    {
        public string Zona { get; set; }
        public List<PromedioPorCategoriaResultado> PromediosPorCategoria { get; set; }
    }
}

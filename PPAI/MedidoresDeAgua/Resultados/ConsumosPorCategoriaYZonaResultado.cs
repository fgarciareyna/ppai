using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedidoresDeAgua.Resultados
{
    public class ConsumosPorCategoriaYZonaResultado
    {
        public string Zona { get; set; }
        public List<ConsumosPorCategoriaResultado> ConsumosPorCategoria { get; set; }
    }
}

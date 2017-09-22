using System.Collections.Generic;

namespace MedidoresDeAgua.Resultados
{
    public class ConsumosPorCategoriaResultado
    {
        public string Categoria { get; set; }
        public List<double> Consumos { get; set; }
    }
}

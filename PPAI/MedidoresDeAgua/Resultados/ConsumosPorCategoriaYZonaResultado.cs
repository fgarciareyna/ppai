using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedidoresDeAgua.Resultados
{
    public class ConsumosPorCategoriaYZonaResultado
    {
        public string Zona { get; set; }
        public List<ConsumosPorCategoriaResultado> ConsumosPorCategoria { get; set; }

        public string[] Lineas()
        {
            var lineas = new string[ConsumosPorCategoria.Count + 1];

            lineas[0] = $"Zona: {Zona}";

            for (var i = 0; i < ConsumosPorCategoria.Count; i++)
            {
                lineas[i + 1] = $"{ConsumosPorCategoria[i].Categoria}: {ConsumosPorCategoria[i].Consumos.Average()}";
            }

            return lineas;
        }
    }
}

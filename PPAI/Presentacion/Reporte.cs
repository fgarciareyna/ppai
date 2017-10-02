using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MedidoresDeAgua.Resultados;

namespace Presentacion
{
    public partial class Reporte : Form
    {
        public Reporte(IEnumerable<ConsumosPorCategoriaYZonaResultado> estadisticas)
        {
            InitializeComponent();

            grafico.Series.Clear();

            foreach (var estadistica in estadisticas)
            {
                var serie = estadistica.Zona;
                grafico.Series.Add(serie);

                foreach (var valores in estadistica.ValoresPorCategoria)
                {
                    var categoria = int.Parse(valores.Categoria.Split(' ')[1]);
                    var valor = valores.Valores[0];
                    grafico.Series[serie].Points.Add(new DataPoint(categoria, valor));
                }
            }

            grafico.Visible = true;
        }
    }
}

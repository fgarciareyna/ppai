using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MedidoresDeAgua.Resultados;

namespace Presentacion
{
    public partial class Reporte : Form
    {
        public Reporte(List<ConsumosPorCategoriaYZonaResultado> estadisticas)
        {
            InitializeComponent();

            ArmarReporte(estadisticas);

            ArmarGrafico(estadisticas);
        }

        private void ArmarReporte(IEnumerable<ConsumosPorCategoriaYZonaResultado> estadisticas)
        {
            txt_estadisticas.Clear();

            var sb = new StringBuilder();

            foreach (var estadistica in estadisticas)
            {
                sb.Append($"{estadistica.Zona}:");
                sb.Append(Environment.NewLine);
                sb.Append(Environment.NewLine);

                foreach (var consumosPorCategoria in estadistica.ConsumosPorCategoria)
                {
                    if (consumosPorCategoria.Consumos.Count == 0)
                        continue;

                    sb.Append($"{consumosPorCategoria.Categoria}: ");
                    
                    foreach (var consumo in consumosPorCategoria.Consumos)
                    {
                        sb.Append($"{consumo} - ");
                    }

                    sb.Remove(sb.Length - 3, 3);
                    sb.Append(Environment.NewLine);
                }

                sb.Append(Environment.NewLine);
            }

            txt_estadisticas.Text = sb.ToString();
            txt_estadisticas.Visible = true;
        }

        private void ArmarGrafico(IEnumerable<ConsumosPorCategoriaYZonaResultado> estadisticas)
        {
            grafico.Series.Clear();

            foreach (var estadistica in estadisticas)
            {
                var serie = estadistica.Zona;
                grafico.Series.Add(serie);

                foreach (var valores in estadistica.ConsumosPorCategoria)
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

using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MedidoresDeAgua.Resultados;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace Presentacion
{
    public partial class Reporte : Form
    {
        private const int Decimales = 2;
        private readonly EstadisticaResultado _estadisticas;
        private readonly PrintDocument _reporte = new PrintDocument();
        private Bitmap _imagen;

        public Reporte(EstadisticaResultado estadisticas)
        {
            InitializeComponent();

            _reporte.PrintPage += _reporte_PrintPage;

            _estadisticas = estadisticas;

            ArmarReporte();

            ArmarGrafico();
        }

        private void ArmarReporte()
        {
            txt_estadisticas.Clear();

            var sb = new StringBuilder();

            foreach (var estadistica in _estadisticas.ConsumosPorCategoriaYZona)
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

        private void ArmarGrafico()
        {
            grafico.Series.Clear();

            grafico.ChartAreas[0].AxisY.Title = $"{_estadisticas.Parametros[0]} (m3)";

            foreach (var estadistica in _estadisticas.ConsumosPorCategoriaYZona)
            {
                var serie = estadistica.Zona;
                grafico.Series.Add(serie);

                foreach (var valores in estadistica.ConsumosPorCategoria)
                {
                    var categoria = int.Parse(valores.Categoria.Split(' ')[1]);
                    var valor = valores.Valores[0];
                    grafico.Series[serie].Points.Add(new DataPoint(categoria, valor));

                    if (valores.Valores.Count > 1 && valores.Valores[1] > 0)
                    {
                        var desvEst = decimal.Round((decimal)valores.Valores[1], Decimales);

                        var descripcion = desvEst.ToString();
                        grafico.Series[serie].Points.Last().Label = descripcion;
                    }
                }
            }

            grafico.Visible = true;
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            ImprimirPantalla();
            _reporte.Print();
        }

        private void ImprimirPantalla()
        {
            var graficos = CreateGraphics();
            var tamaño = Size;
            _imagen = new Bitmap(tamaño.Width, tamaño.Height, graficos);
            var memoria = Graphics.FromImage(_imagen);
            memoria.CopyFromScreen(Location.X, Location.Y, 0, 0, tamaño);
        }

        private void _reporte_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(_imagen, 0, 0);
        }

        private void btn_exportar_Click(object sender, EventArgs e)
        {
            _Application excel = new Application();
            _Workbook workbook = excel.Workbooks.Add(Type.Missing);

            try
            {
                _Worksheet hojaEstadisticas = workbook.ActiveSheet;
                hojaEstadisticas.Name = "Estadísticas";
                
                var filaActual = 1;
                var columnaActual = 3;

                hojaEstadisticas.Cells[filaActual, 1] = "Zonas";
                hojaEstadisticas.Cells[filaActual, 2] = "Categorías";

                foreach (var parametro in _estadisticas.Parametros)
                {
                    hojaEstadisticas.Cells[filaActual, columnaActual] = parametro;
                    columnaActual++;
                }

                filaActual++;

                foreach (var zona in _estadisticas.ConsumosPorCategoriaYZona)
                {
                    var filaZona = filaActual;

                    hojaEstadisticas.Cells[filaActual, 1] = zona.Zona;

                    foreach (var categoria in zona.ConsumosPorCategoria)
                    {
                        if (categoria.Consumos.Count == 0)
                            continue;

                        hojaEstadisticas.Cells[filaActual, 2] = categoria.Categoria;

                        columnaActual = 3;

                        foreach (var valor in categoria.Valores)
                        {
                            hojaEstadisticas.Cells[filaActual, columnaActual] = valor;
                            columnaActual++;
                        }
                        filaActual++;
                    }
                    var rangoZona = hojaEstadisticas.Range[
                        hojaEstadisticas.Cells[filaZona, 1],
                        hojaEstadisticas.Cells[filaActual - 1, 1]];

                    rangoZona.Merge();
                    rangoZona.VerticalAlignment = XlVAlign.xlVAlignCenter;
                }

                workbook.Sheets.Add();
                _Worksheet hojaConsumos = workbook.Sheets[1];
                hojaConsumos.Name = "Consumos";

                filaActual = 1;

                hojaConsumos.Cells[filaActual, 1] = "Zonas";
                hojaConsumos.Cells[filaActual, 2] = "Categorías";
                hojaConsumos.Cells[filaActual, 3] = "Consumos";

                filaActual++;

                foreach (var zona in _estadisticas.ConsumosPorCategoriaYZona)
                {
                    var filaZona = filaActual;

                    hojaConsumos.Cells[filaActual, 1] = zona.Zona;

                    foreach (var categoria in zona.ConsumosPorCategoria)
                    {
                        if (categoria.Consumos.Count == 0)
                            continue;

                        var filaCategoria = filaActual;

                        hojaConsumos.Cells[filaActual, 2] = categoria.Categoria;

                        foreach (var consumo in categoria.Consumos)
                        {
                            hojaConsumos.Cells[filaActual, 3] = consumo;
                            filaActual++;
                        }

                        var rangoCategoria = hojaConsumos.Range[
                            hojaConsumos.Cells[filaCategoria, 2],
                            hojaConsumos.Cells[filaActual - 1, 2]];

                        rangoCategoria.Merge();
                        rangoCategoria.VerticalAlignment = XlVAlign.xlVAlignCenter;
                    }
                    var rangoZona = hojaConsumos.Range[
                        hojaConsumos.Cells[filaZona, 1],
                        hojaConsumos.Cells[filaActual - 1, 1]];

                    rangoZona.Merge();
                    rangoZona.VerticalAlignment = XlVAlign.xlVAlignCenter;
                }

                var saveDialog = new SaveFileDialog
                {
                    Filter = @"Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*",
                    FilterIndex = 1
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(saveDialog.FileName);
                    MessageBox.Show(@"El reporte se exportó correctamente");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                excel.Quit();
            }
        }
    }
}
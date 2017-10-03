using System;
using System.Collections.Generic;
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
        private readonly List<ConsumosPorCategoriaYZonaResultado> _estadisticas;
        private readonly PrintDocument _reporte = new PrintDocument();
        private Bitmap _imagen;

        public Reporte(List<ConsumosPorCategoriaYZonaResultado> estadisticas)
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

            foreach (var estadistica in _estadisticas)
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

            foreach (var estadistica in _estadisticas)
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
                _Worksheet worksheet = workbook.ActiveSheet;
                worksheet.Name = "Consumos";

                worksheet.Visible = XlSheetVisibility.xlSheetVisible;
                
                var filaActual = 1;

                foreach (var zona in _estadisticas)
                {
                    var filaZona = filaActual;

                    worksheet.Cells[filaActual, 1] = zona.Zona;

                    foreach (var categoria in zona.ConsumosPorCategoria)
                    {
                        if (categoria.Consumos.Count == 0)
                            continue;

                        var filaCategoria = filaActual;

                        worksheet.Cells[filaActual, 2] = categoria.Categoria;

                        foreach (var consumo in categoria.Consumos)
                        {
                            worksheet.Cells[filaActual, 3] = consumo;
                            filaActual++;
                        }
                        worksheet.Cells[filaActual, 2] = "Resultado";
                        worksheet.Cells[filaActual, 3] = categoria.Valores[0];

                        if (categoria.Valores.Count > 1 && categoria.Valores[1] > 0)
                        {
                            worksheet.Cells[filaActual, 4] = categoria.Valores[1];
                        }
                        filaActual++;

                        var rangoCategoria = worksheet.Range[
                            worksheet.Cells[filaCategoria, 2],
                            worksheet.Cells[filaActual - 2, 2]];

                        rangoCategoria.Merge();
                        rangoCategoria.VerticalAlignment = XlVAlign.xlVAlignCenter;
                    }
                    var rangoZona = worksheet.Range[
                        worksheet.Cells[filaZona, 1],
                        worksheet.Cells[filaActual - 1, 1]];

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
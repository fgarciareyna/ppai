using MedidoresDeAgua.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using MedidoresDeAgua;

namespace Presentacion
{
    public partial class PresentacionReporteEstadistico : Form
    {
        private const int Decimales = 3;
        private List<Zona> _zonas;

        public PresentacionReporteEstadistico()
        {
            InitializeComponent();

            dtp_desde.Value = DateTime.Today.AddMonths(-1).AddDays(-1);
            dtp_hasta.Value = DateTime.Today.AddDays(-1);

            dtp_desde.MaxDate = DateTime.Today.AddMonths(-1);
            dtp_hasta.MaxDate = DateTime.Today;

            cb_metodos_estadisticos.Items.Add("Sumatoria");
            cb_metodos_estadisticos.Items.Add("Promedio Normalizado");
            cb_metodos_estadisticos.Items.Add("Media con desviación estándar");

            for (var i = 0; i < 10; i++)
            {
                clb_categorias.Items.Add($"Categoría {i + 1}", true);
            }

            GenerarDatos();
        }

        private void GenerarDatos()
        {
            clb_zonas.Items.Clear();

            _zonas = new List<Zona>();

            var zonas = new Random().Next(5, 10);

            for (var i = 0; i < zonas; i++)
            {
                var zona = new Zona($"Zona {i + 1}");

                Thread.Sleep(20);
                var propiedades = new Random().Next(5, 10);

                for (var j = 0; j < propiedades; j++)
                {
                    var propiedad = new Propiedad();

                    Thread.Sleep(20);
                    var categoria = new Categoria($"Categoría {new Random().Next(1, 10)}");

                    var servicio = new Servicio(categoria);

                    propiedad.ContratarServicio(servicio);

                    Thread.Sleep(20);
                    var facturas = new Random().Next(5, 10);

                    for (var k = 0; k < facturas; k++)
                    {
                        var vencimiento = DateTime.Today.AddMonths(-k);

                        var periodo = new PeriodoFacturacion(vencimiento.AddMonths(-1), vencimiento);

                        Thread.Sleep(20);
                        var diasLectura = new Random().Next(1, 31);

                        Thread.Sleep(20);
                        var m3Consumidos = (double)decimal.Round((decimal)new Random().NextDouble() * 100, Decimales);

                        var factura = new Factura(diasLectura, m3Consumidos, periodo);

                        servicio.Facturar(factura);
                    }

                    zona.AgregarPropiedad(propiedad);
                }

                _zonas.Add(zona);
            }

            foreach (var zona in _zonas)
            {
                clb_zonas.Items.Add(zona.Nombre, true);
            }
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            GenerarDatos();
        }

        private void btn_generar_Click(object sender, EventArgs e)
        {
            grafico.Series.Clear();

            if (ValidarFormulario())
            {
                var fechaInicio = dtp_desde.Value;
                var fechaFin = dtp_hasta.Value;

                var categorias = (from object item
                                  in clb_categorias.CheckedItems
                                  select item.ToString()).ToList();

                var zonasSeleccionadas = (from object item
                                  in clb_zonas.CheckedItems
                                  select item.ToString()).ToList();

                var zonas = _zonas.Where(zona => zonasSeleccionadas.Contains(zona.Nombre)).ToList();

                var gestor = new GestorReporte(fechaInicio, fechaFin, categorias, zonas);

                EnumEstrategiasEstadisticas estrategia;

                switch (cb_metodos_estadisticos.SelectedIndex)
                {
                    case 0:
                        estrategia = EnumEstrategiasEstadisticas.Sumatoria;
                        break;
                    case 1:
                        estrategia = EnumEstrategiasEstadisticas.PromedioNormalizado;
                        break;
                    case 2:
                        estrategia = EnumEstrategiasEstadisticas.MediaDesvEst;
                        break;
                    default:
                        MessageBox.Show(@"Estrategia no soportada");
                        cb_metodos_estadisticos.Focus();
                        return;
                }

                gestor.TomarMetodoEstadistico(estrategia);

                var estadisticas = gestor.TomarConfirmacion();

                foreach (var estadistica in estadisticas)
                {
                    var serie = estadistica.Zona;
                    grafico.Series.Add(serie);

                    foreach (var consumos in estadistica.ConsumosPorCategoria)
                    {
                        var categoria = int.Parse(consumos.Categoria.Split(' ')[1]);
                        var consumo = consumos.Consumos.Average();
                        grafico.Series[estadistica.Zona].Points.Add(categoria, consumo);
                    }
                }

                grafico.Visible = true;
            }
        }

        private bool ValidarFormulario()
        {
            if (dtp_desde.Value > dtp_hasta.Value)
            {
                MessageBox.Show(@"La fecha desde debe ser menor a la fecha hasta");

                dtp_desde.Focus();

                return false;
            }

            if (clb_categorias.CheckedItems.Count == 0)
            {
                MessageBox.Show(@"Debe seleccionar al menos una categoría");

                clb_categorias.Focus();

                return false;
            }

            if (clb_zonas.CheckedItems.Count == 0)
            {
                MessageBox.Show(@"Debe seleccionar al menos una zona");

                clb_zonas.Focus();

                return false;
            }

            return true;
        }

        private void dtp_desde_ValueChanged(object sender, EventArgs e)
        {
            dtp_hasta.MinDate = dtp_desde.Value;
        }

        private void dtp_hasta_ValueChanged(object sender, EventArgs e)
        {
            dtp_desde.MaxDate = dtp_hasta.Value;
        }

        private void cb_metodos_estadisticos_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_generar.Enabled = true;
        }
    }
}

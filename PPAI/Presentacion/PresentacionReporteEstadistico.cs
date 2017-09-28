using MedidoresDeAgua.Dominio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class PresentacionReporteEstadistico : Form
    {
        private const int Decimales = 3;
        private List<Zona> _zonas;

        public PresentacionReporteEstadistico()
        {
            InitializeComponent();

            GenerarDatos();
        }

        private void GenerarDatos()
        {
            _zonas = new List<Zona>();

            var zonas = new Random().Next(5, 10);

            for (var i = 0; i < zonas; i++)
            {
                var zona = new Zona($"Zona {i + 1}");

                var propiedades = new Random().Next(5, 10);

                for (var j = 0; j < propiedades; j++)
                {
                    var propiedad = new Propiedad();

                    var categoria = new Categoria($"Categoria {new Random().Next(1, 10)}");

                    var servicio = new Servicio(categoria);

                    propiedad.ContratarServicio(servicio);

                    var facturas = new Random().Next(5, 10);

                    for (var k = 0; k < facturas; k++)
                    {
                        var vencimiento = DateTime.Today.AddMonths(-k);

                        var periodo = new PeriodoFacturacion(vencimiento.AddMonths(-1), vencimiento);

                        var diasLectura = new Random().Next(1, 31);

                        var m3Consumidos = (double)decimal.Round((decimal)new Random().NextDouble() * 100, Decimales);

                        var factura = new Factura(diasLectura, m3Consumidos, periodo);

                        servicio.Facturar(factura);
                    }
                }

                _zonas.Add(zona);
            }
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {

        }

        private void btn_generar_Click(object sender, EventArgs e)
        {

        }
    }
}

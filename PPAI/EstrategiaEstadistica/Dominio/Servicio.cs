using System.Collections.Generic;

namespace MedidoresDeAgua.Dominio
{
    public class Servicio
    {
        public Categoria Categoria { get; protected set; }
        public List<Factura> Facturas { get; protected set; }
    }
}

using System;

namespace MedidoresDeAgua.Dominio
{
    public class Categoria
    {
        public string Nombre { get; protected set; }

        protected Categoria() { }

        public Categoria(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
                throw new NotSupportedException("El nombre es requerido");

            Nombre = nombre;
        }

        public bool EsCategoria(Categoria categoria)
        {
            return Nombre.Equals(categoria.Nombre);
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}

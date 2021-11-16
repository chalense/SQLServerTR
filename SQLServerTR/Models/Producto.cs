using System;
using System.Collections.Generic;

namespace SQLServerTR.Models
{
    public partial class Producto
    {
        public int Idproducto { get; set; }
        public string? Nombre { get; set; }
        public string? Marca { get; set; }
        public decimal? Precio { get; set; }
        public int? Stock { get; set; }
        public int? Idcategoria { get; set; }

        public virtual Categoria? IdcategoriaNavigation { get; set; }
    }
}

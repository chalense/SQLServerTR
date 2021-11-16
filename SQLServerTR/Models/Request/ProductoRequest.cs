namespace SQLServerTR.Models.Request
{
    public class ProductoRequest
    {
        public int idproducto { get; set; }
        public string? nombre { get; set; }
        public string? marca { get; set; }
        public decimal precio { get; set; }
        public int stock { get; set; }
        public int idcategoria { get; set; }

    }
}

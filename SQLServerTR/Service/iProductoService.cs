using SQLServerTR.Models;
using SQLServerTR.Models.Request;

namespace SQLServerTR.Service
{
    public interface iProductoService
    {
        public IQueryable<Producto> GetAll();
        public void Add(ProductoRequest request);
        public void Edit(ProductoRequest request);
        public void Delete(int idproducto);

    }
}

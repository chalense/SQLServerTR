using Microsoft.EntityFrameworkCore;
using SQLServerTR.Data;
using SQLServerTR.Models;
using SQLServerTR.Models.Request;
using System.Threading.Tasks;

namespace SQLServerTR.Service
{
    
    public class ProductoService : iProductoService
    {
        private readonly DataContext _context;
        public ProductoService(DataContext context)
        {
            _context = context;
        }
        public void Add(ProductoRequest request)
        {
            Producto _producto = new Producto();
            _producto.Nombre = request.nombre;
            _producto.Marca = request.marca;
            _producto.Precio = request.precio;
            _producto.Stock = request.stock;
            _producto.Idcategoria = request.idcategoria;
            _context.Add(_producto);
            _context.SaveChanges();
        }

        public void Delete(int idproducto)
        {
            throw new NotImplementedException();
        }

        public void Edit(ProductoRequest request)
        {
            try
            {
                Producto _producto = _context.Productos.Find(request.idproducto);
                _producto.Nombre = request.nombre;
                _producto.Marca = request.marca;
                _producto.Precio = request.precio;
                _producto.Stock = request.stock;
                _producto.Idcategoria = request.idcategoria;
                _context.Update(_producto);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IQueryable<Producto> GetAll()
        {
            return _context.Productos.Include(c => c.IdcategoriaNavigation).OrderByDescending(a => a.Idproducto);
        }
    }
}

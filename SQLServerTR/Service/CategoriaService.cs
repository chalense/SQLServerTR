using SQLServerTR.Data;
using SQLServerTR.Models;

namespace SQLServerTR.Service
{
    public class CategoriaService : iCategoriaService
    {
        private readonly DataContext _context;
        public CategoriaService(DataContext context)
        {
            _context = context;
        }
        public IQueryable<Categoria> GetAll()
        {
            return _context.Categoria.OrderByDescending(c => c.Idcategoria);
        }
    }
}

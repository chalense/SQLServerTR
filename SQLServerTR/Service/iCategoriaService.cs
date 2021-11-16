using SQLServerTR.Models;

namespace SQLServerTR.Service
{
    public interface iCategoriaService
    {
        public IQueryable<Categoria> GetAll();
    }
}

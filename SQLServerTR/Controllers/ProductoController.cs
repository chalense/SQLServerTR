using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQLServerTR.Data;
using SQLServerTR.Models.Request;
using SQLServerTR.Models.Request.Response;
using SQLServerTR.Service;

namespace SQLServerTR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly iProductoService _productoService;
        private readonly DataContext _context;

        public ProductoController(iProductoService productoService, DataContext context)
        {
            _productoService = productoService;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            Respuesta _respuesta = new Respuesta();
            try
            {
                _respuesta.Data = _productoService.GetAll();
                _respuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
            }
            return Ok(_respuesta);
        }

        [HttpPost]
        public IActionResult Add(ProductoRequest request)
        {
            Respuesta _respuesta = new Respuesta();
            try
            {
                _productoService.Add(request);
                _respuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
            }
            return Ok(_respuesta);
        }

        [HttpPut]
        public IActionResult Edit(ProductoRequest request)
        {
            Respuesta _respuesta = new Respuesta();
            try
            {
                _productoService.Edit(request);
                _respuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
            }
            return Ok(_respuesta);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Respuesta _respuesta = new Respuesta();
            try
            {
                var _producto = _context.Productos.FirstOrDefault(a => a.Idproducto==id);
                if (_producto != null)
                {
                    _context.Productos.Remove(_producto);
                    _context.SaveChanges();
                    _respuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {

                _respuesta.Mensaje=ex.Message;
            }
            return Ok(_respuesta);
        }
    
    }

}

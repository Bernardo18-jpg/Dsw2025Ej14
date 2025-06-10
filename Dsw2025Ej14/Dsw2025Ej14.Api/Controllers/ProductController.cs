using Dsw2025Ej14.Api.Data;
using Microsoft.AspNetCore.Mvc;

namespace Dsw2025Ej14.Api.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly PersistenciaEnMemoria _persistencia;

        public ProductsController(PersistenciaEnMemoria persistencia)
        {
            _persistencia = persistencia;
        }

        // Primer endpoint
        [HttpGet()]
        public IActionResult GetAllActivos()
        {
            var activos = _persistencia.GetProducts().Where(p => p.IsActive).ToList();

            if (activos.Count == 0)
                return NoContent(); 

            return Ok(activos); 
        }

        //Segundo endpoint
        [HttpGet("{sku}")]
        public IActionResult GetBySku(string sku)
        {
            var producto = _persistencia.GetProducts().FirstOrDefault(p => p.Sku == sku);

            if (producto == null)
                return NotFound(); 

            return Ok(producto); 
        }
    }
}


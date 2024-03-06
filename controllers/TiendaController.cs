using BackEnd.Models;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiendaController : ControllerBase
    {
        private readonly ITiendaService _service;

        public TiendaController(ITiendaService tiendaService)
        {
            this._service = tiendaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ResultSet<TiendaModel> result = await _service.get();

            return StatusCode(result.CodigoEstatus, result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> getTienda(int id)
        {
            ResultSet<TiendaModel> result = await _service.getId(id);

            return StatusCode(result.CodigoEstatus, result);
        }

        [HttpPost]
        public async Task<ActionResult<List<TiendaModel>>> post(TiendaModel tienda)
        {
            ResultSet<TiendaModel> result = await _service.post(tienda);

            return StatusCode(result.CodigoEstatus, result);
        }

        [HttpPut]
        public async Task<ActionResult<List<TiendaModel>>> put(TiendaModel data)
        {
            ResultSet<TiendaModel> result = await _service.put(data);

            return StatusCode(result.CodigoEstatus, result);
        }

        [HttpDelete]
        public async Task<ActionResult<List<TiendaModel>>> delete(int id)
        {
            ResultSet<TiendaModel> result = await _service.delete(id);

            return StatusCode(result.CodigoEstatus, result);
        }
    }
}
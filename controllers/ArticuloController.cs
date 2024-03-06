using BackEnd.Models;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        private readonly IArticuloService _service;

        public ArticuloController(IArticuloService articuloService)
        {
            this._service = articuloService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> get() {
            ResultSet<ArticuloModel> result = await _service.getArticulos();

            return StatusCode(result.CodigoEstatus, result);
        }

        [HttpGet]
        public async Task<IActionResult> get(int tienda)
        {
            ResultSet<ArticuloModel> result = await _service.get(tienda);

            return StatusCode(result.CodigoEstatus, result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> getArticulo(int id)
        {
            ResultSet<ArticuloModel> result = await _service.getId(id);

            return StatusCode(result.CodigoEstatus, result);
        }

        [HttpPost]
        public async Task<IActionResult> post(ArticuloModel data)
        {
            ResultSet<ArticuloModel> result = await _service.post(data);

            return StatusCode(result.CodigoEstatus, result);
        }

        [HttpPut]
        public async Task<IActionResult> put(ArticuloModel data)
        {
            ResultSet<ArticuloModel> result = await _service.put(data);

            return StatusCode(result.CodigoEstatus, result);
        }

        [HttpDelete]
        public async Task<IActionResult> delete(int id)
        {
            ResultSet<ArticuloModel> result = await _service.delete(id);

            return StatusCode(result.CodigoEstatus, result);
        }
    }
}
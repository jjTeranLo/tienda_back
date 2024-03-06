using BackEnd.Models;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _service;

        public ClienteController(IClienteService clienteService)
        {
            this._service = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ResultSet<ClienteModel> result = await _service.get();

            return StatusCode(result.CodigoEstatus, result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> getCliente(int id)
        {
            ResultSet<ClienteModel> result = await _service.getId(id);

            return StatusCode(result.CodigoEstatus, result);
        }

        [HttpPost]
        public async Task<ActionResult<List<ClienteModel>>> post(ClienteModel cliente)
        {
            ResultSet<ClienteModel> result = await _service.post(cliente);

            return StatusCode(result.CodigoEstatus, result);
        }

        [HttpPut]
        public async Task<ActionResult<List<ClienteModel>>> put(ClienteModel data)
        {
            ResultSet<ClienteModel> result = await _service.put(data);

            return StatusCode(result.CodigoEstatus, result);
        }

        [HttpDelete]
        public async Task<ActionResult<List<ClienteModel>>> delete(int id)
        {
            ResultSet<ClienteModel> result = await _service.delete(id);

            return StatusCode(result.CodigoEstatus, result);
        }
    }
}
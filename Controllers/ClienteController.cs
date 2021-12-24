using Advocacia_Api.Models;
using Advocacia_Api.Services.ClienteServices;
using Microsoft.AspNetCore.Mvc;

namespace Advocacia_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Inserir([FromBody] Cliente cliente)
        {
            try
            {
                await new InserirClienteService().Handle(cliente);
                return StatusCode(201, "Cliente creado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Alterar([FromBody] Cliente Cliente)
        {
            return Ok(Cliente);
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            return Ok(new List<Cliente>());
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> BuscarCliente([FromRoute] int Id)
        {
            return Ok(new Cliente() { Id = Id });
        }
    }
}

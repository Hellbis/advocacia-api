using Advocacia_Api.Models;
using Advocacia_Api.Services.ClienteServices;
using Microsoft.AspNetCore.Mvc;

namespace Advocacia_Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClienteController : ControllerBase
{
    private IConfiguration _configuration;
    public ClienteController(IConfiguration config)
    {
        _configuration = config;
    }

    [HttpPost]
    public async Task<IActionResult> Inserir([FromBody] Cliente cliente)
    {
        try
        {
            await new InserirClienteService().Handle(_configuration, cliente);
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
        return Ok(await new ListarClienteService().Handle(_configuration));
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> BuscarCliente([FromRoute] int Id)
    {
        return Ok(new Cliente() { Id = Id });
    }
}
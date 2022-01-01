using Advocacia_Api.Models;
using Advocacia_Api.Repositories;

namespace Advocacia_Api.Services.ClienteServices;

public class ListarClienteService
{
    public async Task<List<Cliente>> Handle(IConfiguration configuration)
    {
        return await new ClienteRepository(configuration).Listar();
    }
}

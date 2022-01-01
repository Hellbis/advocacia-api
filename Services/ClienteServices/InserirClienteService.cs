using Advocacia_Api.Models;
using Advocacia_Api.Repositories;

namespace Advocacia_Api.Services.ClienteServices;

public class InserirClienteService
{
    public async Task Handle(IConfiguration configuration, Cliente cliente)
    {
        await new ClienteRepository(configuration).Inserir(cliente);
    }
}
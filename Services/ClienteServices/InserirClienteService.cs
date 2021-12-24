using Advocacia_Api.Models;
using Advocacia_Api.Repositories;

namespace Advocacia_Api.Services.ClienteServices
{
    public class InserirClienteService
    {
        public async Task Handle(Cliente cliente)
        {
            await new ClienteRepository().Inserir(cliente);
        }
    }
}

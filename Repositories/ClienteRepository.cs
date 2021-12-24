using Advocacia_Api.Context;
using Advocacia_Api.Models;
using Dapper;
using System.Data.SqlClient;

namespace Advocacia_Api.Repositories
{
    public class ClienteRepository
    {
        private SqlConnection _sqlConnection;

        public ClienteRepository()
        {
            _sqlConnection = DbContext.Connection();
            _sqlConnection.Open();
        }

        public async Task<bool> Inserir(Cliente cliente)
        {
            try
            {
                string query = $"INSERT INTO Cliente(cpf, nome, telefone, email) " +
                    $"VALUES({cliente.Cpf}, {cliente.Nome}, {cliente.Telefone}, {cliente.Email})";
                await _sqlConnection.ExecuteAsync(query, null);
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível inserir cliente");
            }
        }

        public async Task<List<Cliente>> Listar()
        {
            try
            {
                var query = " SELECT Id, Cpf, Nome, Telefone, Email FROM CLIENTE ";
                return (await _sqlConnection.QueryAsync<Cliente>(query, null)).ToList();
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível retornar os clientes");
            }
        }
    }
}

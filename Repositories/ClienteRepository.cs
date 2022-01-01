using Advocacia_Api.Context;
using Advocacia_Api.Models;
using Dapper;
using Npgsql;

namespace Advocacia_Api.Repositories;

public class ClienteRepository
{
    private readonly NpgsqlConnection _sqlConnection;


    public ClienteRepository(IConfiguration configuration)
    {
        _sqlConnection = new DbContext(configuration).GetConnection();
        _sqlConnection.Open();
    }

    public async Task<bool> Inserir(Cliente cliente)
    {
        try
        {
            string query = $"INSERT INTO Cliente(cpf, nome, telefone, email) " +
                $"VALUES('{cliente.Cpf}', '{cliente.Nome}', '{cliente.Telefone}', '{cliente.Email}')";
            await _sqlConnection.ExecuteAsync(query, null);
            _sqlConnection.Close();
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
            var result = (await _sqlConnection.QueryAsync<Cliente>(query, null)).ToList();
            _sqlConnection.Close();
            return result;
        }
        catch (Exception)
        {
            throw new Exception("Não foi possível retornar os clientes");
        }
    }
}
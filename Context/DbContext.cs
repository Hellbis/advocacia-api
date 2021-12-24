using System.Data.SqlClient;

namespace Advocacia_Api.Context
{
    public class DbContext
    {
        public static NpgsqlConnection Connection()
        {
            try
            {
                return new NpgsqlConnection("");
            }
            catch (Exception)
            {
                throw new Exception("Impossível conectar ao banco de dados.");
            }
        }
    }
}

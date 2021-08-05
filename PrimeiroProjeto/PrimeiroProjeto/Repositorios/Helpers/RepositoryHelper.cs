using Microsoft.Data.SqlClient;
using PrimeiroProjeto.Models.Repositories.Helpers;
using System.Data;

namespace PrimeiroProjeto.Repositorios.Helpers
{
    public class RepositoryHelper : IRepositoryHelper
    {
        public IDbConnection GetConnection()
        {
            return new SqlConnection("Server=(localdb)\\servername;Database=escola");
        }
    }
}
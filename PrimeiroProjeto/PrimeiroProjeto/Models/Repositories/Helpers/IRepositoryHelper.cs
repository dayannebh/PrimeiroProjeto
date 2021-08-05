using System.Data;

namespace PrimeiroProjeto.Models.Repositories.Helpers
{
    public interface IRepositoryHelper
    {
        IDbConnection GetConnection();
    }
}

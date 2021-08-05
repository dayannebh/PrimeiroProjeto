using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimeiroProjeto.Models.Repositories.Helpers
{
    public interface IHttpClientHelper
    {
        Task PostAsync(string url, object objToPost);
        Task<TOut> PostAsync<TOut>(string relativePath, object objToPost);
        Task<TOut> PostAsync<TOut>(string relativePath, object objToPost, string mediaType);
        Task<TOut> GetAsync<TOut>(string relativePath);
        Task<TOut> GetAsync<TOut>(string relativePath, IEnumerable<KeyValuePair<string, string>> qryParameters);
        Task<TOut> GetAsync<TOut, TIn>(string relativePath, TIn qryParameters) where TIn : class;
        Task<bool> PutAsync<TOut>(string relativePath, object objToPost);
        Task<bool> DeleteAsync<TOut>(string relativePath);
    }
}


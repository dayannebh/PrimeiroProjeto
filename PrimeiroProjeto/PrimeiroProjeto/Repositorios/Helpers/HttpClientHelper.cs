using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using PrimeiroProjeto.Models.Repositories.Helpers;
using PrimeiroProjeto.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PrimeiroProjeto.Repositorios.Helpers
{
    public class HttpClientHelper : IHttpClientHelper
    {
        private readonly HttpClient _httpClient;

        public HttpClientHelper(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task PostAsync(string url, object objToPost)
        {
            var response = await _httpClient.PostAsync(url, ToJsonStringContent(objToPost));
            await ReadResponseIfSucess(response);
        }

        public async Task<TOut> PostAsync<TOut>(string relativePath, object objToPost)
        {
            var response = await _httpClient.PostAsync(relativePath, ToJsonStringContent(objToPost));
            string responseContent = await ReadResponseIfSucess(response);
            var objResponse = JsonConvert.DeserializeObject<TOut>(responseContent);
            return objResponse;
        }

        public async Task<TOut> PostAsync<TOut>(string relativePath, object objToPost, string mediaType)
        {
            var body = SerializeToString(objToPost);
            var content = new StringContent(body, Encoding.UTF8, mediaType);
            var response = await _httpClient.PostAsync(relativePath, content);
            string responseContent = await ReadResponseIfSucess(response);
            var objResponse = JsonConvert.DeserializeObject<TOut>(responseContent);
            return objResponse;
        }

        public async Task<bool> PutAsync<TOut>(string relativePath, object objToPost)
        {
            var response = await _httpClient.PutAsync(relativePath, ToJsonStringContent(objToPost));
            await ReadResponseIfSucess(response);
            return response.StatusCode.Equals(HttpStatusCode.OK);
        }

        public async Task<bool> DeleteAsync<TOut>(string relativePath)
        {
            var response = await _httpClient.DeleteAsync(relativePath);
            return response.StatusCode.Equals(HttpStatusCode.OK);
        }

        public async Task<TOut> GetAsync<TOut>(string relativePath)
        {
            var response = await _httpClient.GetAsync(relativePath);
            string responseContent = await ReadResponseIfSucess(response);
            return JsonConvert.DeserializeObject<TOut>(responseContent);
        }

        public async Task<TOut> GetAsync<TOut>(string relativePath, IEnumerable<KeyValuePair<string, string>> qryParameters)
        {
            var uri = QueryHelpers.AddQueryString(relativePath, new Dictionary<string, string>(qryParameters));
            var response = await _httpClient.GetAsync(uri);
            string responseContent = await ReadResponseIfSucess(response);
            return JsonConvert.DeserializeObject<TOut>(responseContent);
        }

        public async Task<TOut> GetAsync<TOut, TIn>(string relativePath, TIn qryParameters) where TIn : class
        {
            var parameterList = ToKeyValuePairCollection(qryParameters);
            var uri = QueryHelpers.AddQueryString(relativePath, parameterList);
            var response = await _httpClient.GetAsync(uri);
            string responseContent = await ReadResponseIfSucess(response);
            return JsonConvert.DeserializeObject<TOut>(responseContent);
        }

        protected string SerializeToString(object obj)
        {
            if (obj == null)
            {
                return string.Empty;
            }
            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }

        private async Task<string> ReadResponseIfSucess(HttpResponseMessage response)
        {
            var responseContent = await response.Content.ReadAsStringAsync() ?? string.Empty;

            if (response.StatusCode == HttpStatusCode.Forbidden || response.StatusCode == HttpStatusCode.Unauthorized)
                throw new UnauthorizedAccessException();
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new NotFoundException(responseContent, response.RequestMessage.RequestUri.ToString());
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new BadRequestException(response.RequestMessage.RequestUri.ToString(), response.RequestMessage.Content.ToString(), responseContent);
            }
            else if (response.StatusCode == HttpStatusCode.BadGateway)
            {
                throw new BadGatewayException(response.RequestMessage.RequestUri.ToString(), response.RequestMessage.Content.ToString(), responseContent);
            }
            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                throw new InternalServerErrorException(ex.Message, response.RequestMessage.RequestUri.ToString());
            }

            return responseContent;
        }

        private StringContent ToJsonStringContent(object objToPost)
        {
            var body = SerializeToString(objToPost);
            var content = new StringContent(body, Encoding.UTF8, "application/json");
            return content;
        }

        private Dictionary<string, string> ToKeyValuePairCollection<T>(T objectToConvert) where T : class
            => typeof(T).GetProperties().ToDictionary(p => p.Name, p => p.GetValue(objectToConvert).ToString());
    }
}


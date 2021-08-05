using Newtonsoft.Json;
using System;

namespace PrimeiroProjeto.Shared.Exceptions
{
    public class BadGatewayDto
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }

    public class BadGatewayException : Exception
    {
        public string ErrorMessage { get; private set; }

        public BadGatewayException(string requestUri, string content, string message) : base($"Bad Gateway. Request Uri {requestUri}. Content request {content}. Message: {message}")
        {
            ErrorMessage = new string(JsonConvert.DeserializeObject<BadGatewayDto>(message.Replace("[", "").Replace("]", "")).Message);
        }
    }
}

using System;

namespace PrimeiroProjeto.Shared.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string requestUri, string content, string message) : base($"Bad Request. Request Uri {requestUri}. Content request {content}. Message: {message}") { }
    }
}

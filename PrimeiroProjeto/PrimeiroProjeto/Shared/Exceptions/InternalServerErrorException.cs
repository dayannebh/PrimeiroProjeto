using System;

namespace PrimeiroProjeto.Shared.Exceptions
{
    public class InternalServerErrorException : Exception
    {
        public InternalServerErrorException(string reasonPhrase, string requestUri) : base($"Service internal error. Reason ReasonPhrase {reasonPhrase}, request Uri {requestUri}.") { }
    }
}

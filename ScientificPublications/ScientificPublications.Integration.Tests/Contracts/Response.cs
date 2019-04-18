using System.Collections.Generic;
using System.Net;

namespace ScientificPublications.Integration.Tests.Contracts
{
    public class Response<T>
    {
        public HttpStatusCode StatusCode { get; set; }

        public string StringContent { get; set; }

        public T Content { get; set; }

        public Dictionary<string, string[]> ErrorMessages { get; set; }
    }
}

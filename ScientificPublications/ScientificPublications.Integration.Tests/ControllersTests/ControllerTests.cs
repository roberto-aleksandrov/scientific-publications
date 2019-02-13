using Microsoft.AspNetCore.Mvc.Routing;
using Newtonsoft.Json;
using ScientificPublications.Integration.Tests.Factories;
using ScientificPublications.WebUI;
using System;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ScientificPublications.Integration.Tests.ControllersTests
{
    public abstract class ControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public ControllerTests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        protected virtual async Task<TResponse> CreateResponse<TResponse>(HttpResponseMessage responseMessage)
        {
            return JsonConvert.DeserializeObject<TResponse>(await responseMessage.Content.ReadAsStringAsync());
        }

        protected virtual HttpContent CreateContent<TRequest>(TRequest request)
        {
            return new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
        }

        protected virtual string CreateUri<T>()
        {            
            var controllerRoute = GetType().Name.Replace(nameof(ControllerTests), "");
            var methodRoute = typeof(T).Name.Replace(typeof(T).BaseType.Name, "");

            var httpMethodAttribute = Assembly.
                GetAssembly(typeof(Startup))
                .GetTypes()
                .FirstOrDefault(t => t.Name == $"{controllerRoute}Controller")
                ?.GetMethods()
                ?.FirstOrDefault(m => m.Name == methodRoute)
                ?.GetCustomAttribute<HttpMethodAttribute>();


            return httpMethodAttribute?.Template != null 
                ? httpMethodAttribute.Template 
                : $"api/{controllerRoute}/{methodRoute}";
        }

        public async Task<TResponse> GetAsync<TResponse>()
           where TResponse : class
        {
            return await CreateResponse<TResponse>(await _client.GetAsync(CreateUri<TResponse>()));
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(TRequest request)
            where TRequest : class
            where TResponse : class
        {
            return await CreateResponse<TResponse>(await _client.PostAsync(CreateUri<TRequest>(), CreateContent(request)));
        }

        public async Task<TResponse> PutAsync<TRequest, TResponse>(TRequest request)
            where TRequest : class
            where TResponse : class
        {
            return await CreateResponse<TResponse>(await _client.PutAsync(CreateUri<TRequest>(), CreateContent(request)));
        }

        public async Task<TResponse> DeleteAsync<TRequest, TResponse>(TRequest request)
            where TRequest : class
            where TResponse : class
        {
            var requestMessage = new HttpRequestMessage
            {
                RequestUri = new Uri(CreateUri<TRequest>()),
                Content = CreateContent(request),
                Method = HttpMethod.Delete,
            };

            return await CreateResponse<TResponse>(await _client.SendAsync(requestMessage));
        }
    }
}

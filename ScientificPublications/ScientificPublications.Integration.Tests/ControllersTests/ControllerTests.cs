using Microsoft.AspNetCore.Mvc.Routing;
using Newtonsoft.Json;
using ScientificPublications.Integration.Tests.Attributes;
using ScientificPublications.Integration.Tests.Contracts;
using ScientificPublications.Integration.Tests.Factories;
using ScientificPublications.Integration.Tests.Seed;
using ScientificPublications.WebUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ScientificPublications.Integration.Tests.ControllersTests
{
    public abstract class ControllerTests
    {
        private readonly HttpClient _client;
        protected readonly CustomWebApplicationFactory<Startup> _factory;

        protected HttpStatusCode _statusCode;
        protected string _content;
        protected Dictionary<string, string[]> _errorMessages;

        public ControllerTests()
        {
            _factory = new CustomWebApplicationFactory<Startup>();
            _client = _factory.CreateClient();
        }

        protected virtual async Task<TResponse> CreateResponse<TResponse>(HttpResponseMessage responseMessage)
        {
            _statusCode = responseMessage.StatusCode;
            _content = await responseMessage.Content.ReadAsStringAsync();

            if (!responseMessage.IsSuccessStatusCode)
            {
                try
                {
                    _errorMessages = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(_content);
                }
                catch
                {
                    throw new Exception($"StatusCode: ${_statusCode}\nError: ${_content}");
                }

                return default(TResponse);
            }

            return JsonConvert.DeserializeObject<TResponse>(await responseMessage.Content.ReadAsStringAsync());
        }

        protected virtual HttpContent CreateContent<TRequest>(TRequest request)
        {
            return new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
        }

        protected virtual string CreateUri<T>(T request)
            where T : Request
        {
            var endPointAttribute = typeof(T).GetCustomAttribute<EndpointAttribute>();
            var methodRoute = endPointAttribute.Name;
            var controllerRoute = endPointAttribute.Controller != null
                ? endPointAttribute.Controller
                : GetType().Name.Replace(nameof(ControllerTests), "");

            var httpMethodAttribute = Assembly.
                GetAssembly(typeof(Startup))
                .GetTypes()
                .FirstOrDefault(t => t.Name == $"{controllerRoute}Controller")
                ?.GetMethods()
                ?.FirstOrDefault(m => m.Name == methodRoute)
                ?.GetCustomAttribute<HttpMethodAttribute>();


            var uri = httpMethodAttribute?.Template != null
                ? httpMethodAttribute.Template
                : $"api/{controllerRoute}/{methodRoute}";

            var uriBuilder = new UriBuilder($"{_factory.ClientOptions.BaseAddress}{uri}");
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);

            request.QueryString?.GetType()?.GetProperties()?.ToList()?.ForEach(prop =>
            {
                query[prop.Name] = (string)prop.GetValue(request.QueryString);
            });

            uriBuilder.Query = query.ToString();
            return uriBuilder.ToString();
        }

        protected virtual async Task Authenticate()
        {
            var loginRequest = new LoginRequest
            {
                Username = SeedData.Users[0].Username,
                Password = SeedData.Users[0].Password,
            };

            var loginResponse = await PostAsync<LoginRequest, LoginResponse>(loginRequest);

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginResponse.Token);
        }

        public async Task<TResponse> GetAsync<TRequest, TResponse>(TRequest request)
            where TRequest : Request
            where TResponse : class
        {
            return await CreateResponse<TResponse>(await _client.GetAsync(CreateUri(request)));
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(TRequest request)
            where TRequest : Request
            where TResponse : Response
        {
            return await CreateResponse<TResponse>(await _client.PostAsync(CreateUri(request), CreateContent(request)));
        }

        public async Task<TResponse> PutAsync<TRequest, TResponse>(TRequest request)
            where TRequest : Request
            where TResponse : Response
        {
            return await CreateResponse<TResponse>(await _client.PutAsync(CreateUri(request), CreateContent(request)));
        }

        public async Task<TResponse> DeleteAsync<TRequest, TResponse>(TRequest request)
            where TRequest : Request
            where TResponse : Response
        {
            var requestMessage = new HttpRequestMessage
            {
                RequestUri = new Uri(CreateUri(request)),
                Content = CreateContent(request),
                Method = HttpMethod.Delete,
            };

            return await CreateResponse<TResponse>(await _client.SendAsync(requestMessage));
        }
    }
}

using Microsoft.AspNetCore.Mvc.Routing;
using Newtonsoft.Json;
using ScientificPublications.Domain.Entities.Users;
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

        public ControllerTests()
        {
            _factory = new CustomWebApplicationFactory<Startup>();
            _client = _factory.CreateClient();
        }

        protected virtual async Task<Response<TContent>> CreateResponse<TContent>(HttpResponseMessage responseMessage)
        {
            var response = new Response<TContent>()
            {
                StatusCode = responseMessage.StatusCode,
                StringContent = await responseMessage.Content.ReadAsStringAsync()
            };

            if (!responseMessage.IsSuccessStatusCode)
            {
                try
                {
                    response.ErrorMessages = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(response.StringContent);
                    return response;
                }
                catch
                {
                    throw new Exception($"StatusCode: ${response.StatusCode}\nError: ${response.StringContent}");
                }
            }

            response.Content = JsonConvert.DeserializeObject<TContent>(await responseMessage.Content.ReadAsStringAsync());

            return response;
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
            var user = _factory.Seeder.Seed<UserEntity>();

            var loginRequest = new LoginRequest
            {
                Username = user.Username,
                Password = "Test12345"
            };

            var loginResponse = await PostAsync<LoginRequest, LoginResponse>(loginRequest);

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginResponse.Content.Token);
        }

        public async Task<Response<TContent>> GetAsync<TRequest, TContent>(TRequest request)
            where TRequest : Request
        {
            return await CreateResponse<TContent>(await _client.GetAsync(CreateUri(request)));
        }

        public async Task<Response<TContent>> PostAsync<TRequest, TContent>(TRequest request)
            where TRequest : Request
        {
            return await CreateResponse<TContent>(await _client.PostAsync(CreateUri(request), CreateContent(request)));
        }

        public async Task<Response<TContent>> PutAsync<TRequest, TContent>(TRequest request)
            where TRequest : Request
        {
            return await CreateResponse<TContent>(await _client.PutAsync(CreateUri(request), CreateContent(request)));
        }

        public async Task<Response<TContent>> DeleteAsync<TRequest, TContent>(TRequest request)
            where TRequest : Request
        {
            var requestMessage = new HttpRequestMessage
            {
                RequestUri = new Uri(CreateUri(request)),
                Content = CreateContent(request),
                Method = HttpMethod.Delete,
            };

            return await CreateResponse<TContent>(await _client.SendAsync(requestMessage));
        }
    }
}

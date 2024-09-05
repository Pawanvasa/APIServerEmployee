
using EmployeeManagementApi.Helper.Policies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Polly.CircuitBreaker;
using System.Text.Json.Serialization;

namespace CircuitBreakerService1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CircuitBreakerController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public CircuitBreakerController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            this._httpClient = httpClientFactory.CreateClient();
            _configuration = configuration;
        }
        // GET api/values
        [HttpGet]
        [Route("/TestCircuitBreakar")]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {

            var circuitBreaker = MessagingPolicies.CircuitBreaker;
            var baseUrl = _configuration["CircuitBreakerUrl:baseurl"]!;
            try
            {
                await circuitBreaker.ExecuteAsync(async () =>
                {
                    _httpClient.BaseAddress = new Uri(baseUrl);
                    var response = await _httpClient.GetAsync("api/CircuitBreaker/simulateFailure");
                    return JsonConvert.DeserializeObject<string[]>(await response.Content.ReadAsStringAsync())!;
                });
            }
            catch (BrokenCircuitException ex)
            {
                // Handle the circuit being open
                // This is where you might log or perform additional actions when the circuit is open
                return Ok($"Service is not available Please try again after 30secs Message : {ex.Message}");
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                return Ok(ex.Message);
            }
            return Ok();
        }

    }
}

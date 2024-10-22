using Newtonsoft.Json;
using PMS.Shared.Models.Dtos;
using PMS.Shared.Models.Results;
using PMS.Web.Common;
using PMS.Web.Contracts;

namespace PMS.Web.Services
{
    public class PMSService : IPMSService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<PMSService> _logger;

        public PMSService(IHttpClientFactory httpClientFactory, ILogger<PMSService> logger)
        {
            _httpClient = httpClientFactory.CreateClient(Constant.PMS_API);
            _logger = logger;
        }

        private async Task<TResult> HandleResultResponseAsync<TResult>(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResult>(content)!;
        }

        public async Task<Result<IEnumerable<WorkItemDto>>> GetWorkItemsAsync(CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.GetAsync("api/WorkItems", cancellationToken);
            return await HandleResultResponseAsync<Result<IEnumerable<WorkItemDto>>>(response);
        }
    }
}

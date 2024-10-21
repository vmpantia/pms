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

        public async Task<IEnumerable<WorkItemDto>> GetWorkItemsAsync(CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.GetAsync("api/WorkItems");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Result<IEnumerable<WorkItemDto>>>(content);

            return result.Data;
        }
    }
}

using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace surfs_up_project.Services // Juster til dit faktiske namespace
{
    public class ApiLogService
    {
        private readonly HttpClient _httpClient;

        public ApiLogService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<dynamic>> GetApiLogStatisticsAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<dynamic>>("api/apilog");
        }
    }
}

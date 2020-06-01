using System.Collections.Generic;
using System.Net.Http;
using System.Security.Authentication;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3ClientLATEST.Data.dto;

namespace SEP3ClientLATEST.Data
{
    public class SEP3BusinessClient
    {
        private readonly HttpClient _client;

        private string addr = "https://localhost:8080";

        public SEP3BusinessClient()
        {
            var handler = new HttpClientHandler() {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };
            _client = new HttpClient(handler);
        }

        public async Task<AccountDTO> Login(LoginDTO dto)
        {
            var content = new StringContent(JsonSerializer.Serialize(dto),
                Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($"{addr}/accounts/login", content);

            if (response.IsSuccessStatusCode)
            {
                var respContent = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<AccountDTO>(respContent);
            }
            else
            {
                throw new AuthenticationException();
            }
        }

        public async Task<AccountDTO> Register(RegisterDTO dto)
        {
            var content = new StringContent(JsonSerializer.Serialize(dto),
                Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($"{addr}/accounts/register", content);
            
            var respContent = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<AccountDTO>(respContent);
        }

        public async Task<SongRequestDTO> Request(RequestDTO dto)
        {
            var content = new StringContent(JsonSerializer.Serialize(dto),
                Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($"{addr}/playlist", content);
            
            var respContent = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<SongRequestDTO>(respContent);
        }

        public async Task<List<SongRequestDTO>> GetPlaylist()
        {
            var response = await _client.GetAsync($"{addr}/playlist");
            
            var respContent = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<SongRequestDTO>>(respContent);
        }

        public async Task Vote(long songId)
        {
            await _client.PostAsync($"{addr}/playlist/{songId}/vote", null);
        }

        public async Task Play(long songId)
        {
            await _client.PostAsync($"{addr}/playlist/{songId}/play", null);
        }
    }
}
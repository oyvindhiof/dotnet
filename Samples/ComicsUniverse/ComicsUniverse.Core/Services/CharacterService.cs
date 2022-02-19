using ComicsUniverse.Core.Constants;
using ComicsUniverse.Core.Contracts.Services;
using ComicsUniverse.Core.Dtos;
using ComicsUniverse.Core.Helpers;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ComicsUniverse.Core.Services
{
    // The service is inspired by https://docs.microsoft.com/en-us/xamarin/xamarin-forms/data-cloud/web-services/rest
    public class CharacterService : ICharacterService
    {
        private readonly HttpClient _httpClient;
        public CharacterService()
        {
            _httpClient = new HttpClient() { BaseAddress = new System.Uri(BaseAddress.DataApi) };
        }

        public async Task<IEnumerable<CharacterDto>> GetCharactersAsync()
        {
            var items = new List<CharacterDto>();
            HttpResponseMessage response = await _httpClient.GetAsync("characters?includePowers=true");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                items = await Json.ToObjectAsync<List<CharacterDto>>(content);
            }
            return items;
        }

        public async Task<CharacterDto> CreateCharacterAsync(CharacterDto character)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"characters", character);
            response.EnsureSuccessStatusCode();
         
            return await response.Content.ReadFromJsonAsync<CharacterDto>();
        }

        public async Task<bool> DeleteCharacterAsync(CharacterDto character)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"characters/{character.CharacterId}");
            return response.IsSuccessStatusCode;
        }
    }
}

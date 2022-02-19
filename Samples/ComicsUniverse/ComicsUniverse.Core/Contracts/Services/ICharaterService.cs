using ComicsUniverse.Core.Dtos;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComicsUniverse.Core.Contracts.Services
{
    public interface ICharacterService
    {
        Task<IEnumerable<CharacterDto>> GetCharactersAsync();
        Task<CharacterDto> CreateCharacterAsync(CharacterDto character);
        Task<bool> DeleteCharacterAsync(CharacterDto character);
    }
}

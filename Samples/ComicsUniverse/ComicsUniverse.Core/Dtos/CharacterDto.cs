using ComicsUniverse.ViewModels;
using System.Collections.Generic;

namespace ComicsUniverse.Core.Dtos
{
    public class CharacterDto
    {
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Occupation { get; set; }
        public Universes Universe { get; set; }
        public string ProfileImage { get; set; }
        public string Description { get; set; }

        public List<SuperPowerDto> Powers { get; set; }
    }
}

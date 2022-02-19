using ComicsUniverse.ViewModels;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ComicsUniverse.DataAccess.Model
{
    public class Character
    {
        public int CharacterId { get; set; }

        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        [Required]
        [MinLength(2)]
        public string Alias { get; set; }

        public string Occupation { get; set; }

        public Universes Universe { get; set; }

        public string ProfileImage { get; set; }

        public string Description { get; set; }

        public List<SuperPower> Powers { get; set; }
    }
}

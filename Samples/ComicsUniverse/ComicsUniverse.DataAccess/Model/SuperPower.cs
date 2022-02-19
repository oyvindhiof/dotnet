using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ComicsUniverse.DataAccess.Model
{
    public class SuperPower
    {
        public int SuperPowerId { get; set; }

        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        public List<Character> Characters { get; set; }
    }
}

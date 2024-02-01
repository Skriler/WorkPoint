using System.ComponentModel.DataAnnotations;

namespace WorkPoint.Models.Entities.Skills
{
    public class OperatingSystemSkills : SomeSkills
    {
        [Required]
        public bool Windows { get; set; }

        [Required]
        public bool Mac { get; set; }

        [Required]
        public bool Linux { get; set; }
    }
}

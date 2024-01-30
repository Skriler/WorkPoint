using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace WorkPoint.Models.Entities.Skills
{
    public class OperatingSystemSkills : ISkills
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public bool Windows { get; set; }

        [Required]
        public bool Mac { get; set; }

        [Required]
        public bool Linux { get; set; }

        public Dictionary<string, bool> GetSkillsAsDictionary()
        {
            return new Dictionary<string, bool>
            {
                { "Windows", Windows },
                { "Mac", Mac },
                { "Linux", Linux }
            };
        }
    }
}

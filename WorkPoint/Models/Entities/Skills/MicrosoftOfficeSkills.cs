using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace WorkPoint.Models.Entities.Skills
{
    public class MicrosoftOfficeSkills : ISkills
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public bool Word { get; set; }

        [Required]
        public bool Excel { get; set; }

        [Required]
        public bool Access { get; set; }

        [Required]
        public bool Powerpoint { get; set; }

        public Dictionary<string, bool> GetSkillsAsDictionary()
        {
            return new Dictionary<string, bool>
            {
                { "Word", Word },
                { "Excel", Excel },
                { "Access", Access },
                { "Powerpoint", Powerpoint }
            };
        }
    }
}

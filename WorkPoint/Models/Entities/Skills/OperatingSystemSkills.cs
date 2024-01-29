using System.ComponentModel.DataAnnotations;

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

        public List<bool> GetSkillsAsList()
        {
            return new List<bool>
            {
                Windows,
                Mac,
                Linux
            };
        }
    }
}

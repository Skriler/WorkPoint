using System.ComponentModel.DataAnnotations;

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

        public List<bool> GetSkillsAsList()
        {
            return new List<bool>
            {
                Word,
                Excel,
                Access,
                Powerpoint
            };
        }
    }
}

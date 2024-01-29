using System.ComponentModel.DataAnnotations;

namespace WorkPoint.Models.Entities.Skills
{
    public class GraphicEditorsSkills : ISkills
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public bool VSCO { get; set; }

        [Required]
        public bool Snapseed { get; set; }

        [Required]
        public bool Lightroom { get; set; }

        [Required]
        public bool Photoshop { get; set; }

        public List<bool> GetSkillsAsList()
        {
            return new List<bool>
            {
                VSCO,
                Snapseed,
                Lightroom,
                Photoshop
            };
        }
    }
}

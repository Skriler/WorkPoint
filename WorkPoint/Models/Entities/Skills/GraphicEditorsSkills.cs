using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

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

        public Dictionary<string, bool> GetSkillsAsDictionary()
        {
            return new Dictionary<string, bool>
            {
                { "VSCO", VSCO },
                { "Snapseed", Snapseed },
                { "Lightroom", Lightroom },
                { "Photoshop", Photoshop }
            };
        }
    }
}

using System.ComponentModel.DataAnnotations;
using WorkPoint.Models.Entities.Skills;

namespace WorkPoint.Models.Entities
{
    public class HardSkills
    {
        [Key]
        public int Id { get; set; }

        public int ProgrammingSkillsId { get; set; }
        public ProgrammingSkills? ProgrammingSkills { get; set; }

        public int DBSkillsId { get; set; }
        public DatabaseSkills? DBSkills { get; set; }

        public int MSOfficeSkillsId { get; set; }
        public MicrosoftOfficeSkills? MSOfficeSkills { get; set; }

        public int OSSkillsId { get; set; }
        public OperatingSystemSkills? OSSkills { get; set; }

        public int GESkillsId { get; set; }
        public GraphicEditorsSkills? GESkills { get; set; }

        public int ExtraSkillsId { get; set; }
        public ExtraSkills? ExtraSkills { get; set; }
    }
}

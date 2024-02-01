using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using WorkPoint.Models.Entities.Skills;

namespace WorkPoint.Models.Entities
{
    public class HardSkills
    {
        [Key]
        public int Id { get; set; }

        public int ProgrammingSkillsId { get; set; }
        public ProgrammingSkills ProgrammingSkills { get; set; } = default!;

        public int DBSkillsId { get; set; }
        public DatabaseSkills DBSkills { get; set; } = default!;

        public int MSOfficeSkillsId { get; set; }
        public MicrosoftOfficeSkills MSOfficeSkills { get; set; } = default!;

        public int OSSkillsId { get; set; }
        public OperatingSystemSkills OSSkills { get; set; } = default!;

        public int GESkillsId { get; set; }
        public GraphicEditorsSkills GESkills { get; set; } = default!;

        public int ExtraSkillsId { get; set; }
        public ExtraSkills ExtraSkills { get; set; } = default!;

        public HardSkills()
        {
            ProgrammingSkills = new ProgrammingSkills();
            DBSkills = new DatabaseSkills();
            MSOfficeSkills = new MicrosoftOfficeSkills();
            OSSkills = new OperatingSystemSkills();
            GESkills = new GraphicEditorsSkills();
            ExtraSkills = new ExtraSkills();
        }

        public List<SomeSkills> GetSkillsAsList()
        {
            return new List<SomeSkills>
            {
                ProgrammingSkills,
                DBSkills,
                MSOfficeSkills,
                OSSkills,
                GESkills,
                ExtraSkills
            };
        }
    }
}

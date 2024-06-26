﻿using WorkPoint.Models.Entities.Skills;

namespace WorkPoint.Models.Entities;

public class HardSkills : SomeSkills
{
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

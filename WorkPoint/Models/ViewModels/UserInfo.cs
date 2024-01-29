using WorkPoint.Models.Entities;
using WorkPoint.Models.Entities.Skills;

namespace WorkPoint.Models.ViewModels
{
    public class UserInfo
    {
        public int Salary { get; set; }

        public bool IsRemote { get; set; }

        public bool HasOfficeInZaporizhzhia { get; set; }

        public int Experience { get; set; }

        public bool HighEducation { get; set; }

        public bool KnowledgeB2EnglishLevel { get; set; }

        public SoftSkills SoftSkills { get; set; }
        public HardSkills HardSkills { get; set; }

        public UserInfo()
        {
            Salary = 15000;
            IsRemote = true;
            HasOfficeInZaporizhzhia = true;
            Experience = 2;
            HighEducation = true;
            KnowledgeB2EnglishLevel = true;

            SoftSkills = new SoftSkills()
            {
                Teamwork = true
            };

            HardSkills = new HardSkills()
            {
                ProgrammingSkills = new ProgrammingSkills()
                {
                    CSharp = true,
                    DOTNET = true,
                    HTTP = true
                },
                DBSkills = new DatabaseSkills()
                {
                    MSSQL = true,
                },
                MSOfficeSkills = new MicrosoftOfficeSkills(),
                OSSkills = new OperatingSystemSkills(),
                GESkills = new GraphicEditorsSkills(),
                ExtraSkills = new ExtraSkills()
            };
        }

        public ISkills GetSkillsBySpecialitySkills(ISkills specialitySkills)
        {
            return specialitySkills switch
            {
                ProgrammingSkills => HardSkills.ProgrammingSkills,
                DatabaseSkills => HardSkills.DBSkills,
                MicrosoftOfficeSkills => HardSkills.MSOfficeSkills,
                OperatingSystemSkills => HardSkills.OSSkills,
                GraphicEditorsSkills => HardSkills.GESkills,
                ExtraSkills => HardSkills.ExtraSkills,
                _ => default!
            };
        }
    }
}

using System;
using System.Text.Json;
using WorkPoint.Models.Entities;
using WorkPoint.Models.Entities.Skills;

namespace WorkPoint.DAL
{
    public static class DataInitializer
    {
        private static readonly string specialitiesDataPath = "Data/specialities.json";

        public static List<Speciality> Specialities { get; set; } = default!;
        public static List<HardSkills> HardSkills { get; set; } = default!;
        public static List<SoftSkills?> SoftSkills { get; set; } = default!;
        public static List<ProgrammingSkills?> ProgrammingSkills { get; set; } = default!;
        public static List<DatabaseSkills?> DBSkills { get; set; } = default!;
        public static List<MicrosoftOfficeSkills?> MSOfficeSkills { get; set; } = default!;
        public static List<OperatingSystemSkills?> OSSkills { get; set; } = default!;
        public static List<GraphicEditorsSkills?> GESkills { get; set; } = default!;
        public static List<ExtraSkills?> ExtraSkills { get; set; } = default!;

        public static void Initialize()
        {
            List<Speciality> specialities = GetSpecialityList();

            if (specialities == null && specialities?.Count == 0)
                return;

            ProgrammingSkills = specialities
                .Select(s => s.RequiredHardSkills?.ProgrammingSkills)
                .ToList();
            DBSkills = specialities
                .Select(s => s.RequiredHardSkills?.DBSkills)
                .ToList();
            MSOfficeSkills = specialities
                .Select(s => s.RequiredHardSkills?.MSOfficeSkills)
                .ToList();
            OSSkills = specialities
                .Select(s => s.RequiredHardSkills?.OSSkills)
                .ToList();
            GESkills = specialities
                .Select(s => s.RequiredHardSkills?.GESkills)
                .ToList();
            ExtraSkills = specialities
                .Select(s => s.RequiredHardSkills?.ExtraSkills)
                .ToList();

            SoftSkills = specialities.Select(s => s.RequiredSoftSkills).ToList();
            HardSkills = specialities
                .Select(s => s.RequiredHardSkills)
                .Select(hs => new HardSkills
                {
                    ProgrammingSkillsId = hs.ProgrammingSkillsId,
                    DBSkillsId = hs.DBSkillsId,
                    MSOfficeSkillsId = hs.MSOfficeSkillsId,
                    OSSkillsId = hs.OSSkillsId,
                    GESkillsId = hs.GESkillsId,
                    ExtraSkillsId = hs.ExtraSkillsId
                }).ToList();

            Specialities = specialities.Select(s => new Speciality
            {
                Name = s.Name,
                Salary = s.Salary,
                IsRemote = s.IsRemote,
                HasOfficeInZaporizhzhia = s.HasOfficeInZaporizhzhia,
                RequiredExperience = s.RequiredExperience,
                IsHighEducationNeeded = s.IsHighEducationNeeded,
                IsB2EnglishLevelNeeded = s.IsB2EnglishLevelNeeded,
                Description = s.Description,
                RequiredSoftSkillsId = s.RequiredSoftSkillsId,
                RequiredHardSkillsId = s.RequiredHardSkillsId
            }).ToList();
        }

        private static List<Speciality> GetSpecialityList()
        {
            string jsonString = File.ReadAllText(specialitiesDataPath);
            return JsonSerializer.Deserialize<List<Speciality>>(jsonString);
        }
    }
}

using NuGet.Packaging;
using System.Linq;
using WorkPoint.Models.Entities;
using WorkPoint.Models.Entities.Skills;
using WorkPoint.Models.ViewModels;

namespace WorkPoint.SL
{
    public static class SpecialtyRecommendationService
    {
        private static readonly float minSimilarityMeasure = 0.5f;

        public static List<SpecialityRecommendation> GetRecommendation(UserInfo userInfo, List<Speciality> specialities)
        {
            var specialityRecommendations = new List<SpecialityRecommendation>();
            var suitableSkillsBySpeciality = new Dictionary<Speciality, Dictionary<string, bool>>();

            foreach (Speciality speciality in specialities)
            {
                suitableSkillsBySpeciality.Add(
                    speciality, 
                    GetSuitableSkillsForSpeciality(userInfo, speciality)
                    );
            }

            SpecialityRecommendation recommendation;
            foreach (var skills in suitableSkillsBySpeciality)
            {
                recommendation = new SpecialityRecommendation();

                recommendation.Speciality = skills.Key;
                recommendation.SkillsWithUserStatus = skills.Value;
                recommendation.SimilarityRatio = 
                    skills.Value.Values.Where(skill => skill).Count() /
                    (float)skills.Value.Count;

                specialityRecommendations.Add(recommendation);
            }

            return specialityRecommendations
                .Where(recommendation => recommendation.SimilarityRatio >= minSimilarityMeasure)
                .OrderByDescending(recommendation => recommendation.SimilarityRatio)
                .Take(5)
                .ToList();
        }

        private static Dictionary<string, bool> GetSuitableSkillsForSpeciality(UserInfo userInfo, Speciality speciality)
        {
            Dictionary<string, bool> suitableHardSkills = 
                GetSuitableHardSkills(userInfo, speciality.RequiredHardSkills);

            suitableHardSkills.AddRange(
                GetSuitableSkills(userInfo.SoftSkills, speciality.RequiredSoftSkills)
                );

            suitableHardSkills.Add(
                "Salary",
                userInfo.Salary <= speciality.Salary
                );
            suitableHardSkills.Add(
                "RequiredExperience",
                userInfo.Experience >= speciality.RequiredExperience
                );

            if (speciality.IsRemote)
            {
                suitableHardSkills.Add(
                    "IsRemote",
                    userInfo.IsRemote == speciality.IsRemote
                    );
            }

            if (speciality.HasOfficeInZaporizhzhia)
            {
                suitableHardSkills.Add(
                    "HasOfficeInZaporizhzhia",
                    userInfo.HasOfficeInZaporizhzhia == speciality.HasOfficeInZaporizhzhia
                    );
            }

            if (speciality.IsHighEducationNeeded)
            {
                suitableHardSkills.Add(
                    "HighEducation",
                    userInfo.HighEducation == speciality.IsHighEducationNeeded
                    );
            }

            if (speciality.IsB2EnglishLevelNeeded)
            {
                suitableHardSkills.Add(
                    "KnowledgeB2EnglishLevel",
                    userInfo.KnowledgeB2EnglishLevel == speciality.IsB2EnglishLevelNeeded
                    );
            }

            return suitableHardSkills;
        }

        private static Dictionary<string, bool> GetSuitableHardSkills(UserInfo userInfo, HardSkills requiredSkills)
        {
            Dictionary<string, bool> suitableHardSkills = new Dictionary<string, bool>();

            var requiredSkillsList = requiredSkills.GetSkillsAsList();

            foreach (var skills in requiredSkillsList)
            {
                suitableHardSkills.AddRange(GetSuitableSkills(userInfo.GetSkillsBySpecialitySkills(skills), skills));
            }

            return suitableHardSkills;
        }

        private static Dictionary<string, bool> GetSuitableSkills<TSkills>(TSkills userSkills, TSkills requiredSkills) where TSkills : ISkills
        {
            Dictionary<string, bool> suitableSkills = new Dictionary<string, bool>();

            var userSkillsDictionary = userSkills.GetSkillsAsDictionary();
            var specialtySkillsDictionary = requiredSkills.GetSkillsAsDictionary();


            foreach (var skill in specialtySkillsDictionary)
            {
                if (!skill.Value)
                    continue;

                suitableSkills.Add(skill.Key, userSkillsDictionary.GetValueOrDefault(skill.Key));
            }

            return suitableSkills;
        }
    }
}

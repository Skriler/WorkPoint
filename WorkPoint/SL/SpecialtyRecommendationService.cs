using WorkPoint.Models.Entities;
using WorkPoint.Models.Entities.Skills;
using WorkPoint.Models.ViewModels;

namespace WorkPoint.SL
{
    public static class SpecialtyRecommendationService
    {
        private static readonly float minSimilarityMeasure = 0.6f;

        public static List<Speciality> GetRecommendation(UserInfo userInfo, List<Speciality> specialities)
        {
            var suitableSkillsCountBySpeciality = new Dictionary<Speciality, int>();
            int count;

            foreach (Speciality speciality in specialities)
            {
                count = CalculateSuitableSkillsForSpeciality(userInfo, speciality);

                suitableSkillsCountBySpeciality.Add(speciality, count);
            }

            //TODO return specialities with >= minSimilarityMeasure
            var sortedSpecialities = suitableSkillsCountBySpeciality
                .OrderByDescending(pair => pair.Value)
                .Take(5)
                .Select(pair => pair.Key)
                .ToList();

            return sortedSpecialities;
        }

        private static int CalculateSuitableSkillsForSpeciality(UserInfo userInfo, Speciality speciality)
        {
            int suitableSkillsCount = 0;

            suitableSkillsCount += CalculateSuitableHardSkills(userInfo, speciality.RequiredHardSkills);
            suitableSkillsCount += CalculateSuitableSkills(userInfo.SoftSkills, speciality.RequiredSoftSkills);

            //TODO refactor
            if (userInfo.Salary <= speciality.Salary)
                ++suitableSkillsCount;

            if (userInfo.IsRemote == speciality.IsRemote)
                ++suitableSkillsCount;

            if (userInfo.HasOfficeInZaporizhzhia == speciality.HasOfficeInZaporizhzhia)
                ++suitableSkillsCount;

            if (userInfo.Experience >= speciality.RequiredExperience)
                ++suitableSkillsCount;

            if (userInfo.HighEducation == speciality.IsHighEducationNeeded)
                ++suitableSkillsCount;

            if (userInfo.KnowledgeB2EnglishLevel == speciality.IsB2EnglishLevelNeeded)
                ++suitableSkillsCount;

            return suitableSkillsCount;
        }

        private static int CalculateSuitableHardSkills(UserInfo userInfo, HardSkills requiredSkills)
        {
            var requiredSkillsList = requiredSkills.GetSkillsAsList();

            return requiredSkillsList
                .Sum(specialtySkills => CalculateSuitableSkills(
                    userInfo.GetSkillsBySpecialitySkills(specialtySkills), 
                    specialtySkills
                    ));
        }

        private static int CalculateSuitableSkills<TSkills>(TSkills userSkills, TSkills requiredSkills)  where TSkills : ISkills
        {
            var userSkillsList = userSkills.GetSkillsAsList();
            var specialtySkillsList = requiredSkills.GetSkillsAsList();

            return userSkillsList
                .Zip(specialtySkillsList, (userSkill, specialtySkill) => (userSkill, specialtySkill))
                .Count(pair => pair.specialtySkill && pair.userSkill);
        }
    }
}

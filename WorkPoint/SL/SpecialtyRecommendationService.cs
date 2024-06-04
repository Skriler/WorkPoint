using NuGet.Packaging;
using System.Linq;
using WorkPoint.Models.Entities;
using WorkPoint.Models.Entities.Skills;
using WorkPoint.Models.Storages;
using WorkPoint.Models.ViewModels;

namespace WorkPoint.SL;

public static class SpecialtyRecommendationService
{
    private static readonly float minSimilarityMeasure = 0.5f;

    public static List<SpecialityRecommendation> GetRecommendation(UserInfo userInfo, List<Speciality> specialities)
    {
        var suitableSkillsBySpeciality = new List<UserSpecialityMatch>();

        UserSpecialityMatch userSpecialityMatch;
        foreach (Speciality speciality in specialities)
        {
            userSpecialityMatch = new UserSpecialityMatch
            {
                Speciality = speciality,
                SkillsWithUserStatus = GetSuitableSkillsForSpeciality(userInfo, speciality)
            };

            suitableSkillsBySpeciality.Add(userSpecialityMatch);
        }

        var specialityRecommendations = GetSpecialityRecommendations(userInfo, suitableSkillsBySpeciality);

        return specialityRecommendations
            .Where(recommendation => recommendation.SimilarityRatio >= minSimilarityMeasure)
            .OrderByDescending(recommendation => recommendation.SimilarityRatio)
            .Take(5)
            .ToList();
    }

    private static Dictionary<string, bool> GetSuitableSkillsForSpeciality(UserInfo userInfo, Speciality speciality)
    {
        var suitableSkills = new Dictionary<string, bool>();

        suitableSkills.AddRange(GetSuitableHardSkills(userInfo, speciality.RequiredHardSkills));
        suitableSkills.AddRange(GetSuitableSkills(userInfo.SoftSkills, speciality.RequiredSoftSkills));

        suitableSkills[SpecialityConstants.SalaryKey] = userInfo.Salary <= speciality.Salary;
        suitableSkills[SpecialityConstants.RequiredExperienceKey] = userInfo.Experience >= speciality.RequiredExperience;

        if (speciality.IsRemote)
            suitableSkills[SpecialityConstants.RemoteKey] = userInfo.IsRemote == speciality.IsRemote;

        if (speciality.HasOfficeInZaporizhzhia)
            suitableSkills[SpecialityConstants.OfficeInZaporizhzhiaKey] = userInfo.HasOfficeInZaporizhzhia == speciality.HasOfficeInZaporizhzhia;

        if (speciality.IsHighEducationNeeded)
            suitableSkills[SpecialityConstants.HighEducationKey] = userInfo.HighEducation == speciality.IsHighEducationNeeded;

        if (speciality.IsB2EnglishLevelNeeded)
            suitableSkills[SpecialityConstants.EnglishLevelB2Key] = userInfo.KnowledgeB2EnglishLevel == speciality.IsB2EnglishLevelNeeded;

        return suitableSkills;
    }

    private static List<SpecialityRecommendation> GetSpecialityRecommendations(UserInfo userInfo, List<UserSpecialityMatch> userSpecialityMatches)
    {
        var specialityRecommendations = new List<SpecialityRecommendation>();

        SkillWeights skillWeights = new SkillWeights();
        skillWeights.SetSkillWeights(userInfo);
 
        float totalWeight = 0;
        float matchingWeight = 0;
        SpecialityRecommendation recommendation;

        foreach (var userSpecialityMatch in userSpecialityMatches)
        {
            recommendation = new SpecialityRecommendation
            {
                Speciality = userSpecialityMatch.Speciality,
                SkillsWithUserStatus = userSpecialityMatch.SkillsWithUserStatus
            };

            totalWeight = 0;
            matchingWeight = 0;

            foreach (var skill in userSpecialityMatch.SkillsWithUserStatus)
            {
                float weight = skillWeights.GetSkillWeight(skill.Key);
                totalWeight += weight;

                if (skill.Value)
                {
                    matchingWeight += weight;
                }
            }

            recommendation.SimilarityRatio = totalWeight > 0 ? matchingWeight / totalWeight : 0;
            specialityRecommendations.Add(recommendation);
        }

        return specialityRecommendations;
    }

    private static Dictionary<string, bool> GetSuitableHardSkills(UserInfo userInfo, HardSkills requiredSkills)
    {
        Dictionary<string, bool> suitableHardSkills = new Dictionary<string, bool>();

        var requiredSkillsList = requiredSkills.GetSkillsAsList();

        foreach (var skills in requiredSkillsList)
        {
            suitableHardSkills.AddRange(
                GetSuitableSkills(
                    userInfo.GetSkillsBySpecialitySkills(skills), 
                    skills
                    )
                );
        }

        return suitableHardSkills;
    }

    private static Dictionary<string, bool> GetSuitableSkills<TSkills>(TSkills userSkills, TSkills requiredSkills) where TSkills : SomeSkills
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

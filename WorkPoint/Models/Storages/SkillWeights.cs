using NuGet.Packaging;
using WorkPoint.Models.ViewModels;
using WorkPoint.SL;

namespace WorkPoint.Models.Storages;

public class SkillWeights
{
    public Dictionary<string, float> skillWeights;

    public SkillWeights()
    {
        skillWeights = new Dictionary<string, float>();
    }

    public void SetSkillWeights(UserInfo userInfo)
    {
        skillWeights = new Dictionary<string, float>
        {
            [SpecialityConstants.SalaryKey] = SpecialityConstants.SalaryCoeff,
            [SpecialityConstants.RequiredExperienceKey] = SpecialityConstants.ExperienceCoeff,
            [SpecialityConstants.RemoteKey] = SpecialityConstants.OfficeStatusCoeff,
            [SpecialityConstants.OfficeInZaporizhzhiaKey] = SpecialityConstants.OfficeStatusCoeff,
            [SpecialityConstants.HighEducationKey] = SpecialityConstants.EducationCoeff,
            [SpecialityConstants.EnglishLevelB2Key] = SpecialityConstants.EducationCoeff
        };

        AddSkillWeights(userInfo.HardSkills.ProgrammingSkills.GetSkillNames(), SpecialityConstants.HardSkillsCoeff);
        AddSkillWeights(userInfo.HardSkills.DBSkills.GetSkillNames(), SpecialityConstants.HardSkillsCoeff);
        AddSkillWeights(userInfo.HardSkills.MSOfficeSkills.GetSkillNames(), SpecialityConstants.HardSkillsCoeff);
        AddSkillWeights(userInfo.HardSkills.OSSkills.GetSkillNames(), SpecialityConstants.HardSkillsCoeff);
        AddSkillWeights(userInfo.HardSkills.GESkills.GetSkillNames(), SpecialityConstants.HardSkillsCoeff);
        AddSkillWeights(userInfo.HardSkills.ExtraSkills.GetSkillNames(), SpecialityConstants.HardSkillsCoeff);
        AddSkillWeights(userInfo.SoftSkills.GetSkillNames(), SpecialityConstants.SoftSkillsCoeff);
    }

    public float GetSkillWeight(string skill)
    {
        return skillWeights.TryGetValue(skill, out var weight) ? weight : 0;
    }

    public void AddSkillWeight(string skill, float weight)
    {
        skillWeights[skill] = weight;
    }

    private void AddSkillWeights(IEnumerable<string> skills, float weight)
    {
        foreach (var skill in skills)
        {
            skillWeights[skill] = weight;
        }
    }
}

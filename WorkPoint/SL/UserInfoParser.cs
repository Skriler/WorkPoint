using WorkPoint.Models.Entities;
using WorkPoint.Models.Entities.Skills;
using WorkPoint.Models.ViewModels;

namespace WorkPoint.SL;

public static class UserInfoParser
{
    public static UserInfo Parse(Dictionary<string, string> userSkills)
    {
        var userInfo = new UserInfo();

        var skillActions = new Dictionary<string, Action<string>>()
        {
            { SpecialityConstants.SalaryKey, value => userInfo.Salary = ParseInt(value) },
            { SpecialityConstants.RequiredExperienceKey, value => userInfo.Experience = ParseInt(value) },
            { SpecialityConstants.RemoteKey, value => userInfo.IsRemote = value == SpecialityConstants.HasSkillKey },
            { SpecialityConstants.OfficeInZaporizhzhiaKey, value => userInfo.HasOfficeInZaporizhzhia = value == SpecialityConstants.HasSkillKey },
            { SpecialityConstants.HighEducationKey, value => userInfo.HighEducation = value == SpecialityConstants.HasSkillKey },
            { SpecialityConstants.EnglishLevelB2Key, value => userInfo.KnowledgeB2EnglishLevel = value == SpecialityConstants.HasSkillKey }
        };

        foreach (var skill in userSkills)
        {
            if (skillActions.TryGetValue(skill.Key, out var action))
            {
                action(skill.Value);
            }
        }

        userInfo.SoftSkills = ParseSoftSkills(userSkills);
        userInfo.HardSkills = ParseHardSkills(userSkills);

        return userInfo;
    }

    private static SoftSkills ParseSoftSkills(Dictionary<string, string> userSkills)
    {
        var softSkills = new SoftSkills();
        var userSoftSkills = new Dictionary<string, bool>();

        var softSkillsDictionary = softSkills.GetSkillsAsDictionary();
        foreach (var skill in softSkillsDictionary)
        {
            userSoftSkills.Add(
                skill.Key,
                GetSkillBoolValue(userSkills, skill.Key)
                );
        }

        softSkills.SetSkillsFromDictionary(userSoftSkills);

        return softSkills;
    }

    private static HardSkills ParseHardSkills(Dictionary<string, string> userSkills)
    {
        var hardSkills = new HardSkills()
        {
            ProgrammingSkills = new ProgrammingSkills(),
            DBSkills = new DatabaseSkills(),
            MSOfficeSkills = new MicrosoftOfficeSkills(),
            OSSkills = new OperatingSystemSkills(),
            GESkills = new GraphicEditorsSkills(),
            ExtraSkills = new ExtraSkills()
        };

        Dictionary<string, bool> userSomeSkills;

        var hardSkillsList = hardSkills.GetSkillsAsList();
        foreach (var someSkillsList in hardSkillsList)
        {
            userSomeSkills = new Dictionary<string, bool>();

            var someSkillsDictionary = someSkillsList.GetSkillsAsDictionary();
            foreach (var skill in someSkillsDictionary)
            {
                userSomeSkills.Add(
                    skill.Key,
                    GetSkillBoolValue(userSkills, skill.Key)
                    );
            }

            someSkillsList.SetSkillsFromDictionary(userSomeSkills);
        }

        return hardSkills;
    }

    private static int ParseInt(string value)
    {
        string numericString = new string(
            value.Where(char.IsDigit).ToArray()
            );

        if (int.TryParse(numericString, out int numericValue))
            return numericValue;

        return -1;
    }

    private static bool GetSkillBoolValue(Dictionary<string, string> values, string key)
    {
        if (!values.ContainsKey(key))
            return false;

        string boolString = values[key];

        if (bool.TryParse(boolString, out bool boolValue))
            return boolValue;

        return false;
    }
}

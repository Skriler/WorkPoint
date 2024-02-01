using WorkPoint.Models.Entities;
using WorkPoint.Models.Entities.Skills;
using WorkPoint.Models.ViewModels;

namespace WorkPoint.SL
{
    public static class UserInfoParser
    {
        public static UserInfo Parse(Dictionary<string, string> userSkills)
        {
            var userInfo = new UserInfo();

            foreach (var skill in userSkills)
            {
                switch (skill.Key)
                {
                    case "Salary":
                        userInfo.Salary = ParseInt(skill.Value);
                        break;
                    case "IsRemote":
                        userInfo.IsRemote = skill.Value == "Так" ? true : false;
                        break;
                    case "HasOfficeInZaporizhzhia":
                        userInfo.HasOfficeInZaporizhzhia = skill.Value == "Так" ? true : false;
                        break;
                    case "RequiredExperience":
                        userInfo.Experience = ParseInt(skill.Value);
                        break;
                    case "IsHighEducationNeeded":
                        userInfo.HighEducation = skill.Value == "Так" ? true : false;
                        break;
                    case "IsB2EnglishLevelNeeded":
                        userInfo.KnowledgeB2EnglishLevel = skill.Value == "Так" ? true : false;
                        break;
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
            var hardSkills = new HardSkills();

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
}

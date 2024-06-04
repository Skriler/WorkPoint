using WorkPoint.Models.Entities;

namespace WorkPoint.Models.Storages;

public class UserSpecialityMatch
{
    public Speciality Speciality { get; set; }
    public Dictionary<string, bool> SkillsWithUserStatus { get; set; }

    public UserSpecialityMatch()
    {
        Speciality = new Speciality();
        SkillsWithUserStatus = new Dictionary<string, bool>();
    }
}

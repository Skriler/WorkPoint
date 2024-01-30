using System.ComponentModel.DataAnnotations;

namespace WorkPoint.Models.Entities.Skills
{
    public interface ISkills
    {
        [Key]
        int Id { get; set; }

        Dictionary<string, bool> GetSkillsAsDictionary();
    }
}

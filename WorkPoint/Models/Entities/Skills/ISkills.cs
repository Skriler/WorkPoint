using System.ComponentModel.DataAnnotations;

namespace WorkPoint.Models.Entities.Skills
{
    public interface ISkills
    {
        [Key]
        int Id { get; set; }

        List<bool> GetSkillsAsList();
    }
}

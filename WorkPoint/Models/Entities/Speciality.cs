using System.ComponentModel.DataAnnotations;

namespace WorkPoint.Models.Entities
{
    public class Speciality
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public int Salary { get; set; }

        [Required]
        public bool IsRemote { get; set; }

        [Required]
        public bool HasOfficeInZaporizhzhia { get; set; }

        [Required]
        public int RequiredExperience { get; set; }

        [Required]
        public bool IsHighEducationNeeded { get; set; }

        [Required]
        public bool IsB2EnglishLevelNeeded { get; set; }

        public string? Description { get; set; }

        [Required]
        public int RequiredSoftSkillsId { get; set; }
        public SoftSkills? RequiredSoftSkills { get; set; }

        [Required]
        public int RequiredHardSkillsId { get; set; }
        public HardSkills? RequiredHardSkills { get; set; }
    }
}

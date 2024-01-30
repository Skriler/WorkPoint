using System.ComponentModel.DataAnnotations;

namespace WorkPoint.Models.Entities.Skills
{
    public class DatabaseSkills : ISkills
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public bool MYSQL { get; set; }

        [Required]
        public bool PostgreSQL { get; set; }

        [Required]
        public bool MongoDB { get; set; }

        [Required]
        public bool Redis { get; set; }

        [Required]
        public bool NoSQL { get; set; }

        [Required]
        public bool Oracle { get; set; }

        [Required]
        public bool MSSQL { get; set; }

        public Dictionary<string, bool> GetSkillsAsDictionary()
        {
            return new Dictionary<string, bool>
            {
                { "MYSQL", MYSQL },
                { "PostgreSQL", PostgreSQL },
                { "MongoDB", MongoDB },
                { "Redis", Redis },
                { "NoSQL", NoSQL },
                { "Oracle", Oracle },
                { "MSSQL", MSSQL }
            };
        }
    }
}

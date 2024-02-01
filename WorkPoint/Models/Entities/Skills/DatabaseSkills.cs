using System.ComponentModel.DataAnnotations;

namespace WorkPoint.Models.Entities.Skills
{
    public class DatabaseSkills : SomeSkills
    {
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
    }
}

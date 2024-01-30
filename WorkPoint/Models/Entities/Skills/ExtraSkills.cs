using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace WorkPoint.Models.Entities.Skills
{
    public class ExtraSkills : ISkills
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public bool Git { get; set; }

        [Required]
        public bool GoogleAnalytics { get; set; }

        [Required]
        public bool FacebookAnalytics { get; set; }

        [Required]
        public bool NetworkProtocols { get; set; }

        [Required]
        public bool ComputerNetworks { get; set; }

        [Required]
        public bool MaintainingSoftware { get; set; }

        [Required]
        public bool NeatpeakSpider { get; set; }

        [Required]
        public bool Ahrefs { get; set; }

        public Dictionary<string, bool> GetSkillsAsDictionary()
        {
            return new Dictionary<string, bool>
            {
                { "Git", Git },
                { "GoogleAnalytics", GoogleAnalytics },
                { "FacebookAnalytics", FacebookAnalytics },
                { "NetworkProtocols", NetworkProtocols },
                { "ComputerNetworks", ComputerNetworks },
                { "MaintainingSoftware", MaintainingSoftware },
                { "NeatpeakSpider", NeatpeakSpider },
                { "Ahrefs", Ahrefs }
            };
        }
    }
}

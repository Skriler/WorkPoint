using System.ComponentModel.DataAnnotations;

namespace WorkPoint.Models.Entities.Skills
{
    public class ExtraSkills : SomeSkills
    {
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
    }
}

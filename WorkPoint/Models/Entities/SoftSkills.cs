using System.ComponentModel.DataAnnotations;

namespace WorkPoint.Models.Entities
{
    public class SoftSkills
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public bool Teamwork { get; set; }

        [Required]
        public bool Responsibility { get; set; }

        [Required]
        public bool Punctuality { get; set; }

        [Required]
        public bool Social { get; set; }

        [Required]
        public bool Analytical { get; set; }

        [Required]
        public bool Business { get; set; }

        [Required]
        public bool Attention { get; set; }

        [Required]
        public bool Planning { get; set; }

        [Required]
        public bool QuickLearner { get; set; }

        [Required]
        public bool CriticalThinking { get; set; }

        [Required]
        public bool Statistics { get; set; }

        [Required]
        public bool ContentPromotion { get; set; }
    }
}

using WorkPoint.Models.Entities;

namespace WorkPoint.Models.ViewModels
{
    public class SpecialityRecommendation
    {
        public Speciality Speciality { get; set; } = default!;
        public Dictionary<string, bool> SkillsWithUserStatus { get; set; } = default!;
        public float SimilarityRatio { get; set; }
    }
}

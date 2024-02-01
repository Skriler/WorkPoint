using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace WorkPoint.Models.Entities.Skills
{
    public abstract class SomeSkills
    {
        [Key]
        public int Id { get; set; }

        public Dictionary<string, bool> GetSkillsAsDictionary()
        {
            var properties = GetType().GetProperties()
                .Where(prop => prop.PropertyType == typeof(bool) && prop.GetCustomAttribute<RequiredAttribute>() != null);

            return properties.ToDictionary(prop => prop.Name, prop => (bool)prop.GetValue(this));
        }

        public void SetSkillsFromDictionary(Dictionary<string, bool> skills)
        {
            var properties = GetType().GetProperties()
                .Where(prop => prop.PropertyType == typeof(bool) && prop.GetCustomAttribute<RequiredAttribute>() != null);

            foreach (var prop in properties)
            {
                if (skills.TryGetValue(prop.Name, out bool value))
                {
                    prop.SetValue(this, value);
                }
            }
        }
    }
}

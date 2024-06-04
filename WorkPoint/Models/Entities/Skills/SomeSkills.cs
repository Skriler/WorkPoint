using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace WorkPoint.Models.Entities.Skills;

public abstract class SomeSkills
{
    [Key]
    public int Id { get; set; }

    public Dictionary<string, bool> GetSkillsAsDictionary()
    {
        var properties = GetSkillProperties();
        return properties.ToDictionary(prop => prop.Name, prop => (bool)prop.GetValue(this));
    }

    public List<string> GetSkillNames()
    {
        var properties = GetSkillProperties();
        return properties.Select(prop => prop.Name).ToList();
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

    private IEnumerable<PropertyInfo> GetSkillProperties()
    {
        return GetType().GetProperties()
            .Where(prop => prop.PropertyType == typeof(bool) && prop.GetCustomAttribute<RequiredAttribute>() != null);
    }
}

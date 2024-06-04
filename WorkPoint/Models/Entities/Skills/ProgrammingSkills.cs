using System.ComponentModel.DataAnnotations;

namespace WorkPoint.Models.Entities.Skills;

public class ProgrammingSkills : SomeSkills
{
    [Required]
    public bool HTML { get; set; }

    [Required]
    public bool CSS { get; set; }

    [Required]
    public bool Bootstrap { get; set; }

    [Required]
    public bool PHP { get; set; }

    [Required]
    public bool JS { get; set; }

    [Required]
    public bool React { get; set; }

    [Required]
    public bool NodeJS { get; set; }

    [Required]
    public bool Vue { get; set; }

    [Required]
    public bool Vuex { get; set; }

    [Required]
    [Display(Name = "REST API")]
    public bool RestAPI { get; set; }

    [Required]
    public bool Python { get; set; }

    [Required]
    public bool PyTest { get; set; }

    [Required]
    public bool Mocha { get; set; }

    [Required]
    public bool UnitTesting { get; set; }

    [Required]
    public bool TypeScript { get; set; }

    [Required]
    [Display(Name = "C++")]
    public bool CPlusPlus { get; set; }

    [Required]
    [Display(Name = "C#")]
    public bool CSharp { get; set; }

    [Required]
    [Display(Name = ".NET")]
    public bool DOTNET { get; set; }

    [Required]
    public bool HTTP { get; set; }

    [Required]
    public bool Dart { get; set; }

    [Required]
    public bool Flutter { get; set; }

    [Required]
    public bool Swift { get; set; }

    [Required]
    [Display(Name = "1C")]
    public bool OneC { get; set; }

    [Required]
    public bool WordPress { get; set; }

    [Required]
    public bool PrinciplesOOP { get; set; }

    [Required]
    public bool SolidPrinciples { get; set; }

    [Required]
    public bool Multithreading { get; set; }
}

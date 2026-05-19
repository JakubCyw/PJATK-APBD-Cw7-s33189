using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

[Table("ComponentManufacturers")]
public class ComponentManufacturers
{
    [Key]
    public int Id { get; set; }
    [MaxLength(30)]
    public string Abbreviation { get; set; } = String.Empty;
    [MaxLength(300)]
    public string FullName { get; set; } = String.Empty;
    [Column(TypeName = "date")]
    public DateOnly FoundationDate { get; set; }
    
    public IEnumerable<Components> ComponentTypes { get; set; } = [];
}
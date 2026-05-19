using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

[Table("ComponentTypes")]
public class ComponentTypes
{
    [Key]
    public int Id { get; set; }
    [MaxLength(30)]
    public string Abbreviation { get; set; } =  String.Empty;
    [MaxLength(150)]
    public string Name { get; set; } =  String.Empty;
    
    public IEnumerable<Components> PCComponents { get; set; } = [];
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

[Table("Components")]
public class Components
{
    [Key, Column(TypeName =  "char(10)")]
    public string Code { get; set; } =  String.Empty;
    [MaxLength(300)]
    public string Name { get; set; } =  String.Empty;
    public string Description { get; set; } =  String.Empty;
    public int ComponentManufacturersId { get; set; }
    public int ComponentTypesId { get; set; }
    
    public IEnumerable<PCComponents> PCComponents { get; set; } = [];
    [ForeignKey("ComponentTypesId")]
    public ComponentTypes ComponentTypes { get; set; } = null!;
    [ForeignKey("ComponentManufacturersId")]
    public ComponentManufacturers ComponentManufacturers { get; set; } = null!;

}
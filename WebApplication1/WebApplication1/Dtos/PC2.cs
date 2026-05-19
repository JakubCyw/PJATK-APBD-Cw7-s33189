using System.ComponentModel;

namespace WebApplication1.Dtos;

public record PC2(
    int Id,
    string Name,
    float Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock,
    IEnumerable<PCComponents> Components
    );

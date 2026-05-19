namespace WebApplication1.Dtos;

public record PC(
    int Id,
    string Name,
    float Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock
    );
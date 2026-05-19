namespace WebApplication1.Dtos;

public record CreatePC(
    string Name,
    float Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock
    );
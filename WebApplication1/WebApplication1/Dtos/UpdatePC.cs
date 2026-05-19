namespace WebApplication1.Dtos;

public record UpdatePC(
    string Name,
    float Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock
    );
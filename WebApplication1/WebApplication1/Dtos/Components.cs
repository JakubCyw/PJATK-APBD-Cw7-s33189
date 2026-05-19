namespace WebApplication1.Dtos;

public record Components(
    string Code,
    string Name,
    string Description,
    ComponentManufacturers Manufacturer,
    ComponentType Type
    );
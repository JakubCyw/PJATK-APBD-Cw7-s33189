namespace WebApplication1.Dtos;

public record ComponentManufacturers(
    int Id,
    string Abbreviation,
    string FullName,
    DateOnly FoundationDate
    );
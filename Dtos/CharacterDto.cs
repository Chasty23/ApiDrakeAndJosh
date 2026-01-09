using api.Models;

namespace api.Dtos;


public class CharacterDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; } = "Unknown";
    public required string NameRealComplete { get; set; } = "Unknown";
    public int IdGender { get; set; }
    public BirthDay? DateBirthDay { get; set; }
    public string? PathImage { get; set; }
}






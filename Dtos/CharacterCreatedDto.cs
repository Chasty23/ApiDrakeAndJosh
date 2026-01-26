using api.Models;

namespace api.Dtos;

public class CharacterCreatedDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string NameRealComplete { get; set; }
    public required int IdGender { get; set; }
    public required int IdPhrases { get; set; }
    public string PathImage { get; set; } = "Unknown";
    public BirthDay? DateBirthDay { get; set; }
}







using api.Models;

namespace api.Dtos;

public class CharacterCreatedDto
{
    public required string Name { get; set; }
    public string? Surname { get; set; }
    public required string NameRealComplete { get; set; }
    public required int IdGender { get; set; }
    public ICollection<int> IdPhrases { get; set; } = [];
    public string PathImage { get; set; } = "Unknown";
    public BirthDay DateBirthDay { get; set; } = new BirthDay(0, 0);
}







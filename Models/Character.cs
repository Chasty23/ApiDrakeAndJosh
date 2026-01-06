
namespace api.Models;

public record BirthDay(int Day, int Month);

public class Character
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Surname { get; set; } = "Unknown";
    public int IdGender { get; set; }
    public int IdPhrases { get; set; }
    public string PathImage { get; set; } = "Unknown";
    public BirthDay? DateBirthDay { get; set; }
    public Gender? Gender { get; set; }
    public Phrases? Phrases { get; set; }
}













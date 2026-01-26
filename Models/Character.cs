
namespace api.Models;

public record BirthDay(int? Day, int? Month);

public class Character
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Surname { get; set; } = "Unknown";
    public required string NameRealComplete { get; set; } = "Unknown";
    public required int IdGender { get; set; }
    public ICollection<Phrases> Phrases { get; set; } = [];
    public string PathImage { get; set; } = "Unknown";
    public BirthDay DateBirthDay { get; set; } = new BirthDay(0, 0);
    public Gender? Gender { get; set; }
}














namespace api.Models;

public class Phrases
{
    public int Id { get; set; }
    public required string Content { get; set; }

    public required int IdCharacter { get; set; }

    public Character? Character { get; set; }

}

















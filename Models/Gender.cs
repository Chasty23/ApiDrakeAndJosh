
namespace api.Models;

public class Gender
{
    public int Id { get; set; }
    public required string Name { get; set; } = "Male";

    public ICollection<Character> Characters { get; set; } = [];
}



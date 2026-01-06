using api.Models;

namespace api.Dtos;


public class CharacterDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Surname { get; set; }
    public int IdGender { get; set; }
    public int IdPhrases { get; set; }
    public BirthDay? DateBirthDay { get; set; }
    public string? PathImage { get; set; }
}






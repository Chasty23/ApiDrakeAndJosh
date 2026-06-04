using Riok.Mapperly.Abstractions;
using api.Models;
using api.Dtos;

namespace api.Mappers;

[Mapper]
public partial class CharacterMapper
{
    public CharacterDto ToDto(Character character)
    {
        ArgumentNullException.ThrowIfNull(character);

        return new CharacterDto
        {
            Id = character.Id,
            Name = character.Name,
            Surname = character.Surname ?? "Unknown",
            NameRealComplete = character.NameRealComplete,
            IdGender = character.IdGender,
            Gender = MapGenderById(character.IdGender),
            DateBirthDay = character.DateBirthDay,
            PathImage = character.PathImage
        };
    }

    private static string MapGenderById(int idGender)
    {
        return idGender == 2 ? "Female" : "Male";
    }

    [MapperIgnoreTarget(nameof(Character.Gender))]
    [MapperIgnoreTarget(nameof(Character.Phrases))]
    [MapperIgnoreSource(nameof(CharacterDto.Gender))]
    public partial Character ToCharacterDto(CharacterDto characterDto);

    [MapperIgnoreTarget(nameof(Character.Id))]
    [MapperIgnoreTarget(nameof(Character.Gender))]
    [MapperIgnoreTarget(nameof(Character.Phrases))]
    [MapperIgnoreSource(nameof(CharacterCreatedDto.IdPhrases))]
    public partial Character ToCreatedEntity(CharacterCreatedDto characterCreatedDto);

    [MapperIgnoreSource(nameof(Character.Id))]
    [MapperIgnoreSource(nameof(Character.Gender))]
    [MapperIgnoreSource(nameof(Character.Phrases))]
    [MapperIgnoreTarget(nameof(CharacterCreatedDto.IdPhrases))]
    public partial CharacterCreatedDto ToCharacterCreatedDto(Character character);
}

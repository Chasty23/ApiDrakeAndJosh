using Riok.Mapperly.Abstractions;
using api.Models;
using api.Dtos;

namespace api.Mappers;

[Mapper]
public partial class CharacterMapper
{
    [MapperIgnoreSource(nameof(Character.Gender))]
    [MapperIgnoreSource(nameof(Character.Phrases))]
    public partial CharacterDto ToDto(Character character);

    [MapperIgnoreTarget(nameof(Character.Gender))]
    [MapperIgnoreTarget(nameof(Character.Phrases))]
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

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
    public partial Character ToCreatedDto(CharacterCreatedDto characterCreatedDto);
}

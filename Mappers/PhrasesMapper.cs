using Riok.Mapperly.Abstractions;
using api.Models;
using api.Dtos;

namespace api.Mappers;

[Mapper]
public partial class PhrasesMapper
{
    [MapperIgnoreSource(nameof(Phrases.Character))]
    [MapperIgnoreSource(nameof(Phrases.Id))]
    public partial PhraseDto ToDto(Phrases phrase);


    [MapperIgnoreTarget(nameof(Phrases.Character))]
    [MapperIgnoreTarget(nameof(Phrases.Id))]
    public partial Phrases ToCreatedEntity(PhraseDto phraseDto);
}














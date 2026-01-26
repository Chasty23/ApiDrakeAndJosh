using api.Models;
using api.Dtos;
using FluentResults;
using api.Mappers;

namespace api.Services;

public class CharacterService : ICharacterService
{
    private readonly List<Character> _characters = [];
    private readonly CharacterMapper _characterMapper;

    public CharacterService(CharacterMapper characterMapper)
    {
        _characterMapper = characterMapper;
        _characters.Add(new Character
        {
            Id = 1,
            Name = "Drake",
            Surname = "Parker",
            NameRealComplete = "Drake Parker",
            IdGender = 1,
            PathImage = "",
            DateBirthDay = new BirthDay(21, 12)
        });
        _characters.Add(new Character
        {
            Id = 2,
            Name = "Josh",
            Surname = "Nicols",
            NameRealComplete = "Josh Nicols",
            IdGender = 1,
            PathImage = "",
            DateBirthDay = new BirthDay(22, 10)
        });
    }

    public Task<List<CharacterDto>> GetAll()
    {
        return Task.FromResult(_characters.Select(_characterMapper.ToDto).ToList());
    }

    public Task<Result<CharacterDto>> GetById(int id)
    {
        var character = _characters.FirstOrDefault(c => c.Id == id);

        return Task.FromResult(character == null ?
        Result.Fail("Character not found")
        : Result.Ok(_characterMapper.ToDto(character)));
    }

    public Task<Result<CharacterCreatedDto>> Add(CharacterCreatedDto character)
    {
        var newCharacter = _characterMapper.ToCreatedDto(character);
        if (newCharacter == null)
        {
            return Task.FromResult(Result.Fail<CharacterCreatedDto>("Character Not Created"));
        }
        _characters.Add(newCharacter);
        return Task.FromResult(Result.Ok(character));
    }

    public Task<Character> Update(int id, Character character)
    {
        var characterToUpdate = _characters.FirstOrDefault(c => c.Id == id);
        if (characterToUpdate == null)
        {
            return Task.FromResult(character);
        }
        characterToUpdate.Name = character.Name;
        characterToUpdate.Surname = character.Surname;
        characterToUpdate.IdGender = character.IdGender;
        characterToUpdate.Phrases = character.Phrases;
        characterToUpdate.PathImage = character.PathImage;
        characterToUpdate.DateBirthDay = character.DateBirthDay;
        return Task.FromResult(characterToUpdate);
    }


}















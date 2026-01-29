using api.Models;
using api.Dtos;
using FluentResults;
using api.Mappers;
using api.DbContextApp;
using Microsoft.EntityFrameworkCore;


namespace api.Services;

public class CharacterService : ICharacterService
{
    private readonly CharacterMapper _characterMapper;
    private readonly ILogger<CharacterService> _logger;
    private readonly AppContextDb _context;

    public CharacterService(CharacterMapper characterMapper, ILogger<CharacterService> logger, AppContextDb context)
    {
        _characterMapper = characterMapper;
        _logger = logger;
        _context = context;

    }

    public Task<List<CharacterDto>> GetAll()
    {
        return Task.FromResult(_context.Characters.Select(_characterMapper.ToDto).ToList());
    }

    public Task<Result<CharacterDto>> GetById(int id)
    {
        var character = _context.Characters.FirstOrDefault(c => c.Id == id);

        return Task.FromResult(character == null ?
        Result.Fail("Character not found")
        : Result.Ok(_characterMapper.ToDto(character)));
    }

    public async Task<Result<CharacterCreatedDto>> Add(CharacterCreatedDto characterDto)
    {

        var newCharacter = _characterMapper.ToCreatedEntity(characterDto);

        if (newCharacter == null)
        {
            return Result.Fail<CharacterCreatedDto>("Character Not Created");
        }
        var genderValid = await _context.Genders.FirstOrDefaultAsync(g => g.Id == characterDto.IdGender);
        if (genderValid == null)
        {
            return Result.Fail<CharacterCreatedDto>("Gender not found");
        }
        var phrasesValid = await _context.Phrases.Where(p => characterDto.IdPhrases.Contains(p.Id)).ToListAsync();
        if (phrasesValid.Count != characterDto.IdPhrases.Count)
        {
            return Result.Fail<CharacterCreatedDto>("Phrases not found");
        }

        _context.Characters.Add(newCharacter);
        _context.SaveChanges();
        _logger.LogDebug("Character added successfully");
        return Result.Ok(_characterMapper.ToCharacterCreatedDto(newCharacter));
    }

    public Task<Character> Update(int id, Character character)
    {
        var characterToUpdate = _context.Characters.FirstOrDefault(c => c.Id == id);
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
        _context.SaveChanges();
        _logger.LogDebug("Character updated successfully");
        return Task.FromResult(characterToUpdate);
    }


}















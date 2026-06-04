using api.Models;
using api.Dtos;
using FluentResults;
using api.Mappers;
using api.DbContextApp;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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

    public async Task<Result<List<CharacterDto>>> GetAll()
    {
        List<Character> characters = await _context.Characters.ToListAsync();
        if (characters == null)
        {
            return Result.Fail("Characters not found");
        }

        var charactersDto = characters.Select(c => _characterMapper.ToDto(c)).ToList();
        return Result.Ok(charactersDto);
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
        await _context.SaveChangesAsync();
        _logger.LogDebug("Character added successfully");
        return Result.Ok(_characterMapper.ToCharacterCreatedDto(newCharacter));
    }

    public async Task<Result<CharacterCreatedDto>> Update(int id, CharacterCreatedDto characterDto)
    {
        if (characterDto == null)
        {
            return Result.Fail<CharacterCreatedDto>("Invalid character data");
        }
        var characterToUpdate = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
        if (characterToUpdate == null)
        {
            return Result.Fail<CharacterCreatedDto>("Character not found");
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

        characterToUpdate.Name = characterDto.Name;
        characterToUpdate.Surname = characterDto.Surname;
        characterToUpdate.NameRealComplete = characterDto.NameRealComplete;
        characterToUpdate.IdGender = characterDto.IdGender;
        characterToUpdate.Phrases = phrasesValid;
        characterToUpdate.PathImage = characterDto.PathImage;
        characterToUpdate.DateBirthDay = characterDto.DateBirthDay;
        await _context.SaveChangesAsync();

        _logger.LogDebug("Character updated successfully");
        return Result.Ok(_characterMapper.ToCharacterCreatedDto(characterToUpdate));
    }


}















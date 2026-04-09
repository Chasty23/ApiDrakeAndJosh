using api.Dtos;
using FluentResults;
using api.Models;
using api.DbContextApp;
using api.Mappers;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace api.Services;

public class PhraseService : IPhraseService
{
    private readonly AppContextDb _context;
    private readonly ILogger<PhraseService> _logger;

    private readonly PhrasesMapper _mapper;

    public PhraseService(AppContextDb context, ILogger<PhraseService> logger, PhrasesMapper mapper)
    {
        _context = context;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<Result<List<PhraseDto>>> GetAll()
    {
        var entities = await _context.Phrases.ToListAsync();

        if (entities == null || !entities.Any())
        {
            return Result.Fail("Phrases not found");
        }

        var phrasesDtos = entities.Select(p => _mapper.ToDto(p)).ToList();
        return Result.Ok(phrasesDtos);
    }
    public async Task<Result<PhraseDto>> Add(PhraseDto phrase)
    {
        if (phrase == null)
        {
            return await Task.FromResult(Result.Fail("Phrase is null"));
        }
        var characterExists = await _context.Characters.AnyAsync(c => c.Id == phrase.IdCharacter);
        if (!characterExists)
        {
            return await Task.FromResult(Result.Fail("Character does not exist"));
        }
        var phraseEntity = _mapper.ToCreatedEntity(phrase);

        await _context.Phrases.AddAsync(phraseEntity);

        await _context.SaveChangesAsync();

        _logger.LogDebug("Phrase added successfully");

        return await Task.FromResult(Result.Ok(_mapper.ToDto(phraseEntity)));

    }

}













using api.Dtos;
using api.DbContextApp;
using api.Mappers;
using Microsoft.EntityFrameworkCore;
using FluentResults;


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
            _logger.LogWarning("Attempted to add a null phrase");
            return await Task.FromResult(Result.Fail("Phrase is null"));
        }
        var characterExists = await _context.Characters.AnyAsync(c => c.Id == phrase.IdCharacter);
        if (!characterExists)
        {
            _logger.LogWarning("Attempted to add a phrase for a non-existent character with ID {CharacterId}", phrase.IdCharacter);
            return await Task.FromResult(Result.Fail("Character does not exist"));
        }
        var phraseEntity = _mapper.ToCreatedEntity(phrase);
        if (phraseEntity.Content == null || phraseEntity.Content == "")
        {
            _logger.LogWarning("Attempted to add a phrase with null or empty content");
            return await Task.FromResult(Result.Fail("Phrase content is null or empty"));
        }
        var verifyCharacter = await _context.Characters.FindAsync(phrase.IdCharacter);
        if (verifyCharacter == null)
        {
            _logger.LogWarning("Attempted to add a phrase for a non-existent character with ID {CharacterId}", phrase.IdCharacter);
            return await Task.FromResult(Result.Fail("Character does not exist"));
        }

        await _context.Phrases.AddAsync(phraseEntity);

        await _context.SaveChangesAsync();

        _logger.LogDebug("Phrase added successfully");
        return await Task.FromResult(Result.Ok(_mapper.ToDto(phraseEntity)));
    }

    public async Task<Result<PhraseDto>> Update(int id, PhraseDto phrase)
    {
        var existingPhrase = await _context.Phrases.FindAsync(id);
        if (existingPhrase == null)
        {
            _logger.LogWarning("Attempted to update a non-existent phrase with ID {PhraseId}", id);
            return Result.Fail("Phrase not found");
        }

        if (phrase.Content == null || phrase.Content.Trim() == "")
        {
            _logger.LogWarning("Attempted to update a phrase with null or empty content for Phrase ID {PhraseId}", id);
            return Result.Fail("Phrase content cannot be null or empty");
        }

        existingPhrase.Content = phrase.Content;
        existingPhrase.IdCharacter = phrase.IdCharacter;

        _context.Phrases.Update(existingPhrase);
        await _context.SaveChangesAsync();

        _logger.LogDebug("Phrase with ID {PhraseId} updated successfully", id);
        return Result.Ok(_mapper.ToDto(existingPhrase));
    }

    public async Task<Result<PhraseDto>> Delete(int id)
    {
        var existingPhrase = await _context.Phrases.FindAsync(id);
        if (existingPhrase == null)
        {
            _logger.LogWarning("Attempted to delete a non-existent phrase with ID {PhraseId}", id);
            return Result.Fail("Phrase not found");
        }

        _context.Phrases.Remove(existingPhrase);
        await _context.SaveChangesAsync();

        _logger.LogDebug("Phrase with ID {PhraseId} deleted successfully", id);
        return Result.Ok(_mapper.ToDto(existingPhrase));

    }

}













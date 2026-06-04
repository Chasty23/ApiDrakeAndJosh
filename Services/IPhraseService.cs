using api.Dtos;
using FluentResults;


namespace api.Services;

public interface IPhraseService
{
    Task<Result<List<PhraseDto>>> GetAll();

    Task<Result<PhraseDto>> Add(PhraseDto phrase);
    Task<Result<PhraseDto>> Update(int id, PhraseDto phrase);
    Task<Result<PhraseDto>> Delete(int id);
}












using api.Dtos;
using FluentResults;


namespace api.Services;

public interface IPhraseService
{
    Task<List<PhraseDto>> GetAll();

    Task<Result<PhraseDto>> Add(PhraseDto phrase);

}












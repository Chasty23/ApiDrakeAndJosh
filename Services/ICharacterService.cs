using api.Models;
using FluentResults;
using api.Dtos;
namespace api.Services;

public interface ICharacterService
{
    Task<Result<List<CharacterDto>>> GetAll();
    Task<Result<CharacterDto>> GetById(int id);
    Task<Result<CharacterCreatedDto>> Add(CharacterCreatedDto character);
    Task<Result<CharacterCreatedDto>> Update(int id, CharacterCreatedDto character);
    /*Task<Character> Delete(int id);*/
}






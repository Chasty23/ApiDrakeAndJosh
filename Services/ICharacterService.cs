using api.Models;
using FluentResults;
using api.Dtos;
namespace api.Services;

public interface ICharacterService
{
    Task<List<CharacterDto>> GetAll();
    Task<Result<CharacterDto>> GetById(int id);
    Task<Result<CharacterCreatedDto>> Add(CharacterCreatedDto character);
    Task<Character> Update(int id, Character character);
    /*Task<Character> Delete(int id);*/
}






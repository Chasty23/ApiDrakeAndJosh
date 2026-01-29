using api.Models;
using FluentResults;
using api.Dtos;
namespace api.Services;


public interface IGenderService
{
    Task<List<GenderDto>> GetAll();
    //Task<Gender> GetById(int id);
    Task<Result<Gender>> Create(Gender gender);
    //Task<Gender> Update(int id, Gender gender);
    //Task Delete(int id);
}













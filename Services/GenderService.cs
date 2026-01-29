using api.Models;
using api.DbContextApp;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using api.Dtos;
namespace api.Services;


public class GenderService : IGenderService
{
    private readonly AppContextDb _context;
    private readonly ILogger<GenderService> _logger;

    public GenderService(AppContextDb context, ILogger<GenderService> logger)
    {
        _context = context;
        _logger = logger;
    }


    public async Task<List<GenderDto>> GetAll()
    {
        var genders = await _context.Genders
        .Select(g => new GenderDto { Name = g.Name }).ToListAsync();

        return genders;
    }

    public async Task<Result<Gender>> Create(Gender gender)
    {
        _context.Genders.Add(gender);
        await _context.SaveChangesAsync();
        return Result.Ok(gender);
    }

}







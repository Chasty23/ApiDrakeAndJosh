using Microsoft.AspNetCore.Mvc;
using api.Dtos;
using api.Services;
using api.Utils;
using api.Models;

namespace api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GenderController(IGenderService genderService) : ControllerResponse
{

    private readonly IGenderService _genderService = genderService;

    [HttpGet]
    public async Task<ActionResult<List<GenderDto>>> GetAll()
    {
        var genders = await _genderService.GetAll();

        return SuccessResponse(genders, "Genders", StatusCodes.Status200OK);
    }
    [HttpPost]
    public async Task<ActionResult<GenderDto>> Create([FromBody] GenderDto genderDto)
    {
        var gender = new Gender
        {
            Name = genderDto.Name
        };
        var genderCreate = await _genderService.Create(gender);
        if (genderCreate.IsFailed)
        {
            var errorMessage = genderCreate.Errors[0].Message;
            return ErrorResponse(errorMessage, StatusCodes.Status400BadRequest);
        }

        return SuccessResponse(genderCreate.Value, "Gender Added", StatusCodes.Status201Created);


    }

}









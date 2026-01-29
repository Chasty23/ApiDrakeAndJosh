using Microsoft.AspNetCore.Mvc;
using api.Services;
using api.Models;
using api.Utils;
using FluentResults;
using api.Dtos;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CharacterController : ControllerResponse
{
    private readonly ICharacterService _characterService;

    public CharacterController(ICharacterService characterService)
    {
        _characterService = characterService;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var characters = await _characterService.GetAll();
        if (characters.Count == 0)
        {
            return SuccessResponse(characters, "Empty Characters");
        }
        return SuccessResponse(characters);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var character = await _characterService.GetById(id);
        if (character.IsFailed)
        {
            var errorMessage = character.Errors[0].Message;
            return ErrorResponse(errorMessage, StatusCodes.Status404NotFound);
        }

        return SuccessResponse(character.Value, "Character Found");
    }

    [HttpPost]
    public async Task<ActionResult<CharacterCreatedDto>> Add(CharacterCreatedDto characterDto)
    {


        var newCharacter = await _characterService.Add(characterDto);
        if (newCharacter.IsFailed)
        {
            var errorMessage = newCharacter.Errors[0].Message;
            return ErrorResponse(errorMessage, StatusCodes.Status400BadRequest);
        }

        return SuccessResponse(newCharacter.Value, "Character Added", StatusCodes.Status201Created);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] Character character)
    {
        var updatedCharacter = await _characterService.Update(id, character);
        return SuccessResponse(updatedCharacter, "Character Updated");
    }


}











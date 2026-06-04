using Microsoft.AspNetCore.Mvc;
using api.Utils;
using api.Services;
using api.Dtos;
using api.Models;
using FluentResults;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PhraseController : ControllerResponse
{
    private readonly IPhraseService _phraseService;

    public PhraseController(IPhraseService phraseService)
    {
        _phraseService = phraseService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _phraseService.GetAll();
        if (result.IsFailed)
        {
            var errorMessage = result.Errors[0].Message;
            return ErrorResponse(errorMessage, StatusCodes.Status400BadRequest);
        }
        return SuccessResponse(result.Value);
    }

    [HttpPost]
    public async Task<ActionResult> Add([FromBody] PhraseDto phrase)
    {
        var result = await _phraseService.Add(phrase);

        if (result.IsFailed)
        {
            return ErrorResponse(result.Errors[0].Message, StatusCodes.Status400BadRequest);
        }
        return SuccessResponse(result.Value);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] PhraseDto phrase)
    {
        var result = await _phraseService.Update(id, phrase);
        if (result.IsFailed)
        {
            return ErrorResponse(result.Errors[0].Message, StatusCodes.Status400BadRequest);
        }
        return SuccessResponse(result.Value);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var result = await _phraseService.Delete(id);
        if (result.IsFailed)
        {
            return ErrorResponse(result.Errors[0].Message, StatusCodes.Status400BadRequest);
        }
        return SuccessResponse(result.Value);
    }

}








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

    [HttpPost]
    public async Task<ActionResult> Add([FromBody] PhraseDto phrase)
    {
        var result = await _phraseService.Add(phrase);

        if (result.IsFailed)
        {
            return ErrorResponse("Error al agregar la frase", 400);
        }
        return SuccessResponse(result.Value);
    }




}








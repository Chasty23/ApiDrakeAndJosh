using FluentValidation;
using Scalar.AspNetCore;
using api.Services;
using api.Mappers;
using api.Validators;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using Microsoft.EntityFrameworkCore;
using api.DbContextApp;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddScoped<ICharacterService, CharacterService>();
builder.Services.AddScoped<IGenderService, GenderService>();
builder.Services.AddScoped<IPhraseService, PhraseService>();

builder.Services.AddScoped<CharacterMapper>();
builder.Services.AddScoped<PhrasesMapper>();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CharacterValidator>();
builder.Services.AddDbContextPool<AppContextDb>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options
            .WithTitle("Api Drake and Josh")
            .WithTheme(ScalarTheme.Kepler)
            .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
    });
}

app.MapControllers();


app.Run();

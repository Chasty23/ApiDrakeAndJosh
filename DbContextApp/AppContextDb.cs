using Microsoft.EntityFrameworkCore;
using api.Models;
using api.DbContextApp.Configurations;
namespace api.DbContextApp;

public class AppContextDb : DbContext
{
    public DbSet<Character> Characters { get; set; }
    public DbSet<Gender> Genders { get; set; }
    public DbSet<Phrases> Phrases { get; set; }

    public AppContextDb(DbContextOptions<AppContextDb> options) : base(options)
    {


    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new CharacterConfig());
        builder.ApplyConfiguration(new GenderConfig());
        builder.ApplyConfiguration(new PhrasesConfig());


        base.OnModelCreating(builder);
    }

}








using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using api.Models;

namespace api.DbContextApp.Configurations;

public class CharacterConfig : IEntityTypeConfiguration<Character>
{
    public void Configure(EntityTypeBuilder<Character> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
        .ValueGeneratedOnAdd()
        .UseIdentityColumn();

        builder.HasOne(c => c.Gender)
        .WithMany(g => g.Characters)
        .HasForeignKey(c => c.IdGender).OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(c => c.Phrases)
        .WithOne(p => p.Character)
        .HasForeignKey(p => p.IdCharacter).OnDelete(DeleteBehavior.Cascade);

        builder.Property(c => c.Name)
        .IsRequired()
        .HasColumnType("varchar(50)")
        .HasMaxLength(50);

        builder.Property(c => c.Surname)
        .HasColumnType("varchar(50)")
        .HasDefaultValue("Unknown")
        .HasMaxLength(50);

        builder.Property(c => c.NameRealComplete)
        .HasColumnType("varchar(200)")
        .HasDefaultValue("Unknown")
        .HasMaxLength(200);


        builder.Property(c => c.PathImage)
        .HasColumnType("varchar(255)")
        .HasDefaultValue("Unknown")
        .HasMaxLength(255);

        builder.ComplexProperty(c => c.DateBirthDay, statsDateBuilder =>
        {
            // Configuración del Dia
            statsDateBuilder.Property(b => b.Day)
                .HasColumnName("Day");


            // Configuración del Mes
            statsDateBuilder.Property(b => b.Month)
                .HasColumnName("Month");

        });

        // Las restricciones de verificación para el mes y dia
        builder.ToTable(t =>
        {
            // Restricción para el Día: entre 1 y 31
            t.HasCheckConstraint("CK_Character_Day_Range", "(\"Day\" IS NULL OR (\"Day\" >= 1 AND \"Day\" <= 31))");
            t.HasCheckConstraint("CK_Character_Month_Range", "(\"Month\" IS NULL OR (\"Month\" >= 1 AND \"Month\" <= 12))");
        });


    }
}







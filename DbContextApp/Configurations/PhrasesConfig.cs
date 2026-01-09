using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using api.Models;

namespace api.DbContextApp.Configurations;


public class PhrasesConfig : IEntityTypeConfiguration<Phrases>
{
    public void Configure(EntityTypeBuilder<Phrases> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
        .ValueGeneratedOnAdd()
        .UseIdentityColumn();

        builder.Property(p => p.Content)
        .IsRequired()
        .HasColumnType("varchar(255)")
        .HasMaxLength(255);
    }
}




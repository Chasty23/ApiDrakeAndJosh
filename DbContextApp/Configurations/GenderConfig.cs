using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using api.Models;


namespace api.DbContextApp.Configurations;


public class GenderConfig : IEntityTypeConfiguration<Gender>
{
    public void Configure(EntityTypeBuilder<Gender> builder)
    {
        builder.HasKey(g => g.Id);
        builder.Property(g => g.Id)
        .ValueGeneratedOnAdd()
        .UseIdentityColumn();

        builder.Property(g => g.Name)
        .IsRequired()
        .HasDefaultValue("Male")
        .HasColumnType("varchar(10)")
        .HasMaxLength(10);
    }
}






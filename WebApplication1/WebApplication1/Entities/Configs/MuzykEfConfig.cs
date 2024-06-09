using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication1.Entities.Configs;

public class MuzykEfConfig : IEntityTypeConfiguration<Muzyk>
{
    public void Configure(EntityTypeBuilder<Muzyk> builder)
    {
        builder.HasKey(m => m.IdMuzyk).HasName("IdMuzyk");
        builder.Property(m => m.IdMuzyk).UseIdentityColumn();

        builder.Property(m => m.Imie).IsRequired().HasMaxLength(30);
        builder.Property(m => m.Nazwisko).IsRequired().HasMaxLength(40);
        builder.Property(m => m.Pseudonim).HasMaxLength(50);

        builder.ToTable("Muzyk");

        builder.HasMany(x => x.IdUtwor)
            .WithMany(x => x.IdMuzyk)
            .UsingEntity<Dictionary<object, string>>(
                "WykonawacaUtworu",
                j => j.HasOne<Utwor>().WithMany().HasPrincipalKey("IdUtwor"),
                j => j.HasOne<Muzyk>().WithMany().HasForeignKey("IdMuzyk"))
            .HasData(
                new { IdMuzyk = 2, IdUtwor = 1 },
                new { IdMuzyk = 2, IdUtwor = 2 },
                new { IdMuzyk = 1, IdUtwor = 3 });


    Muzyk[] muzyks =
        {
            new Muzyk()
            {
                IdMuzyk = 1, Imie = "Anna", Nazwisko = "Nowak"
            },
            new Muzyk()
            {
                IdMuzyk = 2, Imie = "Kazimierz", Nazwisko = "Malinowski", Pseudonim = "Kazik"
            }
        };

        builder.HasData(muzyks);
    }
}
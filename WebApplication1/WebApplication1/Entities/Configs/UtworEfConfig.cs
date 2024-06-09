using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication1.Entities.Configs;

public class UtworEfConfig : IEntityTypeConfiguration<Utwor>
{
    public void Configure(EntityTypeBuilder<Utwor> builder)
    {
        builder.HasKey(m => m.IdUtwor).HasName("IdUtwor");
        builder.Property(m => m.IdUtwor).UseIdentityColumn();

        builder.Property(m => m.NazwaUtworu).IsRequired().HasMaxLength(30);
        builder.Property(m => m.CzasTrwania).IsRequired();

        builder.ToTable("Utwor");

        Utwor[] utwors =
        {
            new Utwor()
            {
                IdUtwor = 1, NazwaUtworu = "spiewanie", CzasTrwania = 2.20F
            },
            new Utwor()
            {
                IdUtwor = 2, NazwaUtworu = "granie", CzasTrwania = 3.50F
            },
            new Utwor()
            {
                IdUtwor = 3, NazwaUtworu = "Gitara", CzasTrwania = 5.30F
            }
        };
            
            
        builder.HasData(utwors);
    }
}
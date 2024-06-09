﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Entities;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(MusicDbContext))]
    partial class MusicDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1.Entities.Muzyk", b =>
                {
                    b.Property<int>("IdMuzyk")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMuzyk"));

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Pseudonim")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdMuzyk")
                        .HasName("IdMuzyk");

                    b.ToTable("Muzyk", (string)null);

                    b.HasData(
                        new
                        {
                            IdMuzyk = 1,
                            Imie = "Anna",
                            Nazwisko = "Nowak"
                        },
                        new
                        {
                            IdMuzyk = 2,
                            Imie = "Kazimierz",
                            Nazwisko = "Malinowski",
                            Pseudonim = "Kazik"
                        });
                });

            modelBuilder.Entity("WebApplication1.Entities.Utwor", b =>
                {
                    b.Property<int>("IdUtwor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUtwor"));

                    b.Property<float>("CzasTrwania")
                        .HasColumnType("real");

                    b.Property<string>("NazwaUtworu")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("IdUtwor")
                        .HasName("IdUtwor");

                    b.ToTable("Utwor", (string)null);

                    b.HasData(
                        new
                        {
                            IdUtwor = 1,
                            CzasTrwania = 2.2f,
                            NazwaUtworu = "spiewanie"
                        },
                        new
                        {
                            IdUtwor = 2,
                            CzasTrwania = 3.5f,
                            NazwaUtworu = "granie"
                        },
                        new
                        {
                            IdUtwor = 3,
                            CzasTrwania = 5.3f,
                            NazwaUtworu = "Gitara"
                        });
                });

            modelBuilder.Entity("WykonawacaUtworu", b =>
                {
                    b.Property<int>("IdMuzyk")
                        .HasColumnType("int");

                    b.Property<int>("IdUtwor")
                        .HasColumnType("int");

                    b.HasKey("IdMuzyk", "IdUtwor");

                    b.HasIndex("IdUtwor");

                    b.ToTable("WykonawacaUtworu");

                    b.HasData(
                        new
                        {
                            IdMuzyk = 2,
                            IdUtwor = 1
                        },
                        new
                        {
                            IdMuzyk = 2,
                            IdUtwor = 2
                        },
                        new
                        {
                            IdMuzyk = 1,
                            IdUtwor = 3
                        });
                });

            modelBuilder.Entity("WykonawacaUtworu", b =>
                {
                    b.HasOne("WebApplication1.Entities.Muzyk", null)
                        .WithMany()
                        .HasForeignKey("IdMuzyk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Entities.Utwor", null)
                        .WithMany()
                        .HasForeignKey("IdUtwor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using moviefinder.Entities;

#nullable disable

namespace moviefinder.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230605020333_migrationprod")]
    partial class migrationprod
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("moviefinder.Entities.Ator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TheMovieDbId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Atores");
                });

            modelBuilder.Entity("moviefinder.Entities.AtorFavorito", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Atores")
                        .HasColumnType("int");

                    b.Property<int>("Usuarios")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Atores");

                    b.HasIndex("Usuarios");

                    b.ToTable("AtoresFavoritos");
                });

            modelBuilder.Entity("moviefinder.Entities.Filme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TheMovieDbId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Filmes");
                });

            modelBuilder.Entity("moviefinder.Entities.FilmeFavorito", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Filmes")
                        .HasColumnType("int");

                    b.Property<int>("Usuarios")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Filmes");

                    b.HasIndex("Usuarios");

                    b.ToTable("FilmesFavoritos");
                });

            modelBuilder.Entity("moviefinder.Entities.Genero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TheMovieDbId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("moviefinder.Entities.GeneroFavorito", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Generos")
                        .HasColumnType("int");

                    b.Property<int>("Usuarios")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Generos");

                    b.HasIndex("Usuarios");

                    b.ToTable("GenerosFavoritos");
                });

            modelBuilder.Entity("moviefinder.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("moviefinder.Entities.AtorFavorito", b =>
                {
                    b.HasOne("moviefinder.Entities.Ator", "IdAtor")
                        .WithMany()
                        .HasForeignKey("Atores")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("moviefinder.Entities.Usuario", "IdUsuario")
                        .WithMany()
                        .HasForeignKey("Usuarios")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdAtor");

                    b.Navigation("IdUsuario");
                });

            modelBuilder.Entity("moviefinder.Entities.FilmeFavorito", b =>
                {
                    b.HasOne("moviefinder.Entities.Filme", "IdFilme")
                        .WithMany()
                        .HasForeignKey("Filmes")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("moviefinder.Entities.Usuario", "IdUsuario")
                        .WithMany()
                        .HasForeignKey("Usuarios")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdFilme");

                    b.Navigation("IdUsuario");
                });

            modelBuilder.Entity("moviefinder.Entities.GeneroFavorito", b =>
                {
                    b.HasOne("moviefinder.Entities.Genero", "IdGenero")
                        .WithMany()
                        .HasForeignKey("Generos")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("moviefinder.Entities.Usuario", "IdUsuario")
                        .WithMany()
                        .HasForeignKey("Usuarios")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdGenero");

                    b.Navigation("IdUsuario");
                });
#pragma warning restore 612, 618
        }
    }
}

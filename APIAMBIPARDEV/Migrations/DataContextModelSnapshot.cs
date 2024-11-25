﻿// <auto-generated />
using System;
using APIAMBIPARDEV.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APIAMBIPARDEV.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("APIAMBIPARDEV.Modelo.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("APIAMBIPARDEV.Modelo.Ocorrencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Conclusao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataAbertura")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataOcorrencia")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ResponsavelAberturaId")
                        .HasColumnType("int");

                    b.Property<int>("ResponsavelOcorrenciaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ResponsavelAberturaId");

                    b.HasIndex("ResponsavelOcorrenciaId");

                    b.ToTable("Ocorrencias");
                });

            modelBuilder.Entity("APIAMBIPARDEV.Modelo.Ocorrencia", b =>
                {
                    b.HasOne("APIAMBIPARDEV.Modelo.Cliente", "ResponsavelAbertura")
                        .WithMany("OcorrenciasAbertas")
                        .HasForeignKey("ResponsavelAberturaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("APIAMBIPARDEV.Modelo.Cliente", "ResponsavelOcorrencia")
                        .WithMany("OcorrenciasResponsaveis")
                        .HasForeignKey("ResponsavelOcorrenciaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ResponsavelAbertura");

                    b.Navigation("ResponsavelOcorrencia");
                });

            modelBuilder.Entity("APIAMBIPARDEV.Modelo.Cliente", b =>
                {
                    b.Navigation("OcorrenciasAbertas");

                    b.Navigation("OcorrenciasResponsaveis");
                });
#pragma warning restore 612, 618
        }
    }
}

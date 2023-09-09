﻿// <auto-generated />
using System;
using LocBike.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LocBike.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230909031615_atualizandoTabelaCliente")]
    partial class atualizandoTabelaCliente
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.21");

            modelBuilder.Entity("LocBike.Models.ClienteModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("Telefone")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("Nome")
                        .IsUnique();

                    b.HasIndex("Telefone")
                        .IsUnique();

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("LocBike.Models.LocacaoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataDevolucao")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataLocacao")
                        .HasColumnType("TEXT");

                    b.Property<string>("NomeCliente")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("ValorDiaria")
                        .HasColumnType("REAL");

                    b.Property<double>("ValorTotal")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("NomeCliente")
                        .IsUnique();

                    b.ToTable("Locacao");
                });
#pragma warning restore 612, 618
        }
    }
}

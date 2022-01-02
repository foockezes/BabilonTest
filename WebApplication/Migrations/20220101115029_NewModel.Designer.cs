﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication;

namespace WebApplication.Migrations
{
    [DbContext(typeof(QuotesDBContext))]
    [Migration("20220101115029_NewModel")]
    partial class NewModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("WebApplication.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Balance")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Identification")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9327f9ff-b974-47d4-8260-7b8923160c74"),
                            Balance = 0m,
                            Identification = true,
                            LastName = "Boluevna",
                            Name = "Olucha"
                        },
                        new
                        {
                            Id = new Guid("c986f286-0a2a-41f2-bdba-b88b8fa3f055"),
                            Balance = 0m,
                            Identification = true,
                            LastName = "holova",
                            Name = "Anora"
                        });
                });

            modelBuilder.Entity("WebApplication.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Sum")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("transactions");
                });

            modelBuilder.Entity("WebApplication.Transaction", b =>
                {
                    b.HasOne("WebApplication.Client", "Client")
                        .WithMany("Transactions")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("WebApplication.Client", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
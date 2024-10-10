﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Organizer.Data;

#nullable disable

namespace Organizer.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241010183202_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.DataProtection.EntityFrameworkCore.DataProtectionKey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FriendlyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Xml")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DataProtectionKeys");
                });

            modelBuilder.Entity("Organizer.Data.Models.Player", b =>
                {
                    b.Property<string>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasHalfPointBye")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumGamesAsBlack")
                        .HasColumnType("int");

                    b.Property<int>("NumGamesAsWhite")
                        .HasColumnType("int");

                    b.Property<string>("PlayerId1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Rating")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ReceivedFullPointBye")
                        .HasColumnType("bit");

                    b.Property<double>("Score")
                        .HasColumnType("float");

                    b.Property<string>("TournamentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("PlayerId");

                    b.HasIndex("PlayerId1");

                    b.HasIndex("TournamentId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Organizer.Data.Models.Tournament", b =>
                {
                    b.Property<string>("TournamentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CurrentRound")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("TournamentId");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("Organizer.Data.Models.Player", b =>
                {
                    b.HasOne("Organizer.Data.Models.Player", null)
                        .WithMany("PastOpponents")
                        .HasForeignKey("PlayerId1")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Organizer.Data.Models.Tournament", "Tournament")
                        .WithMany("Players")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("Organizer.Data.Models.Player", b =>
                {
                    b.Navigation("PastOpponents");
                });

            modelBuilder.Entity("Organizer.Data.Models.Tournament", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
﻿// <auto-generated />
using System;
using Draft.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Draft.Migrations
{
    [DbContext(typeof(DraftContext))]
    partial class DraftContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Draft.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("ClubName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhotoPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PositionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Draft.Models.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("Draft.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Deffender1Id")
                        .HasColumnType("int");

                    b.Property<int?>("Deffender2Id")
                        .HasColumnType("int");

                    b.Property<int?>("Deffender3Id")
                        .HasColumnType("int");

                    b.Property<int?>("Deffender4Id")
                        .HasColumnType("int");

                    b.Property<int?>("Forward1Id")
                        .HasColumnType("int");

                    b.Property<int?>("Forward2Id")
                        .HasColumnType("int");

                    b.Property<int?>("GoalkeeperId")
                        .HasColumnType("int");

                    b.Property<int?>("Midfielder1Id")
                        .HasColumnType("int");

                    b.Property<int?>("Midfielder2Id")
                        .HasColumnType("int");

                    b.Property<int?>("Midfielder3Id")
                        .HasColumnType("int");

                    b.Property<int?>("Midfielder4Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Deffender1Id");

                    b.HasIndex("Deffender2Id");

                    b.HasIndex("Deffender3Id");

                    b.HasIndex("Deffender4Id");

                    b.HasIndex("Forward1Id");

                    b.HasIndex("Forward2Id");

                    b.HasIndex("GoalkeeperId");

                    b.HasIndex("Midfielder1Id");

                    b.HasIndex("Midfielder2Id");

                    b.HasIndex("Midfielder3Id");

                    b.HasIndex("Midfielder4Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Draft.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.Property<int>("UserRole")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TeamId")
                        .IsUnique()
                        .HasFilter("[TeamId] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Draft.Models.Player", b =>
                {
                    b.HasOne("Draft.Models.Position", "Position")
                        .WithMany("Players")
                        .HasForeignKey("PositionId");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("Draft.Models.Team", b =>
                {
                    b.HasOne("Draft.Models.Player", "Deffender1")
                        .WithMany()
                        .HasForeignKey("Deffender1Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Draft.Models.Player", "Deffender2")
                        .WithMany()
                        .HasForeignKey("Deffender2Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Draft.Models.Player", "Deffender3")
                        .WithMany()
                        .HasForeignKey("Deffender3Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Draft.Models.Player", "Deffender4")
                        .WithMany()
                        .HasForeignKey("Deffender4Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Draft.Models.Player", "Forward1")
                        .WithMany()
                        .HasForeignKey("Forward1Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Draft.Models.Player", "Forward2")
                        .WithMany()
                        .HasForeignKey("Forward2Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Draft.Models.Player", "Goalkeeper")
                        .WithMany()
                        .HasForeignKey("GoalkeeperId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Draft.Models.Player", "Midfielder1")
                        .WithMany()
                        .HasForeignKey("Midfielder1Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Draft.Models.Player", "Midfielder2")
                        .WithMany()
                        .HasForeignKey("Midfielder2Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Draft.Models.Player", "Midfielder3")
                        .WithMany()
                        .HasForeignKey("Midfielder3Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Draft.Models.Player", "Midfielder4")
                        .WithMany()
                        .HasForeignKey("Midfielder4Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Deffender1");

                    b.Navigation("Deffender2");

                    b.Navigation("Deffender3");

                    b.Navigation("Deffender4");

                    b.Navigation("Forward1");

                    b.Navigation("Forward2");

                    b.Navigation("Goalkeeper");

                    b.Navigation("Midfielder1");

                    b.Navigation("Midfielder2");

                    b.Navigation("Midfielder3");

                    b.Navigation("Midfielder4");
                });

            modelBuilder.Entity("Draft.Models.User", b =>
                {
                    b.HasOne("Draft.Models.Team", "Team")
                        .WithOne()
                        .HasForeignKey("Draft.Models.User", "TeamId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Draft.Models.Position", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}

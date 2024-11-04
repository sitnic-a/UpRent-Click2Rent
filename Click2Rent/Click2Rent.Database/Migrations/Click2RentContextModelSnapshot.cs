﻿// <auto-generated />
using System;
using Click2Rent.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Click2Rent.Database.Migrations
{
    [DbContext(typeof(Click2RentContext))]
    partial class Click2RentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Click2Rent.Domain.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CreatedByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("Locked")
                        .HasColumnType("bit");

                    b.Property<int>("ModifiedByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.Property<bool>("Visible")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedByUserId = 0,
                            CreatedDate = new DateTime(2024, 11, 4, 17, 46, 17, 561, DateTimeKind.Local).AddTicks(173),
                            IsDeleted = false,
                            Locked = false,
                            ModifiedByUserId = 0,
                            ModifiedDate = new DateTime(2024, 11, 4, 17, 46, 17, 561, DateTimeKind.Local).AddTicks(224),
                            Name = "Administrator",
                            Version = 0,
                            Visible = true
                        },
                        new
                        {
                            Id = 2,
                            CreatedByUserId = 0,
                            CreatedDate = new DateTime(2024, 11, 4, 17, 46, 17, 561, DateTimeKind.Local).AddTicks(227),
                            IsDeleted = false,
                            Locked = false,
                            ModifiedByUserId = 0,
                            ModifiedDate = new DateTime(2024, 11, 4, 17, 46, 17, 561, DateTimeKind.Local).AddTicks(229),
                            Name = "User",
                            Version = 0,
                            Visible = true
                        },
                        new
                        {
                            Id = 3,
                            CreatedByUserId = 0,
                            CreatedDate = new DateTime(2024, 11, 4, 17, 46, 17, 561, DateTimeKind.Local).AddTicks(231),
                            IsDeleted = false,
                            Locked = false,
                            ModifiedByUserId = 0,
                            ModifiedDate = new DateTime(2024, 11, 4, 17, 46, 17, 561, DateTimeKind.Local).AddTicks(232),
                            Name = "Izvjestaji",
                            Version = 0,
                            Visible = true
                        });
                });

            modelBuilder.Entity("Click2Rent.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CreatedByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("Locked")
                        .HasColumnType("bit");

                    b.Property<int>("ModifiedByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.Property<bool>("Visible")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedByUserId = 1,
                            CreatedDate = new DateTime(2024, 11, 4, 17, 46, 17, 561, DateTimeKind.Local).AddTicks(400),
                            IsDeleted = false,
                            Locked = false,
                            ModifiedByUserId = 0,
                            ModifiedDate = new DateTime(2024, 11, 4, 17, 46, 17, 561, DateTimeKind.Local).AddTicks(403),
                            Username = "Admin",
                            Version = 0,
                            Visible = true
                        });
                });

            modelBuilder.Entity("Click2Rent.Domain.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CreatedByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("Locked")
                        .HasColumnType("bit");

                    b.Property<int>("ModifiedByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.Property<bool>("Visible")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Comment = "",
                            CreatedByUserId = 1,
                            CreatedDate = new DateTime(2024, 11, 4, 17, 46, 17, 561, DateTimeKind.Local).AddTicks(425),
                            IsDeleted = false,
                            Locked = false,
                            ModifiedByUserId = 0,
                            ModifiedDate = new DateTime(2024, 11, 4, 17, 46, 17, 561, DateTimeKind.Local).AddTicks(427),
                            RoleId = 1,
                            UserId = 1,
                            Version = 0,
                            Visible = true
                        });
                });

            modelBuilder.Entity("Click2Rent.Domain.UserRole", b =>
                {
                    b.HasOne("Click2Rent.Domain.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Click2Rent.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}

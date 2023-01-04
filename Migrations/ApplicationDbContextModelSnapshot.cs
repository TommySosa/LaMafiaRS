﻿// <auto-generated />
using System;
using LaMafiaRS.Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LaMafiaRS.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LaMafiaRS.Models.Like", b =>
                {
                    b.Property<int>("LikeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("LikeId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LikeId"), 1L, 1);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreationDate");

                    b.Property<int>("TweetId")
                        .HasColumnType("int")
                        .HasColumnName("TweetId");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserId");

                    b.HasKey("LikeId");

                    b.HasIndex("UserId");

                    b.ToTable("Like");
                });

            modelBuilder.Entity("LaMafiaRS.Models.Tweet", b =>
                {
                    b.Property<int>("TweetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TweetId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TweetId"), 1L, 1);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreationDate");

                    b.Property<string>("Imagen1")
                        .IsRequired()
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Imagen1");

                    b.Property<string>("Imagen2")
                        .IsRequired()
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Imagen1");

                    b.Property<string>("Imagen3")
                        .IsRequired()
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Imagen1");

                    b.Property<string>("Imagen4")
                        .IsRequired()
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Imagen1");

                    b.Property<int>("RetweetId")
                        .HasColumnType("int")
                        .HasColumnName("RetweetId");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(280)
                        .HasColumnType("nvarchar(280)")
                        .HasColumnName("Text");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserId");

                    b.Property<string>("Video")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Video");

                    b.HasKey("TweetId");

                    b.HasIndex("UserId");

                    b.ToTable("Tweet");
                });

            modelBuilder.Entity("LaMafiaRS.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("User");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreationDate");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("EMAIL");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("PASS");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("SALT");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Tipo");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Username");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("LaMafiaRS.Models.Like", b =>
                {
                    b.HasOne("LaMafiaRS.Models.User", "User")
                        .WithMany("Like")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("LaMafiaRS.Models.Tweet", b =>
                {
                    b.HasOne("LaMafiaRS.Models.User", "User")
                        .WithMany("Tweet")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("LaMafiaRS.Models.User", b =>
                {
                    b.Navigation("Like");

                    b.Navigation("Tweet");
                });
#pragma warning restore 612, 618
        }
    }
}
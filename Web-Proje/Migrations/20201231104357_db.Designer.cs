﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Web_Proje.Models;

namespace Web_Proje.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20201231104357_db")]
    partial class db
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Web_Proje.Models.Books", b =>
                {
                    b.Property<int>("kitapID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("basimYili")
                        .HasColumnType("int");

                    b.Property<string>("kategori")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("kitapAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("konu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("sayfaSayisi")
                        .HasColumnType("int");

                    b.Property<string>("yazar")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("kitapID");

                    b.ToTable("books");
                });

            modelBuilder.Entity("Web_Proje.Models.Messages", b =>
                {
                    b.Property<int>("messageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("User")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("message")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("messageID");

                    b.ToTable("messages");
                });
#pragma warning restore 612, 618
        }
    }
}

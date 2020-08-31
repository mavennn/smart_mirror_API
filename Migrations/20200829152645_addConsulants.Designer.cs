﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartMirror.Domain;

namespace SmartMirror.Migrations
{
    [DbContext(typeof(SmartMirrorDbContext))]
    [Migration("20200829152645_addConsulants")]
    partial class addConsulants
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SmartMirror.Domain.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Sex");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("SmartMirror.Domain.Models.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ProductId");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("SmartMirror.Domain.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Barcode");

                    b.Property<string>("Brand");

                    b.Property<Guid?>("CategoryId");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<string>("Sex");

                    b.Property<string>("VendorCode");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("SmartMirror.Domain.Models.Size", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EU");

                    b.Property<string>("Name");

                    b.Property<Guid?>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Sizes");
                });

            modelBuilder.Entity("SmartMirror.Domain.Models.Image", b =>
                {
                    b.HasOne("SmartMirror.Domain.Models.Product")
                        .WithMany("ImagesUrls")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("SmartMirror.Domain.Models.Product", b =>
                {
                    b.HasOne("SmartMirror.Domain.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("SmartMirror.Domain.Models.Size", b =>
                {
                    b.HasOne("SmartMirror.Domain.Models.Product")
                        .WithMany("Sizes")
                        .HasForeignKey("ProductId");
                });
#pragma warning restore 612, 618
        }
    }
}

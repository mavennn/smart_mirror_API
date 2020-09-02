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
    [Migration("20200902001105_addNewCOlumnsToRequest")]
    partial class addNewCOlumnsToRequest
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SmartMirror.Domain.Models.Basket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ProductId");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Basket");
                });

            modelBuilder.Entity("SmartMirror.Domain.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<Guid>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("SmartMirror.Domain.Models.Consultant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Consultants");
                });

            modelBuilder.Entity("SmartMirror.Domain.Models.HistoryItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ProductId");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.ToTable("HistoryItems");
                });

            modelBuilder.Entity("SmartMirror.Domain.Models.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ProductId");

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

                    b.Property<int>("Gender");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<Guid?>("RequestId");

                    b.Property<string>("VendorCode");

                    b.HasKey("Id");

                    b.HasIndex("RequestId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("SmartMirror.Domain.Models.Request", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ConsulantId");

                    b.Property<Guid?>("ConsultantId");

                    b.Property<int>("Status");

                    b.Property<DateTime?>("Time");

                    b.Property<string>("Title");

                    b.Property<int>("Type");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ConsultantId");

                    b.HasIndex("UserId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("SmartMirror.Domain.Models.Size", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EU");

                    b.Property<string>("Name");

                    b.Property<Guid>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Sizes");
                });

            modelBuilder.Entity("SmartMirror.Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("UserAgent");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SmartMirror.Domain.Models.Basket", b =>
                {
                    b.HasOne("SmartMirror.Domain.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SmartMirror.Domain.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SmartMirror.Domain.Models.Category", b =>
                {
                    b.HasOne("SmartMirror.Domain.Models.Product")
                        .WithOne("Category")
                        .HasForeignKey("SmartMirror.Domain.Models.Category", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SmartMirror.Domain.Models.Image", b =>
                {
                    b.HasOne("SmartMirror.Domain.Models.Product")
                        .WithMany("Images")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SmartMirror.Domain.Models.Product", b =>
                {
                    b.HasOne("SmartMirror.Domain.Models.Request")
                        .WithMany("Products")
                        .HasForeignKey("RequestId");
                });

            modelBuilder.Entity("SmartMirror.Domain.Models.Request", b =>
                {
                    b.HasOne("SmartMirror.Domain.Models.Consultant", "Consultant")
                        .WithMany()
                        .HasForeignKey("ConsultantId");

                    b.HasOne("SmartMirror.Domain.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SmartMirror.Domain.Models.Size", b =>
                {
                    b.HasOne("SmartMirror.Domain.Models.Product", "Product")
                        .WithMany("Sizes")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

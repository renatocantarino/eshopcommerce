﻿// <auto-generated />
using Discount.GRPC.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Discount.GRPC.Migrations
{
    [DbContext(typeof(DiscountContext))]
    [Migration("20250119183841_SkillSeeding")]
    partial class SkillSeeding
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.1");

            modelBuilder.Entity("Discount.GRPC.Models.Coupon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ammount")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Coupons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "aplle phone",
                            ProductName = "IPhone X",
                            ammount = 150
                        },
                        new
                        {
                            Id = 2,
                            Description = "aplle phone X",
                            ProductName = "IPhone XX",
                            ammount = 100
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
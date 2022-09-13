﻿// <auto-generated />
using GeekShop.CouponAPI.Model.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GeekShop.CouponAPI.Migrations
{
    [DbContext(typeof(MySqlContext))]
    partial class MySqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("GeekShop.CouponAPI.Model.Coupon", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<string>("CouponCode")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("coupon_code");

                    b.Property<decimal>("DiscountAmount")
                        .HasColumnType("decimal(65,30)")
                        .HasColumnName("discount_amount");

                    b.HasKey("ID");

                    b.ToTable("coupon");

                    b.HasData(
                        new
                        {
                            ID = 1L,
                            CouponCode = "LEONARDO_2022_10",
                            DiscountAmount = 10m
                        },
                        new
                        {
                            ID = 2L,
                            CouponCode = "LEONARDO_2022_15",
                            DiscountAmount = 15m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

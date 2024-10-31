﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;
using ReceiptAPI.Data;

#nullable disable

namespace ReceiptAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ReceiptAPI.Application.Models.Category", b =>
                {
                    b.Property<int>("LoaiNguyenLieuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoaiNguyenLieuId"));

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("TenLoai")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("NVARCHAR2(20)");

                    b.HasKey("LoaiNguyenLieuId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ReceiptAPI.Application.Models.Ingredient", b =>
                {
                    b.Property<int>("NguyenLieuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NguyenLieuId"));

                    b.Property<string>("DonViTinh")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("NVARCHAR2(10)");

                    b.Property<double>("GiaBan")
                        .HasColumnType("BINARY_DOUBLE");

                    b.Property<int>("LoaiNguyenLieuId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("SoLuongKho")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("TenNguyenLieu")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("NVARCHAR2(20)");

                    b.HasKey("NguyenLieuId");

                    b.HasIndex("LoaiNguyenLieuId");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("ReceiptAPI.Application.Models.Receipt", b =>
                {
                    b.Property<int>("PhieuThuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PhieuThuId"));

                    b.Property<string>("GhiChu")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime>("NgayLap")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("NhanVienLap")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<double>("ThanhTien")
                        .HasColumnType("BINARY_DOUBLE");

                    b.HasKey("PhieuThuId");

                    b.ToTable("Receipts");
                });

            modelBuilder.Entity("ReceiptAPI.Application.Models.ReceiptDetail", b =>
                {
                    b.Property<int>("ChiTietPhieuThuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChiTietPhieuThuId"));

                    b.Property<int>("NguyenLieuId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("PhieuThuId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("SoLuongBan")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("ChiTietPhieuThuId");

                    b.HasIndex("NguyenLieuId");

                    b.HasIndex("PhieuThuId");

                    b.ToTable("ReceiptDetails");
                });

            modelBuilder.Entity("ReceiptAPI.Application.Models.Ingredient", b =>
                {
                    b.HasOne("ReceiptAPI.Application.Models.Category", "Category")
                        .WithMany("Ingredients")
                        .HasForeignKey("LoaiNguyenLieuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ReceiptAPI.Application.Models.ReceiptDetail", b =>
                {
                    b.HasOne("ReceiptAPI.Application.Models.Ingredient", "Ingredient")
                        .WithMany("ReceiptDetails")
                        .HasForeignKey("NguyenLieuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReceiptAPI.Application.Models.Receipt", "Receipt")
                        .WithMany("ReceiptDetails")
                        .HasForeignKey("PhieuThuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("Receipt");
                });

            modelBuilder.Entity("ReceiptAPI.Application.Models.Category", b =>
                {
                    b.Navigation("Ingredients");
                });

            modelBuilder.Entity("ReceiptAPI.Application.Models.Ingredient", b =>
                {
                    b.Navigation("ReceiptDetails");
                });

            modelBuilder.Entity("ReceiptAPI.Application.Models.Receipt", b =>
                {
                    b.Navigation("ReceiptDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
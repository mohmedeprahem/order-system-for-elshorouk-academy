﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using src.Data;

#nullable disable

namespace src.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20240804192658_CreateUserTable")]
    partial class CreateUserTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("src.Models.Branch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BranchName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasDefaultValue("");

                    b.Property<int>("CityId")
                        .HasColumnType("int")
                        .HasColumnName("CityID");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("src.Models.Cashier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BranchId")
                        .HasColumnType("int")
                        .HasColumnName("BranchID");

                    b.Property<string>("CashierName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasDefaultValue("");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.ToTable("Cashier", (string)null);
                });

            modelBuilder.Entity("src.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CityName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasDefaultValue("");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("src.Models.InvoiceDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("InvoiceHeaderId")
                        .HasColumnType("bigint")
                        .HasColumnName("InvoiceHeaderID");

                    b.Property<double>("ItemCount")
                        .HasColumnType("float");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasDefaultValue("");

                    b.Property<double>("ItemPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceHeaderId");

                    b.ToTable("InvoiceDetails");
                });

            modelBuilder.Entity("src.Models.InvoiceHeader", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("BranchId")
                        .HasColumnType("int")
                        .HasColumnName("BranchID");

                    b.Property<int?>("CashierId")
                        .HasColumnType("int")
                        .HasColumnName("CashierID");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasDefaultValue("");

                    b.Property<DateTime>("Invoicedate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("CashierId");

                    b.ToTable("InvoiceHeader", (string)null);
                });

            modelBuilder.Entity("src.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("password")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("src.Models.Branch", b =>
                {
                    b.HasOne("src.Models.City", "City")
                        .WithMany("Branches")
                        .HasForeignKey("CityId")
                        .IsRequired()
                        .HasConstraintName("FK_Branches_Cities");

                    b.Navigation("City");
                });

            modelBuilder.Entity("src.Models.Cashier", b =>
                {
                    b.HasOne("src.Models.Branch", "Branch")
                        .WithMany("Cashiers")
                        .HasForeignKey("BranchId")
                        .IsRequired()
                        .HasConstraintName("FK_Cashier_Branches");

                    b.Navigation("Branch");
                });

            modelBuilder.Entity("src.Models.InvoiceDetail", b =>
                {
                    b.HasOne("src.Models.InvoiceHeader", "InvoiceHeader")
                        .WithMany("InvoiceDetails")
                        .HasForeignKey("InvoiceHeaderId")
                        .IsRequired()
                        .HasConstraintName("FK_InvoiceDetails_InvoiceHeader");

                    b.Navigation("InvoiceHeader");
                });

            modelBuilder.Entity("src.Models.InvoiceHeader", b =>
                {
                    b.HasOne("src.Models.Branch", "Branch")
                        .WithMany("InvoiceHeaders")
                        .HasForeignKey("BranchId")
                        .IsRequired()
                        .HasConstraintName("FK_InvoiceHeader_Branches");

                    b.HasOne("src.Models.Cashier", "Cashier")
                        .WithMany("InvoiceHeaders")
                        .HasForeignKey("CashierId")
                        .HasConstraintName("FK_InvoiceHeader_Cashier");

                    b.Navigation("Branch");

                    b.Navigation("Cashier");
                });

            modelBuilder.Entity("src.Models.Branch", b =>
                {
                    b.Navigation("Cashiers");

                    b.Navigation("InvoiceHeaders");
                });

            modelBuilder.Entity("src.Models.Cashier", b =>
                {
                    b.Navigation("InvoiceHeaders");
                });

            modelBuilder.Entity("src.Models.City", b =>
                {
                    b.Navigation("Branches");
                });

            modelBuilder.Entity("src.Models.InvoiceHeader", b =>
                {
                    b.Navigation("InvoiceDetails");
                });
#pragma warning restore 612, 618
        }
    }
}

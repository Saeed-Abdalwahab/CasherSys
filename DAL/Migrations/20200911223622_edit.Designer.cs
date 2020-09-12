﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(CasherSysContext))]
    [Migration("20200911223622_edit")]
    partial class edit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.Item", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.ToTable("items");
                });

            modelBuilder.Entity("DAL.ItemDetails", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ItemID")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ItemID");

                    b.ToTable("ItemDetails");
                });

            modelBuilder.Entity("DAL.LoafType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.Property<double?>("plusCost")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.ToTable("LoafType");
                });

            modelBuilder.Entity("DAL.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<double?>("Discount")
                        .HasColumnType("float");

                    b.Property<int>("OrderNumber")
                        .HasColumnType("int");

                    b.Property<double>("TotalCoast")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("DAL.OrderDetails", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("LoafTypeID")
                        .HasColumnType("int");

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("count")
                        .HasColumnType("int");

                    b.Property<int>("itemDetailsID")
                        .HasColumnType("int");

                    b.Property<string>("notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("totalPrice")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("LoafTypeID");

                    b.HasIndex("OrderID");

                    b.HasIndex("itemDetailsID");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("DAL.itemCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("itemCategories");
                });

            modelBuilder.Entity("DAL.Item", b =>
                {
                    b.HasOne("DAL.itemCategory", "ItemCategory")
                        .WithMany("items")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.ItemDetails", b =>
                {
                    b.HasOne("DAL.Item", "Item")
                        .WithMany("ItemDetails")
                        .HasForeignKey("ItemID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.OrderDetails", b =>
                {
                    b.HasOne("DAL.LoafType", "LoafType")
                        .WithMany("OrderDetails")
                        .HasForeignKey("LoafTypeID");

                    b.HasOne("DAL.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.ItemDetails", "ItemDetails")
                        .WithMany("OrderDetails")
                        .HasForeignKey("itemDetailsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using B2C.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace B2C.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241001120604_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("core")
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("B2C.Domain.Models.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.HasKey("Id")
                        .HasName("pk_customer");

                    b.ToTable("customer", "core");
                });

            modelBuilder.Entity("B2C.Domain.Models.Customer", b =>
                {
                    b.OwnsOne("B2C.Domain.Models.CustomerDetails", "Details", b1 =>
                        {
                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<int>("Age")
                                .HasColumnType("integer")
                                .HasColumnName("details_age");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("details_name");

                            b1.HasKey("CustomerId");

                            b1.ToTable("customer", "core");

                            b1.ToJson("Details");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId")
                                .HasConstraintName("fk_customer_customer_id");

                            b1.OwnsMany("B2C.Domain.Models.Order", "Orders", b2 =>
                                {
                                    b2.Property<Guid>("CustomerDetailsCustomerId")
                                        .HasColumnType("uuid");

                                    b2.Property<int>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("integer");

                                    b2.Property<decimal>("Price")
                                        .HasColumnType("numeric");

                                    b2.Property<string>("ShippingAddress")
                                        .IsRequired()
                                        .HasColumnType("text");

                                    b2.HasKey("CustomerDetailsCustomerId", "Id")
                                        .HasName("pk_customer");

                                    b2.ToTable("customer", "core");

                                    b2.WithOwner()
                                        .HasForeignKey("CustomerDetailsCustomerId")
                                        .HasConstraintName("fk_customer_customer_customer_details_customer_id");
                                });

                            b1.Navigation("Orders");
                        });

                    b.Navigation("Details");
                });
#pragma warning restore 612, 618
        }
    }
}

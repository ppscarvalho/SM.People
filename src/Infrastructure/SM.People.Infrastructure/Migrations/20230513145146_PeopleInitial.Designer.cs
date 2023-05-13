﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SM.People.Infrastructure.DbContexts;

#nullable disable

namespace SM.People.Infrastructure.Migrations
{
    [DbContext(typeof(PeopleDbContext))]
    [Migration("20230513145146_PeopleInitial")]
    partial class PeopleInitial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SM.People.Core.Domain.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("Birthday")
                        .IsRequired()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CellPhone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("ModfiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("SM.People.Core.Domain.Entities.Supplier", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CellPhone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("CorporateName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("FantasyName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("ModfiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NRLE")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("StateRegistration")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Supplier", (string)null);
                });

            modelBuilder.Entity("SM.People.Core.Domain.Entities.Customer", b =>
                {
                    b.OwnsOne("SM.People.Core.Domain.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(60)
                                .HasColumnType("varchar(60)")
                                .HasColumnName("City");

                            b1.Property<string>("District")
                                .IsRequired()
                                .HasMaxLength(60)
                                .HasColumnType("varchar(60)")
                                .HasColumnName("District");

                            b1.Property<string>("PublicPlace")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("varchar(100)")
                                .HasColumnName("PublicPlace");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasMaxLength(2)
                                .HasColumnType("varchar(2)")
                                .HasColumnName("State");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasMaxLength(13)
                                .HasColumnType("varchar(13)")
                                .HasColumnName("ZipCode");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customer");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.OwnsOne("SM.People.Core.Domain.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("EmailAddress")
                                .HasMaxLength(100)
                                .HasColumnType("varchar(100)")
                                .HasColumnName("Email");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customer");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Email")
                        .IsRequired();
                });

            modelBuilder.Entity("SM.People.Core.Domain.Entities.Supplier", b =>
                {
                    b.OwnsOne("SM.People.Core.Domain.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("SupplierId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(60)
                                .HasColumnType("varchar(60)")
                                .HasColumnName("City");

                            b1.Property<string>("District")
                                .IsRequired()
                                .HasMaxLength(60)
                                .HasColumnType("varchar(60)")
                                .HasColumnName("District");

                            b1.Property<string>("PublicPlace")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("varchar(100)")
                                .HasColumnName("PublicPlace");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasMaxLength(2)
                                .HasColumnType("varchar(2)")
                                .HasColumnName("State");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasMaxLength(13)
                                .HasColumnType("varchar(13)")
                                .HasColumnName("ZipCode");

                            b1.HasKey("SupplierId");

                            b1.ToTable("Supplier");

                            b1.WithOwner()
                                .HasForeignKey("SupplierId");
                        });

                    b.OwnsOne("SM.People.Core.Domain.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("SupplierId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("EmailAddress")
                                .HasMaxLength(100)
                                .HasColumnType("varchar(100)")
                                .HasColumnName("Email");

                            b1.HasKey("SupplierId");

                            b1.ToTable("Supplier");

                            b1.WithOwner()
                                .HasForeignKey("SupplierId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Email")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
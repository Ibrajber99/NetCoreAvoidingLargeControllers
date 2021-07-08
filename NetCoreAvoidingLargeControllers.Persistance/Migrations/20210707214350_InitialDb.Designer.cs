﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetCoreAvoidingLargeControllers.Persistance;

namespace NetCoreAvoidingLargeControllers.Persistance.Migrations
{
    [DbContext(typeof(TestRegistrationDbContext))]
    [Migration("20210707214350_InitialDb")]
    partial class InitialDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NetCoreAvoidingLargeControllers.Domain.Entities.TestApplicant", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TestInfoID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TestInfoID");

                    b.ToTable("TestApplicants");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfBirth = new DateTime(1999, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Ibrahim",
                            LastName = "Jaber",
                            TestInfoID = 1
                        },
                        new
                        {
                            ID = 2,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfBirth = new DateTime(1999, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Ibrahim",
                            LastName = "Jaber",
                            TestInfoID = 2
                        },
                        new
                        {
                            ID = 3,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfBirth = new DateTime(1999, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Ali",
                            LastName = "Samlioglu",
                            TestInfoID = 2
                        });
                });

            modelBuilder.Entity("NetCoreAvoidingLargeControllers.Domain.Entities.TestInfo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TestDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TestName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Tests");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Celpip Test for english profeciency",
                            TestDate = new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TestName = "Celpip-G"
                        },
                        new
                        {
                            ID = 2,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Celpip Test for english profeciency",
                            TestDate = new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TestName = "Celpip-LS"
                        },
                        new
                        {
                            ID = 3,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Azure Fundamentals Certificate",
                            TestDate = new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TestName = "Azure AZ-900"
                        });
                });

            modelBuilder.Entity("NetCoreAvoidingLargeControllers.Domain.Entities.TestApplicant", b =>
                {
                    b.HasOne("NetCoreAvoidingLargeControllers.Domain.Entities.TestInfo", "TestInfo")
                        .WithMany("TestApplicants")
                        .HasForeignKey("TestInfoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

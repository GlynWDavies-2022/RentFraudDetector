﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RentFraudDetector.Shared.Data;

#nullable disable

namespace RentFraudDetector.Shared.Migrations
{
    [DbContext(typeof(RentFraudDetectorDbContext))]
    partial class RentFraudDetectorDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RentFraudDetector.Shared.Models.CompanyDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Conway"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Countryside"
                        });
                });

            modelBuilder.Entity("RentFraudDetector.Shared.Models.EmployeeDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("AccountName")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("AccountNumber")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("BranchName")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("CompanyDbId")
                        .HasColumnType("int");

                    b.Property<byte[]>("FirstName")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("Key")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("RollNumber")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("SortCode")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("StaffNumber")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("Surname")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("Vector")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}

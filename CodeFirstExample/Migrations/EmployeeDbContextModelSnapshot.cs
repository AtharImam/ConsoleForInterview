﻿// <auto-generated />
using System;
using CodeFirstExample.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CodeFirstExample.Migrations
{
    [DbContext(typeof(EmployeeDbContext))]
    partial class EmployeeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CodeFirstExample.Data.BillingDetail", b =>
                {
                    b.Property<int>("BillingDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Owner")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BillingDetailId");

                    b.ToTable("BillingDetails");
                });

            modelBuilder.Entity("CodeFirstExample.Data.ContractEmployee", b =>
                {
                    b.Property<int>("CEId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmpId")
                        .HasColumnType("int");

                    b.Property<decimal>("HourlySalary")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CEId");

                    b.HasIndex("EmpId");

                    b.ToTable("ContractEmployees");
                });

            modelBuilder.Entity("CodeFirstExample.Data.CustomerTpt", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("CustomersTpt");
                });

            modelBuilder.Entity("CodeFirstExample.Data.Department", b =>
                {
                    b.Property<int>("DeptId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DepartmentDeptId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DeptId");

                    b.HasIndex("DepartmentDeptId");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            DeptId = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            DeptId = 2,
                            Name = "IT"
                        });
                });

            modelBuilder.Entity("CodeFirstExample.Data.Employee", b =>
                {
                    b.Property<int>("EmpId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("EmailId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("EmpId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmpId = 1,
                            DepartmentId = 1,
                            EmailId = "äbc@xyz.com",
                            Gender = "Male",
                            MobileNo = "9999999999",
                            Name = "Athar"
                        },
                        new
                        {
                            EmpId = 2,
                            DepartmentId = 2,
                            EmailId = "ddd@xyz.com",
                            Gender = "FeMale",
                            MobileNo = "888888",
                            Name = "Shaheen"
                        });
                });

            modelBuilder.Entity("CodeFirstExample.Data.EmployeeTpt", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Turnover")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("EmployeesTpt");
                });

            modelBuilder.Entity("CodeFirstExample.Data.PermanentEmployee", b =>
                {
                    b.Property<int>("PEId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("AnnualSalary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("EmpId")
                        .HasColumnType("int");

                    b.HasKey("PEId");

                    b.HasIndex("EmpId");

                    b.ToTable("PermanentEmployes");
                });

            modelBuilder.Entity("CodeFirstExample.Data.PersonTph", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PeopleTph");

                    b.HasDiscriminator<string>("Discriminator").HasValue("PersonTph");
                });

            modelBuilder.Entity("CodeFirstExample.Data.PersonTpt", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PeopleTpt");
                });

            modelBuilder.Entity("CodeFirstExample.Data.TestEmployee", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("EmployeeType")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id", "EmployeeType");

                    b.ToTable("TestEmployees");
                });

            modelBuilder.Entity("CodeFirstExample.Data.CustomerTph", b =>
                {
                    b.HasBaseType("CodeFirstExample.Data.PersonTph");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue("CustomerTph");
                });

            modelBuilder.Entity("CodeFirstExample.Data.EmployeeTph", b =>
                {
                    b.HasBaseType("CodeFirstExample.Data.PersonTph");

                    b.Property<decimal>("Turnover")
                        .HasColumnType("decimal(18,2)");

                    b.HasDiscriminator().HasValue("EmployeeTph");
                });

            modelBuilder.Entity("CodeFirstExample.Data.ContractEmployee", b =>
                {
                    b.HasOne("CodeFirstExample.Data.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmpId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CodeFirstExample.Data.CustomerTpt", b =>
                {
                    b.HasOne("CodeFirstExample.Data.PersonTpt", "Person")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CodeFirstExample.Data.Department", b =>
                {
                    b.HasOne("CodeFirstExample.Data.Department", null)
                        .WithMany("Departments")
                        .HasForeignKey("DepartmentDeptId");
                });

            modelBuilder.Entity("CodeFirstExample.Data.Employee", b =>
                {
                    b.HasOne("CodeFirstExample.Data.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CodeFirstExample.Data.EmployeeTpt", b =>
                {
                    b.HasOne("CodeFirstExample.Data.PersonTpt", "Person")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CodeFirstExample.Data.PermanentEmployee", b =>
                {
                    b.HasOne("CodeFirstExample.Data.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmpId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

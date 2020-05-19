using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstExample.Migrations
{
    public partial class initdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BillingDetails",
                columns: table => new
                {
                    BillingDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Owner = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 5, 13, 16, 33, 38, 359, DateTimeKind.Local).AddTicks(1311))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingDetails", x => x.BillingDetailId);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 5, 13, 16, 33, 38, 368, DateTimeKind.Local).AddTicks(2783))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "PeopleTph",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 5, 13, 16, 33, 38, 368, DateTimeKind.Local).AddTicks(2783)),
                    Discriminator = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: true),
                    Turnover = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeopleTph", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PeopleTpt",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 5, 13, 16, 33, 38, 368, DateTimeKind.Local).AddTicks(2783))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeopleTpt", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestEmployees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    EmployeeType = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 5, 13, 16, 33, 38, 368, DateTimeKind.Local).AddTicks(2783))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestEmployees", x => new { x.Id, x.EmployeeType });
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmpId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gender = table.Column<string>(nullable: true),
                    MobileNo = table.Column<string>(nullable: true),
                    EmailId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<int>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 5, 13, 16, 33, 38, 368, DateTimeKind.Local).AddTicks(2783))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmpId);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomersTpt",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 5, 13, 16, 33, 38, 368, DateTimeKind.Local).AddTicks(2783))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersTpt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomersTpt_PeopleTpt_Id",
                        column: x => x.Id,
                        principalTable: "PeopleTpt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeesTpt",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Turnover = table.Column<decimal>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 5, 13, 16, 33, 38, 368, DateTimeKind.Local).AddTicks(2783))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesTpt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeesTpt_PeopleTpt_Id",
                        column: x => x.Id,
                        principalTable: "PeopleTpt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractEmployees",
                columns: table => new
                {
                    CEId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<int>(nullable: false),
                    HourlySalary = table.Column<decimal>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 5, 13, 16, 33, 38, 368, DateTimeKind.Local).AddTicks(2783))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractEmployees", x => x.CEId);
                    table.ForeignKey(
                        name: "FK_ContractEmployees_Employees_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Employees",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermanentEmployes",
                columns: table => new
                {
                    PEId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<int>(nullable: false),
                    AnnualSalary = table.Column<decimal>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 5, 13, 16, 33, 38, 368, DateTimeKind.Local).AddTicks(2783))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermanentEmployes", x => x.PEId);
                    table.ForeignKey(
                        name: "FK_PermanentEmployes_Employees_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Employees",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "Name" },
                values: new object[] { 1, "Admin" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "Name" },
                values: new object[] { 2, "IT" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmpId", "DepartmentId", "EmailId", "Gender", "MobileNo", "Name" },
                values: new object[] { 1, 1, "äbc@xyz.com", "Male", "9999999999", "Athar" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmpId", "DepartmentId", "EmailId", "Gender", "MobileNo", "Name" },
                values: new object[] { 2, 2, "ddd@xyz.com", "FeMale", "888888", "Shaheen" });

            migrationBuilder.CreateIndex(
                name: "IX_ContractEmployees_EmpId",
                table: "ContractEmployees",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PermanentEmployes_EmpId",
                table: "PermanentEmployes",
                column: "EmpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillingDetails");

            migrationBuilder.DropTable(
                name: "ContractEmployees");

            migrationBuilder.DropTable(
                name: "CustomersTpt");

            migrationBuilder.DropTable(
                name: "EmployeesTpt");

            migrationBuilder.DropTable(
                name: "PeopleTph");

            migrationBuilder.DropTable(
                name: "PermanentEmployes");

            migrationBuilder.DropTable(
                name: "TestEmployees");

            migrationBuilder.DropTable(
                name: "PeopleTpt");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}

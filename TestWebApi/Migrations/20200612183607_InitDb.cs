using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestWebApi.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Gender = table.Column<string>(maxLength: 10, nullable: true),
                    AnnualSalary = table.Column<double>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Code);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Code", "AnnualSalary", "DateOfBirth", "Gender", "Name" },
                values: new object[,]
                {
                    { "Emp101", 5500.0, new DateTime(1988, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "Tom" },
                    { "Emp102", 5700.9499999999998, new DateTime(1982, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "Alex" },
                    { "Emp103", 5900.0, new DateTime(1979, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "Mike" },
                    { "Emp104", 6500.826, new DateTime(1980, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female", "Mary" },
                    { "Emp105", 6700.826, new DateTime(1982, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female", "Nancy" },
                    { "Emp106", 7700.4809999999998, new DateTime(1979, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "Steve" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}

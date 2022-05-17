﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Zoobook.Data.Migrations.Initial
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FirstName", "LastName", "MiddleName" },
                values: new object[] { 1, "Abraham", "Lincoln", "the Great Emancipator" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FirstName", "LastName", "MiddleName" },
                values: new object[] { 2, "George", "Washington", "the Founding Father" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}

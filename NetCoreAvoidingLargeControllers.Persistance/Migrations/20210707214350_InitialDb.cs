using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCoreAvoidingLargeControllers.Persistance.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    TestName = table.Column<string>(nullable: false),
                    TestDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TestApplicants",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    TestInfoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestApplicants", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TestApplicants_Tests_TestInfoID",
                        column: x => x.TestInfoID,
                        principalTable: "Tests",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tests",
                columns: new[] { "ID", "CreatedBy", "CreatedDate", "Description", "LastModifiedBy", "LastModifiedDate", "TestDate", "TestName" },
                values: new object[] { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Celpip Test for english profeciency", null, null, new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Celpip-G" });

            migrationBuilder.InsertData(
                table: "Tests",
                columns: new[] { "ID", "CreatedBy", "CreatedDate", "Description", "LastModifiedBy", "LastModifiedDate", "TestDate", "TestName" },
                values: new object[] { 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Celpip Test for english profeciency", null, null, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Celpip-LS" });

            migrationBuilder.InsertData(
                table: "Tests",
                columns: new[] { "ID", "CreatedBy", "CreatedDate", "Description", "LastModifiedBy", "LastModifiedDate", "TestDate", "TestName" },
                values: new object[] { 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Azure Fundamentals Certificate", null, null, new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Azure AZ-900" });

            migrationBuilder.InsertData(
                table: "TestApplicants",
                columns: new[] { "ID", "CreatedBy", "CreatedDate", "DateOfBirth", "FirstName", "LastModifiedBy", "LastModifiedDate", "LastName", "TestInfoID" },
                values: new object[] { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1999, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ibrahim", null, null, "Jaber", 1 });

            migrationBuilder.InsertData(
                table: "TestApplicants",
                columns: new[] { "ID", "CreatedBy", "CreatedDate", "DateOfBirth", "FirstName", "LastModifiedBy", "LastModifiedDate", "LastName", "TestInfoID" },
                values: new object[] { 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1999, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ibrahim", null, null, "Jaber", 2 });

            migrationBuilder.InsertData(
                table: "TestApplicants",
                columns: new[] { "ID", "CreatedBy", "CreatedDate", "DateOfBirth", "FirstName", "LastModifiedBy", "LastModifiedDate", "LastName", "TestInfoID" },
                values: new object[] { 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1999, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ali", null, null, "Samlioglu", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_TestApplicants_TestInfoID",
                table: "TestApplicants",
                column: "TestInfoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestApplicants");

            migrationBuilder.DropTable(
                name: "Tests");
        }
    }
}

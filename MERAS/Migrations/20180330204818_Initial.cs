using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MERAS.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(maxLength: 100, nullable: false),
                    ContactEmail = table.Column<string>(nullable: true),
                    ContactFirstName = table.Column<string>(maxLength: 45, nullable: false),
                    ContactLastName = table.Column<string>(maxLength: 45, nullable: false),
                    ContactPhone = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Internship",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplyFinishtDate = table.Column<DateTime>(nullable: false),
                    ApplyStartDate = table.Column<DateTime>(nullable: false),
                    City = table.Column<string>(maxLength: 45, nullable: false),
                    CompanyID = table.Column<int>(nullable: false),
                    Country = table.Column<string>(maxLength: 45, nullable: false),
                    FinishtDate = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 45, nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Internship", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Internship_Company_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Company",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    ID = table.Column<string>(maxLength: 2, nullable: false),
                    InternshipID = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Department_Internship_InternshipID",
                        column: x => x.InternshipID,
                        principalTable: "Internship",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Supervisor",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartmentID = table.Column<string>(maxLength: 2, nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 45, nullable: false),
                    LastName = table.Column<string>(maxLength: 45, nullable: false),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supervisor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Supervisor_Department_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Department",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AssignedInternshipID = table.Column<int>(nullable: false),
                    CreditHrs = table.Column<int>(nullable: false),
                    DepartmentID = table.Column<string>(maxLength: 2, nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 45, nullable: false),
                    LastName = table.Column<string>(maxLength: 45, nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    SupervisorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Student_Department_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Department",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_Supervisor_SupervisorID",
                        column: x => x.SupervisorID,
                        principalTable: "Supervisor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplyForList",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplyDate = table.Column<DateTime>(nullable: false),
                    InternshipID = table.Column<int>(nullable: false),
                    StudentID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplyForList", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ApplyForList_Internship_InternshipID",
                        column: x => x.InternshipID,
                        principalTable: "Internship",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplyForList_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplyForList_InternshipID",
                table: "ApplyForList",
                column: "InternshipID");

            migrationBuilder.CreateIndex(
                name: "IX_ApplyForList_StudentID",
                table: "ApplyForList",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Department_InternshipID",
                table: "Department",
                column: "InternshipID");

            migrationBuilder.CreateIndex(
                name: "IX_Internship_CompanyID",
                table: "Internship",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_DepartmentID",
                table: "Student",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_SupervisorID",
                table: "Student",
                column: "SupervisorID");

            migrationBuilder.CreateIndex(
                name: "IX_Supervisor_DepartmentID",
                table: "Supervisor",
                column: "DepartmentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplyForList");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Supervisor");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Internship");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}

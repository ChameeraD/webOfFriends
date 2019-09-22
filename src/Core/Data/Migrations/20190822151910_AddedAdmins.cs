using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Data.Migrations
{
    public partial class AddedAdmins : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchoolClasses_SchoolAdmins_SchoolAdminId",
                table: "SchoolClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_SchoolAdmins_SchoolAdminId",
                table: "Surveys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SchoolAdmins",
                table: "SchoolAdmins");

            migrationBuilder.RenameTable(
                name: "SchoolAdmins",
                newName: "Schools");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schools",
                table: "Schools",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    IdentityGuid = table.Column<Guid>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    SchoolClassId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admins_SchoolClasses_SchoolClassId",
                        column: x => x.SchoolClassId,
                        principalTable: "SchoolClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_SchoolClassId",
                table: "Admins",
                column: "SchoolClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolClasses_Schools_SchoolAdminId",
                table: "SchoolClasses",
                column: "SchoolAdminId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_Schools_SchoolAdminId",
                table: "Surveys",
                column: "SchoolAdminId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchoolClasses_Schools_SchoolAdminId",
                table: "SchoolClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_Schools_SchoolAdminId",
                table: "Surveys");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schools",
                table: "Schools");

            migrationBuilder.RenameTable(
                name: "Schools",
                newName: "SchoolAdmins");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SchoolAdmins",
                table: "SchoolAdmins",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolClasses_SchoolAdmins_SchoolAdminId",
                table: "SchoolClasses",
                column: "SchoolAdminId",
                principalTable: "SchoolAdmins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_SchoolAdmins_SchoolAdminId",
                table: "Surveys",
                column: "SchoolAdminId",
                principalTable: "SchoolAdmins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

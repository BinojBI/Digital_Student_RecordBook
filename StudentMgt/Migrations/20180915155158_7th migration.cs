using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace StudentMgt.Migrations
{
    public partial class _7thmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Marks_Student_details_Student_DetailsID",
                table: "Marks");

            migrationBuilder.DropIndex(
                name: "IX_Marks_Student_DetailsID",
                table: "Marks");

            migrationBuilder.DropColumn(
                name: "Student_DetailsID",
                table: "Marks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Student_DetailsID",
                table: "Marks",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Marks_Student_DetailsID",
                table: "Marks",
                column: "Student_DetailsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Marks_Student_details_Student_DetailsID",
                table: "Marks",
                column: "Student_DetailsID",
                principalTable: "Student_details",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

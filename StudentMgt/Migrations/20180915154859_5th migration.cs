using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace StudentMgt.Migrations
{
    public partial class _5thmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Marks_Student_details_Student_detailsID",
                table: "Marks");

            migrationBuilder.RenameColumn(
                name: "Student_detailsID",
                table: "Marks",
                newName: "Student_DetailsID");

            migrationBuilder.RenameIndex(
                name: "IX_Marks_Student_detailsID",
                table: "Marks",
                newName: "IX_Marks_Student_DetailsID");

            migrationBuilder.AlterColumn<int>(
                name: "Student_DetailsID",
                table: "Marks",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Marks_Student_details_Student_DetailsID",
                table: "Marks",
                column: "Student_DetailsID",
                principalTable: "Student_details",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Marks_Student_details_Student_DetailsID",
                table: "Marks");

            migrationBuilder.RenameColumn(
                name: "Student_DetailsID",
                table: "Marks",
                newName: "Student_detailsID");

            migrationBuilder.RenameIndex(
                name: "IX_Marks_Student_DetailsID",
                table: "Marks",
                newName: "IX_Marks_Student_detailsID");

            migrationBuilder.AlterColumn<int>(
                name: "Student_detailsID",
                table: "Marks",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Marks_Student_details_Student_detailsID",
                table: "Marks",
                column: "Student_detailsID",
                principalTable: "Student_details",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

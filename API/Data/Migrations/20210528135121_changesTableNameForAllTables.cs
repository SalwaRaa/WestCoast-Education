using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class changesTableNameForAllTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseParticipants_Courses_CourseId",
                table: "CourseParticipants");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseParticipants_Participant_ParticipantId",
                table: "CourseParticipants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseParticipants",
                table: "CourseParticipants");

            migrationBuilder.EnsureSchema(
                name: "Courses");

            migrationBuilder.EnsureSchema(
                name: "CourseParticipants");

            migrationBuilder.EnsureSchema(
                name: "Participants");

            migrationBuilder.RenameTable(
                name: "Participant",
                newName: "Participant",
                newSchema: "Participants");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Course",
                newSchema: "Courses");

            migrationBuilder.RenameTable(
                name: "CourseParticipants",
                newName: "CourseParticipant",
                newSchema: "CourseParticipants");

            migrationBuilder.RenameIndex(
                name: "IX_CourseParticipants_ParticipantId",
                schema: "CourseParticipants",
                table: "CourseParticipant",
                newName: "IX_CourseParticipant_ParticipantId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseParticipants_CourseId",
                schema: "CourseParticipants",
                table: "CourseParticipant",
                newName: "IX_CourseParticipant_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                schema: "Courses",
                table: "Course",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseParticipant",
                schema: "CourseParticipants",
                table: "CourseParticipant",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseParticipant_Course_CourseId",
                schema: "CourseParticipants",
                table: "CourseParticipant",
                column: "CourseId",
                principalSchema: "Courses",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseParticipant_Participant_ParticipantId",
                schema: "CourseParticipants",
                table: "CourseParticipant",
                column: "ParticipantId",
                principalSchema: "Participants",
                principalTable: "Participant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseParticipant_Course_CourseId",
                schema: "CourseParticipants",
                table: "CourseParticipant");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseParticipant_Participant_ParticipantId",
                schema: "CourseParticipants",
                table: "CourseParticipant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseParticipant",
                schema: "CourseParticipants",
                table: "CourseParticipant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                schema: "Courses",
                table: "Course");

            migrationBuilder.RenameTable(
                name: "Participant",
                schema: "Participants",
                newName: "Participant");

            migrationBuilder.RenameTable(
                name: "CourseParticipant",
                schema: "CourseParticipants",
                newName: "CourseParticipants");

            migrationBuilder.RenameTable(
                name: "Course",
                schema: "Courses",
                newName: "Courses");

            migrationBuilder.RenameIndex(
                name: "IX_CourseParticipant_ParticipantId",
                table: "CourseParticipants",
                newName: "IX_CourseParticipants_ParticipantId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseParticipant_CourseId",
                table: "CourseParticipants",
                newName: "IX_CourseParticipants_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseParticipants",
                table: "CourseParticipants",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseParticipants_Courses_CourseId",
                table: "CourseParticipants",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseParticipants_Participant_ParticipantId",
                table: "CourseParticipants",
                column: "ParticipantId",
                principalTable: "Participant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

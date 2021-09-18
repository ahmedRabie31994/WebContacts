using Microsoft.EntityFrameworkCore.Migrations;

namespace WebContacts.DL.Migrations
{
    public partial class addmessageTypeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "messageTypeId",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_messageTypeId",
                table: "Messages",
                column: "messageTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_messageTypes_messageTypeId",
                table: "Messages",
                column: "messageTypeId",
                principalTable: "messageTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_messageTypes_messageTypeId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_messageTypeId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "messageTypeId",
                table: "Messages");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Film_Equipment_Rentals.Migrations
{
    public partial class ticketaddusername : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "OrderTicket",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "OrderTicket");
        }
    }
}

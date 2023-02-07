using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Film_Equipment_Rentals.Migrations
{
    public partial class ticketaddemailremoveusername : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "OrderTicket",
                newName: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "OrderTicket",
                newName: "Username");
        }
    }
}

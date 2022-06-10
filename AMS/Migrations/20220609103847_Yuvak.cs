using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMS.Migrations
{
    public partial class Yuvak : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "idSamparkKaryakar",
                table: "Yuvak",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idSamparkKaryakar",
                table: "Yuvak");
        }
    }
}

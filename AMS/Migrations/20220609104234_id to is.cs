using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMS.Migrations
{
    public partial class idtois : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "idSamparkKaryakar",
                table: "Yuvak",
                newName: "isSamparkKaryakar");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isSamparkKaryakar",
                table: "Yuvak",
                newName: "idSamparkKaryakar");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMS.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Karyakar_KarayakarRole_KarayakarRoleId",
                table: "Karyakar");

            migrationBuilder.DropForeignKey(
                name: "FK_KshetraNirdeshak_Karyakar_KaryakarId",
                table: "KshetraNirdeshak");

            migrationBuilder.DropForeignKey(
                name: "FK_Mandal_Karyakar_KaryakarId",
                table: "Mandal");

            migrationBuilder.DropIndex(
                name: "IX_Mandal_KaryakarId",
                table: "Mandal");

            migrationBuilder.DropIndex(
                name: "IX_KshetraNirdeshak_KaryakarId",
                table: "KshetraNirdeshak");

            migrationBuilder.DropColumn(
                name: "KaryakarId",
                table: "Mandal");

            migrationBuilder.DropColumn(
                name: "KaryakarId",
                table: "KshetraNirdeshak");

            migrationBuilder.RenameColumn(
                name: "KarayakarRoleId",
                table: "Karyakar",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Karyakar_KarayakarRoleId",
                table: "Karyakar",
                newName: "IX_Karyakar_RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Mandal_NirikshakId",
                table: "Mandal",
                column: "NirikshakId");

            migrationBuilder.CreateIndex(
                name: "IX_KshetraNirdeshak_NirdeshakId",
                table: "KshetraNirdeshak",
                column: "NirdeshakId");

            migrationBuilder.AddForeignKey(
                name: "FK_Karyakar_KarayakarRole_RoleId",
                table: "Karyakar",
                column: "RoleId",
                principalTable: "KarayakarRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KshetraNirdeshak_Karyakar_NirdeshakId",
                table: "KshetraNirdeshak",
                column: "NirdeshakId",
                principalTable: "Karyakar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mandal_Karyakar_NirikshakId",
                table: "Mandal",
                column: "NirikshakId",
                principalTable: "Karyakar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Karyakar_KarayakarRole_RoleId",
                table: "Karyakar");

            migrationBuilder.DropForeignKey(
                name: "FK_KshetraNirdeshak_Karyakar_NirdeshakId",
                table: "KshetraNirdeshak");

            migrationBuilder.DropForeignKey(
                name: "FK_Mandal_Karyakar_NirikshakId",
                table: "Mandal");

            migrationBuilder.DropIndex(
                name: "IX_Mandal_NirikshakId",
                table: "Mandal");

            migrationBuilder.DropIndex(
                name: "IX_KshetraNirdeshak_NirdeshakId",
                table: "KshetraNirdeshak");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "Karyakar",
                newName: "KarayakarRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Karyakar_RoleId",
                table: "Karyakar",
                newName: "IX_Karyakar_KarayakarRoleId");

            migrationBuilder.AddColumn<int>(
                name: "KaryakarId",
                table: "Mandal",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KaryakarId",
                table: "KshetraNirdeshak",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mandal_KaryakarId",
                table: "Mandal",
                column: "KaryakarId");

            migrationBuilder.CreateIndex(
                name: "IX_KshetraNirdeshak_KaryakarId",
                table: "KshetraNirdeshak",
                column: "KaryakarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Karyakar_KarayakarRole_KarayakarRoleId",
                table: "Karyakar",
                column: "KarayakarRoleId",
                principalTable: "KarayakarRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KshetraNirdeshak_Karyakar_KaryakarId",
                table: "KshetraNirdeshak",
                column: "KaryakarId",
                principalTable: "Karyakar",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Mandal_Karyakar_KaryakarId",
                table: "Mandal",
                column: "KaryakarId",
                principalTable: "Karyakar",
                principalColumn: "Id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace OurShopK5.Migrations
{
    public partial class UpdateModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NhanQuas_HangHoa_MaHh",
                table: "NhanQuas");

            migrationBuilder.DropForeignKey(
                name: "FK_NhanQuas_QuaTangs_MaQT",
                table: "NhanQuas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuaTangs",
                table: "QuaTangs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NhanQuas",
                table: "NhanQuas");

            migrationBuilder.RenameTable(
                name: "QuaTangs",
                newName: "QuaTang");

            migrationBuilder.RenameTable(
                name: "NhanQuas",
                newName: "NhanQua");

            migrationBuilder.RenameIndex(
                name: "IX_NhanQuas_MaQT",
                table: "NhanQua",
                newName: "IX_NhanQua_MaQT");

            migrationBuilder.RenameIndex(
                name: "IX_NhanQuas_MaHh",
                table: "NhanQua",
                newName: "IX_NhanQua_MaHh");

            migrationBuilder.AlterColumn<string>(
                name: "TenLoai",
                table: "Loai",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Hinh",
                table: "Loai",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenHh",
                table: "HangHoa",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Hinh",
                table: "HangHoa",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuaTang",
                table: "QuaTang",
                column: "QuaTangId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NhanQua",
                table: "NhanQua",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NhanQua_HangHoa_MaHh",
                table: "NhanQua",
                column: "MaHh",
                principalTable: "HangHoa",
                principalColumn: "MaHh",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NhanQua_QuaTang_MaQT",
                table: "NhanQua",
                column: "MaQT",
                principalTable: "QuaTang",
                principalColumn: "QuaTangId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NhanQua_HangHoa_MaHh",
                table: "NhanQua");

            migrationBuilder.DropForeignKey(
                name: "FK_NhanQua_QuaTang_MaQT",
                table: "NhanQua");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuaTang",
                table: "QuaTang");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NhanQua",
                table: "NhanQua");

            migrationBuilder.RenameTable(
                name: "QuaTang",
                newName: "QuaTangs");

            migrationBuilder.RenameTable(
                name: "NhanQua",
                newName: "NhanQuas");

            migrationBuilder.RenameIndex(
                name: "IX_NhanQua_MaQT",
                table: "NhanQuas",
                newName: "IX_NhanQuas_MaQT");

            migrationBuilder.RenameIndex(
                name: "IX_NhanQua_MaHh",
                table: "NhanQuas",
                newName: "IX_NhanQuas_MaHh");

            migrationBuilder.AlterColumn<string>(
                name: "TenLoai",
                table: "Loai",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Hinh",
                table: "Loai",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenHh",
                table: "HangHoa",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Hinh",
                table: "HangHoa",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuaTangs",
                table: "QuaTangs",
                column: "QuaTangId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NhanQuas",
                table: "NhanQuas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NhanQuas_HangHoa_MaHh",
                table: "NhanQuas",
                column: "MaHh",
                principalTable: "HangHoa",
                principalColumn: "MaHh",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NhanQuas_QuaTangs_MaQT",
                table: "NhanQuas",
                column: "MaQT",
                principalTable: "QuaTangs",
                principalColumn: "QuaTangId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

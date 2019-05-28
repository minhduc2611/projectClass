using Microsoft.EntityFrameworkCore.Migrations;

namespace OurShopK5.Migrations
{
    public partial class UpdateKhachHang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DiaChiGiaoHang",
                table: "DonHang",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiNhan",
                table: "DonHang",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiaChiGiaoHang",
                table: "DonHang");

            migrationBuilder.DropColumn(
                name: "NguoiNhan",
                table: "DonHang");
        }
    }
}

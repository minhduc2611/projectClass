using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OurShopK5.Migrations
{
    public partial class Order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    MaKh = table.Column<string>(maxLength: 20, nullable: false),
                    HoTen = table.Column<string>(maxLength: 150, nullable: false),
                    GioiTinh = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    DiaChi = table.Column<string>(nullable: true),
                    MatKhau = table.Column<string>(nullable: true),
                    ConHieuLuc = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.MaKh);
                });

            migrationBuilder.CreateTable(
                name: "DonHang",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NgayDatHang = table.Column<DateTime>(nullable: false),
                    TrangThaiDonHang = table.Column<int>(nullable: false),
                    TongTien = table.Column<double>(nullable: false),
                    MaKh = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonHang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonHang_KhachHang_MaKh",
                        column: x => x.MaKh,
                        principalTable: "KhachHang",
                        principalColumn: "MaKh",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CTDonHang",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MaDh = table.Column<int>(nullable: false),
                    MaHh = table.Column<int>(nullable: false),
                    SoLuong = table.Column<int>(nullable: false),
                    DonGia = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTDonHang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CTDonHang_DonHang_MaDh",
                        column: x => x.MaDh,
                        principalTable: "DonHang",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CTDonHang_HangHoa_MaHh",
                        column: x => x.MaHh,
                        principalTable: "HangHoa",
                        principalColumn: "MaHh",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CTDonHang_MaDh",
                table: "CTDonHang",
                column: "MaDh");

            migrationBuilder.CreateIndex(
                name: "IX_CTDonHang_MaHh",
                table: "CTDonHang",
                column: "MaHh");

            migrationBuilder.CreateIndex(
                name: "IX_DonHang_MaKh",
                table: "DonHang",
                column: "MaKh");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CTDonHang");

            migrationBuilder.DropTable(
                name: "DonHang");

            migrationBuilder.DropTable(
                name: "KhachHang");
        }
    }
}

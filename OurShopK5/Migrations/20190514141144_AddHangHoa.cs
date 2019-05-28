using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OurShopK5.Migrations
{
    public partial class AddHangHoa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HangHoa",
                columns: table => new
                {
                    MaHh = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TenHh = table.Column<string>(nullable: true),
                    Hinh = table.Column<string>(nullable: true),
                    MoTa = table.Column<string>(nullable: true),
                    DonGia = table.Column<double>(nullable: false),
                    GiamGia = table.Column<byte>(nullable: false),
                    MaLoai = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangHoa", x => x.MaHh);
                    table.ForeignKey(
                        name: "FK_HangHoa_Loai_MaLoai",
                        column: x => x.MaLoai,
                        principalTable: "Loai",
                        principalColumn: "MaLoai",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuaTangs",
                columns: table => new
                {
                    QuaTangId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TenQua = table.Column<string>(nullable: true),
                    MoTa = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    HanDung = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuaTangs", x => x.QuaTangId);
                });

            migrationBuilder.CreateTable(
                name: "NhanQuas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MaQT = table.Column<int>(nullable: false),
                    MaHh = table.Column<int>(nullable: false),
                    MaKh = table.Column<string>(nullable: true),
                    NgayNhan = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanQuas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhanQuas_HangHoa_MaHh",
                        column: x => x.MaHh,
                        principalTable: "HangHoa",
                        principalColumn: "MaHh",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NhanQuas_QuaTangs_MaQT",
                        column: x => x.MaQT,
                        principalTable: "QuaTangs",
                        principalColumn: "QuaTangId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HangHoa_MaLoai",
                table: "HangHoa",
                column: "MaLoai");

            migrationBuilder.CreateIndex(
                name: "IX_NhanQuas_MaHh",
                table: "NhanQuas",
                column: "MaHh");

            migrationBuilder.CreateIndex(
                name: "IX_NhanQuas_MaQT",
                table: "NhanQuas",
                column: "MaQT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NhanQuas");

            migrationBuilder.DropTable(
                name: "HangHoa");

            migrationBuilder.DropTable(
                name: "QuaTangs");
        }
    }
}

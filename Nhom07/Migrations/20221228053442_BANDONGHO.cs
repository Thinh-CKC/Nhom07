using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nhom07.Migrations
{
    public partial class BANDONGHO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoaiSanPhams",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoaiSP = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiSanPhams", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RegisterViewModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterViewModel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoans",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoans", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SanPhams",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenSP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ID_LoaiSP = table.Column<int>(type: "int", nullable: false),
                    LoaiSanPhamID = table.Column<int>(type: "int", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MauSac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TonKho = table.Column<int>(type: "int", nullable: false),
                    MatKinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiDay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Anh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gia = table.Column<int>(type: "int", nullable: false),
                    NoiBat = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhams", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SanPhams_LoaiSanPhams_LoaiSanPhamID",
                        column: x => x.LoaiSanPhamID,
                        principalTable: "LoaiSanPhams",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "HoaDons",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_TaiKhoan = table.Column<int>(type: "int", nullable: false),
                    TaiKhoanID = table.Column<int>(type: "int", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TongTien = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDons", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HoaDons_TaiKhoans_TaiKhoanID",
                        column: x => x.TaiKhoanID,
                        principalTable: "TaiKhoans",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "GioHangs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_TaiKhoan = table.Column<int>(type: "int", nullable: false),
                    TaiKhoanID = table.Column<int>(type: "int", nullable: true),
                    ID_SanPham = table.Column<int>(type: "int", nullable: false),
                    SanPhamID = table.Column<int>(type: "int", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    Gia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHangs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GioHangs_SanPhams_SanPhamID",
                        column: x => x.SanPhamID,
                        principalTable: "SanPhams",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_GioHangs_TaiKhoans_TaiKhoanID",
                        column: x => x.TaiKhoanID,
                        principalTable: "TaiKhoans",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "HinhAnhs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_SanPham = table.Column<int>(type: "int", nullable: false),
                    SanPhamID = table.Column<int>(type: "int", nullable: true),
                    Anh = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HinhAnhs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HinhAnhs_SanPhams_SanPhamID",
                        column: x => x.SanPhamID,
                        principalTable: "SanPhams",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ChiTietHoaDons",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_HoaDon = table.Column<int>(type: "int", nullable: false),
                    HoaDonID = table.Column<int>(type: "int", nullable: true),
                    ID_SanPham = table.Column<int>(type: "int", nullable: false),
                    SanPhamID = table.Column<int>(type: "int", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    Gia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietHoaDons", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDons_HoaDons_HoaDonID",
                        column: x => x.HoaDonID,
                        principalTable: "HoaDons",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDons_SanPhams_SanPhamID",
                        column: x => x.SanPhamID,
                        principalTable: "SanPhams",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDons_HoaDonID",
                table: "ChiTietHoaDons",
                column: "HoaDonID");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDons_SanPhamID",
                table: "ChiTietHoaDons",
                column: "SanPhamID");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangs_SanPhamID",
                table: "GioHangs",
                column: "SanPhamID");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangs_TaiKhoanID",
                table: "GioHangs",
                column: "TaiKhoanID");

            migrationBuilder.CreateIndex(
                name: "IX_HinhAnhs_SanPhamID",
                table: "HinhAnhs",
                column: "SanPhamID");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_TaiKhoanID",
                table: "HoaDons",
                column: "TaiKhoanID");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_LoaiSanPhamID",
                table: "SanPhams",
                column: "LoaiSanPhamID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietHoaDons");

            migrationBuilder.DropTable(
                name: "GioHangs");

            migrationBuilder.DropTable(
                name: "HinhAnhs");

            migrationBuilder.DropTable(
                name: "RegisterViewModel");

            migrationBuilder.DropTable(
                name: "HoaDons");

            migrationBuilder.DropTable(
                name: "SanPhams");

            migrationBuilder.DropTable(
                name: "TaiKhoans");

            migrationBuilder.DropTable(
                name: "LoaiSanPhams");
        }
    }
}

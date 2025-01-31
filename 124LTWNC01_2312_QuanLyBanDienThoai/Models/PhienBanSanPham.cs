﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace _124LTWNC01_2312_QuanLyBanDienThoai.Models
{

    [Table("phienbansanpham")]  // Chỉ định tên bảng trong CSDL
    public class PhienBanSanPham
    {
        public int maPhienBanSanPham { get; set; }

        public int maSanPham { get; set; }

        public int rom { get; set; }

        public int ram { get; set; }

        public int mauSac { get; set; }

        public int giaNhap { get; set; }

        public int giaXuat { get; set; }

        public int soLuongTon { get; set; }

        public byte trangThai { get; set; }

        public ICollection<CTSanPham> CTSanPhams { get; set; }

        // Thuộc tính điều hướng tới bảng SanPham
        public sanpham SanPham { get; set; }

        // Thuộc tính điều hướng tới bảng DungLuongRom
        public DungLuongRom DungLuongRom { get; set; }

        // Thuộc tính điều hướng tới bảng DungLuongRam
        public DungLuongRam DungLuongRam { get; set; }
    }
}

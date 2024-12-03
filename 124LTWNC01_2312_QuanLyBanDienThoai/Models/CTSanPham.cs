namespace _124LTWNC01_2312_QuanLyBanDienThoai.Models
{
    public class CTSanPham
    {
        public int maImei { get; set; }

        public int maPhienBanSanPham { get; set; }

        public int maPhieuNhap { get; set; }

        public int maPhieuXuat { get; set; }

        public int tinhTrang { get; set; }

        public PhienBanSanPham PhienBanSanPham { get; set; }
    }
}

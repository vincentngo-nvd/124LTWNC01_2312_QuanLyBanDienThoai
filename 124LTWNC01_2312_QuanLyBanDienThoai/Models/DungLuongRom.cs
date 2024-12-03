namespace _124LTWNC01_2312_QuanLyBanDienThoai.Models
{
    public class DungLuongRom
    {
        public int maDungLuongRom { get; set; }

        public int kichThuocRom { get; set; }

        public int trangThai { get; set; }

        public ICollection<PhienBanSanPham> PhienBanSanPhams { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace _124LTWNC01_2312_QuanLyBanDienThoai.Models
{
    public class ThuongHieus
    {
        [Key]
        public int mathuonghieu { get; set; }
        public string tenthuonghieu { get; set; }
        public byte trangthai { get; set; } = 1;
    }
}

using _124LTWNC01_2312_QuanLyBanDienThoai.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _124LTWNC01_2312_QuanLyBanDienThoai.Controllers
{
    // Chỉ cần Controller, không cần ApiController nếu bạn trả về View
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Thay vì trả về JSON, ta trả về View chứa dữ liệu sản phẩm
        public async Task<IActionResult> TrangChu()
        {
            var products = await _context.PhienBanSanPhams
                                         .Include(p => p.SanPham)  // Lấy thông tin về sản phẩm liên quan
                                         .ToListAsync();

            // Trả về view TrangChu với danh sách sản phẩm
            return View(products);
        }
    }
}

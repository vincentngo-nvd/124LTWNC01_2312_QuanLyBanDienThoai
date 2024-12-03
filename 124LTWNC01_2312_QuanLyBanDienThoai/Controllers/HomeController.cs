using _124LTWNC01_2312_QuanLyBanDienThoai.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace _124LTWNC01_2312_QuanLyBanDienThoai.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly HttpClient _httpClient;

        private readonly ApplicationDbContext _dbContext; // Kết nối tới DbContext

        public HomeController(ILogger<HomeController> logger, HttpClient httpClient, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _httpClient = httpClient;

            _dbContext = dbContext;
        }

        public async Task<IActionResult> TrangChu()
        {
            // Gọi API ListSanPhamWeb
            var apiSanPhamUrl = "https://localhost:7009/api/CongAPI/ListSanPhamWeb";
            var responseSanPham = await _httpClient.GetAsync(apiSanPhamUrl);

            List<SanPhamDTO> sanPhamDTOList = new();
            if (responseSanPham.IsSuccessStatusCode)
            {
                var dataSanPham = await responseSanPham.Content.ReadAsStringAsync();
                sanPhamDTOList = JsonConvert.DeserializeObject<List<SanPhamDTO>>(dataSanPham);
            }

            // Gọi API ListThuongHieu
            var apiThuongHieuUrl = "https://localhost:7009/api/CongAPI/ListThuongHieu";
            var responseThuongHieu = await _httpClient.GetAsync(apiThuongHieuUrl);

            List<string> thuongHieuList = new();
            if (responseThuongHieu.IsSuccessStatusCode)
            {
                var dataThuongHieu = await responseThuongHieu.Content.ReadAsStringAsync();
                var allThuongHieuList = JsonConvert.DeserializeObject<List<string>>(dataThuongHieu);

                // Lấy 4 thương hiệu đầu tiên
                thuongHieuList = allThuongHieuList.Take(4).ToList();
            }

            // Truyền cả danh sách sản phẩm và thương hiệu vào ViewBag
            ViewBag.ThuongHieuList = thuongHieuList;
            return View(sanPhamDTOList);
        }

        //public async Task<IActionResult> SanPham()
        //{
        //    var apiUrl = "https://localhost:7009/api/CongAPI/ListSanPhamWeb";
        //    var response = await _httpClient.GetAsync(apiUrl);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var data = await response.Content.ReadAsStringAsync();

        //        // Deserialize dữ liệu trả về thành danh sách SanPhamDTO
        //        var sanPhamDTOList = JsonConvert.DeserializeObject<IEnumerable<SanPhamDTO>>(data);

        //        return View(sanPhamDTOList);
        //    }
        //    else
        //    {
        //        ViewBag.ErrorMessage = "Không thể lấy danh sách sản phẩm từ API.";
        //        return View();
        //    }
        //}

        public async Task<IActionResult> SanPham(string brand)
        {
            if (string.IsNullOrEmpty(brand))
            {
                return RedirectToAction("TrangChu");
            }

            // URL API dựa vào tên thương hiệu
            var apiUrl = $"https://localhost:7009/api/CongAPI/ListSanPhamByBrand?brand={brand}";
            var response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var sanPhamDTOList = JsonConvert.DeserializeObject<IEnumerable<SanPhamDTO>>(data);

                return View("SanPham", sanPhamDTOList); // Dùng view SanPham.cshtml cho tất cả thương hiệu
            }
            else
            {
                ViewBag.ErrorMessage = $"Không thể lấy danh sách sản phẩm cho thương hiệu: {brand}.";
                return View("SanPham");
            }
        }


        public async Task<IActionResult> SanPham_Iphone()
        {
            var apiUrl = "https://localhost:7009/api/CongAPI/ListSanPhamIphone";
            var response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var sanPhamDTOList = JsonConvert.DeserializeObject<IEnumerable<SanPhamDTO>>(data);

                return View(sanPhamDTOList);
            }
            else
            {
                ViewBag.ErrorMessage = "Không thể lấy danh sách sản phẩm iPhone từ API.";
                return View();
            }
        }


        // Trang Profile
        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult ThongTinCaNhan()
        {
            return View();
        }

        public IActionResult LienHe()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        // Trang Error
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

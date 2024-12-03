using _124LTWNC01_2312_QuanLyBanDienThoai.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Cấu hình kết nối cơ sở dữ liệu SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Cấu hình CORS - Cho phép tất cả các nguồn (nếu bạn cần giới hạn nguồn thì có thể điều chỉnh lại)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin()    // Cho phép tất cả các nguồn (domain)
              .AllowAnyMethod()    // Cho phép tất cả các phương thức HTTP (GET, POST, PUT, DELETE, ...)
              .AllowAnyHeader();   // Cho phép tất cả các tiêu đề
    });
});

// Đọc cấu hình URL API từ appsettings.json
var apiBaseUrl = builder.Configuration.GetValue<string>("ApiSettings:BaseUrl");

// Đăng ký HttpClient với cấu hình URL API
builder.Services.AddHttpClient("API", client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
});

// Thêm dịch vụ MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Cấu hình đường dẫn nếu không phải môi trường phát triển
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // Giá trị HSTS mặc định là 30 ngày. Bạn có thể thay đổi nếu cần cho môi trường sản xuất.
    app.UseHsts();
}

// **Cấu hình các middleware**
app.UseHttpsRedirection();

// **Đảm bảo cấu hình phục vụ tệp tĩnh từ thư mục wwwroot**
app.UseStaticFiles(); // Phục vụ tệp tĩnh từ wwwroot

// Áp dụng CORS
app.UseCors("AllowAllOrigins");

app.UseRouting();

app.UseAuthorization();

// Định nghĩa các route controller
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=TrangChu}/{id?}");

app.MapControllerRoute(
    name: "custom-profile",
    pattern: "Profile",
    defaults: new { controller = "Home", action = "Profile" });

app.MapControllerRoute(
    name: "custom-thongtincanhan",
    pattern: "ThongTinCaNhan",
    defaults: new { controller = "Home", action = "ThongTinCaNhan" });

app.MapControllerRoute(
    name: "custom-lienhe",
    pattern: "LienHe",
    defaults: new { controller = "Home", action = "LienHe" });

app.MapControllerRoute(
    name: "custom-login",
    pattern: "Login",
    defaults: new { controller = "Home", action = "Login" });

app.MapControllerRoute(
    name: "custom-register",
    pattern: "Register",
    defaults: new { controller = "Home", action = "Register" });

//app.MapControllerRoute(
//    name: "custom-sanpham",
//    pattern: "SanPham",
//    defaults: new { controller = "Home", action = "SanPham" });

//app.MapControllerRoute(
//    name: "custom-sanpham-iphone",
//    pattern: "SanPham_Iphone",
//    defaults: new { controller = "Home", action = "SanPham_Iphone" });

app.MapControllerRoute(
    name: "sanpham-brand",
    pattern: "Home/SanPham_{brand}",
    defaults: new { controller = "Home", action = "SanPham" });


app.Run();

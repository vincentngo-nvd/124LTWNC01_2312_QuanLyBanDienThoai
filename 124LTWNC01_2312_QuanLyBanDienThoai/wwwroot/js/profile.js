document.addEventListener('DOMContentLoaded', function () {
    // Lắng nghe sự kiện click trên tất cả các thẻ <a> trong sidebar
    document.querySelectorAll('.sidebar .menu a').forEach(function (link) {
        link.addEventListener('click', function (event) {
            // Ngừng hành động mặc định của thẻ a
            event.preventDefault();

            // Điều hướng đến URL được chỉ định trong href của thẻ a
            const targetUrl = link.getAttribute('href');
            window.location.href = targetUrl;
        });
    });

    document.querySelector('.logout-btn').addEventListener('click', function () {
        // Chuyển hướng đến trang Login.cshtml
        window.location.href = '/Home/Login'; // Điều hướng đến Login.cshtml
    });
});


document.querySelector('.logo').addEventListener('click', function () {
    // Chuyển hướng đến TrangChu.cshtml
    window.location.href = '/Home/TrangChu'; // Điều hướng đến trang TrangChu.cshtml
});

// Lắng nghe sự kiện click trên button có class "btn-profile"
document.querySelectorAll('.btn-profile').forEach(function (btn) {
    btn.addEventListener('click', function () {
        // Chuyển hướng đến Action Profile
        window.location.href = '/Home/Profile';
    });
});
document.addEventListener('DOMContentLoaded', function () {
    // Lấy tất cả các thẻ div trong product-specs
    const productSpecsDivs = document.querySelectorAll('.product-specs div');

    // Lấy tất cả các thẻ color-item
    const colorItems = document.querySelectorAll('.color-item');

    // Hàm thay đổi border và thêm icon
    function toggleSelectedClass(element, group) {
        // Nếu nhóm đã có một phần tử được chọn, thì bỏ chọn phần tử trước đó
        const selectedElement = document.querySelector(`${group}.selected`);
        if (selectedElement) {
            // Gỡ bỏ class selected và border màu đỏ của phần tử trước đó
            selectedElement.classList.remove('selected');
            selectedElement.style.border = '1px solid #ccc';
            const icon = selectedElement.querySelector('img.red-check');
            if (icon) {
                selectedElement.removeChild(icon);
            }
        }

        // Nếu phần tử chưa được chọn thì chọn nó
        if (!element.classList.contains('selected')) {
            // Thêm class 'selected' và thay đổi border
            element.classList.add('selected');
            element.style.border = '1px solid red';

            // Tạo icon và thêm vào góc trên bên phải
            const icon = document.createElement('img');
            icon.src = '/Images/red_check.png';
            icon.classList.add('red-check'); // Thêm class để dễ dàng nhận diện
            icon.style.position = 'absolute';
            icon.style.top = '5px';
            icon.style.right = '5px';
            icon.style.width = '20px';
            icon.style.height = '20px';

            element.appendChild(icon);
        }
    }

    // Thêm sự kiện cho các thẻ div trong product-specs
    productSpecsDivs.forEach(function (div) {
        div.style.position = 'relative'; // Đảm bảo div có thể chứa icon
        div.addEventListener('click', function () {
            toggleSelectedClass(div, '.product-specs div');
        });
    });

    // Thêm sự kiện cho các thẻ color-item
    colorItems.forEach(function (item) {
        item.style.position = 'relative'; // Đảm bảo item có thể chứa icon
        item.addEventListener('click', function () {
            toggleSelectedClass(item, '.color-item');
        });
    });

    // Thêm sự kiện cho nút Thêm vào giỏ hàng
    const addToCartButton = document.querySelector('.add-cart');
    if (addToCartButton) {
        addToCartButton.addEventListener('click', function () {
            const selectedSpec = document.querySelector('.product-specs .selected');
            const selectedColor = document.querySelector('.color-item.selected');

            if (selectedSpec && selectedColor) {
                alert("Đã thêm vào giỏ hàng!");
            } else if (!selectedSpec && !selectedColor) {
                alert("Vui lòng chọn phiên bản và màu!");
            } else if (!selectedSpec) {
                alert("Vui lòng chọn phiên bản!");
            } else if (!selectedColor) {
                alert("Vui lòng chọn màu!");
            }
        });
    }

    // Thêm sự kiện cho logo (chuyển về TrangChu.cshtml)
    const logo = document.querySelector('.logo');
    if (logo) {
        logo.addEventListener('click', function () {
            // Chuyển hướng về TrangChu.cshtml
            window.location.href = '/Home/TrangChu';
        });
    }

    // Lắng nghe sự kiện click trên button có class "btn-profile"
    document.querySelectorAll('.btn-profile').forEach(function (btn) {
        btn.addEventListener('click', function () {
            // Chuyển hướng đến Action Profile
            window.location.href = '/Home/Profile';
        });
    });
});


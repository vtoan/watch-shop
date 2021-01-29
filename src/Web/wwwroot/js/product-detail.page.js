Gallery();
let ar = location.href.split("-");
let itemid = Number(ar.pop());
window.addEventListener("load", function () {
    let query = document.querySelector("[item-related]").textContent;
    getRelated(query);
});
document.querySelector(".to-cart").addEventListener("click", function (e) {
    e.preventDefault();
    cartObject.addItem(itemid);
    updateViewCount();
    swal({
        title: "Thêm sản phẩm thành công!",
        icon: "success",
        buttons: ["Tiếp tục", "Giỏ hàng"],
    }).then(function (act) {
        if (act) {
            saveCookie();
            location.assign("/gio-hang");
        }
    });
});
document.querySelector(".buy-now").addEventListener("click", function (e) {
    e.preventDefault();
    cartObject.addItem(itemid);
    updateViewCount();
    saveCookie();
    location.assign("/gio-hang");
});
//
let productContainer = document.querySelector("#related-container");
function getRelated(query) {
    let path = getPathCurrent();
    fetch(path + "?handler=related&&query=" + query).then((data) => {
        if (data.ok) {
            data.text().then(renderProduct);
        }
        return null;
    });
}
function renderProduct(html) {
    productContainer.innerHTML = "";
    productContainer.innerHTML = html;
}

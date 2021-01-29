// ==================== View ====================
function currency(number) {
    return new Intl.NumberFormat("de-DE", {
        style: "currency",
        currency: "VND",
    }).format(number);
}
function toggleElm(eOpen, eClose, eTarget) {
    let tagetElm = document.querySelector(eTarget);
    document.querySelector(eOpen).addEventListener("click", function () {
        tagetElm.classList.remove("hide-item");
        tagetElm.classList.add("show-item");
    });
    document.querySelector(eClose).addEventListener("click", function () {
        tagetElm.classList.remove("show-item");
        tagetElm.classList.add("hide-item");
    });
}
function getPathCurrent() {
    return location.href.replaceAll(/[#!]/g, "");
}
toggleElm("#menu-open", "#menu-close", "#menu-target");
toggleElm("#search-open", "#search-close", "#search-target");
document.querySelector("#search-sm").addEventListener("click", function () {
    document.querySelector("#menu-close").click();
    document.querySelector("#search-open").click();
});
// ==================== Loader ====================
let loader = document.querySelector("#loader");
function showLoader() {
    loader.classList.add("active");
}
function closeLoader() {
    setTimeout(function () {
        loader.classList.remove("active");
    }, 500);
}
// ==================== Cart ====================
let cartObject = new Cart();
let countItems = document.querySelector("#cart-count-items");
let addCartEvent = function (elm) {
    let id = elm.getAttribute("item-id");
    if (typeof id == "undefined") window.location.href = "/error";
    cartObject.addItem(id);
    updateViewCount();
};
let updateViewCount = function () {
    countItems.textContent = cartObject.getCount();
};
function saveCookie() {
    let dt = new Date(Date.now() + 30 * 86400000);
    document.cookie = `basketshopping=${JSON.stringify(
        cartObject.getData()
    )};expires=${dt.toString()};path=/;`;
}
function getCookie() {
    let cookie = document.cookie;
    let stringUtf = decodeURIComponent(cookie);
    let asset = stringUtf.split(";");
    let cart;
    for (let i = 0; i < asset.length; i++) {
        let data = asset[i].split("=");
        if (data[0].trimStart() == "basketshopping") {
            cart = data[1];
        }
    }
    if (cart) return JSON.parse(cart);
    return [];
}
function attachEventProductItem() {
    document.querySelectorAll(".add-cart").forEach((item) => {
        item.addEventListener("click", function () {
            addCartEvent(this);
            swal({
                title: "Thêm sản phẩm thành công!",
                icon: "success",
                buttons: ["Tiếp tục", "Giỏ hàng"],
            }).then((act) => {
                if (act) location.assign("/gio-hang");
            });
        });
    });
}
cartObject.setData(getCookie());
window.addEventListener("beforeunload", saveCookie);
updateViewCount();
attachEventProductItem();

Gallery();
let itemid = location.href.split("=")[1];
window.addEventListener("load", function () {
    let query = document.querySelector("[item-related]").textContent;
    getRelated(query);
});
document.querySelector(".to-cart").addEventListener("click", function (e) {
    e.preventDefault();
    cartObject.addItem(itemid);
    updateViewCount();
    showAddCartAlert();
});
document.querySelector(".buy-now").addEventListener("click", function (e) {
    e.preventDefault();
    cartObject.addItem(itemid);
    updateViewCount();
    location.assign("/goi-hang");
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

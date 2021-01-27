Gallery();
let itemid = location.href.split("=")[1];
window.addEventListener("load", function () {
    let query = document.querySelector("[item-related]").textContent;
    getRelated(query);
});
document.querySelector(".to-cart").addEventListener("click", function (e) {
    cartObject.addItem(itemid);
    updateViewCount();
    showAddCartAlert();
});
document.querySelector(".buy-now").addEventListener("click", function (e) {
    cartObject.addItem(itemid);
    updateViewCount();
    location.assign("/goi-hang");
});
//
let productContainer = document.querySelector("#related-container");

function getRelated(query) {
    let path = location.href;
    fetch(path + "?handler=related&&query=" + query)
        .then((data) => {
            if (data.ok) return data.text();
            return null;
        })
        .then(renderProduct)
        .catch((er) => console.log(er));
}
function renderProduct(html) {
    productContainer.innerHTML = "";
    productContainer.innerHTML = html;
}

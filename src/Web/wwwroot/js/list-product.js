let dropdown = new UIDropDown();
let pageItems = document.querySelectorAll(".page-item");
let orderItems = document.querySelectorAll(".order-item");
let scrollValue = screen.width > 1024 ? 475 : 145;
let valOrder = 0;
//
let productContainer = document.querySelector("#product-container");
//
pageItems.forEach((item) => {
    item.addEventListener("click", function (e) {
        e.preventDefault();
        showLoader();
        pageItems.forEach((page) => {
            if (page.classList.contains("active")) {
                page.classList.remove("active");
                return;
            }
        });
        this.classList.add("active");
        getPage(Number(this.textContent));
    });
});
orderItems.forEach((item) => {
    item.addEventListener("click", function (e) {
        e.preventDefault();
        showLoader();
        orderItems.forEach((page) => {
            if (page.classList.contains("active")) {
                page.classList.remove("active");
                return;
            }
        });
        this.classList.add("active");
        valOrder = Number(this.getAttribute("index"));
        if (pageItems.length > 0) pageItems.item(0).click();
        else getPage(1);
    });
});
function renderProduct(html) {
    productContainer.innerHTML = "";
    productContainer.innerHTML = html;
    closeLoader();
    window.scrollTo({
        top: scrollValue,
        behavior: "smooth",
    });
}
function getPage(page) {
    let path = location.href;
    let query =
        (path.includes("?") ? "&&" : "?") +
        `handler=ajax&&o=${valOrder}&&p=${page}`;
    fetch(path + query)
        .then((data) => {
            if (data.ok) return data.text();
            return null;
        })
        .then(renderProduct)
        .catch((er) => console.log(er));
}

let dropdown = new UIDropDown((idx) => console.log(idx));
let pageItems = document.querySelectorAll(".page-item");
let scrollValue = screen.width > 1024 ? 525 : 145;
//
let productContainer = document.querySelector("#product-container");

pageItems.forEach((item) => {
    item.addEventListener("click", function (e) {
        e.preventDefault();
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

function renderProduct(html) {
    productContainer.innerHTML = "";
    productContainer.innerHTML = html;
    window.scrollTo({
        top: scrollValue,
        behavior: "smooth",
    });
}

function getPage(page) {
    let url = location.href + "?handler=ajax&&p=" + page;
    fetch(url)
        .then((data) => data.text())
        .then(renderProduct)
        .catch((er) => console.log(er));
}

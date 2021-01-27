function cart(config) {
    let options = {
        cart: null,
        quantityChanged: null,
        root: "#cart",
        currency: null,
        loader: { show: null, close: null },
        popup: { show: null, close: null },
        checkOutUri: "",
    };
    options = config;
    let cart = options.cart;
    let root = document.querySelector(options.root);
    let listCartItem = [];
    let listFees = [];
    let promo = null;
    let elmTotal = root.querySelector("[order-total]");
    let elmPay = root.querySelector("[order-pay]");
    let elmPromo = root.querySelector("[order-promotion]");
    let countItem = root.querySelector("#count-items");
    countItem.textContent = cart.getCount();
    //get list item in cart;
    root.querySelectorAll(".cart-item").forEach((element) => {
        let itemId = element.getAttribute("item-id");
        listCartItem.push({
            id: itemId,
            elm: element,
        });
        attachEventItem(element, itemId);
    });
    //get fees in cart;
    root.querySelectorAll("td[order-fees]").forEach(function (element) {
        let cost = element.getAttribute("fee-cost");
        if (!cost) return;
        listFees.push(cost);
        element.textContent =
            cost % 1 == 0 ? options.currency(cost) : cost * 100 + " %";
    });
    root.querySelector("a[prom-submit]").addEventListener(
        "click",
        function (e) {
            e.preventDefault();
            let promELm = this.previousElementSibling;
            let val = promELm.value;
            if (!val) return;
            checkPromotion(val);
            promELm.value = "";
        }
    );
    root.querySelector("form").addEventListener("submit", function (e) {
        let prom = document.createElement("input");
        prom.value = promo?.code;
        prom.name = "promCode";
        prom.type = "hidden";
        this.appendChild(prom);
        let listItem = document.createElement("input");
        listItem.value = JSON.stringify(cart.getData());
        listItem.name = "listItem";
        listItem.type = "hidden";
        this.appendChild(listItem);
        return true;
    });
    // ========== define event ==========
    function attachEventItem(element, id) {
        element
            .querySelector("a[quantity-add]")
            .addEventListener("click", function (e) {
                e.preventDefault();
                updateQuantityItem(this.nextElementSibling, id, true);
            });
        element
            .querySelector("a[quantity-subtract]")
            .addEventListener("click", function (e) {
                e.preventDefault();
                updateQuantityItem(this.previousElementSibling, id, false);
            });
        element
            .querySelector("a[quantity-remove]")
            .addEventListener("click", function (e) {
                e.preventDefault();
                removeItem(this);
            });
    }
    function removeItem(element) {
        let index = listCartItem.findIndex((obj) => obj.elm.contains(element));
        //remove
        cart.removeItem(listCartItem[index].id);
        listCartItem[index].elm.remove();
        listCartItem.splice(index, 1);
        if (listCartItem.length == 0) {
            elmPromo.parentElement.classList.add("d-none");
            elmPromo.textContent = "0 đ";
            root.querySelector(
                "#cart-container"
            ).innerHTML = `<p class="text-center"> Trống !</p>`;
        }
        //update change
        options.quantityChanged();
        countItem.textContent = cart.getCount();
        updateSummaryOrder();
    }
    function updateQuantityItem(countElm, itemId, operation) {
        let count = parseInt(countElm.textContent) + (operation ? 1 : -1);
        if (!count) return;
        //update change
        cart.changeQuantityItem(itemId, operation);
        countElm.textContent = count;
        updateTotalItem(countElm, count);
        options.quantityChanged();
        countItem.textContent = cart.getCount();
        updateSummaryOrder();
    }
    function updateTotalItem(element, count) {
        let price = element.getAttribute("item-price");
        let total = price * (count ?? 1);
        let elm = element
            .closest(".col-12")
            .nextElementSibling.querySelector("span[item-total]");
        elm.textContent = currency(total);
        elm.setAttribute("item-total", total);
    }
    function updateSummaryOrder() {
        let totalOrder = listCartItem.reduce((count, value) => {
            return (count += Number(
                value.elm
                    .querySelector("span[item-total]")
                    .getAttribute("item-total")
            ));
        }, 0);
        let totalFee =
            listFees?.reduce((count, value) => {
                return (count += Number(
                    value % 1 == 0 ? value : totalOrder * value
                ));
            }, 0) ?? 0;

        let pay = totalOrder + totalFee;
        //show to view
        elmTotal.textContent = options.currency(totalOrder);
        elmPay.textContent = options.currency(Math.round(pay));
    }
    //promotion
    function checkPromotion(promCode) {
        options.loader.show();

        if (location.href.endsWith("#!")) return;
        let url = location.href + "?handler=checkprom&&code=" + promCode;
        fetch(url).then(function (response) {
            if (response.ok) {
                // response.json().
                // let cost = promo.discount;
                // elmPromo.textContent =
                //     "- " + (cost % 1 == 0 ? currency(cost) : cost * 100 + " %");
                // elmPromo.parentElement.classList.remove("d-none");
                // options.loader.close();
                // options.popup.show(
                //     true,
                //     "Thành công!",
                //     "Đã áp dụng mã giảm giá"
                // );
            } else {
                options.loader.close();
                options.popup.show(
                    false,
                    "Thất bại!",
                    "Mã giảm giá không hợp lệ"
                );
            }
        });
    }
    updateSummaryOrder();
}
//
function showPopup(success, title, messsage) {
    swal({
        title: title,
        text: messsage,
        icon: success ? "success" : "error",
        button: "OK",
    });
}
let container = document.querySelector("#cart-container");
function renderCartItem(data) {
    container.innerHTML = "";
    container.innerHTML = data;
    let act = cart({
        cart: cartObject,
        quantityChanged: updateViewCount,
        root: "#cart",
        currency: currency,
        loader: { show: showLoader, close: closeLoader },
        popup: { show: showPopup, close: null },
        checkOutUri: "/gio-hang",
    });
}
window.addEventListener("load", function () {
    let val = JSON.stringify(cartObject.getData());
    if (location.href.endsWith("#!")) return;
    let url = location.href + "?handler=cartitem&&ids=" + val;
    fetch(url)
        .then((response) => {
            if (response.ok) return response.text();
            return null;
        })
        .then(renderCartItem)
        .catch((er) => console.log(er));
});

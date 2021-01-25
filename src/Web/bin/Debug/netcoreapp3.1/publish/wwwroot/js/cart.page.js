(function (config) {
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
    let promo = { code: "ABC", discount: "0.3" };
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
        e.preventDefault();
        var formData = new FormData();
        formData.append("promCode", promo.code);
        formData.append("order", JSON.stringify(cart.getData()));
        console.log(this);
        var request = new XMLHttpRequest();
        request.open("POST", options.checkOutUri);
        request.send(formData);
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
        let cost = promo.discount;
        elmPromo.textContent =
            "- " + (cost % 1 == 0 ? currency(cost) : cost * 100 + " %");
        elmPromo.parentElement.classList.remove("d-none");
        setTimeout(function () {
            options.loader.close();
            options.popup.show(true, "Thành công!", "Đã áp dụng mã giảm giá");
        }, 1500);
        // fetch("", {
        //     method: "GET",
        //     body: { promCode: promCode },
        // }).then(function (response) {
        //     console.log(response);
        // });
    }
    updateSummaryOrder();
})({
    cart: cartObject,
    quantityChanged: updateViewCount,
    root: "#cart",
    currency: currency,
    loader: { show: showLoader, close: closeLoader },
    popup: { show: showPopup, close: null },
    checkOutUri: "/",
});
//
function showPopup(success, title, messsage) {
    swal({
        title: title,
        text: messsage,
        icon: success ? "success" : "error",
        button: "OK",
    });
}
//dump-data
cartObject.addItem(1);
cartObject.addItem(2);

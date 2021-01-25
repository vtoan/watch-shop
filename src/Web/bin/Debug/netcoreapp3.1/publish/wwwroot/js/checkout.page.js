let province = "";
let district = "";
let dropdown = new UIDropDown(function (val) {
    province = val;
}, "[local-province ]");
let dropdown2 = new UIDropDown(function (val) {
    district = val;
}, "[local-district ]");
document.querySelector("#send-order").addEventListener("click", function (e) {
    document.querySelector("#formOrder [type=submit]").click();
});
let form = document.querySelector("#formOrder");
form.addEventListener("submit", function (e) {
    if (!province) dropdown.invalid();
    if (!district) dropdown2.invalid();
    if (district && province) {
        var formData = new FormData(form);
        formData.append("promCode", "ABC");
        formData.append("order", JSON.stringify(cartObject.getData()));
        return true;
    }
    return false;
});
function createInputElm(name, data) {
    return `<input type="hidden" name="${name}" value="${data}">`;
}

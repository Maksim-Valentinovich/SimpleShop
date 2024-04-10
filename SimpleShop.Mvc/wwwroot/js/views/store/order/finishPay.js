$(".finish-pay-button").click(function () {
    window.location.href = "http://localhost:5255/Home/Index";
});

setInterval(function () {
    var div = document.querySelector("#counter");
    var count = div.textContent * 1 - 1;
    div.textContent = count;
    if (count <= 0) {
        window.location.replace("http://localhost:5255/Home/Index");
    }
}, 1000);
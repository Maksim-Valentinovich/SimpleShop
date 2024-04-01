let user;

$(".offline").click(function () {
    $.ajax({
        url: 'MakeOrder',
        type: 'POST',
        data: {...user,isOnline:false},
        success: function (content) {
            window.location.href = "http://localhost:5255/Store/Order/FinishPay";
        },
        error: function (e) { }
    })
})

$(".online").click(function () {
    $(".payment-method").addClass("d-none")
    $('#onlinePay').removeClass("d-none")
});

$(".finish-pay").click(function () {
    $.ajax({
        url: 'MakeOrder',
        type: 'POST',
        data: { ...user, isOnline: true },
        success: function (content) {
            window.location.href = "http://localhost:5255/Store/Order/FinishPay";
        },
        error: function (e) { }
    })
})

$("#buy").on("click", function () {
    user = {
        Name: $("#name").val(),
        Surname: $("#surname").val(),
        Patronymic: $("#patronymic").val(),
        Phone: $("#phone").val(),
        Birthday: $("#birthday").val(),
        IsMan: $("input[type='radio'][name='flexRadioDefault']:checked").val(),
        Email: $("#email").val(),
    };
    if (!user.Name) {
        $("#validation-name").text("Поле не заполнено!")
        return;
    } else {
        $("#validation-name").text("")
    }
    if (!user.Surname) {
        $("#validation-surname").text("Поле не заполнено!")
        return;
    } else {
        $("#validation-surname").text("")
    }
    if (!user.Patronymic) {
        $("#validation-patronymic").text("Поле не заполнено!")
        return;
    } else {
        $("#validation-patronymic").text("")
    }
    if (!user.Birthday) {
        $("#validation-birthday").text("Поле не заполнено!")
        return;
    } else {
        $("#validation-birthday").text("")
    }
    if (!user.Phone) {
        $("#validation-phone").text("Поле не заполнено!")
        return;
    } else {
        $("#validation-phone").text("")
    }
    if (!user.Email) {
        $("#validation-email").text("Поле не заполнено!")
        return;
    } else {
        $("#validation-email").text("")
    }
    $('#choose-pay').modal('show');
});

$(document).ready(function () {
    $.ajax({
        url: 'Product',
        type: 'GET',
        dataType: 'html',
        success: function (content) {
            $('#additional div.partial-content').html(content);
        },
        error: function (e) { }
    });
})

$("#phone").mask("+7(999) 999-9999");


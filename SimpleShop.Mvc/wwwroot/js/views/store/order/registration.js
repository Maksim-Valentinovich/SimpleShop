let user;

function makeOrder(user, isOnline) {
    $.ajax({
        url: 'MakeOrder',
        type: 'POST',
        data: { ...user, isOnline },
        success: function (content) {
            window.location.href = "http://localhost:5255/Store/Order/FinishPay";
        },
        error: function (e) { }
    })
}
$(".offline").click(function () {
    makeOrder(user,false);
})

$(".finish-online-pay").click(function () {
    makeOrder(user, true);
})

$(".online").click(function () {
    $(".payment-method").addClass("d-none")
    $(".modal-title").text('Оплата картой')
    $('#onlinePay').removeClass("d-none")
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
})

$(document).ready(function () {
    $.ajax({
        url: '/Store/ShopCard/Product',
        type: 'GET',
        dataType: 'html',
        success: function (content) {
            $('#additional div.partial-content').html(content);
        },
        error: function (e) { }
    });
})

$("#phone").mask("+7(999) 999-9999")

$('#form').on('change', function () {
    if ($(this).is(':checked')) $('.button-choose-pay').attr('disabled', false);
    else $('.button-choose-pay').attr('disabled', true);
})

$(function () {
    $('#birthday').datepicker({
        position: 'bottom right',
        onSelect(formatedDate, date, inst) {
            inst.hide();
        }
    });
})
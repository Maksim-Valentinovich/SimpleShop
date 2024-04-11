$(document).ready(function () {
    $.ajax({
        url: '/Store/ShopCard/BasketModal',
        type: 'GET',
        dataType: 'html',
        success: function (content) {
            $('#additional div.partial-content').html(content);
        },
        error: function (e) { }
    });
})


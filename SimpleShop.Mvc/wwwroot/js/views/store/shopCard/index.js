$(document).ready(function () {
    $.ajax({
        url: 'Order/BasketModal',
        type: 'GET',
        dataType: 'html',
        success: function (content) {
            $('#additional div.partial-content').html(content);
        },
        error: function (e) { }
    });
})


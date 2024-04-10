
$(document).ready(function () {
    $.ajax({
        url: 'Recommendations',
        type: 'GET',
        dataType: 'html',
        success: function (content) {
            $('#additional div.partial-content').html(content);
        },
        error: function (e) { }
    });
})

$('#modal').on('hidden', function () {
    $(this).data('modal').$element.removeData();
})

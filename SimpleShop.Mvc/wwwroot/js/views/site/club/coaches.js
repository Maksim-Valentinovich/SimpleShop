
$(".dropdown-item").click(function () {
    let clubId = $(this).data("club")
    $(".button-see").data("club", clubId);
})

$(".button-see").click(function () {
    let clubId = $(this).data("club")
    $.ajax({
        url: 'CategoryCoaches?clubId=' + clubId,
        type: 'GET',
        dataType: 'html',
        success: function (content) {
            $('#coaches div.partial-content').html(content);
        },
        error: function (e) { }
    });
})

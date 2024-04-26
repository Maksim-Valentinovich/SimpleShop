let coach
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

$(".change-city").click(function () {
    $.ajax({
        url: '/Home/ChooseCityModal',
        type: 'GET',
        dataType: 'html',
        success: function (content) {
            $('#choose-city div.modal-content').html(content);
            $('#choose-city').modal('show');
        },
        error: function (e) { }
    })
})



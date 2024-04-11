$(".change-city").click(function () {
    $.ajax({
        url: '/Home/ChooseCityModal',
        type: 'GET',
        dataType: 'html',
        success: function (content) {
            $('#choose-city div.modal-body').html(content);
            $('#choose-city').modal('show');
        },
        error: function (e) { }
    })
})

$(document).ready(function () {
    $.ajax({
        url: '/Home/CookieCheck2',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            console.dir(data);
        },
        error: function (jqXHR, exception) {
            if (jqXHR.status == 200) {
                // window.location.href = "http:localhost:5255/Home/Index";
                // window.location === document.location;  
                console.dir(data);
            }
            else if (jqXHR.status == 404) {
                $.ajax({
                    url: 'ChooseCityModal',
                    type: 'GET',
                    dataType: 'html',
                    success: function (content) {
                        $('#choose-city div.modal-body').html(content);
                        $('#choose-city').modal('show');
                    },
                    error: function (e) { }
                })
            }
            else (jqXHR.status == 400)
            {
                navigator.geolocation.getCurrentPosition(
                    function (position) {
                        $.ajax({
                            url: 'Home/AgreeCityModal?latitude=' + position.coords.latitude + "&longitude=" + encodeURIComponent(position.coords.longitude),
                            type: 'GET',
                            dataType: 'html',
                            success: function (content) {
                                $('#question div.location-content').html(content);
                            },
                            error: function (e) { }
                        });
                    }
                );
            }
        }
    })
})

$(function () {
    $('#airdatepicker').datepicker({
        position: 'bottom right',
        onSelect(formatedDate, date, inst) {
            inst.hide();
        }
    });
})
$('#form-checkbox').on('change', function () {
    if ($(this).is(':checked')) $('.btn-primary').attr('disabled', false);
    else $('.btn-primary').attr('disabled', true);
});

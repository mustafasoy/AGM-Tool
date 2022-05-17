$(document).ready(function () {
    $('#master').hide();
    $('#doctoral').hide();

    $('#educationStatu').change(function () {
        var education = $("#educationStatu option:selected").val();
        if (education == 8) {
            $('#master').show();
        }
        if (education == 10) {
            $('#master').show();
            $('#doctoral').show();
        }
        if (education != 8 && education != 10) {
            $('#master').hide();
            $('#doctoral').hide();
        }
    });
})
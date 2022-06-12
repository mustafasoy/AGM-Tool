$(document).ready(function () {
    $('#natSupportProgram').hide();
    $('#intSupportProgram').hide();
    $('#orderBase').hide();

    if ($('#natSupportProgram').val()) {
        $('#checkNatSupportProgram').prop('checked', true);
        $('#natSupportProgram').show();
    }
    if ($('#intSupportProgram').val()) {
        $('#checkIntSupportProgram').prop('checked', true);
        $('#intSupportProgram').show();
    }
    if ($('#orderBase').val()) {
        $('#checkOrderBase').prop('checked', true);
        $('#orderBase').show();
    }

    $('#natSupportProgram').on('blur', function () {
        if (!$('#natSupportProgram').val()) {
            $('#checkNatSupportProgram').prop('checked', false);
            $('#natSupportProgram').hide();
        };
    });

    $('#intSupportProgram').on('blur', function () {
        if (!$('#intSupportProgram').val()) {
            $('#checkIntSupportProgram').prop('checked', false);
            $('#intSupportProgram').hide();
        };
    });

    $('#checkOrderBase').on('blur', function () {
        if (!$('#checkOrderBase').val()) {
            $('#checkOrderBase').prop('checked', false);
            $('#checkOrderBase').hide();
        };
    });

    $("#checkNatSupportProgram").on("click", function () {
        $("#natSupportProgram").val('');
        $("#natSupportProgram").toggle(this.checked);
    });
    $("#checkIntSupportProgram").on("click", function () {
        $("#intSupportProgram").toggle(this.checked);
    });
    $("#checkOrderBase").on("click", function () {
        $("#orderBase").toggle(this.checked);
    });
});
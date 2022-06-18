$(document).ready(function () {
    $('#projectCode').change(function () {
        $('#error').text('');
    });
});

$(function () {
    $("#save").click(function () {
        if (!$('#projectCode').val()) {
            $('#error').text('Proje kodu seçiniz.');
            return;
        }

        if ($("#personnelTable input[type=checkbox]:checked").length === 0) {
            showErrorMessage("Personel seçiniz.");
            return;
        }

        var token = $('input[name="__RequestVerificationToken"]').val();

        var projectCode = $("#projectCode option:selected").val();
        var projectName = $("#projectCode option:selected").text();

        var persList = [];
        $("#personnelTable input[type=checkbox]:checked").each(function (i) {
            var row = $(this).closest("tr")[0];

            if (i !== 0) {
                persList.push({
                    id: row.cells[2].innerHTML,
                    identityNumber: row.cells[3].innerHTML,
                    registrationNo: row.cells[4].innerHTML,
                    nameSurname: row.cells[5].innerHTML,
                    projectCode: projectCode,
                    projectName: projectName
                });
            }
        });

        $.ajax({
            type: 'POST',
            url: '/RdCenterCal/PersonnelAssing',
            data: {
                __RequestVerificationToken: token,
                persAssingViewModel: persList
            },
            success: function (response) {
                if (response === "201" || response === "204") {
                    response === "201" ? showMessage('Personellere proje kodu atandı.') : showMessage('Personellere atanan proje kodu güncellendi.')
                }
                else {
                    showErrorMessage('Personellere proje kodu atanamadı.')
                }
            },
            error: function () {
                showErrorMessage('Personellere proje kodu atanırken hata oluştu.')
            }
        });
    });
});
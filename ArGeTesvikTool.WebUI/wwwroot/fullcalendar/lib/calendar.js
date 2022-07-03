$(document).ready(function () {

    $("#startDatetimepicker, #endDatetimepicker").on("change.datetimepicker", function () {
        $('#error').text('');
    });

    $("#updateStartDatetimepicker, #updateEndDatetimepicker").on("change.datetimepicker", function () {
        $('#updateError').text('');
    });

    $('#projectCode, #timeAwayCode').on('change', function () {
        $('#error').text('');
        if ($('#timeAwayCode').val() >= 3 && $('#timeAwayCode').val() <= 12) {
            $("#project").show();
        }
        else {
            $("#project").hide();
        }
    });

    $('#updateProjectCode, #updateTimeAwayCode').on('change', function () {
        $('#updateError').text('');
        if ($('#updateTimeAwayCode').val() >= 3 && $('#updateTimeAwayCode').val() <= 12) {
            $("#updateProject").show();
        }
        else {
            $("#updateProject").hide();
        }
    });

    /*$("#outside").hide();*/
    $("input[name='radioTime']").click(function () {
        if ($("#projectTime").is(":checked")) {
            $("#project").show();
            $("#outside").hide();
            $('#timeAwayCode').prop('selectedIndex', 0);
        } else {
            $("#outside").show();
            $("#project").hide();
            $('#projectCode').prop('selectedIndex', 0);
        }
    });
});

document.addEventListener('DOMContentLoaded', function () {
    var calendarEl = document.getElementById('calendar');
    var selectedEvent = null;
    var events = [];

    var calendar = new FullCalendar.Calendar(calendarEl, {
        contentHeight: 750,
        themeSystem: 'bootstrap',
        bootstrapFontAwesome: {
            prev: 'fa-arrow-circle-left',
            next: 'fa-arrow-circle-right'
        },
        locale: 'tr',
        headerToolbar: {
            left: 'prev next today',
            center: 'title',
            right: 'dayGridMonth timeGridWeek timeGridDay timeGridFourDay listWeek'
        },
        initialView: 'timeGridWeek',
        dayHeaderFormat: {
            weekday: 'long'
        },
        allDaySlot: false,
        views: {
            timeGridFourDay: {
                type: 'timeGrid',
                duration: { days: 4 },
                buttonText: '4 Gün'
            },
            listWeek: {
                buttonText: 'Planlama',
            },
        },
        selectable: true,
        select: function (selectionInfo) {
            var end = moment(selectionInfo.end);
            var start = moment(selectionInfo.start);

            if (end.isAfter(start, 'day')) {
                calendar.unselect();
                return;
            }
            selectedEvent = {
                id: 0,
                userId: 0,
                ProjectCode: "",
                timeAwayCode: "",
                start: moment(selectionInfo.start),
                end: moment(selectionInfo.end),
            };

            checkPreWeekTime();
            //getPersonnelTime();
        },
        //slotDuration: '00:15:00',
        //slotLabelInterval: '00:15:00',
        snapDuration: '00:15:00',
        eventOverlap: function (stillEvent, movingEvent) {
            return stillEvent.allDay && movingEvent.allDay;
        },
        slotLabelFormat: {
            hour: 'numeric',
            minute: '2-digit'
        },
        fixedWeekCount: false,
        editable: true,
        eventClick: function (info) {
            var backgroundColor = info.event.backgroundColor;
            if (backgroundColor === '#db3939') {
                showErrorMessage('Tatil gününe giriş yapılamaz.');
                return;
            };

            selectedEvent = {
                id: info.event.id,
                projectCode: info.event.extendedProps.projectCode,
                timeAwayCode: info.event.extendedProps.timeAwayCode,
                start: moment(info.event.start),
                end: moment(info.event.end)
            };

            $('#updateEntryId').val(info.event.id);
            $('#updateProjectCode').val(info.event.extendedProps.projectCode);
            $('#updateTimeAwayCode').val(info.event.extendedProps.timeAwayCode);
            $('#updateStartDate').val(moment(info.event.start).format('DD.MM.YYYY HH:mm'));
            $('#updateEndDate').val(moment(info.event.end).format('DD.MM.YYYY HH:mm'));

            getUpdatePersonnelTime();
            $('#updateModal').modal();
        },
        eventDrop: function (dropEventInfo) {
            var backgroundColor = dropEventInfo.event.backgroundColor;
            if (backgroundColor === '#db3939') {
                showErrorMessage('Tatil gününe giriş yapılamaz.');
                dropEventInfo.revert();
                return;
            };

            var events = {
                Id: dropEventInfo.event.id,
                ProjectCode: dropEventInfo.event.extendedProps.projectCode,
                ProjectName: dropEventInfo.event.extendedProps.projectName,
                TimeAwayCode: dropEventInfo.event.extendedProps.timeAwayCode,
                TimeAwayName: dropEventInfo.event.extendedProps.timeAwayName,
                StartDate: moment(dropEventInfo.event.start).format('DD.MM.YYYY HH:mm'),
                EndDate: moment(dropEventInfo.event.end).format('DD.MM.YYYY HH:mm')
            };
            $.ajax({
                type: 'GET',
                url: '/RdCenterCal/CheckPersonnelTime',
                data: {
                    startDate: events.StartDate,
                    endDate: events.EndDate,
                    projectCode: events.ProjectCode,
                    timeAwayCode: events.TimeAwayCode
                },
                success: function (response) {
                    if (response === "200") {
                        saveAppoinment(events)
                    };
                    if (response === "400") {
                        dropEventInfo.revert();
                        showErrorMessage('Pdks süresinden fazla zaman aralığı seçildi.');
                    };
                    if (response === "404") {
                        dropEventInfo.revert();
                        showErrorMessage('Kapı geçiş verileri bulunamadı.');
                    };
                },
                error: function () {
                    dropEventInfo.revert();
                    showErrorMessage('Kapı geçiş verileri bulunamadı.');
                }
            });
        },
        eventResize: function (dropEventInfo) {
            var backgroundColor = dropEventInfo.event.backgroundColor;
            if (backgroundColor === '#db3939') {
                showErrorMessage('Tatil gününe giriş yapılamaz.');
                dropEventInfo.revert();
                return;
            };

            var events = {
                Id: dropEventInfo.event.id,
                ProjectCode: dropEventInfo.event.extendedProps.projectCode,
                ProjectName: dropEventInfo.event.extendedProps.projectName,
                TimeAwayCode: dropEventInfo.event.extendedProps.timeAwayCode,
                TimeAwayName: dropEventInfo.event.extendedProps.timeAwayName,
                StartDate: moment(dropEventInfo.event.start).format('DD.MM.YYYY HH:mm'),
                EndDate: moment(dropEventInfo.event.end).format('DD.MM.YYYY HH:mm')
            };

            $.ajax({
                type: 'GET',
                url: '/RdCenterCal/CheckPersonnelTime',
                data: {
                    startDate: events.StartDate,
                    endDate: events.EndDate,
                    projectCode: events.ProjectCode,
                    timeAwayCode: events.TimeAwayCode
                },
                success: function (response) {
                    if (response === "200") {
                        saveAppoinment(events)
                    };
                    if (response === "400") {
                        dropEventInfo.revert();
                        showErrorMessage('Pdks süresinden fazla zaman aralığı seçildi.');
                    };
                    if (response === "404") {
                        dropEventInfo.revert();
                        showErrorMessage('Kapı geçiş verileri bulunamadı.');
                    };
                },
                error: function () {
                    dropEventInfo.revert();
                    showErrorMessage('Kapı geçiş verileri bulunamadı.');
                }
            });
        },
    });

    calendar.render();
    getPersonnelEntry();

    $('#startDatetimepicker, #endDatetimepicker, #updateStartDatetimepicker, #updateEndDatetimepicker').datetimepicker({
        format: 'DD.MM.YYYY HH:mm',
        locale: 'tr'
    });

    function openCreateOrUpdateModal() {
        $('#error').text('');

        if ($("#projectTime").is(":checked")) {
            $("#project").show();
            $("#outside").hide();
            $('#timeAwayCode').prop('selectedIndex', 0);
        } else {
            $("#outside").show();
            $("#project").hide();
            $('#projectCode').prop('selectedIndex', 0);
        }

        if (selectedEvent != null) {
            $('#entryId').val(selectedEvent.id);
            $('#userId').val(selectedEvent.userId);
            $('#projectCode').val(selectedEvent.projectCode);
            $('#timeAwayCode').val(selectedEvent.timeAwayCode);
            $('#startDate').val(selectedEvent.start.format('DD.MM.YYYY HH:mm'));
            $('#endDate').val(selectedEvent.end.format('DD.MM.YYYY HH:mm'));
        }

        $('#saveModal').modal();
    };

    function getPersonnelTime() {
        var entryId = selectedEvent.id;
        var sDate = selectedEvent.start.format('DD.MM.YYYY')
        var eDate = selectedEvent.end.format('DD.MM.YYYY')
        $.ajax({
            type: 'GET',
            url: '/RdCenterCal/GetPersonnelTime',
            data: {
                id: entryId,
                startDate: sDate,
                endDate: eDate,
            },
            success: function (response) {
                $('#projectText').text(response.projectTime);
                $('#projectMin').text(response.projectMin);
                $('#timeAwayText').text(response.timeAwayTime);
                $('#timeAwayMin').text(response.timeAwayMin);
                if (!response.projectTime) {
                    $("#projectRadio").hide();
                    $("#project").hide();
                }
                if (!response.timeAwayTime) {
                    $("#timeAwayRadio").hide();
                    $("#outside").hide();

                }
                if (response === '401') {
                    showErrorMessage('Tatil gününe giriş yapılamaz.');
                    return;
                }

                openCreateOrUpdateModal();
            },
            error: function () {
                showErrorMessage('Kapı geçiş verileri bulunamadı.');
            }
        });
    };

    function getUpdatePersonnelTime() {
        var entryId = selectedEvent.id;
        var sDate = selectedEvent.start.format('DD.MM.YYYY HH:mm')
        var eDate = selectedEvent.end.format('DD.MM.YYYY HH:mm')
        $.ajax({
            type: 'GET',
            url: '/RdCenterCal/GetPersonnelTime',
            data: {
                id: entryId,
                startDate: sDate,
                endDate: eDate,
            },
            success: function (response) {
                $('#updateProjectText').text(response.projectTime);
                $('#updateProjectMin').text(response.projectMin);
                $('#updateTimeAwayText').text(response.timeAwayTime);
                $('#updateTimeAwayMin').text(response.timeAwayMin);
                if (!response.projectTime) {
                    $("#updateProjectRadio").hide();
                    $("#updateProject").hide();
                }
                if (!response.timeAwayTime) {
                    $("#updateTimeAwayRadio").hide();
                    $("#updateOutside").hide();
                }
            },
        });
    };

    function getPersonnelEntry() {
        $.ajax({
            type: 'GET',
            url: '/RdCenterCal/GetPersonnelEntry',
            success: function (response) {
                events = [];
                var source = calendar.getEventSources();
                for (var i = 0; i < source.length; i++) {
                    source[i].remove();
                }

                for (var i = 0; i < response.length; i++) {
                    var title;
                    var color;
                    if (response[i].projectCode != null) {
                        title = response[i].projectName;
                        color = '#5a8dee';
                    };

                    if (response[i].timeAwayCode != null) {
                        title = response[i].timeAwayName;
                        color = '#43a047';
                    };

                    if (response[i].id === 0) {
                        title = response[i].projectCode;
                        color = '#db3939';
                    }
                    events.push({
                        id: response[i].id,
                        title: title,
                        projectCode: response[i].projectCode,
                        timeAwayCode: response[i].timeAwayCode,
                        start: response[i].startDate,
                        end: response[i].endDate,
                        color: color
                    });
                }

                calendar.addEventSource(events);
            }
        });
    };

    function checkPreWeekTime() {
        var entryId = selectedEvent.id;
        var sDate = selectedEvent.start.format('DD.MM.YYYY')
        var eDate = selectedEvent.end.format('DD.MM.YYYY')
        $.ajax({
            type: 'GET',
            url: '/RdCenterCal/CheckPreWeekPersonnelTime',
            data: {
                id: entryId,
                startDate: sDate,
                endDate: eDate,
            },
            success: function (response) {
                if (response === '401') {
                    showErrorMessage('Bir önceki haftanın eksik girişlerinizi tamamlayınız.');
                    return;
                }
                getPersonnelTime();
            }
        });
    };

    var token = $('input[name="__RequestVerificationToken"]').val();

    $('#save').click(function () {
        $('#error').text('');

        if ($("#projectTime").is(":checked")) {
            if (!$('#projectCode').val()) {
                $('#error').text('Proje kodu seçiniz.');
                return;
            }
        } else {
            if (!$('#timeAwayCode').val()) {
                $('#error').text('Dışarıda geçirilen süre kodu seçiniz.');
                return;
            }
            if ($('#timeAwayCode').val() != 1 && $('#timeAwayCode').val() != 2 && !$('#projectCode').val()) {
                $('#error').text('Proje kodu seçiniz.');
                return;
            }
        };

        checkTimeOk();
        if ($('#error').text() != '') {
            return;
        }

        var projectName;
        if ($('#projectCode').val() != "") {
            projectName = $("#projectCode option:selected").text()
        };

        var timeAwayName;
        if ($('#timeAwayCode').val() != "") {
            timeAwayName = $("#timeAwayCode option:selected").text()
        };

        var events = {
            Id: $('#entryId').val(),
            ProjectCode: $('#projectCode').val(),
            ProjectName: projectName,
            TimeAwayCode: $('#timeAwayCode').val(),
            TimeAwayName: timeAwayName,
            StartDate: $('#startDate').val(),
            EndDate: $('#endDate').val()
        };

        saveAppoinment(events)
    });

    $('#update').click(function () {
        $('#updateError').text('');

        if ($("#updateProjectTime").is(":checked")) {
            if (!$('#updateProjectCode').val()) {
                $('#updateError').text('Proje kodu seçiniz.');
                return;
            }
        } else {
            if (!$('#updateTimeAwayCode').val()) {
                $('#updateError').text('Dışarıda geçirilen süre kodu seçiniz.');
                return;
            }
            if ($('#updateTimeAwayCode').val() != 1 && $('#updateTimeAwayCode').val() != 2 && !$('#updateProjectCode').val()) {
                $('#updateError').text('Proje kodu seçiniz.');
                return;
            }
        };
        checkTimeOk();
        if ($('#updateError').text() != '') {
            return;
        }

        var projectName;
        if ($('#updateProjectCode').val() != "") {
            projectName = $("#updateProjectCode option:selected").text()
        };

        var timeAwayName;
        if ($('#updateTimeAwayCode').val() != "") {
            timeAwayName = $("#updateTimeAwayCode option:selected").text()
        };

        var events = {
            Id: $('#updateEntryId').val(),
            ProjectCode: $('#updateProjectCode').val(),
            ProjectName: projectName,
            TimeAwayCode: $('#updateTimeAwayCode').val(),
            TimeAwayName: timeAwayName,
            StartDate: $('#updateStartDate').val(),
            EndDate: $('#updateEndDate').val()
        };

        saveAppoinment(events)
    });

    $('#delete').click(function () {
        if (confirm('Kaydı silmek istediğinize emin misiniz?')) {
            $.ajax({
                type: 'GET',
                url: '/RdCenterCal/DeletePersonnelEntry?id=' + selectedEvent.id,
                success: function (response) {
                    if (response === "200") {
                        var event = calendar.getEventById(selectedEvent.id);
                        event.remove();
                        getPersonnelEntry();
                        $('#updateModal').modal('hide');
                        showMessage('Kayıt silindi.');
                    }
                },
                error: function () {
                    $('#updateModal').modal('hide');
                    showErrorMessage('Kayıt silinirken hata oluştu.')
                }
            });
        }
    });

    function saveAppoinment(events) {
        $.ajax({
            type: 'POST',
            url: '/RdCenterCal/CreateorUpdatePersonnelEntry',
            data: {
                __RequestVerificationToken: token,
                personnelViewModel: events
            },
            success: function (response) {
                if (response === "201" || response === "204") {
                    getPersonnelEntry();

                    if (response === "201") {
                        $('#saveModal').modal('hide');
                        showMessage('Kayıt eklendi.')
                    }
                    else {
                        $('#updateModal').modal('hide');
                        showMessage('Kayıt güncellendi.')
                    }
                }
                else {
                    $('#saveModal').modal('hide');
                    showErrorMessage('Kayıt eklenemedi.')
                }
            },
            error: function () {
                $('#saveModal').modal('hide');
                showErrorMessage('Kayıt eklenirken hata oluştu.')
            }
        });
    };

    function checkTimeOk() {
        var projectTimeEntered;
        var timeAwayTimeEntered;

        var oldSTime = selectedEvent.start.format('YYYY-MM-DD');
        var oldETime = selectedEvent.end.format('YYYY-MM-DD');

        var sTime;
        var eTime;
        var isCreateorUpdate;
        if ($('#startDate').val() != '' && $('#endDate').val() != '') {
            sTime = moment($('#startDate').val(), 'DD.MM.YYYY HH:mm').format("YYYY-MM-DD HH:mm");
            eTime = moment($('#endDate').val(), 'DD.MM.YYYY HH:mm').format("YYYY-MM-DD HH:mm");
            projectTimeEntered = $('#projectMin').text();
            timeAwayTimeEntered = $('#timeAwayMin').text();
            isCreateorUpdate = 'C';
            console.log(isCreateorUpdate);
        }

        if ($('#updateStartDate').val() != '' && $('#updateEndDate').val() != '') {
            sTime = moment($('#updateStartDate').val(), 'DD.MM.YYYY HH:mm').format("YYYY-MM-DD HH:mm");
            eTime = moment($('#updateEndDate').val(), 'DD.MM.YYYY HH:mm').format("YYYY-MM-DD HH:mm");
            projectTimeEntered = $('#updateProjectMin').text();
            timeAwayTimeEntered = $('#updateTimeAwayMin').text();
            isCreateorUpdate = 'U';
        }

        var splitSTime = sTime.split(" ");
        var splitETime = eTime.split(" ");

        console.log(oldSTime);
        if (splitSTime[0] != oldSTime) {
            if (isCreateorUpdate === 'C') {
                $('#error').text('Başlangıç tarih farklı bir gün seçemezsiniz.');
            }
            if (isCreateorUpdate === 'U') {
                $('#updateError').text('Başlangıç tarih farklı bir gün seçemezsiniz.');
            }
            return;
        }

        if (splitETime[0] != oldETime) {
            if (isCreateorUpdate === 'C') {
                $('#error').text('Bitiş tarih farklı bir gün seçemezsiniz.');
            }
            if (isCreateorUpdate === 'U') {
                $('#updateError').text('Bitiş tarih farklı bir gün seçemezsiniz.');
            }
            return;
        }

        if (sTime === eTime || sTime > eTime) {
            if (isCreateorUpdate === 'C') {
                $('#error').text('Başlangıç tarih ve zamanı bitiş tarih ve zamanından büyük veya eşit olamaz.');
            }
            if (isCreateorUpdate === 'U') {
                $('#updateError').text('Başlangıç tarih ve zamanı bitiş tarih ve zamanından büyük veya eşit olamaz.');
            }
            return;
        }

        var diff = (new Date(eTime) - new Date(sTime)) / (1000 * 60);

        if (isCreateorUpdate === 'C') {
            if ($("#projectTime").is(":checked")) {
                if (diff > projectTimeEntered) {
                    $('#error').text('Proje koduna fazla süre girdiniz.');
                }
            };

            if ($("#outsideTime").is(":checked")) {
                if (diff > timeAwayTimeEntered) {
                    $('#error').text('Dışarıda geçirilen koduna fazla süre girdiniz.');
                }
            };
        }
        if (isCreateorUpdate === 'U') {
            if ($("#updateProjectTime").is(":checked")) {
                if (diff > projectTimeEntered) {
                    $('#updateError').text('Proje koduna fazla süre girdiniz.');
                }
            };

            if ($("#updateOutsideTime").is(":checked")) {
                if (diff > timeAwayTimeEntered) {
                    $('#updateError').text('Dışarıda geçirilen koduna fazla süre girdiniz.');
                }
            };
        }
    }
});
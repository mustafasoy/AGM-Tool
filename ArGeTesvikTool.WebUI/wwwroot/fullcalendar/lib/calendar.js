$(document).ready(function () {
    $('#projectCode, #timeAwayCode').on('change', function () {
        $('#error').text('');
    });

    $("#outside").hide();
    $("input[name='radioTime']").click(function () {
        if ($("#projectTime").is(":checked")) {
            $("#project").show();
            $("#outside").hide();
        } else {
            $("#outside").show();
            $("#project").hide();
        }
    });
});

document.addEventListener('DOMContentLoaded', function () {
    var calendarEl = document.getElementById('calendar');
    var selectedEvent = null;
    var events = [];

    var calendar = new FullCalendar.Calendar(calendarEl, {
        googleCalendarApiKey: 'AIzaSyDcnW6WejpTOCffshGDDb4neIrXVUA1EAE',
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

            getPersonnelTime();
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
            selectedEvent = {
                id: info.event.id,
                projectCode: info.event.extendedProps.projectCode,
                timeAwayCode: info.event.extendedProps.timeAwayCode,
                start: moment(info.event.start).format('DD.MM.YYYY HH:mm'),
                end: moment(info.event.end).format('DD.MM.YYYY HH:mm')
            };

            $('#updateProjectCode').val(info.event.extendedProps.projectCode);
            $('#updateTimeAwayCode').val(info.event.extendedProps.timeAwayCode);
            $('#updateStartDate').val(moment(info.event.start).format('DD.MM.YYYY HH:mm'));
            $('#updateEndDate').val(moment(info.event.end).format('DD.MM.YYYY HH:mm'));

            $('#updateModal').modal();
        },
        eventDrop: function (dropEventInfo) {
            var events = {
                Id: dropEventInfo.event.id,
                ProjectCode: dropEventInfo.event.extendedProps.projectCode,
                ProjectName: dropEventInfo.event.extendedProps.projectName,
                TimeAwayCode: dropEventInfo.event.extendedProps.timeAwayCode,
                TimeAwayName: dropEventInfo.event.extendedProps.timeAwayName,
                StartDate: moment(dropEventInfo.event.start).format('DD.MM.YYYY HH:mm'),
                EndDate: moment(dropEventInfo.event.end).format('DD.MM.YYYY HH:mm')
            };

            saveAppoinment(events)
        },
        eventResize: function (dropEventInfo) {
            var events = {
                Id: dropEventInfo.event.id,
                ProjectCode: dropEventInfo.event.extendedProps.projectCode,
                ProjectName: dropEventInfo.event.extendedProps.projectName,
                TimeAwayCode: dropEventInfo.event.extendedProps.timeAwayCode,
                TimeAwayName: dropEventInfo.event.extendedProps.timeAwayName,
                StartDate: moment(dropEventInfo.event.start).format('DD.MM.YYYY HH:mm'),
                EndDate: moment(dropEventInfo.event.end).format('DD.MM.YYYY HH:mm')
            };

            saveAppoinment(events)
        },
    });

    calendar.render();
    getPersonnelEntry();

    $('#startDatetimepicker, #endDatetimepicker, #UpdateStartDatetimepicker, #UpdateEndDatetimepicker').datetimepicker({
        format: 'DD.MM.YYYY HH:mm',
        locale: 'tr'
    });

    function openCreateOrUpdateModal() {
        $('#error').text('');
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
        var sDate = selectedEvent.start.format('DD.MM.YYYY')
        var eDate = selectedEvent.end.format('DD.MM.YYYY')
        $.ajax({
            type: 'GET',
            url: '/RdCenterCal/GetPersonnelTime',
            data: {
                startDate: sDate,
                endDate: eDate,
            },
            success: function (response) {
                $('#projectText').text(response.projectTime);
                $('#projectMin').text(response.projectMin);
                $('#timeAwayText').text(response.timeAwayTime);
                $('#timeAwayMin').text(response.projectMin);
                if (!response.projectTime) {
                    $("#projectRadio").hide();
                }
                if (!response.timeAwayTime) {
                    $("#timeAwayRadio").hide();
                }
                openCreateOrUpdateModal();
            },
            error: function () {
                showErrorMessage('Kapı geçiş verileri bulunamadı.');
            }
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
                calendar.addEventSource("tr.turkish#holiday@group.v.calendar.google.com");
            },
            error: function () {
                $('#saveModal').modal('hide');
                showErrorMessage('Kayıt eklenirken hata oluştu.')
            }
        });
    }

    var token = $('input[name="__RequestVerificationToken"]').val();

    $('#save').click(function () {
        $('#error').text('');

        checkTimeOk();
        if ($('#error').text() != '') {
            return;
        }

        if (!$('#projectCode').val() && !$('#timeAwayCode').val()) {
            if (!$('#projectCode').val()) {
                $('#error').text('Proje kodu seçiniz.');
            }
            else {
                $('#error').text('Dışarıda geçirilen süre kodu seçiniz.');
            }
            return;
        };

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
        $('#updateModal').modal('hide');
        openCreateOrUpdateModal();
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
                    $('#saveModal').modal('hide');
                    response === "201" ? showMessage('Kayıt eklendi.') : showMessage('Kayıt güncellendi.')
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
        var projectTimeEntered = $('#projectMin').text();
        var timeAwayTimeEntered = $('#timeAwayMin').text();

        var sTime = selectedEvent.start.format('YYYY-MM-DD HH:mm')
        var eTime = selectedEvent.end.format('YYYY-MM-DD HH:mm')

        var diff = (new Date(eTime) - new Date(sTime)) / (1000 * 60);
        if ($("#projectTime").is(":checked")) {
            if (diff > projectTimeEntered) {
                $('#error').text('Proje koduna fazla süre girdiniz');
            }
        }
        else {
            if (diff > timeAwayTimeEntered) {
                $('#error').text('Dışarıda geçirilen koduna fazla süre girdiniz');
            }
        }
    }
});
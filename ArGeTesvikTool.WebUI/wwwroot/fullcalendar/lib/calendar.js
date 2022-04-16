$(document).ready(function () {
    $('#projectCode, #timeAwayCode').on('change', function () {
        $('#error').text('');
    });
});

document.addEventListener('DOMContentLoaded', function () {
    var calendarEl = document.getElementById('calendar');
    var selectedEvent = null;
    var events = [];

    var calendar = new FullCalendar.Calendar(calendarEl, {
        googleCalendarApiKey: 'AIzaSyAcToVvraZ9HVOTPTsP_tU7fKC-pBBGS0Q',
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
            selectedEvent = {
                id: 0,
                userId: 0,
                ProjectCode: "",
                timeAwayCode: "",
                start: moment(selectionInfo.start),
                end: moment(selectionInfo.end),
            }
            openCreateOrUpdateModal();
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

    function saveAppoinment(events) {
        $.ajax({
            type: 'POST',
            url: '/RdCenterCal/CreateorUpdatePersonnelEntry',
            data: {
                __RequestVerificationToken: token,
                personnelViewModel: events
            },
            success: function (response) {
                if (response === "201" || response==="204") {
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
    }

    $('#save').click(function () {
        $('#error').text('');

        if (!$('#projectCode').val() && !$('#timeAwayCode').val()) {
            $('#error').text('Proje kodu veya Dışarıda geçirilen süre kodu seçiniz.');
            return;
        }

        var projectName;
        if ($('#projectCode').val() != "") {
            projectName = $("#projectCode option:selected").text()
        }

        var timeAwayName;
        if ($('#timeAwayCode').val() != "") {
            timeAwayName = $("#timeAwayCode option:selected").text()
        }

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
    })

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
    })
});
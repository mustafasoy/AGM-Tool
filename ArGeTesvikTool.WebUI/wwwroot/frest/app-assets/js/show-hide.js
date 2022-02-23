$(document).ready(function () {
    $("#show_hide_password a").on('click', function (event) {
        event.preventDefault();
        if ($('#show_hide_password input').attr("type") == "text") {
            $('#show_hide_password input').attr('type', 'password');
            $('#show_hide_password i').addClass("bx-show");
            $('#show_hide_password i').removeClass("bx-hide");
        } else if ($('#show_hide_password input').attr("type") == "password") {
            $('#show_hide_password input').attr('type', 'text');
            $('#show_hide_password i').addClass("bx-hide");
            $('#show_hide_password i').removeClass("bx-show");
        }
    });

    $("#password_old a").on('click', function (event) {
        event.preventDefault();
        if ($('#password_old input').attr("type") == "text") {
            $('#password_old input').attr('type', 'password');
            $('#password_old i').addClass("bx-show");
            $('#password_old i').removeClass("bx-hide");
        } else if ($('#password_old input').attr("type") == "password") {
            $('#password_old input').attr('type', 'text');
            $('#password_old i').addClass("bx-hide");
            $('#password_old i').removeClass("bx-show");
        }
    });

    $("#password_new a").on('click', function (event) {
        event.preventDefault();
        if ($('#password_new input').attr("type") == "text") {
            $('#password_new input').attr('type', 'password');
            $('#password_new i').addClass("bx-show");
            $('#password_new i').removeClass("bx-hide");
        } else if ($('#password_new input').attr("type") == "password") {
            $('#password_new input').attr('type', 'text');
            $('#password_new i').addClass("bx-hide");
            $('#password_new i').removeClass("bx-show");
        }
    });

    $("#password_confirm a").on('click', function (event) {
        event.preventDefault();
        if ($('#password_confirm input').attr("type") == "text") {
            $('#password_confirm input').attr('type', 'password');
            $('#password_confirm i').addClass("bx-show");
            $('#password_confirm i').removeClass("bx-hide");
        } else if ($('#password_confirm input').attr("type") == "password") {
            $('#password_confirm input').attr('type', 'text');
            $('#password_confirm i').addClass("bx-hide");
            $('#password_confirm i').removeClass("bx-show");
        }
    });
});
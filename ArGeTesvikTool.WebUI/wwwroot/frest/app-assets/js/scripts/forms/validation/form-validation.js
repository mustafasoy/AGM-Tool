/*=========================================================================================
  File Name: form-validation.js
  Description: jquery bootsreap validation js
  ----------------------------------------------------------------------------------------
  Item Name: Frest HTML Admin Template
  Version: 1.0
  Author: PIXINVENT
  Author URL: http://www.themeforest.net/user/pixinvent
==========================================================================================*/


$(function () {
    'use strict';

    var jqForm = $('#jquery-val-form'),
        select = $('.select2');

    // select2
    select.each(function () {
        var $this = $(this);
        $this.wrap('<div class="position-relative"></div>');
        $this
            .select2({
                placeholder: 'Select value',
                dropdownParent: $this.parent()
            })
            .change(function () {
                $(this).valid();
            });
    });

    // jQuery Validation
    // --------------------------------------------------------------------
    if (jqForm.length) {
        jqForm.validate({
            rules: {
                'Name': {
                    required: true
                },
                'User.Name': {
                    required: true
                },
                'LastName': {
                    required: true
                },
                'User.LastName': {
                    required: true
                },
                'UserName': {
                    required: true
                },
                'Email': {
                    required: true,
                    email: true
                },
                'Password': {
                    required: true
                },
                'ConfirmPassword': {
                    required: true,
                    equalTo: '#Password'
                },
                'RoleName': {
                    required: true
                },
                'RoleText': {
                    required: true
                },
                'SelectCountry': {
                    required: true
                },
                customFile: {
                    required: true
                },
                validationRadiojq: {
                    required: true
                },
                validationBiojq: {
                    required: true
                },
                validationCheck: {
                    required: true
                }
            }
        });
    }
});

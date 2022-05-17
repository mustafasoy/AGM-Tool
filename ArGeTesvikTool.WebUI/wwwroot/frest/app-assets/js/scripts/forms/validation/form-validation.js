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
                placeholder: 'Seciniz',
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
                    required: true,
                },
                'RegistrationNo': {
                    required: true,
                },
                'StartDate': {
                    required: true
                },
                'EndDate': {
                    required: true
                },
                'User.Name': {
                    required: true
                },
                'User.Role': {
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
                'User.Email': {
                    required: true,
                    email: true
                },
                'Password': {
                    required: true,
                },
                'ConfirmPassword': {
                    required: true,
                    equalTo: '#Password',
                },
                'CountryCode': {
                    required: true,
                },
                'PersonPosition': {
                    required: true,
                },
                'WorkType': {
                    required: true,
                },
                'EducationStatu': {
                    required: true,
                },
                'GraduateUniversity': {
                    required: true,
                },
                'UniversityDepartmant': {
                    required: true,
                },
                'MasterUniversity': {
                    required: true,
                },
                'MasterDepartmant': {
                    required: true,
                },
                'DoctoralUniversity': {
                    required: true,
                },
                'DoctoralDepartmant': {
                    required: true,
                },
                'RoleName': {
                    required: true
                },
                'RoleText': {
                    required: true
                },
                'BusinessContact.IdentityNumber': {
                    required: true
                },
                'BusinessContact.NameSurname': {
                    required: true
                },
                'BusinessInfo.CompanyName': {
                    required: true
                },
                'BusinessIntro.Text': {
                    required: true
                },
                'BusinessInfo.ActivityCode': {
                    required: true
                },
                'GroupInfo.CompanyName': {
                    required: true
                },
                'Strategy.Text': {
                    required: true
                },
                'RdCenterContact.IdentityNumber': {
                    required: true
                },
                'RdCenterContact.NameSurname': {
                    required: true
                },
                'RdCenterInfo.CompanyName': {
                    required: true
                },
                'NewProject.ProjectStatu': {
                    required: true
                },
                'NewProject.ProjectCode': {
                    required: true
                },
                'NewProject.ProjectName': {
                    required: true
                },
                FormFile: {
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

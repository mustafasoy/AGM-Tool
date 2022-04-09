function showMessage(message) {
    toastr.success(message, 'Bilgi', {
        timeOut: 5000,
        showMethod: "slideDown",
        hideMethod: "slideUp"
    })
};

function showErrorMessage(message) {
    toastr.error(message, 'Bilgi', {
        timeOut: 5000,
        showMethod: "slideDown",
        hideMethod: "slideUp"
    })
}
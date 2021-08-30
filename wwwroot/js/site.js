// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$('#userCad').submit(function (e) {
    e.preventDefault();

    $.ajax({
        url: '/Usuario/Cadastro',
        data: $('#userCad').serialize(),
        type: 'POST',
        success: function (e) {
            $('#modalSucesso').modal('show');
        },
        error: function (e) {
            $('#modalFalha').modal('show');
        }
    });
})

$('#userEdit').submit(function (e) {
    e.preventDefault();

    $.ajax({
        url: '/Usuario/Editar',
        data: $('#userEdit').serialize(),
        type: 'POST',
        success: function (e) {
            $('#modalSucesso').modal('show');
        },
        error: function (e) {
            $('#modalFalha').modal('show');
        }
    });
})

$('#userDel').submit(function (e) {
    e.preventDefault();

    $.ajax({
        url: '/Usuario/Deletar',
        data: $('#userDel').serialize(),
        type: 'POST',
        success: function (e) {
            $('#modalSucesso').modal('show');
        },
        error: function (e) {
            $('#modalFalha').modal('show');
        }
    });
})

$('#notaPub').submit(function (e) {
    e.preventDefault();

    $.ajax({
        url: '/NotaAluno/Publicar',
        data: $('#notaPub').serialize(),
        type: 'POST',
        success: function (e) {
            $('#modalSucesso').modal('show');
        },
        error: function (e) {
            $('#modalFalha').modal('show');
        }
    });
})

$('#notaEdit').submit(function (e) {
    e.preventDefault();

    $.ajax({
        url: '/NotaAluno/EditarNota',
        data: $('#notaEdit').serialize(),
        type: 'POST',
        success: function (e) {
            $('#modalSucesso').modal('show');
        },
        error: function (e) {
            $('#modalFalha').modal('show');
        }
    });
})

$('#notaDel').submit(function (e) {
    e.preventDefault();

    $.ajax({
        url: '/NotaAluno/DeletarNota',
        data: $('#notaDel').serialize(),
        type: 'POST',
        success: function (e) {
            $('#modalSucesso').modal('show');
        },
        error: function (e) {
            $('#modalFalha').modal('show');
        }
    });
})
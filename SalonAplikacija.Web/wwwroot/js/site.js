//// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
//// for details on configuring this project to bundle and minify static web assets.

//// Write your JavaScript code.

////Here we will handle all AJAX operations for SaloonOwner area


//$(function () {

//    //Global handler for opening modal
//    var placeholderElement = $('#modal-placeholder');
//    $('button[data-toggle="ajax-modal"]').click(function (event) {
//        var url = $(this).data('url');
//        $.get(url).done(function (data) {
//            placeholderElement.html(data);
//            placeholderElement.find('.modal').modal('show');
//        });
//    });

//    //Clients
//    //UPDATE
//    placeholderElement.on('click', '[id="btnUpdateClient"]', function (event) {
//        event.preventDefault();

//        var form = $(this).parents('.modal').find('form');
//        var actionUrl = "/SaloonOwner/Clients/"+form.attr('action');
//        var dataToSend = form.serialize();

//        $.post(actionUrl, dataToSend).done(function (data) {
//            var newBody = $('.modal-body', data);

//            var isValid = newBody.find('[name="IsValid"]').val() === 'True';
//            if (isValid) {
//                placeholderElement.find('.modal').modal('hide');
//                //$("#dataBody").load("/SaloonOwner/Clients/LoadData");
//                location.reload();
//            } else {
//                placeholderElement.find('.modal-body').replaceWith(newBody);
//            }


//        });
//    });

//    //CREATE
//    placeholderElement.on('click', '[id="btnCreateClient"]', function (event) {
//        console.log("it's create");
//        event.preventDefault();

//        var form = $(this).parents('.modal').find('form');
//        var actionUrl = "/SaloonOwner/Clients/"+form.attr('action');
//        var dataToSend = form.serialize();

//        $.post(actionUrl, dataToSend).done(function (data) {
//            var newBody = $('.modal-body', data);

//            var isValid = newBody.find('[name="IsValid"]').val() === 'True';
//            if (isValid) {
//                placeholderElement.find('.modal').modal('hide');
//                //$("#dataBody").load("/SaloonOwner/Clients/LoadData");
//                location.reload();
//            } else {
//                placeholderElement.find('.modal-body').replaceWith(newBody);
//            }


//        });
//    });

//});
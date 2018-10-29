// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//Here we will handle all AJAX operations for SaloonOwner area


$(function () {

    //Global handler for opening modal
    var placeholderElement = $('#modal-placeholder');
    $('button[data-toggle="ajax-modal"]').click(function (event) {
        var url = $(this).data('url');
        $.get(url).done(function (data) {
            placeholderElement.html(data);
            placeholderElement.find('.modal').modal('show');
        });
    });

    //Clients
    placeholderElement.on('click', '[data-save="modal"]', function (event) {
        event.preventDefault();

        var form = $(this).parents('.modal').find('form');
        var actionUrl = form.attr('action');
        var dataToSend = form.serialize();

        $.post(actionUrl, dataToSend).done(function (data) {
            var newBody = $('.modal-body', data);

            var isValid = newBody.find('[name="IsValid"]').val() === 'True';
            if (isValid) {
                placeholderElement.find('.modal').modal('hide');
                $("#dataBody").load("/SaloonOwner/Clients/LoadData");

            } else {
                placeholderElement.find('.modal-body').replaceWith(newBody);
            }


        });
    });
    //$("#btnUpdateClient").click(function (event) {
    //    event.preventDefault();

    //    var form = $(this).parents("modal").find("form");
    //    var actionUrl = form.attr("action");
    //    var formData = form.serialize();

    //    $.ajax({
    //        type: "POST",
    //        url: actionUrl,
    //        data: formData,
    //        success: function (data) {
    //            var newBody = $(".modal-body", data);

    //            var isValid = newBody.find("[name='isValid']").val() === 'True';
    //            if (isValid) {
    //                placeholderElement.find(".modal").modal("hide");
    //                $("#dataBody").load("/SaloonOwner/Clients/LoadData");
    //            } else {
    //                placeholderElement.find(".modal-body").replaceWith(newBody);
    //            }
    //        },
    //        error: function (err) {
    //            console.log(err);
    //        }
    //    });

    //});


});
function AjaxCall(obj) {

    var type = obj.type || 'GET';
    var url = obj.url;
    var data = obj.data || null;
    var dataType = obj.dataType || 'json';
    var processData = obj.processData || false;

    return $.ajax({
        type: type,
        url: url,
        data: data,
        dataType: dataType,
        processData: processData,
        async: true,
        beforeSend: function () {
            disableButton();
        },
        success: function (response) {
            return response;
        },
        error: function (response) {
            return response;
        },
        complete: function () {
            enableButton();
        }
    });
};

function disableButton() {
    $('input[type="submit"]').prop('disabled', true);
};

function enableButton() {
    $('input[type="submit"]').prop('disabled', false);
};
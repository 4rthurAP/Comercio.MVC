// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function AjaxCall(url, dados, tipo, mycallback) {
    $.ajax({
        url: url,
        data: dados,
        type: tipo,
        contentType: 'application/json',
        success: function (data) {

            mycallback(data);
        },
        error: function (data) {
            console.error(data);
            try {
                mycallback(data.responseJSON);
            }
            catch (E) { }
        }
    });
}


function ChamadaAjax(url, data, tipo, mycallback) {
    var xhr;
    if (!window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
        xhr = new ActiveXObject("Microsoft.XMLHTTP");
    }
    else {
        xhr = new XMLHttpRequest();
    }

    xhr.open(tipo, url);
    xhr.setRequestHeader('Content-Type', 'application/json');
    xhr.setRequestHeader('Cache-Control', 'no-cache,no-store');
    xhr.onreadystatechange = function () {
        try {
            var ndata;
            if (xhr.status) {
                if ((xhr.status == 200 || xhr.status == 400) && xhr.readyState == 4) {
                    try {
                        ndata = JSON.parse(xhr.responseText);
                    } catch (e) {
                        try {
                            if (xhr.responseText !== null)
                                document.writeln(xhr.responseText);
                        }
                        catch (ex) { }
                    }
                    mycallback(ndata);
                }
            }
        } catch (ex) {
            try {
                mycallback(data.responseJSON);
            }
            catch (e) { }
        }
    }
}
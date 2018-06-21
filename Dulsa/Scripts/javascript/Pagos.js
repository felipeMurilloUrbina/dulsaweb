$(document).ready(() => {
    console.log('cliente seleccionado');

    $('#ClienteId').change(function () {
        var serviceURL = '/Pagos/GetCliente?clienteId=' + $(this).val();
    $.ajax({
            type: "Get",
            url: serviceURL,
            data: param = "",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: successFunc,
            error: errorFunc
        });

        function successFunc(data, status) {
            console.log(data);
            var body = '<div class="panel panel-primary">' +
                            '<div class="panel-heading"> Datos Cliente</div >' +
                            '<div class="panel-body">' +
                                'Nombre: ' + data.Nombre +'<br/>'+
                                'RFC: ' + data.RFC +
                                'Direccion: ' + data.Direccion + '<br/>' +
                            '</div>' +
                        '</div>';

            $('#dato-cliente').append(body);
            console.log(body);
        }

        function errorFunc() {
            alert('error');
        }
    });

});
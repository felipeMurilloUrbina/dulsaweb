$("#btnNuevo").click(function (eve) {
    $("#modal-content").load("/Asesores/Create");
});

$(".btnEditar").click(function (eve) {
    $("#modal-content").load("/Asesores/Edit/" + $(this).data("id"));
});

$(".btnDetails").click(function (eve) {
    $("#modal-content").load("/Asesores/Details/" + $(this).data("id"));
});

$(".btnDelete").click(function (eve) {
    $("#modal-content").load("/Asesores/Delete/" + $(this).data("id"));
});
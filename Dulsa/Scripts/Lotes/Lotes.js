$("#btnNuevo").click(function (eve) {
    $("#modal-content").load("/Lotes/Create");
});

$(".btnEditar").click(function (eve) {
    $("#modal-content").load("/Lotes/Edit/" + $(this).data("id"));
});

$(".btnDetails").click(function (eve) {
    $("#modal-content").load("/Lotes/Details/" + $(this).data("id"));
});

$(".btnDelete").click(function (eve) {
    $("#modal-content").load("/Lotes/Delete/" + $(this).data("id"));
});
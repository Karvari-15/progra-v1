"use strict";
var MarcaVehiculoGrid;
(function (MarcaVehiculoGrid) {
    if (MensajeApp != "") {
        Toast.fire({
            icon: "success", title: MensajeApp
        });
    }
    function OnClickEliminar(id) {
        ComfirmAlert("Desea eliminar este registro?", "Eliminar", "warning", "#3085d6", "d33")
            .then(function (result) {
            if (result.isConfirmed) {
                window.location.href = "/MarcaVehiculo/Grid?handler=Eliminar&id=" + id;
            }
        });
    }
    MarcaVehiculoGrid.OnClickEliminar = OnClickEliminar;
    $("#GridView").DataTable();
})(MarcaVehiculoGrid || (MarcaVehiculoGrid = {}));
//# sourceMappingURL=Grid.js.map
"use strict";
var MarcaVehiculoEdit;
(function (MarcaVehiculoEdit) {
    var Formulario = new Vue({
        data: {
            Formulario: "#FormEdit"
        },
        mounted: function () {
            CreateValidator(this.Formulario);
        }
    });
    Formulario.$mount("#AppEdit");
})(MarcaVehiculoEdit || (MarcaVehiculoEdit = {}));
//# sourceMappingURL=Edit.js.map
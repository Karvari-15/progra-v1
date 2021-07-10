using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
using Entity;
namespace WebApp.Pages.Vehiculo
{
    public class GridModel : PageModel
    {
        private readonly IVehiculoService vehiculoService;

        public GridModel(IVehiculoService vehiculoService)
        {
            this.vehiculoService = vehiculoService;
        }

        public IEnumerable<VehiculoEntity> GridList { get; set; } = new List<VehiculoEntity>();
        public string Mensaje { get; set; }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                GridList = await vehiculoService.Get();
                if (TempData.ContainsKey(key: "Msg"))
                {
                    Mensaje = TempData[key: "Msg"] as string;
                }
                TempData.Clear();
                return Page();
            }
            catch (Exception ex)
            {
                return Content(content: ex.Message);
            }
        }
        public void OnPost()
        {
        }
        public void OnPut()
        {
        }
        public async Task<IActionResult> OnGetEliminar(int id)
        {
            try
            {
                var result = await vehiculoService.Delete(new()
                {
                    VehiculoId = id
                });
                if (result.CodeError != 0)
                {
                    throw new Exception(result.MsgError);
                }
                TempData["Msg"] = "se elimino correctamente";
                return Redirect("Grid");
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }
    }
}

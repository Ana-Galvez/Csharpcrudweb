using Microsoft.AspNetCore.Mvc;
using C_crudweb.Datos;
using C_crudweb.Models;


namespace C_crudweb.Controllers
{
    public class MantenedorController : Controller
    {
        ContactoDatos contactoDatos=new ContactoDatos();
        public IActionResult Listar()
        {
            var objLista = contactoDatos.Listar();
            return View(objLista);
        } 
        public IActionResult GuardarLista()
        {
            return View();
        }          
        public IActionResult Guardar(ContactoModelo objContacto)
        {
            if (!ModelState.IsValid) return View();

            var respuesta = contactoDatos.GuardarContacto(objContacto);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }        
        public IActionResult Modificar()
        {
            return View();
        }        
        public IActionResult Eliminar()
        {
            return View();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using parcial.Data;
using parcial.Models;
using parcial.ViewModel;

namespace parcial.Controllers
{
    public class RegistroRemesaController : Controller
    {
        private readonly ILogger<RegistroRemesaController> _logger;

        private readonly ApplicationDbContext _context;

        public RegistroRemesaController(ILogger<RegistroRemesaController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            var remesas = from o in _context.DataRegistroRemesa select o;

            // Crear el ViewModel con un formulario vacío y una lista de remesas
            var viewModel = new RegistroRemesaViewModel
            {
                FormRemesa = new RegistroRemesa(),  // Objeto vacío para el formulario

            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Registrar(RegistroRemesaViewModel viewModel)
        {
            if (viewModel.FormRemesa.Id == 0)
            {
                _context.Add(viewModel.FormRemesa);
                TempData["Message"] = "Se ha registrado una nueva remesa. :D";
            }

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}
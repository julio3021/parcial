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

    public class ListarRemesa : Controller
    {
        private readonly ILogger<ListarRemesa> _logger;
        private readonly ApplicationDbContext _context;

        public ListarRemesa(ILogger<ListarRemesa> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {

            var remisiones = _context.DataRegistroRemesa.ToList();

            var viewModel = new RegistroRemesaViewModel
            {
                ListarRemesa = remisiones
            };

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}
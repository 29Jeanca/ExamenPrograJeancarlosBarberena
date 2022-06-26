using ExamenPrograJeancarlosBarberena.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ExamenPrograJeancarlosBarberena.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            OrdenProfesor pr = OrdenProfesor.ListaProfesor;
            return View(pr.Profesor);
        }
        public IActionResult IndexEstudiantes()
        {
            OrdenEstudiantes ES = OrdenEstudiantes.ListaEstudiantes;
            return View(ES.Estudiante);
        }
        public IActionResult Buscar(string texto)
        {
            OrdenProfesor pr = OrdenProfesor.ListaProfesor;
            OrdenEstudiantes ES = OrdenEstudiantes.ListaEstudiantes;
            var estudiantes = ES.Estudiante.Where(x => x.nombreCompletoEstudiante.Contains(texto) || x.carreraEstudiante.Contains(texto));
            var profesores = pr.Profesor.Where(x => x.nombreCompletoProfesor.Contains(texto) || x.areaConocimiento.Contains(texto));
            return View(profesores);
        }

        public IActionResult VerProfesor(int id)
        {
            OrdenProfesor OP = OrdenProfesor.ListaProfesor;
            Profesores pr = OP.Profesor.Where(x => x.ID == id).FirstOrDefault();
            if (pr == null)
            {
                return NotFound();
            }
            else
            {
                return View(pr);
            }
        }
        public IActionResult VerEstudiante(int id)
        {
            OrdenEstudiantes OE = OrdenEstudiantes.ListaEstudiantes;
            Estudiantes ES = OE.Estudiante.Where(x => x.ID == id).FirstOrDefault();
            if (ES == null)
            {
                return NotFound();
            }
            else
            {
                return View(ES);
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using Actividad3LengProg3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Actividad3LengProg3.Controllers
{
    public class EstudiantesController : Controller
    {
        // Lista estática para almacenar los estudiantes (simula base de datos)
        private static List<EstudianteViewModel> estudiantes = new List<EstudianteViewModel>();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrar(EstudianteViewModel estudiante)
        {
            if (ModelState.IsValid)
            {
                estudiantes.Add(estudiante);
                return RedirectToAction("Lista");
            }
            return View("Index", estudiante);
        }

        public ActionResult Lista()
        {
            return View(estudiantes);
        }

        // GET: Mostrar formulario de edición
        public ActionResult Editar(string matricula)
        {
            var estudiante = estudiantes.FirstOrDefault(e => e.Matricula == matricula);
            if (estudiante == null)
                return NotFound(); 

            return View(estudiante);
        }

        
        [HttpPost]
        public ActionResult Editar(EstudianteViewModel estudiante)
        {
            if (ModelState.IsValid)
            {
                var original = estudiantes.FirstOrDefault(e => e.Matricula == estudiante.Matricula);
                if (original != null)
                {
                    
                    original.NombreCompleto = estudiante.NombreCompleto;
                    original.Carrera = estudiante.Carrera;
                    original.CorreoInstitucional = estudiante.CorreoInstitucional;
                    original.Telefono = estudiante.Telefono;
                    original.FechaNacimiento = estudiante.FechaNacimiento;
                    original.Genero = estudiante.Genero;
                    original.Turno = estudiante.Turno;
                    original.TipoIngreso = estudiante.TipoIngreso;
                    original.EstaBecado = estudiante.EstaBecado;
                    original.PorcentajeBeca = estudiante.PorcentajeBeca;
                    original.TerminosYCondiciones = estudiante.TerminosYCondiciones;

                    return RedirectToAction("Lista");
                }
            }
            return View(estudiante);
        }
        public ActionResult Detalle(string matricula)
        {
            var estudiante = estudiantes.FirstOrDefault(e => e.Matricula == matricula);
            if (estudiante == null) return NotFound();
            return View(estudiante);
        }










        // Eliminar estudiante por matrícula
        public ActionResult Eliminar(string matricula)
        {
            var estudiante = estudiantes.FirstOrDefault(e => e.Matricula == matricula);
            if (estudiante != null)
            {
                estudiantes.Remove(estudiante);
            }
            return RedirectToAction("Lista");
        }
    }
}


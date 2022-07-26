using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityAPI.Contracts;
using UniversityAPI.Database;
using UniversityAPI.Models.DataModels;
using UniversityAPI.Repositories.Interfaces;
using UniversityAPI.Services.Clases;
using UniversityAPI.Services.Interfaces;

namespace UniversityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IServiceWrapper _service;
        private readonly IStudentService _studentService;

        public StudentsController(IServiceWrapper service)
        {
            _service = service;
            _studentService = service.StudentService;
        }

        // GET: api/Estudiantes
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetEstudiantes()
        {
            var estudiantes = _studentService.GetAll(); 
            if (estudiantes == null || estudiantes.Count() < 1)
            {
                return NotFound();
            }
            return Ok(estudiantes);
        }

        // GET: api/Estudiantes/5
        [HttpGet("{id}")]
        public ActionResult<Student> GetEstudiante(int id)
        {
            var estudiante = _studentService.GetById(id);
            if (estudiante == null)
            {
                return NotFound();
            }
            return estudiante;
        }

        // PUT: api/Estudiantes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public IActionResult PutEstudiante(int id, Student estudiante)
        //{
        //    if (id != estudiante.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _studentService.Update(estudiante);

        //    try
        //    {
        //        _studentService.Save();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!EstudianteExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Estudiantes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Student> PostEstudiante(Student estudiante)
        {
            _studentService.Add(estudiante);
            return CreatedAtAction("GetEstudiante", new { id = estudiante.Id }, estudiante);
        }

        // DELETE: api/Estudiantes/5
        [HttpDelete("{id}")]
        public IActionResult DeleteEstudiante(int id)
        {
            _studentService.Delete(id);
            return NoContent();
        }

        private bool EstudianteExists(int id)
        {
            return (_studentService.GetAll()?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

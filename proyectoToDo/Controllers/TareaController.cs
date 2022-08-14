using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proyectoToDo.Models;

namespace proyectoToDo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {

        private readonly pruebaContext _dbContext;

        public TareaController(pruebaContext context)
        {
           _dbContext = context;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            List<Tarea> lista = _dbContext.Tareas.OrderByDescending(t => t.IdTarea).ThenBy(t => t.FechaRegistro).ToList();

            return StatusCode(StatusCodes.Status200OK, lista);
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] Tarea request)
        {
            await _dbContext.Tareas.AddAsync(request);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        [HttpDelete]
        [Route("Cerrar/{id:int}")]
        public async Task<IActionResult> Cerrar(int id)
        {

            Tarea tarea = _dbContext.Tareas.Find(id);   


            _dbContext.Tareas.Remove(tarea);    
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "ok");
        }

    }
}

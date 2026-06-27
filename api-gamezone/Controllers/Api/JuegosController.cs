using api_gamezone.Entities;
using api_gamezone.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_gamezone.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class JuegosController : ControllerBase
    {
        private readonly IJuegosService _service;

        public JuegosController(IJuegosService service)
        {
            _service = service;
        }

        // GET /api/juegos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Juego>>> GetAll()
        {
            var juegos = await _service.GetAllAsync();
            return Ok(juegos);                          // 200 + JSON
        }

        // GET /api/juegos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Juego>> GetById(int id)
        {
            var juego = await _service.GetByIdAsync(id);
            if (juego is null) return NotFound();       // 404
            return Ok(juego);                           // 200 + JSON
        }

        //// POST /api/juegos
        //[HttpPost]
        //public async Task<ActionResult<Juego>> Create([FromBody] Juego juego)
        //{
        //    var creado = await _service.CreateAsync(juego);
        //    return CreatedAtAction(nameof(GetById),
        //        new { id = creado.Id }, creado);        // 201 + Location header
        //}

        // PUT /api/juegos/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Juego>> Update(int id, [FromBody] Juego juego)
        {
            var actualizado = await _service.UpdateAsync(id, juego);
            if (actualizado is null) return NotFound(); // 404
            return Ok(actualizado);                     // 200 + JSON
        }

        //// DELETE /api/juegos/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var eliminado = await _service.DeleteAsync(id);
        //    if (!eliminado) return NotFound();          // 404
        //    return NoContent();                         // 204
        //}
    }
}

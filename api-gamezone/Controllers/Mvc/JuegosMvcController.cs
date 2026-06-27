using api_gamezone.Entities;
using api_gamezone.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api_gamezone.Controllers.Mvc
{
    public class JuegosController : Controller
    {
        private readonly IJuegosService _service;

        public JuegosController(IJuegosService service)
        {
            _service = service;
        }

        // GET /juegos
        public async Task<IActionResult> Index()
        {
            var juegos = await _service.GetAllAsync();
            return View(juegos);
        }

        // GET /juegos/create
        public IActionResult Create()
        {
            return View();
        }

        // POST /juegos/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Juego juego)
        {
            if (!ModelState.IsValid) return View(juego);
            await _service.CreateAsync(juego);
            return RedirectToAction(nameof(Index));
        }

        // GET /juegos/edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var juego = await _service.GetByIdAsync(id);
            if (juego is null) return NotFound();
            return View(juego);
        }

        // POST /juegos/edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Juego juego)
        {
            if (!ModelState.IsValid) return View(juego);
            var actualizado = await _service.UpdateAsync(id, juego);
            if (actualizado is null) return NotFound();
            return RedirectToAction(nameof(Index));
        }

        // GET /juegos/delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var juego = await _service.GetByIdAsync(id);
            if (juego is null) return NotFound();
            return View(juego);
        }

        // POST /juegos/delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

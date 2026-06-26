using api_gamezone.Data;
using api_gamezone.Entities;
using api_gamezone.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api_gamezone.Services
{
    public class JuegosService : IJuegosService
    {
        private readonly AppDbContext _context; //Mensajero para acceder a la base de datos

        public JuegosService(AppDbContext context)
        {
            _context = context;
        }

        // GET ALL
        public async Task<IEnumerable<Juego>> GetAllAsync()
        {
            return await _context.Juegos.ToListAsync();
        }

        // GET BY ID
        public async Task<Juego?> GetByIdAsync(int id)
        {
            return await _context.Juegos.FindAsync(id);
            // Devuelve null si no existe — el controlador maneja el 404
        }

        // CREATE
        public async Task<Juego> CreateAsync(Juego juego)
        {
            juego.FechaCreacion = DateTime.UtcNow;
            _context.Juegos.Add(juego);
            await _context.SaveChangesAsync();   // INSERT en la BD
            return juego;                        // juego.Id ya tiene el valor 
        }

        // UPDATE (PUT completo)
        public async Task<Juego?> UpdateAsync(int id, Juego juego)
        {
            var existente = await _context.Juegos.FindAsync(id);
            if (existente is null) return null;

            existente.Titulo = juego.Titulo;
            existente.Genero = juego.Genero;
            existente.Precio = juego.Precio;
            existente.Disponible = juego.Disponible;

            await _context.SaveChangesAsync();   // UPDATE en la BD
            return existente;
        }

        // DELETE
        public async Task<bool> DeleteAsync(int id)
        {
            var juego = await _context.Juegos.FindAsync(id);
            if (juego is null) return false;

            _context.Juegos.Remove(juego);
            await _context.SaveChangesAsync();   // DELETE en la BD
            return true;
        }


    }
}

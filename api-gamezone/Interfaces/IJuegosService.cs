using api_gamezone.Entities;

namespace api_gamezone.Interfaces
{
    public interface IJuegosService
    {
        Task<IEnumerable<Juego>> GetAllAsync();
        Task<Juego?> GetByIdAsync(int id);
        Task<Juego> CreateAsync(Juego juego);
        Task<Juego?> UpdateAsync(int id, Juego juego);
        Task<bool> DeleteAsync(int id);
    }
}

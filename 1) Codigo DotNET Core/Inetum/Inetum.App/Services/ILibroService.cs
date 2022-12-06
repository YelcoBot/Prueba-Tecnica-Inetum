using Inetum.Datos.Modelos;
using Inetum.Modelo;

namespace Inetum.App.Services
{
    public interface ILibroService
    {
        Task<List<Libro>> GetAllAsync();
        Task<Libro> GetByIsbnAsync(int Isbn);
        Task<bool> SaveOrUpdateAsync(LibroModel libro, string accion);
        Task<bool> DeleteByIsbnAsync(int id);

    }
}

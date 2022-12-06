using Inetum.Datos.Modelos;

namespace Inetum.App.Services
{
    public interface IAutorService
    {
        Task<List<Autor>> GetAllAsync();

        Task<List<Autor>> GetByEditorialAsync(int EditorialId);
    }
}

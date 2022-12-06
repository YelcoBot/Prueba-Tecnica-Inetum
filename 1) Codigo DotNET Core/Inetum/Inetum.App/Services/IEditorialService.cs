using Inetum.Datos.Modelos;
using Inetum.Modelo;

namespace Inetum.App.Services
{
    public interface IEditorialService
    {
        Task<List<Editorial>> GetAllAsync();

        Task<Editorial> GetByIdAsync(int Id);

        Task<EditorialModel> SaveAsync(EditorialModel editorial);

    }
}

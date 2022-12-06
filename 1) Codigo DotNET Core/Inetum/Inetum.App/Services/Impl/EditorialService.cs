using Inetum.Datos.Modelos;
using Inetum.Modelo;
using Microsoft.EntityFrameworkCore;

namespace Inetum.App.Services.Impl
{
    public class EditorialService : IEditorialService
    {
        protected PruebaInetumContext context = new PruebaInetumContext();

        public async Task<List<Editorial>> GetAllAsync()
        {
            List<Editorial> editoriales = await context.Editorials.ToListAsync();
            return editoriales;
        }

        public async Task<Editorial> GetByIdAsync(int Id)
        {
            Editorial editorial = await context.Editorials.FirstOrDefaultAsync(edi => edi.Id.Equals(Id));
            return editorial;
        }

        public async Task<EditorialModel> SaveAsync(EditorialModel editorial)
        {
            Editorial objEditorial = new Editorial();
            objEditorial.Nombre = editorial.Nombre;
            objEditorial.Sede = editorial.Sede;
            context.Editorials.Add(objEditorial);
            await context.SaveChangesAsync();
            editorial.Id = objEditorial.Id;
            return editorial;
        }
    }
}

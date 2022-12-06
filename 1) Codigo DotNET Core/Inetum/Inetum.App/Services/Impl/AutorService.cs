using Inetum.Datos.Modelos;
using Inetum.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace Inetum.App.Services.Impl
{
    public class AutorService : IAutorService
    {
        protected PruebaInetumContext context = new PruebaInetumContext();

        public async Task<List<Autor>> GetAllAsync()
        {
            List<Autor> autores = await context.Autors.ToListAsync();
            return autores;
        }       

        public async Task<List<Autor>> GetByEditorialAsync(int EditorialId)
        {
            List<Autor> autores = await context.Autors
                .Where(aut => aut.AutorHasLibros.Any(autLib => autLib.LibroIsbnNavigation.EditorialId.Equals(EditorialId)))
                .ToListAsync();

            return autores;
        }
    }
}

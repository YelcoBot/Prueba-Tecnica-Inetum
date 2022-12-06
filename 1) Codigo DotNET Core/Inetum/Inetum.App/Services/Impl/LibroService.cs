using Inetum.Datos.Modelos;
using Inetum.Modelo;
using Microsoft.EntityFrameworkCore;

namespace Inetum.App.Services.Impl
{
    public class LibroService : ILibroService
    {
        protected PruebaInetumContext context = new PruebaInetumContext();

        public async Task<List<Libro>> GetAllAsync()
        {
            List<Libro> libros = await context.Libros.Include(lib => lib.Editorial).ToListAsync();
            return libros;
        }

        public async Task<Libro> GetByIsbnAsync(int Isbn)
        {
            Libro libro = await context.Libros.Include(lib => lib.AutorHasLibros).FirstOrDefaultAsync(lib => lib.Isbn.Equals(Isbn));
            return libro;
        }

        public async Task<bool> SaveOrUpdateAsync(LibroModel libro, string accion)
        {
            Libro? objLibro = new Libro();

            if ((accion ?? string.Empty).Equals("Edit"))
            {
                objLibro = await context.Libros.Include(lib => lib.AutorHasLibros).FirstOrDefaultAsync(lib => lib.Isbn.Equals(libro.Isbn));

                if (objLibro == null)
                {
                    throw new ArgumentNullException(paramName: nameof(objLibro), message: $@"El libro no existe.");
                }
            }
            objLibro.Titulo = libro.Titulo;
            objLibro.Sinopsis = libro.Sinopsis;
            objLibro.EditorialId = libro.EditorialId;
            objLibro.NPaginas = libro.NPaginas;

            if ((accion ?? string.Empty).Equals("Create"))
            {
                context.Libros.Add(objLibro);
                await context.SaveChangesAsync();
            }

            //Delete Autor
            foreach (AutorHasLibro? autLib in objLibro.AutorHasLibros?.ToList()?.Where(aut => !libro.Autores.Contains(aut.AutorId)))
            {
                objLibro.AutorHasLibros.Remove(autLib);
            }

            List<int>? autoresExist = objLibro?.AutorHasLibros?.ToList()?.Where(autLib => libro.Autores.Contains(autLib.AutorId))?.Select(autLib => autLib.AutorId)?.ToList();
            //New Autor
            foreach (int aut in libro?.Autores?.Distinct()?.Where(aut => !autoresExist.Contains(aut)))
            {
                objLibro.AutorHasLibros.Add(new AutorHasLibro() { AutorId = aut, LibroIsbn = objLibro.Isbn });
            }

            context.Libros.Update(objLibro);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteByIsbnAsync(int Isbn)
        {
            Libro? objLibro = new Libro();

            objLibro = await context.Libros.Include(lib => lib.AutorHasLibros).FirstOrDefaultAsync(lib => lib.Isbn.Equals(Isbn));
            if (objLibro == null)
            {
                throw new ArgumentNullException(paramName: nameof(objLibro), message: $@"El libro no existe.");
            }

            //objLibro.AutorHasLibros.Clear();

            context.Libros.Remove(objLibro);
            await context.SaveChangesAsync();

            return true;
        }
    }
}

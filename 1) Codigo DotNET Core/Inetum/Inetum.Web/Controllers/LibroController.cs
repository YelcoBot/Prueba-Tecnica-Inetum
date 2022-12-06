using Inetum.App.Services;
using Inetum.Datos.Modelos;
using Inetum.Modelo;
using Inetum.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Inetum.Web.Controllers
{
    public class LibroController : Controller
    {
        private readonly ILogger<LibroController> _logger;
        private readonly ILibroService _libroService;
        private readonly IEditorialService _editorialService;
        private readonly IAutorService _autorService;


        public LibroController(ILogger<LibroController> logger, ILibroService libroService, IEditorialService editorialService, IAutorService autorService)
        {
            _logger = logger;
            _libroService = libroService;
            _editorialService = editorialService;
            _autorService = autorService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> GetData(string Titulo)
        {
            List<Libro> Libros = await _libroService.GetAllAsync();

            if (!string.IsNullOrEmpty(Titulo))
            {
                Libros = Libros?.Where(lib => lib.Titulo.Contains(Titulo))?.ToList();
            }

            return PartialView("_ListLibro", Libros);
        }

        public async Task<IActionResult> GetForm(int Isbn, string accion)
        {
            LibroModel model = null;

            if (Isbn > 0)
            {
                Libro libro = await _libroService.GetByIsbnAsync(Isbn);

                model = new LibroModel()
                {
                    Isbn = libro.Isbn,
                    EditorialId = libro.EditorialId,
                    Titulo = libro.Titulo,
                    Sinopsis = libro.Sinopsis,
                    NPaginas = libro.NPaginas,
                    Autores = libro.AutorHasLibros?.ToList()?.Select(autLib => autLib.AutorId)?.ToList(),
                };
            }

            List<Autor> Autores = await _autorService.GetAllAsync();
            List<Editorial> Editoriales = await _editorialService.GetAllAsync();

            List<SelectListItem> AutoresItems = Autores?.Select(aut => new SelectListItem()
            {
                Text = $@"{aut.Nombre} {aut.Apellidos}",
                Value = $@"{aut.Id}",
                Selected = (model?.Autores?.Contains(aut.Id) ?? false)
            })?.ToList();

            List<SelectListItem> EditorialesItems = Editoriales?.Select(edit => new SelectListItem()
            {
                Text = $@"{edit.Nombre} - {edit.Sede}",
                Value = $@"{edit.Id}",
                Selected = (model?.EditorialId.Equals(edit.Id) ?? false)
            })?.ToList();

            ViewBag.Accion = accion;
            ViewBag.AutoresItems = AutoresItems;
            ViewBag.EditorialesItems = EditorialesItems;


            return PartialView("_FormLibro", model);
        }

        [HttpPost()]
        public async Task<ActionResult> SaveOrUpdate(LibroModel libro, string accion)
        {
            List<string> Errors = new List<string>();

            if (string.IsNullOrEmpty(libro?.Titulo))
            {
                Errors.Add($@"Ingrese un título para el libro.");
            }

            if ((libro?.EditorialId ?? 0) == 0)
            {
                Errors.Add($@"Seleccione una editorial");
            }

            if ((libro?.Autores?.Count ?? 0) == 0)
            {
                Errors.Add($@"Seleccione un autor");
            }

            if (string.IsNullOrEmpty(libro?.NPaginas))
            {
                Errors.Add($@"Ingrese el número de paginas");
            }

            try
            {
                if ((Errors?.Count ?? 0) == 0)
                {
                    await _libroService.SaveOrUpdateAsync(libro, accion);
                }
            }
            catch (Exception ex)
            {
                Errors.Add($@"Error al guardar la información : {ex.Message}");
            }

            if ((Errors?.Count ?? 0) == 0)
            {
                return Ok(BaseResponse<bool>.Success(true));
            }
            else
            {
                return Ok(BaseResponse<List<string>>.Failure(Errors));
            }
        }

        [HttpDelete()]
        public async Task<ActionResult> Delete(int Isbn)
        {
            List<string> Errors = new List<string>();

            try
            {
                if ((Errors?.Count ?? 0) == 0)
                {
                    await _libroService.DeleteByIsbnAsync(Isbn);
                }
            }
            catch (Exception ex)
            {
                Errors.Add($@"Error al eliminar la información : {ex.Message}");
            }

            if ((Errors?.Count ?? 0) == 0)
            {
                return Ok(BaseResponse<bool>.Success(true));
            }
            else
            {
                return Ok(BaseResponse<List<string>>.Failure(Errors));
            }
        }

    }
}
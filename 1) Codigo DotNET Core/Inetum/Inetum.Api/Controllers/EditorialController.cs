using Inetum.App.Services;
using Inetum.Datos.Modelos;
using Inetum.Modelo;
using Inetum.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Inetum.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EditorialController : ControllerBase
    {
        private readonly ILogger<EditorialController> _logger;
        private readonly IEditorialService _editorialService;

        public EditorialController(ILogger<EditorialController> logger, IEditorialService editorialService)
        {
            _logger = logger;
            _editorialService = editorialService;
        }

        [HttpPost()]
        public async Task<ActionResult> CreateAsync(EditorialModel editorial)
        {
            List<string> Errors = new List<string>();

            if (string.IsNullOrEmpty(editorial?.Nombre))
            {
                Errors.Add($@"Ingrese un nombre para la editorial");
            }

            if (string.IsNullOrEmpty(editorial?.Sede))
            {
                Errors.Add($@"Ingrese una sede para la editorial");
            }

            try
            {
                if ((Errors?.Count ?? 0) == 0)
                {
                    editorial = await _editorialService.SaveAsync(editorial);
                }
            }
            catch (Exception ex)
            {
                Errors.Add($@"Error al guardar la información : {ex.Message}");
            }

            if ((Errors?.Count ?? 0) == 0)
            {
                return Ok(BaseResponse<EditorialModel>.Success(editorial));
            }
            else
            {
                return Ok(BaseResponse<List<string>>.Failure(Errors));
            }
        }
    }
}
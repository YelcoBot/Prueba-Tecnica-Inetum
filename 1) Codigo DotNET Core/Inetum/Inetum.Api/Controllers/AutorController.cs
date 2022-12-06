using Inetum.App.Services;
using Inetum.App.Services.Impl;
using Inetum.Datos.Modelos;
using Inetum.Modelo;
using Inetum.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Inetum.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutorController : ControllerBase
    {
        private readonly ILogger<AutorController> _logger;
        private readonly IAutorService _autorService;
        public AutorController(ILogger<AutorController> logger, IAutorService autorService)
        {
            _logger = logger;
            _autorService = autorService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            List<string> Errors = new List<string>();

            List<AutorModel> AutoresResponse = new List<AutorModel>();

            try
            {
                if ((Errors?.Count ?? 0) == 0)
                {
                    List<Autor> Autores = await _autorService.GetAllAsync();
                    AutoresResponse = Autores?.Select(aut => new AutorModel()
                    {
                        Id = aut.Id,
                        Nombre = aut.Nombre,
                        Apellidos = aut.Apellidos
                    })?.ToList();
                }
            }
            catch (Exception ex)
            {
                Errors.Add($@"Error al consultar la información : {ex.Message}");
            }

            if ((Errors?.Count ?? 0) == 0)
            {
                return Ok(BaseResponse<List<AutorModel>>.Success(AutoresResponse));
            }
            else
            {
                return Ok(BaseResponse<List<string>>.Failure(Errors));
            }
        }


        [HttpGet]
        [Route("Editorial/{id}")]
        public async Task<ActionResult> GetByEditorialAsync(int id)
        {
            List<string> Errors = new List<string>();

            List<AutorModel> AutoresResponse = new List<AutorModel>();

            if (id <= 0)
            {
                Errors.Add($@"Ingrese un código de editorial correcto : {id}");
            }

            try
            {
                if ((Errors?.Count ?? 0) == 0)
                {
                    List<Autor> Autores = await _autorService.GetByEditorialAsync(id);
                    AutoresResponse = Autores?.Select(aut => new AutorModel()
                    {
                        Id = aut.Id,
                        Nombre = aut.Nombre,
                        Apellidos = aut.Apellidos
                    })?.ToList();
                }
            }
            catch (Exception ex)
            {
                Errors.Add($@"Error al consultar la información : {ex.Message}");
            }

            if ((Errors?.Count ?? 0) == 0)
            {
                return Ok(BaseResponse<List<AutorModel>>.Success(AutoresResponse));
            }
            else
            {
                return Ok(BaseResponse<List<string>>.Failure(Errors));
            }
        }
    }
}
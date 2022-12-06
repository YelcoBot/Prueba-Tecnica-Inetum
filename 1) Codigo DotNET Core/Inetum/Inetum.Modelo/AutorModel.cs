using System.ComponentModel.DataAnnotations;

namespace Inetum.Modelo
{
    public class AutorModel
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        public string Nombre { get; set; } = null!;

        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; } = null!;

    }
}

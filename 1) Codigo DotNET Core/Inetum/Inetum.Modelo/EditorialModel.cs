using System.ComponentModel.DataAnnotations;

namespace Inetum.Modelo
{
    public class EditorialModel
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        public string Nombre { get; set; } = null!;

        [Display(Name = "Sede")]
        public string Sede { get; set; } = null!;

    }
}

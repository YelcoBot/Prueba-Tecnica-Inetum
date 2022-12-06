using System.ComponentModel.DataAnnotations;

namespace Inetum.Modelo
{
    public class LibroModel
    {
        public int Isbn { get; set; }

        [Display(Name = "Editorial")]
        public int EditorialId { get; set; }

        [Display(Name = "Titulo")]
        public string Titulo { get; set; } = null!;

        [Display(Name = "Sinopsis")]
        public string Sinopsis { get; set; } = null!;

        [Display(Name = "Número de paginas")]
        public string NPaginas { get; set; } = null!;

        [Display(Name = "Autores")]
        public List<int> Autores { get; set; } = null!;

    }
}

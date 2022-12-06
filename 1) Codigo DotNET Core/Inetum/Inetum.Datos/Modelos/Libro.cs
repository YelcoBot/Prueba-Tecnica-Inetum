using System;
using System.Collections.Generic;

namespace Inetum.Datos.Modelos;

public partial class Libro
{
    public int Isbn { get; set; }

    public int EditorialId { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Sinopsis { get; set; }

    public string NPaginas { get; set; } = null!;

    public virtual ICollection<AutorHasLibro> AutorHasLibros { get; } = new List<AutorHasLibro>();

    public virtual Editorial Editorial { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace Inetum.Datos.Modelos;

public partial class AutorHasLibro
{
    public int Id { get; set; }

    public int AutorId { get; set; }

    public int LibroIsbn { get; set; }

    public virtual Autor Autor { get; set; } = null!;

    public virtual Libro LibroIsbnNavigation { get; set; } = null!;
}

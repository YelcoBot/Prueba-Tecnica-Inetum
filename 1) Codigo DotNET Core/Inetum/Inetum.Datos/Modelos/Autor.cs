using System;
using System.Collections.Generic;

namespace Inetum.Datos.Modelos;

public partial class Autor
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public virtual ICollection<AutorHasLibro> AutorHasLibros { get; } = new List<AutorHasLibro>();
}

using System;
using System.Collections.Generic;

namespace Inetum.Datos.Modelos;

public partial class Editorial
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Sede { get; set; } = null!;

    public virtual ICollection<Libro> Libros { get; } = new List<Libro>();
}

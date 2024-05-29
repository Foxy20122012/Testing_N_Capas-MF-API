using System;
using System.Collections.Generic;

namespace Testing.Models.Inventarios;

public partial class Almacenes
{
    public int AlmacenId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Direccion { get; set; }
}

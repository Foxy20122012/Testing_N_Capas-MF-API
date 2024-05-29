using System;
using System.Collections.Generic;

namespace Testing.Models.Inventarios;

public partial class Proveedores
{
    public int ProveedorId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Email { get; set; }
}

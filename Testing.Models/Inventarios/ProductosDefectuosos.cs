using System;
using System.Collections.Generic;

namespace Testing.Models.Inventarios;

public partial class ProductosDefectuosos
{
    public int ProductoDefectuosoId { get; set; }

    public int? ProductoId { get; set; }

    public int Cantidad { get; set; }

    public DateOnly FechaReporte { get; set; }

    public virtual Inventario? Producto { get; set; }
}

using System;
using System.Collections.Generic;

namespace Testing.Models.Inventarios;

public partial class MovimientosInventario
{
    public int MovimientoId { get; set; }

    public int? ProductoId { get; set; }

    public string TipoMovimiento { get; set; } = null!;

    public int Cantidad { get; set; }

    public DateOnly FechaMovimiento { get; set; }

    public virtual Inventario? Producto { get; set; }
}

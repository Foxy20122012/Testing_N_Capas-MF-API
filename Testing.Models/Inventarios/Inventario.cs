using System;
using System.Collections.Generic;

namespace Testing.Models.Inventarios;

public partial class Inventario
{
    public int ProductoId { get; set; }

    public int StockActual { get; set; }

    public int StockMinimo { get; set; }

    public virtual ICollection<MovimientosInventario> MovimientosInventarios { get; set; } = new List<MovimientosInventario>();

    public virtual ICollection<ProductosDefectuosos> ProductosDefectuosos { get; set; } = new List<ProductosDefectuosos>();
}

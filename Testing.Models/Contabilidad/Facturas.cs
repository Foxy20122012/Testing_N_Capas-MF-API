using System;
using System.Collections.Generic;

namespace Testing.Models.Contabilidad;

public partial class Facturas
{
    public int FacturaId { get; set; }

    public int? ClienteId { get; set; }

    public DateOnly FechaFactura { get; set; }

    public decimal Total { get; set; }
}

using System;
using System.Collections.Generic;

namespace Testing.Models.Contabilidad;

public partial class Gastos
{
    public int GastoId { get; set; }

    public string? Descripcion { get; set; }

    public DateOnly FechaGasto { get; set; }

    public decimal Monto { get; set; }
}

using System;
using System.Collections.Generic;

namespace Testing.Models.Contabilidad;

public partial class Pagos
{
    public int PagoId { get; set; }

    public int? ClienteId { get; set; }

    public DateOnly FechaPago { get; set; }

    public decimal Monto { get; set; }
}

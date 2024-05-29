using System;
using System.Collections.Generic;

namespace Testing.Models.Contabilidad;

public partial class BalanceGeneral
{
    public int BalanceId { get; set; }

    public DateOnly Fecha { get; set; }

    public decimal ActivoTotal { get; set; }

    public decimal PasivoTotal { get; set; }

    public decimal PatrimonioTotal { get; set; }
}

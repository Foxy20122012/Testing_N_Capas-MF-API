using System;
using System.Collections.Generic;

namespace Testing.Models.Contabilidad;

public partial class LibroMayor
{
    public int MovimientoId { get; set; }

    public DateOnly Fecha { get; set; }

    public string? Descripcion { get; set; }

    public decimal Debe { get; set; }

    public decimal Haber { get; set; }
}

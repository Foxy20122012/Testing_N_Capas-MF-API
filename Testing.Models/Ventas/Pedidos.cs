using System;
using System.Collections.Generic;

namespace Testing.Models.Ventas;

public partial class Pedidos
{
    public int PedidoId { get; set; }

    public int? ClienteId { get; set; }

    public DateOnly FechaPedido { get; set; }

    public decimal Total { get; set; }

    public virtual Clientes? Cliente { get; set; }
}

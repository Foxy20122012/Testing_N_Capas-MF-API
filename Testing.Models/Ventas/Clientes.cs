using System;
using System.Collections.Generic;

namespace Testing.Models.Ventas;

public partial class Clientes
{
    public int ClienteId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public virtual ICollection<Pedidos> Pedidos { get; set; } = new List<Pedidos>();
}

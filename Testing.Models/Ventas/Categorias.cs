using System;
using System.Collections.Generic;

namespace Testing.Models.Ventas;

public partial class Categorias
{
    public int CategoriaId { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Productos> Productos { get; set; } = new List<Productos>();
}

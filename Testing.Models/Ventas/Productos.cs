using System;
using System.Collections.Generic;

namespace Testing.Models.Ventas;

public partial class Productos
{
    public int ProductoId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    public int Stock { get; set; }

    public int? CategoriaId { get; set; }

    public virtual Categorias? Categoria { get; set; }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Testing.Models.Ventas;

namespace Testing.DAL.Contexts;

public partial class VentasContext : DbContext
{
    public VentasContext()
    {
    }

    public VentasContext(DbContextOptions<VentasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorias> Categorias { get; set; }

    public virtual DbSet<Clientes> Clientes { get; set; }

    public virtual DbSet<Empleados> Empleados { get; set; }

    public virtual DbSet<Pedidos> Pedidos { get; set; }

    public virtual DbSet<Productos> Productos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=F01-IT-MIGUEL\\SQLEXPRESS;Database=test;Integrated Security=true;MultipleActiveResultSets=true;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorias>(entity =>
        {
            entity.HasKey(e => e.CategoriaId).HasName("PK__Categori__F353C1C5BCD1EF95");

            entity.ToTable("Categorias", "Ventas");

            entity.Property(e => e.CategoriaId).HasColumnName("CategoriaID");
            entity.Property(e => e.Nombre).HasMaxLength(255);
        });

        modelBuilder.Entity<Clientes>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PK__Clientes__71ABD0A7188FC1E5");

            entity.ToTable("Clientes", "Ventas");

            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.Apellido).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(255);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<Empleados>(entity =>
        {
            entity.HasKey(e => e.EmpleadoId).HasName("PK__Empleado__958BE6F03F27FE4E");

            entity.ToTable("Empleados", "Ventas");

            entity.Property(e => e.EmpleadoId).HasColumnName("EmpleadoID");
            entity.Property(e => e.Apellido).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(255);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<Pedidos>(entity =>
        {
            entity.HasKey(e => e.PedidoId).HasName("PK__Pedidos__09BA1410A042533E");

            entity.ToTable("Pedidos", "Ventas");

            entity.Property(e => e.PedidoId).HasColumnName("PedidoID");
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK__Pedidos__Cliente__4F7CD00D");
        });

        modelBuilder.Entity<Productos>(entity =>
        {
            entity.HasKey(e => e.ProductoId).HasName("PK__Producto__A430AE83F27A1762");

            entity.ToTable("Productos", "Ventas");

            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            entity.Property(e => e.CategoriaId).HasColumnName("CategoriaID");
            entity.Property(e => e.Nombre).HasMaxLength(255);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Productos)
                .HasForeignKey(d => d.CategoriaId)
                .HasConstraintName("FK__Productos__Categ__52593CB8");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

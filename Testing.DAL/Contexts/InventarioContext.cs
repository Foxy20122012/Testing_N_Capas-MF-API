using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Testing.Models.Inventarios;

namespace Testing.DAL.Contexts;

public partial class InventarioContext : DbContext
{
    public InventarioContext()
    {
    }

    public InventarioContext(DbContextOptions<InventarioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Almacenes> Almacenes { get; set; }

    public virtual DbSet<Inventario> Inventarios { get; set; }

    public virtual DbSet<MovimientosInventario> MovimientosInventarios { get; set; }

    public virtual DbSet<ProductosDefectuosos> ProductosDefectuosos { get; set; }

    public virtual DbSet<Proveedores> Proveedores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=F01-IT-MIGUEL\\SQLEXPRESS;Database=test;Integrated Security=true;MultipleActiveResultSets=true;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Almacenes>(entity =>
        {
            entity.HasKey(e => e.AlmacenId).HasName("PK__Almacene__022A0856E33C44B3");

            entity.ToTable("Almacenes", "Inventario");

            entity.Property(e => e.AlmacenId).HasColumnName("AlmacenID");
            entity.Property(e => e.Nombre).HasMaxLength(255);
        });

        modelBuilder.Entity<Inventario>(entity =>
        {
            entity.HasKey(e => e.ProductoId).HasName("PK__Inventar__A430AE83A240BF64");

            entity.ToTable("Inventario", "Inventario");

            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
        });

        modelBuilder.Entity<MovimientosInventario>(entity =>
        {
            entity.HasKey(e => e.MovimientoId).HasName("PK__Movimien__BF923FCCD66B720B");

            entity.ToTable("MovimientosInventario", "Inventario");

            entity.Property(e => e.MovimientoId).HasColumnName("MovimientoID");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            entity.Property(e => e.TipoMovimiento).HasMaxLength(50);

            entity.HasOne(d => d.Producto).WithMany(p => p.MovimientosInventarios)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK__Movimient__Produ__5DCAEF64");
        });

        modelBuilder.Entity<ProductosDefectuosos>(entity =>
        {
            entity.HasKey(e => e.ProductoDefectuosoId).HasName("PK__Producto__2A6F3550AEEA5A54");

            entity.ToTable("ProductosDefectuosos", "Inventario");

            entity.Property(e => e.ProductoDefectuosoId).HasColumnName("ProductoDefectuosoID");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

            entity.HasOne(d => d.Producto).WithMany(p => p.ProductosDefectuosos)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK__Productos__Produ__5AEE82B9");
        });

        modelBuilder.Entity<Proveedores>(entity =>
        {
            entity.HasKey(e => e.ProveedorId).HasName("PK__Proveedo__61266BB9D4309163");

            entity.ToTable("Proveedores", "Inventario");

            entity.Property(e => e.ProveedorId).HasColumnName("ProveedorID");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(255);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

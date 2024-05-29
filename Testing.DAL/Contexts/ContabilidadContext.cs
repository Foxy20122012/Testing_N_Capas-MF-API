using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Testing.Models.Contabilidad;

namespace Testing.DAL.Contexts;

public partial class ContabilidadContext : DbContext
{
    public ContabilidadContext()
    {
    }

    public ContabilidadContext(DbContextOptions<ContabilidadContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BalanceGeneral> BalanceGenerals { get; set; }

    public virtual DbSet<Facturas> Facturas { get; set; }

    public virtual DbSet<Gastos> Gastos { get; set; }

    public virtual DbSet<LibroMayor> LibroMayors { get; set; }

    public virtual DbSet<Pagos> Pagos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=F01-IT-MIGUEL\\SQLEXPRESS;Database=test;Integrated Security=true;MultipleActiveResultSets=true;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BalanceGeneral>(entity =>
        {
            entity.HasKey(e => e.BalanceId).HasName("PK__BalanceG__A760D59E4EAAEE75");

            entity.ToTable("BalanceGeneral", "Contabilidad");

            entity.Property(e => e.BalanceId).HasColumnName("BalanceID");
            entity.Property(e => e.ActivoTotal).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PasivoTotal).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PatrimonioTotal).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Facturas>(entity =>
        {
            entity.HasKey(e => e.FacturaId).HasName("PK__Facturas__5C024805924FE482");

            entity.ToTable("Facturas", "Contabilidad");

            entity.Property(e => e.FacturaId).HasColumnName("FacturaID");
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Gastos>(entity =>
        {
            entity.HasKey(e => e.GastoId).HasName("PK__Gastos__815BB1105CF0E15E");

            entity.ToTable("Gastos", "Contabilidad");

            entity.Property(e => e.GastoId).HasColumnName("GastoID");
            entity.Property(e => e.Monto).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<LibroMayor>(entity =>
        {
            entity.HasKey(e => e.MovimientoId).HasName("PK__LibroMay__BF923FCC19F604DC");

            entity.ToTable("LibroMayor", "Contabilidad");

            entity.Property(e => e.MovimientoId).HasColumnName("MovimientoID");
            entity.Property(e => e.Debe).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Haber).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Pagos>(entity =>
        {
            entity.HasKey(e => e.PagoId).HasName("PK__Pagos__F00B61588374CD34");

            entity.ToTable("Pagos", "Contabilidad");

            entity.Property(e => e.PagoId).HasColumnName("PagoID");
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.Monto).HasColumnType("decimal(10, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

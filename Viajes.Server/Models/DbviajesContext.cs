using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Viajes.Server.Models;

public partial class DbviajesContext : DbContext
{
    public DbviajesContext()
    {
    }

    public DbviajesContext(DbContextOptions<DbviajesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ciudade> Ciudades { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    public virtual DbSet<Viaje> Viajes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ciudade>(entity =>
        {
            entity.HasKey(e => e.IdCiudad).HasName("PK__ciudades__AEA2A71B439094DD");

            entity.ToTable("ciudades");

            entity.Property(e => e.IdCiudad).HasColumnName("idCiudad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Pais)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pais");
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.IdVehiculo).HasName("PK__vehiculo__4868297045F44951");

            entity.ToTable("vehiculos");

            entity.Property(e => e.IdVehiculo).HasColumnName("idVehiculo");
            entity.Property(e => e.DetalleVehiculo)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("detalle_vehiculo");
            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("marca");
            entity.Property(e => e.Matricula)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("matricula");
            entity.Property(e => e.TipoVehiculo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo_vehiculo");
        });

        modelBuilder.Entity<Viaje>(entity =>
        {
            entity.HasKey(e => e.IdViaje).HasName("PK__viajes__CFFF2BF0147EDB60");

            entity.ToTable("viajes");

            entity.Property(e => e.IdViaje).HasColumnName("idViaje");
            entity.Property(e => e.Clima)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("clima");
            entity.Property(e => e.CodigoCiudad).HasColumnName("codigo_ciudad");
            entity.Property(e => e.CodigoVehiculo).HasColumnName("codigo_vehiculo");
            entity.Property(e => e.Destino)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");

            entity.HasOne(d => d.CodigoCiudadNavigation).WithMany(p => p.Viajes)
                .HasForeignKey(d => d.CodigoCiudad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__viajes__codigo_c__3B75D760");

            entity.HasOne(d => d.CodigoVehiculoNavigation).WithMany(p => p.Viajes)
                .HasForeignKey(d => d.CodigoVehiculo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__viajes__codigo_v__3A81B327");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

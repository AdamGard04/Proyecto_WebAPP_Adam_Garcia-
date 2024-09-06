using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebPrestamoBack.Model
{
    public partial class prestamosContext : DbContext
    {
        public prestamosContext()
        {
        }

        public prestamosContext(DbContextOptions<prestamosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrador> Administradors { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Pago> Pagos { get; set; } = null!;
        public virtual DbSet<Prestamo> Prestamos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>(entity =>
            {
                entity.ToTable("Administrador");

                entity.HasIndex(e => e.Email, "UQ__Administ__A9D10534E76CDA6C")
                    .IsUnique();

                entity.Property(e => e.AdministradorId).HasColumnName("AdministradorID");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Rol)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");

                entity.HasIndex(e => e.Email, "UQ__Cliente__A9D10534EF5C033A")
                    .IsUnique();

                entity.Property(e => e.ClienteId).HasColumnName("ClienteID");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.HistorialCrediticio).IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroTelefono)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.ToTable("Pago");

                entity.Property(e => e.PagoId).HasColumnName("PagoID");

                entity.Property(e => e.CapitalAmortizado).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Comisiones).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.FechaPago).HasColumnType("date");

                entity.Property(e => e.Intereses).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.MontoPago).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.PrestamoId).HasColumnName("PrestamoID");

                entity.HasOne(d => d.Prestamo)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.PrestamoId)
                    .HasConstraintName("FK__Pago__PrestamoID__2E1BDC42");
            });

            modelBuilder.Entity<Prestamo>(entity =>
            {
                entity.ToTable("Prestamo");

                entity.Property(e => e.PrestamoId).HasColumnName("PrestamoID");

                entity.Property(e => e.ClienteId).HasColumnName("ClienteID");

                entity.Property(e => e.Estado)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FechaSolicitud).HasColumnType("date");

                entity.Property(e => e.MontoSolicitado).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.TasaInteres).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.TipoPrestamo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Prestamos)
                    .HasForeignKey(d => d.ClienteId)
                    .HasConstraintName("FK__Prestamo__Client__2A4B4B5E");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

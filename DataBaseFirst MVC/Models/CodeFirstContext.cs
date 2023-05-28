using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataBaseFirst_MVC.Models;

public partial class CodeFirstContext : DbContext
{
    public CodeFirstContext()
    {
    }

    public CodeFirstContext(DbContextOptions<CodeFirstContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Libro> Libros { get; set; }

    public virtual DbSet<Personaje> Personajes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MSI;Initial Catalog=CodeFirst;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.LibId).HasName("PK__Libros__4151D0F3E5C27AEC");

            entity.Property(e => e.LibId).HasColumnName("Lib_Id");
            entity.Property(e => e.LibAutor)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Lib_Autor");
            entity.Property(e => e.LibGenero)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Lib_Genero");
            entity.Property(e => e.LibNombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Lib_Nombre");
            entity.Property(e => e.LibStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Lib_Status");
            entity.Property(e => e.LibTipoproyecto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Lib_Tipoproyecto");
        });

        modelBuilder.Entity<Personaje>(entity =>
        {
            entity.HasKey(e => e.PerId).HasName("PK__personaj__32A0223FFDCFB468");

            entity.ToTable("personajes");

            entity.Property(e => e.PerId).HasColumnName("per_Id");
            entity.Property(e => e.PerApellido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("per_Apellido");
            entity.Property(e => e.PerDescripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("per_Descripcion");
            entity.Property(e => e.PerFechaNacimiento)
                .HasColumnType("date")
                .HasColumnName("per_FechaNacimiento");
            entity.Property(e => e.PerLibId).HasColumnName("per_LibId");
            entity.Property(e => e.PerLugarNacimiento)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("per_LugarNacimiento");
            entity.Property(e => e.PerNombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("per_Nombre");
            entity.Property(e => e.PerRolId).HasColumnName("per_RolId");
            entity.Property(e => e.PerStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("per_Status");

            entity.HasOne(d => d.PerLib).WithMany(p => p.Personajes)
                .HasForeignKey(d => d.PerLibId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__personaje__per_L__46E78A0C");

            entity.HasOne(d => d.PerRol).WithMany(p => p.Personajes)
                .HasForeignKey(d => d.PerRolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__personaje__per_R__47DBAE45");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RolId).HasName("PK__Roles__795EBD49A746716E");

            entity.Property(e => e.RolId).HasColumnName("Rol_Id");
            entity.Property(e => e.RolDescripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Rol_Descripcion");
            entity.Property(e => e.RolStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Rol_Status");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

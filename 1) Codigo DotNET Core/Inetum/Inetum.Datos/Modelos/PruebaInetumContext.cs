using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Inetum.Datos.Modelos;

public partial class PruebaInetumContext : DbContext
{
    public PruebaInetumContext()
    {
    }

    public PruebaInetumContext(DbContextOptions<PruebaInetumContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Autor> Autors { get; set; }

    public virtual DbSet<AutorHasLibro> AutorHasLibros { get; set; }

    public virtual DbSet<Editorial> Editorials { get; set; }

    public virtual DbSet<Libro> Libros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-AJQ074C;Database=PruebaInetum;Trusted_Connection=True;Trust Server Certificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Autor");

            entity.ToTable("autor");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(45)
                .HasColumnName("apellidos");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<AutorHasLibro>(entity =>
        {
            entity.ToTable("autor_has_libro");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AutorId).HasColumnName("autor_id");
            entity.Property(e => e.LibroIsbn).HasColumnName("libro_ISBN");

            entity.HasOne(d => d.Autor).WithMany(p => p.AutorHasLibros)
                .HasForeignKey(d => d.AutorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_autor_id");

            entity.HasOne(d => d.LibroIsbnNavigation).WithMany(p => p.AutorHasLibros)
                .HasForeignKey(d => d.LibroIsbn)
                .HasConstraintName("fk_libro_ISBN");
        });

        modelBuilder.Entity<Editorial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Editorial");

            entity.ToTable("editorial");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .HasColumnName("nombre");
            entity.Property(e => e.Sede)
                .HasMaxLength(45)
                .HasColumnName("sede");
        });

        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.Isbn).HasName("PK_Libro");

            entity.ToTable("libro");

            entity.Property(e => e.Isbn).HasColumnName("ISBN");
            entity.Property(e => e.EditorialId).HasColumnName("editorial_id");
            entity.Property(e => e.NPaginas)
                .HasMaxLength(45)
                .HasColumnName("n_paginas");
            entity.Property(e => e.Sinopsis)
                .HasColumnType("text")
                .HasColumnName("sinopsis");
            entity.Property(e => e.Titulo)
                .HasMaxLength(45)
                .HasColumnName("titulo");

            entity.HasOne(d => d.Editorial).WithMany(p => p.Libros)
                .HasForeignKey(d => d.EditorialId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_editorial_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

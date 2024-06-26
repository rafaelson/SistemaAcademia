﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SistemaAcademia.MODEL.Models;

public partial class SistemaAcademiaContext : DbContext
{
    public SistemaAcademiaContext()
    {
    }

    public SistemaAcademiaContext(DbContextOptions<SistemaAcademiaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Membros> Membros { get; set; }

    public virtual DbSet<PlanosTreino> PlanosTreino { get; set; }

    public virtual DbSet<Treinadores> Treinadores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-869HT1T\\SQLEXPRESS;Initial Catalog=SistemaAcademia;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Membros>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Membros__3214EC074CA1BA7E");

            entity.Property(e => e.DataCadastro).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.StatusCadastro).HasDefaultValue(true);
            entity.Property(e => e.Telefone)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PlanosTreino>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PlanosTr__3214EC0745865FD5");

            entity.HasIndex(e => e.MembroId, "IFK_Rel_01");

            entity.HasIndex(e => e.TreinadorId, "IFK_Rel_02");

            entity.HasIndex(e => e.MembroId, "PlanosTreino_FKIndex1");

            entity.HasIndex(e => e.TreinadorId, "PlanosTreino_FKIndex2");

            entity.Property(e => e.DataCriacao).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Descricao).IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.HasOne(d => d.Membro).WithMany(p => p.PlanosTreino)
                .HasForeignKey(d => d.MembroId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PlanosTre__Membr__2D27B809");

            entity.HasOne(d => d.Treinador).WithMany(p => p.PlanosTreino)
                .HasForeignKey(d => d.TreinadorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PlanosTre__Trein__2E1BDC42");
        });

        modelBuilder.Entity<Treinadores>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Treinado__3214EC07DA1DF681");

            entity.Property(e => e.DataContratacao).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.StatusAtuacao).HasDefaultValue(true);
            entity.Property(e => e.Telefone)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
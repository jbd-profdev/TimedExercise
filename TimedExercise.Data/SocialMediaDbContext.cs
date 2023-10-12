using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TimedExercise.Data.Entities;

namespace TimedExercise.Data;

public partial class SocialMediaDbContext : DbContext
{
    public SocialMediaDbContext()
    {
    }

    public SocialMediaDbContext(DbContextOptions<SocialMediaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Like> Likes { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Reply> Replies { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:SocialMediaDb");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comments__3214EC07C17985EA");

            entity.ToTable("Comments", "dev");

            entity.Property(e => e.Text).HasMaxLength(256);

            entity.HasOne(d => d.Author).WithMany(p => p.Comments)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comments__Author__3C69FB99");

            entity.HasOne(d => d.Post).WithMany(p => p.Comments)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comments__PostId__3D5E1FD2");
        });

        modelBuilder.Entity<Like>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Likes__3214EC074779D539");

            entity.ToTable("Likes", "dev");

            entity.HasOne(d => d.Post).WithMany(p => p.Likes)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Likes__PostId__44FF419A");

            entity.HasOne(d => d.User).WithMany(p => p.Likes)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Likes__UserId__440B1D61");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Posts__3214EC07FC0B5168");

            entity.ToTable("Posts", "dev");

            entity.Property(e => e.Title).HasMaxLength(100);
            entity.Property(e => e.Url).HasMaxLength(100);

            entity.HasOne(d => d.Author).WithMany(p => p.Posts)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Posts__AuthorId__398D8EEE");
        });

        modelBuilder.Entity<Reply>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Replies__3214EC076C5D073A");

            entity.ToTable("Replies", "dev");

            entity.Property(e => e.Text).HasMaxLength(256);

            entity.HasOne(d => d.Author).WithMany(p => p.Replies)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Replies__AuthorI__403A8C7D");

            entity.HasOne(d => d.Parent).WithMany(p => p.Replies)
                .HasForeignKey(d => d.ParentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Replies__ParentI__412EB0B6");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07CDD26C33");

            entity.ToTable("Users", "dev");

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using LegalFileControl.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LegalFileControl.Infrastructure.data;

public partial class LegalFileControlDbContext : DbContext
{
    public LegalFileControlDbContext()
    {
    }

    public LegalFileControlDbContext(DbContextOptions<LegalFileControlDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Charge> Charges { get; set; }

    public virtual DbSet<ChargeLegalFile> ChargeLegalFiles { get; set; }

    public virtual DbSet<LegalFile> LegalFiles { get; set; }

    public virtual DbSet<LegalFileStatus> LegalFileStatuses { get; set; }

    public virtual DbSet<MenuItem> MenuItems { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RolePermission> RolePermissions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Charge>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Charges__3214EC077186439B");

            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ImagePath)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.ReceptionDate).HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.Charges)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Charges__UserId__6383C8BA");
        });

        modelBuilder.Entity<ChargeLegalFile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ChargeLe__3214EC072A9E2585");

            entity.ToTable("ChargeLegalFile");

            entity.HasOne(d => d.Charge).WithMany(p => p.ChargeLegalFiles)
                .HasForeignKey(d => d.ChargeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChargeLeg__Charg__66603565");

            entity.HasOne(d => d.LegalFile).WithMany(p => p.ChargeLegalFiles)
                .HasForeignKey(d => d.LegalFileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChargeLeg__Legal__6754599E");
        });

        modelBuilder.Entity<LegalFile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LegalFil__3214EC07DF49A72C");

            entity.Property(e => e.CustomerCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Period)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.RejectionReason)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ValidationDate).HasColumnType("datetime");
            entity.Property(e => e.Wocount).HasColumnName("WOCount");

            entity.HasOne(d => d.LegalFileStatus).WithMany(p => p.LegalFiles)
                .HasForeignKey(d => d.LegalFileStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LegalFile__Legal__5FB337D6");
        });

        modelBuilder.Entity<LegalFileStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LegalFil__3214EC0723D1697E");

            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StatusCode)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<MenuItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MenuItem__3214EC07A01ED443");

            entity.Property(e => e.Icon)
                .HasMaxLength(220)
                .IsUnicode(false);
            entity.Property(e => e.Label)
                .HasMaxLength(220)
                .IsUnicode(false);
            entity.Property(e => e.RouterLink)
                .HasMaxLength(220)
                .IsUnicode(false);

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .HasConstraintName("FK__MenuItems__Paren__5441852A");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Permissi__3214EC07FA9A5A18");

            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.MenuItem).WithMany(p => p.Permissions)
                .HasForeignKey(d => d.MenuItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Permissio__MenuI__571DF1D5");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC0738461793");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(220)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RolePermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RolePerm__3214EC0758EA0E48");

            entity.HasOne(d => d.Permission).WithMany(p => p.RolePermissions)
                .HasForeignKey(d => d.PermissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RolePermi__Permi__59FA5E80");

            entity.HasOne(d => d.Role).WithMany(p => p.RolePermissions)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RolePermi__RoleI__5AEE82B9");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07B7DF7C9E");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Dni)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Name)
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Users__RoleId__4E88ABD4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Models;

public partial class TicketContext : DbContext
{
    public TicketContext()
    {
    }

    public TicketContext(DbContextOptions<TicketContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Route> Routes { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-H56BTO6;Database=Ticket;User Id=gulzaib;Password=gulzaib123;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__D80AB4BBB8A26F66");

            entity.Property(e => e.RoleId).HasColumnName("Role_Id");
            entity.Property(e => e.RoleDesc)
                .HasMaxLength(50)
                .HasColumnName("Role_Desc");
        });

        modelBuilder.Entity<Route>(entity =>
        {
            entity.HasKey(e => e.RouteId).HasName("PK__Routes__6DC9D91186EA71D7");

            entity.Property(e => e.RouteId).HasColumnName("Route_Id");
            entity.Property(e => e.Destinations).HasMaxLength(50);
            entity.Property(e => e.Origin).HasMaxLength(50);
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("PK__Tickets__ED7260B9DCEE22A2");

            entity.Property(e => e.TicketId).HasColumnName("Ticket_Id");
            entity.Property(e => e.Arrival).HasColumnType("datetime");
            entity.Property(e => e.BookedBy).HasColumnName("BOOKED_BY");
            entity.Property(e => e.Departure).HasColumnType("datetime");
            entity.Property(e => e.Destination).HasMaxLength(50);
            entity.Property(e => e.Origin).HasMaxLength(50);
            entity.Property(e => e.TravlerName)
                .HasMaxLength(50)
                .HasColumnName("TRAVLER_NAME");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__206D9170B06214A0");

            entity.Property(e => e.UserId).HasColumnName("User_Id");
            entity.Property(e => e.CreationDate)
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.ExpiryDate)
                .HasColumnType("datetime")
                .HasColumnName("Expiry_Date");
            entity.Property(e => e.RoleId).HasColumnName("Role_ID");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .HasColumnName("User_Name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

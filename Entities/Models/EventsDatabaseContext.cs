using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entities.Models
{
    public partial class EventsDatabaseContext : DbContext
    {
        public EventsDatabaseContext()
        {
        }

        public EventsDatabaseContext(DbContextOptions<EventsDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Event> Events { get; set; } = null!;
        public virtual DbSet<EventDiscussion> EventDiscussions { get; set; } = null!;
        public virtual DbSet<EventRegistration> EventRegistrations { get; set; } = null!;
        public virtual DbSet<Notification> Notifications { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EventsDatabase;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("Event");

                entity.Property(e => e.EventId)
                    .HasColumnName("EventID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Location).HasMaxLength(100);

                entity.Property(e => e.OrganizerId).HasColumnName("OrganizerID");

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.Property(e => e.Visibility).HasMaxLength(20);

                entity.HasOne(d => d.Organizer)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.OrganizerId)
                    .HasConstraintName("FK__Event__Organizer__3E52440B");
            });

            modelBuilder.Entity<EventDiscussion>(entity =>
            {
                entity.HasKey(e => e.DiscussionId)
                    .HasName("PK__EventDis__7E8E3920C4E75A5C");

                entity.ToTable("EventDiscussion");

                entity.Property(e => e.DiscussionId)
                    .HasColumnName("DiscussionID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.Timestamp).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventDiscussions)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK__EventDisc__Event__46E78A0C");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EventDiscussions)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__EventDisc__UserI__47DBAE45");
            });

            modelBuilder.Entity<EventRegistration>(entity =>
            {
                entity.HasKey(e => e.RegistrationId)
                    .HasName("PK__EventReg__6EF58830258F8FE0");

                entity.ToTable("EventRegistration");

                entity.Property(e => e.RegistrationId)
                    .HasColumnName("RegistrationID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.RegistrationDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventRegistrations)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK__EventRegi__Event__4222D4EF");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EventRegistrations)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__EventRegi__UserI__4316F928");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.Property(e => e.NotificationId)
                    .HasColumnName("NotificationID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.ContentId).HasColumnName("ContentID");

                entity.Property(e => e.IsSeen).HasColumnName("isSeen");

                entity.Property(e => e.MessageContent).IsUnicode(false);

                entity.Property(e => e.ReceiverId).HasColumnName("ReceiverID");

                entity.Property(e => e.SendDateTime).HasColumnType("datetime");

                entity.Property(e => e.SenderId).HasColumnName("SenderID");

                entity.HasOne(d => d.Receiver)
                    .WithMany(p => p.NotificationReceivers)
                    .HasForeignKey(d => d.ReceiverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Notificat__Recei__5DCAEF64");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.NotificationSenders)
                    .HasForeignKey(d => d.SenderId)
                    .HasConstraintName("FK__Notificat__Sende__5EBF139D");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Username, "UQ__Users__536C85E408406FE1")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.PasswordHash).HasMaxLength(100);

                entity.Property(e => e.RegistrationDate).HasColumnType("datetime");

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.Roles })
                    .HasName("PK_EMAIL");

                entity.ToTable("UserRole");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserRole__UserID__3A81B327");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

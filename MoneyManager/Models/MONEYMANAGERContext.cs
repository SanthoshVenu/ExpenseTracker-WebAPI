using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MoneyManager.Models
{
    public partial class MONEYMANAGERContext : DbContext
    {
        public MONEYMANAGERContext()
        {
        }

        public MONEYMANAGERContext(DbContextOptions<MONEYMANAGERContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountMaster> AccountMasters { get; set; }
        public virtual DbSet<CategoryMaster> CategoryMasters { get; set; }
        public virtual DbSet<CurrencyMaster> CurrencyMasters { get; set; }
        public virtual DbSet<ExpenseTracker> ExpenseTrackers { get; set; }
        public virtual DbSet<MoneyManager> MoneyManagers { get; set; }
        public virtual DbSet<SubCategoryMaster> SubCategoryMasters { get; set; }
        public virtual DbSet<VwAllColumnsPrimarykey> VwAllColumnsPrimarykeys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-29VJ4C5O\\SQLEXPRESS;Database=MONEY MANAGER;Trusted_Connection=True;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountMaster>(entity =>
            {
                entity.HasKey(e => e.PaymentModetId);

                entity.ToTable("AccountMaster", "mm");

                entity.HasIndex(e => e.PaymentModeName, "IX_AccountMaster")
                    .IsUnique();

                entity.Property(e => e.PaymentModeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CategoryMaster>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.ToTable("CategoryMaster", "mm");

                entity.HasIndex(e => e.CategoryName, "IX_CategoryMaster")
                    .IsUnique();

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CurrencyMaster>(entity =>
            {
                entity.HasKey(e => e.CurrencyId);

                entity.ToTable("CurrencyMaster", "mm");

                entity.HasIndex(e => e.CurrencyName, "IX_CurrencyMaster")
                    .IsUnique();

                entity.Property(e => e.CurrencyName)
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<ExpenseTracker>(entity =>
            {
                entity.ToTable("ExpenseTracker", "mm");

                entity.Property(e => e.Category).HasMaxLength(50);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.ExpenseInfoId)
                    .HasMaxLength(50)
                    .HasColumnName("ExpenseInfo_Id");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModeOfPayment)
                    .HasMaxLength(50)
                    .HasColumnName("Mode_Of_Payment");

                entity.Property(e => e.SubCategory).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            modelBuilder.Entity<MoneyManager>(entity =>
            {
                entity.HasKey(e => e.ExpenseId);

                entity.ToTable("MoneyManager", "mm");

                entity.Property(e => e.Category).HasMaxLength(100);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.ExpenseDescription).HasMaxLength(255);

                entity.Property(e => e.ExpenseInfoId)
                    .HasMaxLength(50)
                    .HasColumnName("ExpenseInfo_Id")
                    .IsFixedLength(true);

                entity.Property(e => e.IncomeExpense)
                    .HasMaxLength(20)
                    .HasColumnName("Income_Expense");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModeOfPayment)
                    .HasMaxLength(20)
                    .HasColumnName("Mode_Of_Payment")
                    .IsFixedLength(true);

                entity.Property(e => e.Subcategory).HasMaxLength(100);

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<SubCategoryMaster>(entity =>
            {
                entity.HasKey(e => e.SubCategoryId);

                entity.ToTable("SubCategoryMaster", "mm");

                entity.HasIndex(e => e.SubCategoryName, "IX_SubCategoryMaster")
                    .IsUnique();

                entity.Property(e => e.SubCategoryName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.SubCategoryMasters)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_SubCategoryMaster_CategoryMaster");
            });

            modelBuilder.Entity<VwAllColumnsPrimarykey>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwAllColumnsPrimarykeys", "mm");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

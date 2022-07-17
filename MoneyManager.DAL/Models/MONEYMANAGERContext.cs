using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MoneyManager.DAL.Models
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

        public virtual DbSet<AccountMasterModel> AccountMasters { get; set; }
        public virtual DbSet<CategoryMasterModel> CategoryMasters { get; set; }
        public virtual DbSet<CurrencyMasterModel> CurrencyMasters { get; set; }
        public virtual DbSet<ExpenseTrackerModel> ExpenseTrackers { get; set; }
        public virtual DbSet<MoneyManagerModel> MoneyManagers { get; set; }
        public virtual DbSet<SubCategoryMasterModel> SubCategoryMasters { get; set; }
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
            modelBuilder.Entity<AccountMasterModel>(entity =>
            {
                entity.HasKey(e => e.AccountId);

                entity.ToTable("AccountMaster", "mm");

                entity.HasIndex(e => e.AccountName, "IX_AccountMaster")
                    .IsUnique();

                entity.Property(e => e.AccountName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<CategoryMasterModel>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.ToTable("CategoryMaster", "mm");

                entity.HasIndex(e => e.CategoryName, "IX_CategoryMaster")
                    .IsUnique();

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<CurrencyMasterModel>(entity =>
            {
                entity.HasKey(e => e.CurrencyId);

                entity.ToTable("CurrencyMaster", "mm");

                entity.HasIndex(e => e.CurrencyName, "IX_CurrencyMaster")
                    .IsUnique();

                entity.Property(e => e.CurrencyName)
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<ExpenseTrackerModel>(entity =>
            {
                entity.ToTable("ExpenseTracker", "mm");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Account)
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.Property(e => e.Category)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.Cost)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.IncomeExpenses)
                    .HasMaxLength(15)
                    .HasColumnName("Income/Expenses")
                    .IsFixedLength(true);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.SubCategory)
                    .HasMaxLength(100)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<MoneyManagerModel>(entity =>
            {
                entity.HasKey(e => e.ExpenseId);

                entity.ToTable("MoneyManager", "mm");

                entity.Property(e => e.Account)
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.Property(e => e.Category).HasMaxLength(255);

                entity.Property(e => e.Currency)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.IncomeExpense)
                    .HasMaxLength(255)
                    .HasColumnName("Income_Expense");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.SpecificNotes).HasMaxLength(255);

                entity.Property(e => e.Subcategory).HasMaxLength(255);

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<SubCategoryMasterModel>(entity =>
            {
                entity.HasKey(e => e.SubCategoryId);

                entity.ToTable("SubCategoryMaster", "mm");

                entity.HasIndex(e => e.SubCategoryName, "IX_SubCategoryMaster")
                    .IsUnique();

                entity.Property(e => e.SubCategoryName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsFixedLength(true);

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

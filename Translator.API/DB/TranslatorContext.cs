using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Translator.API.DB
{
    public partial class TranslatorContext : DbContext
    {
        private string _connectionString { get; set; }

        public TranslatorContext()
        {
        }

        public TranslatorContext(DbContextOptions<TranslatorContext> options, string connectionString)
            : base(options)
        {
            _connectionString = connectionString;
        }

        public virtual DbSet<Translation> Translations { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Translation>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Translation");

                entity.Property(e => e.Chinese).HasMaxLength(255);

                entity.Property(e => e.English).HasMaxLength(255);

                entity.Property(e => e.Hungarian).HasMaxLength(255);

                entity.Property(e => e.Portuguese).HasMaxLength(255);

                entity.Property(e => e.Spanish).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

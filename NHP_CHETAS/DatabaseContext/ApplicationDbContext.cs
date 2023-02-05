using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NHP_CHETAS.Models;

namespace NHP_CHETAS.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DamLevelDetails>().HasNoKey();
            modelBuilder.Entity<GraphModel>().HasNoKey();
            modelBuilder.Entity<List<MasterData>>().HasNoKey();
            modelBuilder.Entity<List<DamLevelReport>>().HasNoKey();
        }

        public virtual DbSet<GraphModel> IsLogin { get; set; }

        public virtual DbSet<DamLevelDetails> DamLevelData { get; set; }

        public virtual DbSet<List<MasterData>> MasterData { get; set; }
        public virtual DbSet<List<DamLevelReport>> DamLevelReport { get; set; }

    }
}

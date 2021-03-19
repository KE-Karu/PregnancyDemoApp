using Microsoft.EntityFrameworkCore;
using PregnancyDemoApp.Models;

namespace PregnancyDemoApp.AppDbContext
{
    public class PregnancyDbContext : DbContext
    {
        public PregnancyDbContext(DbContextOptions<PregnancyDbContext> options) : base(options) { }

        public PregnancyDbContext() { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Childbirth> Childbirths { get; set; }
        public DbSet<Pregnancy> Pregnancies { get; set; }
        public DbSet<Obstetrician> Obstetricians { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            InitializeTables(builder);
        }

        public static void InitializeTables(ModelBuilder builder)
        {
            if (builder is null) return;
            builder.Entity<Person>().ToTable(nameof(Persons)).HasIndex(a => a.NatIdNr).IsUnique();
            builder.Entity<Childbirth>().ToTable(nameof(Childbirths));
            builder.Entity<Pregnancy>().ToTable(nameof(Pregnancies)).HasOne(x => x.Childbirth).WithOne(c => c.Pregnancy);
            builder.Entity<Obstetrician>().ToTable(nameof(Obstetricians)).HasOne(x => x.Person);
        }
    }   
}

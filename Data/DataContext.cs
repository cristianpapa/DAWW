using DAWW.Models;
using Microsoft.EntityFrameworkCore;

namespace DAWW.Data
{
    public class DataContext: DbContext
    {
        public DataContext()
        {
        }
        public DataContext(DbContextOptions<DataContext>options): base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-L383BD9;Initial Catalog=DAWW;Integrated Security=True;");
        }
        public DbSet<Achizitie> Achizitii { get; set; }
        public DbSet<User> Useri { get; set; }
        public DbSet<Produs> Produse { get; set; }
        public DbSet<Comanda> Comenzi { get; set; }
        public DbSet<Plata> Plati { get; set; }
        public DbSet<Livrare> Livrari { get; set; }
        public DbSet<Adresa> Adrese { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Achizitie>()
                .HasKey(a => new { a.IdUser, a.IdProdus, a.IdComanda });
            modelBuilder.Entity<Achizitie>()
                .HasOne(u => u.User)
                .WithMany(a => a.Achizitii)
                .HasForeignKey(u => u.IdUser);
            modelBuilder.Entity<Achizitie>()
                .HasOne(p => p.Produs)
                .WithMany(a => a.Achizitii)
                .HasForeignKey(p => p.IdProdus);
            modelBuilder.Entity<Achizitie>()
               .HasOne(p => p.Comanda)
               .WithMany(a => a.Achizitii)
               .HasForeignKey(p => p.IdComanda);


            modelBuilder.Entity<Plata>()
                .HasOne(p => p.Comanda)
                .WithOne(c => c.Plata)
                .HasForeignKey<Comanda>(c => c.IdPlata);

            modelBuilder.Entity<Livrare>()
               .HasOne(p => p.Comanda)
               .WithOne(c => c.Livrare)
               .HasForeignKey<Comanda>(c => c.IdLivrare);


            modelBuilder.Entity<Livrare>()
               .HasOne(p => p.Adresa)
               .WithMany(c => c.Livrari)
               .HasForeignKey(c => c.IdAdresa);


        }
    }
}

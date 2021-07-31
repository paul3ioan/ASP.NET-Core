using System;
using MagazinData.Entity;
using MagazinData.Users;
using Microsoft.EntityFrameworkCore;
namespace MagazinData
{
    public class DepozitContext : DbContext
    {
        public DbSet<Produs> produs { get; set; }
        public DbSet<Aliment> aliments { get; set; }
        public DbSet<Books> books { get; set; }
        public DbSet<Jucarii> jucarii { get; set; }
        public DbSet<User> user { get; set; }
        public DbSet<Transaction> transaction { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:cloud-paul-db.database.windows.net,1433;Database=cloud-paul-db;User ID=paul;Password=0eV01pwLo9QKAcv7FHDs;Trusted_Connection=False;Encrypt=True;");
     //       optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Magazin;Trusted_Connection=True;User Id = paul; Password=paul") ;
        }


    }
}

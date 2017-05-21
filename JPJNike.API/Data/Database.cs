using JPJNike.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPJNike.API.Data
{
    public class Database : DbContext
    {
        public DbSet<Exercicio> Exercicio { get; set; }

        public DbSet<BlogPost> BlogPosts { get; set; }

        public Database()
        {

        }

        public Database(DbContextOptions<Database> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exercicio>()
                .HasKey(m => m.Id);
            modelBuilder.Entity<Exercicio>()
                .Property(c => c.Nome)
                .HasMaxLength(100);


            modelBuilder.Entity<BlogPost>()
                .Property(c => c.Tag)
                .HasMaxLength(20);
            modelBuilder.Entity<BlogPost>()
                .Property(c => c.Titulo)
                .HasMaxLength(100)
                .IsRequired(true);

            base.OnModelCreating(modelBuilder);
        }

        // gonne to the code's grave 
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=jpjnike;Integrated Security=True;Pooling=False");
        //}
    }
}

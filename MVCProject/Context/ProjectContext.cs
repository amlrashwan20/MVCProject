using MVCProject.Models;
using Microsoft.EntityFrameworkCore;


namespace MVCProject.Context
{
    public class ProjectContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=AMLRASHWAN\\MSSQLSERVER2022;Database=HijabyDb;Trusted_Connection=true;Encrypt=false");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var _Products = new List<Product>
            {
             new Product{ProductId=1,Title="Hijab Scarf ",Price=150 , Description="Hijab Scarf for Women Soft Cotton ",Code="100h" ,Quantity=10,PathImage="https://m.media-amazon.com/images/I/619BQu-V1RL._AC_SX569_.jpg",CategoryId=1},
             new Product{ProductId=2,Title="VOILE CHIC Premium Jersey Hijab ",Price=250 , Description="The Voile Chic jersey hijab scarf ",Code="200v",Quantity=20,PathImage="https://m.media-amazon.com/images/I/71ijjqs2hBL._AC_SX569_.jpg",CategoryId=1},
             new Product {ProductId=3,Title="Satin Dress",Price=550,Description="OBEEII Muslim Dress for Women",Code="300d",  Quantity=5,PathImage="https://m.media-amazon.com/images/I/41bxd5WS9SL._AC_SX569_.jpg",CategoryId=3},
             new Product {ProductId=4,Title="Sleeve Maxi Dress",Price=650,Description="Abayas for Women Muslim Dress",Code="400d",   Quantity=15,PathImage="https://m.media-amazon.com/images/I/51BesB1bCIL._AC_SX569_.jpg",CategoryId=3},
             new Product {ProductId=5,Title="Long Khimar",Price=200,Description="OLEMEK Women Muslim Long Khimar ", Code="300kh",Quantity=10,PathImage="https://m.media-amazon.com/images/I/71wzUtsdv3L._AC_SX569_.jpg",CategoryId=2}

            };

            var _Categories = new List<Category>
            {
                new Category {CategoryId=1,Name="Hijab",Description="Hijab for Women Soft Cotton"},
                new Category{CategoryId=2,Name=" Khimar ",Description=" Hijab Solid Color 3 Layers Hijab"},
                new Category{CategoryId=3,Name=" Dresses",Description="Muslim prayer long dress"}

            };
           
            modelBuilder.Entity<Product>().HasData(_Products);
            modelBuilder.Entity<Category>().HasData(_Categories);
            
        } 

        public virtual DbSet<Product> Products  { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<User> users { get; set; }
    }
    }

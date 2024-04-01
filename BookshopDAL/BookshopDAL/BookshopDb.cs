using Bookshop.DAL.Entities;
using BookshopDAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Bookshop.DAL
{
    public class BookshopDb : DbContext
    {
      
        public DbSet<Book> Books { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PurchasedBook> PurchasedBooks { get; set; }

        public static BookshopDb Create()
        {
            
            return new BookshopDb();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog = BookshopDb; " +
                "Integrated Security = True; Connect Timeout = 2");
        }

    }
}
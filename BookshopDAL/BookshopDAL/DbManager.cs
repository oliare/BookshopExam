using Bookshop.DAL.Entities;
using BookshopDAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.DAL
{
    public static class DbManager
    {
        private static BookshopDb context = BookshopDb.Create();

        public static User AddUser(User user)
        {
            var newUser = context.Users.Add(user);
            context.SaveChanges();
            return newUser.Entity;
        }
<<<<<<< HEAD

        public static Book AddNewBook(Book book)
        {
            //var newBook = new Book
            //{
            //    Title = book.Title,
            //    Author = book.Author,
            //    Publisher = book.Publisher,
            //    Pages = book.Pages,
            //    Genre = book.Genre,
            //    Year = book.Year,
            //    CostPrice = book.CostPrice,
            //    SellingPrice = book.SellingPrice,
            //    IsContinuation = book.IsContinuation,
            //    Quantity = book.Quantity,
            //    DiscountId = book.DiscountId,
            //    IsReserved = book.IsReserved
            //};

            var newBook = context.Books.Add(book);
            context.SaveChanges();
            return newBook.Entity;
        }
        public static User AddNewUser(User user)
        {
            var newUser = context.Users.Add(user);
            context.SaveChanges();
            return newUser.Entity;
        }
        public static Discount AddNewDiscount(Discount discount)
        {
            var newDisc = context.Discounts.Add(discount);
            context.SaveChanges();
            return newDisc.Entity;
        }
        public static PurchasedBook AddNewPurchasedBook(PurchasedBook pb)
        {
            var newPb = context.PurchasedBooks.Add(pb);
            context.SaveChanges();
            return newPb.Entity;
        }
=======
>>>>>>> 9f6134b44aaecbd8af703c0037a0e5082d9b87a9
        public static void BuyBook(Book book, User user)
        {
            context.PurchasedBooks.Add(new PurchasedBook() { User = user, Book = book });
            book.Quantity--;
            context.SaveChanges();
        }
        public static List<Book> GetBooks()
        {
            return context.Books.OrderBy(d => d.Id).ToList();
        }
        public static List<Book> GetPurchasedBooks(User user)
        {
            return context.PurchasedBooks.Include(p => p.Book).Where(u => u.UserId == user.Id).Select(b => b.Book).ToList();
        }
        public static List<object> GetUserPurchasedBooks()
        {
            var purchasedBooks = context.PurchasedBooks
            .Include(pb => pb.User).Include(pb => pb.Book)
            .Select(pb => new { User = pb.User.Username, Book = pb.Book.Title }).ToList();

            return purchasedBooks.Cast<object>().ToList();
        }
        public static List<User> GetUsers()
        {
            return context.Users.OrderBy(u => u.Id).ToList();
        }
        public static List<Discount> GetDiscounts()
        {
            return context.Discounts.OrderBy(d => d.AmountDiscount).ToList();
        }
        public static User? GetUserByUsername(string name)
        {
            return context.Users.Where(n => n.Username == name).FirstOrDefault();
        }
        public static List<Book> GetBookByTitle(string title)
        {
            return context.Books.Where(b => b.Title == title).ToList();
        }
        public static List<Book> GetBookByAuthor(string author)
        {
            return context.Books.Where(b => b.Author == author).ToList();
        }
        public static List<Book> GetBookByGenre(string genre)
        {
            return context.Books.Where(b => b.Genre == genre).ToList();
        }
        public static List<Book> GetBookByYear(int year)
        {
            return context.Books.Where(b => b.Year.ToString()
                    .Contains(year.ToString())).ToList();
        }
        public static List<Book> GetNewReleases(int year)
        {
            return context.Books.Where(b => b.Year >= year).OrderByDescending(b => b.Year).ToList();
        }
<<<<<<< HEAD

        public static List<Book> GetPopularBooks(int number)
        {
            return context.PurchasedBooks
                    .GroupBy(pb => pb.Book)
                    .Select(g => new { Book = g.Key, SalesCount = g.Count() })
                    .OrderByDescending(g => g.SalesCount)
                    .Take(number)
                    .Select(g => g.Book)
                    .ToList();
=======
      
        public static List<Book> GetPopularBooks(int number)
        {
           return context.PurchasedBooks
                   .GroupBy(pb => pb.Book)
                   .Select(g => new { Book = g.Key, SalesCount = g.Count() })
                   .OrderByDescending(g => g.SalesCount)
                   .Take(number)
                   .Select(g => g.Book)
                   .ToList();
>>>>>>> 9f6134b44aaecbd8af703c0037a0e5082d9b87a9
        }

        public static List<Book> GetPopularGenres()
        {
            return context.PurchasedBooks.GroupBy(pb => pb.Book.Genre)
                  .Select(g => new { Genre = g.Key, BookCount = g.Count() })
                  .OrderByDescending(g => g.BookCount)
                  .SelectMany(g => context.Books.Where(b => b.Genre == g.Genre))
                  .ToList();
        }

        public static List<Book> GetPopularAuthors(int number)
        {
            return context.PurchasedBooks.GroupBy(pb => pb.Book.Author)
                    .Select(g => new { Author = g.Key, BookCount = g.Count() })
                    .OrderByDescending(g => g.BookCount)
                    .SelectMany(g => context.Books.Where(b => b.Author == g.Author))
                    .ToList();
        }


    }
}
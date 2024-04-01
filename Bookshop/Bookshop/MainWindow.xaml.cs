using Bookshop.DAL;
using Bookshop.DAL.Entities;
using Microsoft.VisualBasic.ApplicationServices;
using System.Windows;

namespace Bookshop
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new Entrance();

            // BookshopDb db = new BookshopDb();

            // DISCOUNTS +
            //db.Discounts.Add(new Discount()
            //{
            //    Description = "Black Friday Dicounts",
            //    AmountDiscount = 35,
            //    StartDate = new DateTime(2024, 10, 21),
            //    EndDate = new DateTime(2024, 10, 24),
            //    IsActive = false
            //});

            //db.Discounts.Add(new Discount()
            //{
            //    Description = "Exclusive Literary Deals",
            //    AmountDiscount = 25,
            //    StartDate = new DateTime(2024, 03, 24),
            //    EndDate = new DateTime(2024, 03, 31),
            //    IsActive = true
            //});
            //db.Discounts.Add(new Discount()
            //{
            //    Description = "Book Blitz Discounts",
            //    AmountDiscount = 15,
            //    StartDate = new DateTime(2024, 03, 28),
            //    EndDate = new DateTime(2024, 04, 10),
            //    IsActive = true

            //});
            //db.Discounts.Add(new Discount()
            //{
            //    Description = "Literary Festival of Savings",
            //    AmountDiscount = 35,
            //    StartDate = new DateTime(2024, 05, 24),
            //    EndDate = new DateTime(2024, 05, 31),
            //    IsActive = false

            //});
            //db.Discounts.Add(new Discount()
            //{
            //    Description = "Mega Book Sale",
            //    AmountDiscount = 45,
            //    StartDate = new DateTime(2024, 03, 25),
            //    EndDate = new DateTime(2024, 04, 10),
            //    IsActive = true
            //});


            // BOOKS 
            //db.Books.Add(new Book
            //{
            //    Title = "To Kill a Mockingbird",
            //    Author = "Harper Lee",
            //    Publisher = "J.B. Lippincott & Co.",
            //    Pages = 336,
            //    Genre = "Classic",
            //    Year = 1960,
            //    CostPrice = 10.30m,
            //    SellingPrice = 16.00m,
            //    IsContinuation = false,
            //    Quantity = 8,
            //    DiscountId = 2,
            //    IsReserved = false
            //});

            //db.Books.Add(new Book
            //{
            //    Title = "1984",
            //    Author = "George Orwell",
            //    Publisher = "Secker & Warburg",
            //    Pages = 328,
            //    Genre = "Dystopian",
            //    Year = 1949,
            //    CostPrice = 9.99m,
            //    SellingPrice = 14.99m,
            //    IsContinuation = false,
            //    Quantity = 6,
            //    DiscountId = 2,
            //    IsReserved = true,
            //});

            //db.Books.Add(new Book
            //{
            //    Title = "The Lord of the Rings",
            //    Author = "J.R.R. Tolkien",
            //    Publisher = "Houghton Mifflin",
            //    Pages = 1178,
            //    Genre = "Fantasy",
            //    Year = 1954,
            //    CostPrice = 20.50m,
            //    SellingPrice = 25.99m,
            //    IsContinuation = true,
            //    Quantity = 10,
            //    DiscountId = 4,
            //    IsReserved = true,
            //});

            //db.Books.Add(new Book
            //{
            //    Title = "Harry Potter and the Philosopher's Stone",
            //    Author = "J.K. Rowling",
            //    Publisher = "Bloomsbury",
            //    Pages = 223,
            //    Genre = "Fantasy",
            //    Year = 1997,
            //    CostPrice = 15.75m,
            //    SellingPrice = 19.99m,
            //    IsContinuation = true,
            //    Quantity = 12,
            //    DiscountId = 3,
            //    IsReserved = true,
            //});

            //db.Books.Add(new Book
            //{
            //    Title = "The Great Gatsby",
            //    Author = "F. Scott Fitzgerald",
            //    Publisher = "Scribner",
            //    Pages = 180,
            //    Genre = "Novel",
            //    Year = 1925,
            //    CostPrice = 9.99m,
            //    SellingPrice = 13.50m,
            //    IsContinuation = false,
            //    DiscountId = 5,
            //    Quantity = 12,
            //    IsReserved = true,
            //});

            //db.Books.Add(new Book
            //{
            //    Title = "Pride and Prejudice",
            //    Author = "Jane Austen",
            //    Publisher = "Wordsworth Classics",
            //    Pages = 352,
            //    Genre = "Novel",
            //    Year = 1813,
            //    CostPrice = 11.25m,
            //    SellingPrice = 15.49m,
            //    IsContinuation = false,
            //    Quantity = 15,
            //    DiscountId = 3,
            //    IsReserved = true,
            //});

            //var b7 = new Book
            //{
            //    Title = "The Catcher in the Rye",
            //    Author = "J.D. Salinger",
            //    Publisher = "Little, Brown and Company",
            //    Pages = 224,
            //    Genre = "Novel",
            //    Year = 1951,
            //    CostPrice = 13.50m,
            //    SellingPrice = 17.99m,
            //    IsContinuation = false,
            //    Quantity = 7,
            //    IsReserved = true,
            //};
            //db.Books.Add(b7);


            //db.SaveChanges();

        }
    }
}
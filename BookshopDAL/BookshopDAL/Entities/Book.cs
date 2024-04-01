using BookshopDAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bookshop.DAL.Entities
{
    public class Book
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Title { get; set; }
        [Required, MaxLength(100)]
        public string Author { get; set; }
        [Required, MaxLength(100)]
        public string Publisher { get; set; }
        [Required]
        public int Pages { get; set; }
        [Required, MaxLength(50)]
        public string Genre { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public decimal CostPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public bool IsContinuation { get; set; }
        [Required]
        public int Quantity { get; set; }
        public int? DiscountId { get; set; }
        public Discount Discount { get; set; }
        public bool IsReserved { get; set; }
        public ICollection<PurchasedBook> PurchasedBooks { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bookshop.DAL.Entities
{
    public class Discount
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        [Required]
        [Range(0, 100)]
        public uint AmountDiscount { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public ICollection<Book> Books { get; set; }

    }

}
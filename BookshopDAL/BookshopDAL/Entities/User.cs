using BookshopDAL.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookshop.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [MaxLength(13)]
        public string Phone { get; set; }
        [Required]
        public string Password { get; set; }
        public ICollection<PurchasedBook> PurchasedBooks { get; set; }

    }
}
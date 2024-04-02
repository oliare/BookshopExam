using Bookshop.DAL;
using Bookshop.DAL.Entities;
using BookshopDAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using User = Bookshop.DAL.Entities.User;

namespace Bookshop
{
    public partial class EditPage : Page
    {
        private static BookshopDb context = BookshopDb.Create();
<<<<<<< HEAD
=======
        private string _table;
>>>>>>> 9f6134b44aaecbd8af703c0037a0e5082d9b87a9
        private static User User { get; set; }
        private static Book Book { get; set; }
        public EditPage(User? user)
        {
            if (user != null)
                User = user;
            InitializeComponent();
            grid.HeadersVisibility = DataGridHeadersVisibility.Row;
        }
        public EditPage(Book? book)
        {
            if (book != null)
                Book = book;
            InitializeComponent();
            grid.HeadersVisibility = DataGridHeadersVisibility.Row;
        }
        private void viewBookshop_Click(object sender, RoutedEventArgs e)
        {
            grid.HeadersVisibility = DataGridHeadersVisibility.All;
            grid.ItemsSource = DbManager.GetBooks();
<<<<<<< HEAD
            mode = EditMode.Books;
=======
            mode = DeleteMode.Books;
>>>>>>> 9f6134b44aaecbd8af703c0037a0e5082d9b87a9
        }
        private void viewUsers_Click(object sender, RoutedEventArgs e)
        {
            grid.HeadersVisibility = DataGridHeadersVisibility.All;
            grid.ItemsSource = DbManager.GetUsers();
<<<<<<< HEAD
            mode = EditMode.Users;
=======
>>>>>>> 9f6134b44aaecbd8af703c0037a0e5082d9b87a9
        }
        private void viewDiscounts_Click(object sender, RoutedEventArgs e)
        {
            grid.HeadersVisibility = DataGridHeadersVisibility.All;
            grid.ItemsSource = DbManager.GetDiscounts();
<<<<<<< HEAD
            mode = EditMode.Discounts;
=======
>>>>>>> 9f6134b44aaecbd8af703c0037a0e5082d9b87a9
        }
        private void viewPurchasedBooks_Click(object sender, RoutedEventArgs e)
        {
            grid.HeadersVisibility = DataGridHeadersVisibility.All;
            grid.ItemsSource = DbManager.GetUserPurchasedBooks();
<<<<<<< HEAD
            mode = EditMode.PurchasedBooks;
        }
        private void back_Click(object sender, RoutedEventArgs e)
        {
            var hasChanges = context.ChangeTracker.HasChanges();
            if (hasChanges)
=======
        }
        private void back_Click(object sender, RoutedEventArgs e)
        {
            var selectedItems = grid.SelectedItems;
            
            var hasChanges = context.ChangeTracker.HasChanges();
            if (hasChanges != null)
>>>>>>> 9f6134b44aaecbd8af703c0037a0e5082d9b87a9
            {
                MessageBoxResult result = MessageBox.Show("Save changes before leaving this page?", "Confirmation", MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Cancel)
                {
                    return;
                }
                else if (result == MessageBoxResult.Yes)
                {
                    context.SaveChanges();
<<<<<<< HEAD
                    MessageBox.Show("Changes saved successfully!");
=======
                    MessageBox.Show("Changes saved successfully");
>>>>>>> 9f6134b44aaecbd8af703c0037a0e5082d9b87a9
                }
            }
            NavigationService.Navigate(new AdminPage(null));
        }
<<<<<<< HEAD
        public enum EditMode
=======
        public enum DeleteMode
>>>>>>> 9f6134b44aaecbd8af703c0037a0e5082d9b87a9
        {
            None,
            Books,
            Discounts,
            Users,
            PurchasedBooks
        }
<<<<<<< HEAD
        private EditMode mode = EditMode.None;

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            switch (mode)
            {
                case EditMode.Books:
                    var booksToDelete = grid.SelectedItems.OfType<Book>().ToList();
                    context.Books.RemoveRange(booksToDelete);
                    break;
                case EditMode.Discounts:
                    var discountsToDelete = grid.SelectedItems.OfType<Discount>().ToList();
                    context.Discounts.RemoveRange(discountsToDelete);
                    break;
                case EditMode.Users:
                    var usersToDelete = grid.SelectedItems.OfType<User>().ToList();
                    context.Users.RemoveRange(usersToDelete);
                    break;
                case EditMode.PurchasedBooks:
                    var purchasedBooksToDelete = grid.SelectedItems.OfType<PurchasedBook>().ToList();
                    context.PurchasedBooks.RemoveRange(purchasedBooksToDelete);
                    break;
                default:
                    MessageBox.Show("Please select an edit mode");
                    return;
            }

            MessageBox.Show("Deletion is successful!");
            context.SaveChanges();
        }
        private void add_Click(object sender, RoutedEventArgs e)
        {
            grid.ItemsSource = null;
            switch (mode)
            {
                case EditMode.Books:
                    var book = new Book();
                    grid.Items.Add(book);
                    DbManager.AddNewBook(book);
                    break;
                case EditMode.Discounts:
                    var disc = new Discount();
                    grid.Items.Add(disc);
                    DbManager.AddNewDiscount(disc);
                    break;
                case EditMode.Users:
                    var user = new User();
                    grid.Items.Add(user);
                    DbManager.AddNewUser(user); 
                    break;
                case EditMode.PurchasedBooks:
                    var pb = new PurchasedBook();
                    grid.Items.Add(pb);
                    DbManager.AddNewPurchasedBook(pb); 
                    break;
                default:
                    MessageBox.Show("Please select an edit mode");
                    return;
            }

            MessageBox.Show("New item added successfully!");
        }
=======
        private DeleteMode mode = DeleteMode.None;

        private void delete_Click(object sender, RoutedEventArgs e)
        { 
            MessageBox.Show("Deletion is successful");
            context.SaveChanges();
        }
>>>>>>> 9f6134b44aaecbd8af703c0037a0e5082d9b87a9

        private void saveChanges_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var hasChanges = context.ChangeTracker.HasChanges();
<<<<<<< HEAD
                if (hasChanges)
=======
                if (hasChanges != null)
>>>>>>> 9f6134b44aaecbd8af703c0037a0e5082d9b87a9
                {
                    context.SaveChanges();
                    MessageBox.Show("Changes saved successfully");
                    return;
                }
                else
                {
                    MessageBox.Show("No changes were made");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving changes: {ex.Message}");
            }
        }

        private void grid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            switch (mode)
            {
<<<<<<< HEAD
                case EditMode.Books:
                    var books = grid.SelectedItems.OfType<Book>().ToList();
                    context.Books.UpdateRange(books);
                    break;
                case EditMode.Discounts:
                    var discounts = grid.SelectedItems.OfType<Discount>().ToList();
                    context.Discounts.UpdateRange(discounts);
                    break;
                case EditMode.Users:
                    var users = grid.SelectedItems.OfType<User>().ToList();
                    context.Users.UpdateRange(users);
                    break;
                case EditMode.PurchasedBooks:
                    var purchasedBooks = grid.SelectedItems.OfType<PurchasedBook>().ToList();
                    context.PurchasedBooks.UpdateRange(purchasedBooks);
=======
                case DeleteMode.Books:
                    var books = grid.SelectedItems.OfType<Book>().ToList();
                    context.Books.UpdateRange(books);
                    break;
                case DeleteMode.Discounts:
                    var discounts = grid.SelectedItems.OfType<Discount>().ToList();
                    context.Discounts.RemoveRange(discounts);
                    break;
                case DeleteMode.Users:
                    var users = grid.SelectedItems.OfType<User>().ToList();
                    context.Users.RemoveRange(users);
                    break;
                case DeleteMode.PurchasedBooks:
                    var purchasedBooks = grid.SelectedItems.OfType<PurchasedBook>().ToList();
                    context.PurchasedBooks.RemoveRange(purchasedBooks);
>>>>>>> 9f6134b44aaecbd8af703c0037a0e5082d9b87a9
                    break;
                default:
                    MessageBox.Show("Please select a delete mode");
                    return;
            }
<<<<<<< HEAD
=======


>>>>>>> 9f6134b44aaecbd8af703c0037a0e5082d9b87a9
        }
    }
}

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
        private string _table;
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
            mode = DeleteMode.Books;
        }
        private void viewUsers_Click(object sender, RoutedEventArgs e)
        {
            grid.HeadersVisibility = DataGridHeadersVisibility.All;
            grid.ItemsSource = DbManager.GetUsers();
        }
        private void viewDiscounts_Click(object sender, RoutedEventArgs e)
        {
            grid.HeadersVisibility = DataGridHeadersVisibility.All;
            grid.ItemsSource = DbManager.GetDiscounts();
        }
        private void viewPurchasedBooks_Click(object sender, RoutedEventArgs e)
        {
            grid.HeadersVisibility = DataGridHeadersVisibility.All;
            grid.ItemsSource = DbManager.GetUserPurchasedBooks();
        }
        private void back_Click(object sender, RoutedEventArgs e)
        {
            var selectedItems = grid.SelectedItems;
            
            var hasChanges = context.ChangeTracker.HasChanges();
            if (hasChanges != null)
            {
                MessageBoxResult result = MessageBox.Show("Save changes before leaving this page?", "Confirmation", MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Cancel)
                {
                    return;
                }
                else if (result == MessageBoxResult.Yes)
                {
                    context.SaveChanges();
                    MessageBox.Show("Changes saved successfully");
                }
            }
            NavigationService.Navigate(new AdminPage(null));
        }
        public enum DeleteMode
        {
            None,
            Books,
            Discounts,
            Users,
            PurchasedBooks
        }
        private DeleteMode mode = DeleteMode.None;

        private void delete_Click(object sender, RoutedEventArgs e)
        { 
            MessageBox.Show("Deletion is successful");
            context.SaveChanges();
        }

        private void saveChanges_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var hasChanges = context.ChangeTracker.HasChanges();
                if (hasChanges != null)
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
                    break;
                default:
                    MessageBox.Show("Please select a delete mode");
                    return;
            }


        }
    }
}

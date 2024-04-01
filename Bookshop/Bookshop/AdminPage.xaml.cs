using Bookshop.DAL.Entities;
using Bookshop.DAL;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Bookshop
{
    public partial class AdminPage : Page
    {
        private static User User { get; set; }
        public AdminPage(User? user)
        {
            if (user != null)
                User = user;

            InitializeComponent();
            grid.HeadersVisibility = DataGridHeadersVisibility.Row;
            grid.IsReadOnly = true;
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Entrance());
        }
        private void edit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditPage(User));
        }
        private void viewBookshop_Click(object sender, RoutedEventArgs e)
        {
            grid.HeadersVisibility = DataGridHeadersVisibility.All;
            grid.ItemsSource = DbManager.GetBooks();
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
        private void NewReleases_Click(object sender, RoutedEventArgs e)
        {
            grid.HeadersVisibility = DataGridHeadersVisibility.All;
            grid.ItemsSource = DbManager.GetNewReleases(-1);
        }

        private void PopularBooks_Click(object sender, RoutedEventArgs e)
        {
            grid.HeadersVisibility = DataGridHeadersVisibility.All;
            grid.ItemsSource = DbManager.GetPopularBooks(5);
        }

        private void PopularAuthors_Click(object sender, RoutedEventArgs e)
        {
            grid.HeadersVisibility = DataGridHeadersVisibility.All;
            grid.ItemsSource = DbManager.GetPopularAuthors(5);
        }

        private void PopularGenres_Click(object sender, RoutedEventArgs e)
        {
            grid.HeadersVisibility = DataGridHeadersVisibility.All;
            grid.ItemsSource = DbManager.GetPopularGenres();
        }

        private void searchUser_Click(object sender, RoutedEventArgs e)
        {
            grid.HeadersVisibility = DataGridHeadersVisibility.All;
            string textbox = searchTextBox.Text;

            if (string.IsNullOrWhiteSpace(textbox))
            {
                MessageBox.Show($"Please enter username");
                return;
            }

            var user = DbManager.GetUserByUsername(textbox);
            if (user != null)
            {
                grid.ItemsSource = new List<User> { user };
            }
            else
            {
                MessageBox.Show($"User '{textbox}' not found");
            }
        }

    }
}

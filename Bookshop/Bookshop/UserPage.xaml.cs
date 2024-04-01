using Bookshop.DAL;
using Bookshop.DAL.Entities;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Navigation;
using MessageBox = System.Windows.MessageBox;

namespace Bookshop
{

    public partial class UserPage : Page
    {
        private User User { get; set; }
        public UserPage(User user)
        {
            User = user;
            InitializeComponent();
            userName.Content = user.Username;
            grid.IsReadOnly = true;
            grid.HeadersVisibility = DataGridHeadersVisibility.Row;
        }
        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            grid.HeadersVisibility = DataGridHeadersVisibility.All;
            string textbox = searchTextBox.Text;
            string item = searchTypeComboBox.Text;

            if (string.IsNullOrWhiteSpace(item))
            {
                MessageBox.Show($"Please select search option");
                return;
            }
            if (string.IsNullOrWhiteSpace(textbox))
            {
                return;
            }

            try
            {
                switch (item)
                {
                    case "Title":
                        grid.ItemsSource = DbManager.GetBookByTitle(textbox);
                        break;
                    case "Author":
                        grid.ItemsSource = DbManager.GetBookByAuthor(textbox);
                        break;
                    case "Genre":
                        grid.ItemsSource = DbManager.GetBookByGenre(textbox);
                        break;
                    case "Year":
                        if (int.TryParse(textbox, out int _year))
                        {
                            grid.ItemsSource = DbManager.GetBookByYear(_year);
                        }
                        else
                        {
                            MessageBox.Show("Invalid year format");
                            return;
                        }
                        break;
                    default:
                        MessageBox.Show("Invalid search type ");
                        return;
                }
            }
            catch
            {
                MessageBox.Show("Invalid data format");
            }
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Entrance());
        }
        private void viewBookshop_Click(object sender, RoutedEventArgs e)
        {
            grid.HeadersVisibility = DataGridHeadersVisibility.All;
            grid.ItemsSource = DbManager.GetBooks();
        }
        private void NewReleases_Click(object sender, RoutedEventArgs e)
        {
            grid.ItemsSource = DbManager.GetNewReleases(-1);
        }

        private void PopularBooks_Click(object sender, RoutedEventArgs e)
        {
            grid.ItemsSource = DbManager.GetPopularBooks(5);
        }

        private void PopularAuthors_Click(object sender, RoutedEventArgs e)
        {
            grid.ItemsSource = DbManager.GetPopularAuthors(5);
        }

        private void PopularGenres_Click(object sender, RoutedEventArgs e)
        {
            grid.ItemsSource = DbManager.GetPopularGenres();
        }

        private void viewMyBooks_Click(object sender, RoutedEventArgs e)
        {
            grid.ItemsSource = DbManager.GetPurchasedBooks(User);
        }

        private void BooksDataGrid_PreviewMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Right)
            {
                var row = sender as DataGridRow;
                var selectedBook = row?.Item as Book;

                if (selectedBook != null)
                {
                    MessageBoxResult result = MessageBox.Show($"Do you want to buy '{selectedBook.Title}'?", "Confirmation of purchase", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        if (selectedBook.Quantity != 0)
                        {
                            var user = DbManager.GetUserByUsername(User.Username);
                            if (user != null)
                            {
                                DbManager.BuyBook(selectedBook, user);
                                MessageBox.Show($"The '{selectedBook.Title}' is purchased! \n(more details in the 'My books' section)");
                            }
                            else
                            {
                                MessageBox.Show("Unable to find customer information");
                            }
                        }
                        else
                        {
                            MessageBox.Show($"It is impossible to buy '{selectedBook.Title}' because it is not available");
                        }
                    }
                }
            }
        }

        private void searchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            searchButton_Click(sender, e);
        }
    }

}


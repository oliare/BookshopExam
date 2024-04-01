using Bookshop.DAL;
using Microsoft.VisualBasic.ApplicationServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Bookshop
{

    public partial class SignIn : Page
    {
        private static BookshopDb context = BookshopDb.Create();
        public SignIn()
        {
            InitializeComponent();
        }

        private void passwordVisibility_Click(object sender, RoutedEventArgs e)
        {

            if (passwordCheckBox.IsChecked == true)
            {
                passwordBox.Visibility = Visibility.Collapsed;
                textBox.Visibility = Visibility.Visible;
                textBox.Text = passwordBox.Password;
                passwordCheckBox.Content = "hide";
            }
            else
            {
                passwordBox.Visibility = Visibility.Visible;
                textBox.Visibility = Visibility.Collapsed;
                passwordCheckBox.Content = "show";
            }
        }

        private void goBack_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string username = usernameBox.Text;
                string password = PasswordHasher.HashPassword(passwordBox.Password);
                
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("All fields must be filled");
                    return;
                }

                var admin = context.Users.FirstOrDefault(u => u.Username == "admin" && u.Password == "UBL1GCBhxG5XhZz2FxKMb3Dt37pNsndyve3loDn6cIU=");
                var user = context.Users.FirstOrDefault(u => u.Username == username && u.Password == password && u.Username != "admin");

                if (admin != null && username == "admin" && password == "UBL1GCBhxG5XhZz2FxKMb3Dt37pNsndyve3loDn6cIU=")
                {
                    NavigationService.Navigate(new AdminPage(admin));
                }
                else if (user != null)
                {
                    NavigationService.Navigate(new UserPage(user));
                }
                else
                {
                    MessageBox.Show("Username or password is incorrect");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }

}

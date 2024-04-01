using Bookshop.DAL;
using Bookshop.DAL.Entities;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;


namespace Bookshop
{

    public partial class SignUp : Page
    {
        private static BookshopDb context = BookshopDb.Create();
        public SignUp()
        {
            InitializeComponent();
        }
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }
        private void ConfirmRegistr_Click(object sender, RoutedEventArgs e)
        {
            VerificationOfLoginData();
            var existingUser = context.Users.FirstOrDefault(u => u.Username == usernameBox.Text);
            if (existingUser != null)
            {
                MessageBox.Show("This username is already taken. Please choose another one");
                return;
            }
            string hashed = PasswordHasher.HashPassword(passwordBox.Password); 
           
            var newUser = DbManager.AddUser(new User
            {
                FirstName = firstNameBox.Text,
                LastName = lastNameBox.Text,
                Username = usernameBox.Text,
                Password = hashed,
                Phone = phoneBox.Text,
                Email = emailBox.Text,
            });

            MessageBox.Show("Registration successful!!!");

            NavigationService.Navigate(new UserPage(newUser));
        }
      
        private void VerificationOfLoginData()
        {
            var existingUser = context.Users.FirstOrDefault(u => u.Username == usernameBox.Text);
            if (existingUser != null)
            {
                return;
            }
            Dictionary<string, string> fields = new Dictionary<string, string>
            {
                { "first name", firstNameBox.Text },
                { "last name", lastNameBox.Text },
                { "username", usernameBox.Text },
                { "password", passwordBox.Password },
                { "confirm password", passwordCheckBox.Password },
                { "email", emailBox.Text },
                { "phone", phoneBox.Text }
            };

            foreach (var field in fields)
            {
                if (string.IsNullOrWhiteSpace(field.Value))
                {
                    MessageBox.Show($"* \"{field.Key}\" field is empty, please fill it in");
                    return;
                }
            }

            if (passwordBox.Password.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long");
                return;
            }

            if (passwordBox.Password != passwordCheckBox.Password)
            {
                MessageBox.Show("Passwords don`t match");
                return;
            }

            if (phoneBox.Text.Length != 13)
            {
                MessageBox.Show("Phone number must be 13 characters long");
                return;
            }

            if (!emailBox.Text.Contains("@"))
            {
                MessageBox.Show("Email address is invalid");
            }
        }


    }
}

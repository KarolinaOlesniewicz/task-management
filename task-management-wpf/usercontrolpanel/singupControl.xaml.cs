using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;

namespace task_management_wpf.usercontrolpanel
{
    public partial class singupControl : UserControl
    {
        public singupControl()
        {
            InitializeComponent();
        }

        // Metoda uruchamiana po kliknięciu na "Sign Up" (rejestracja)
        private async void SinUp_Click(object sender, RoutedEventArgs e)
        {
            var firstName = txtName.Text;
            var lastName = txtLastName.Text;
            var username = txtusername.Text;
            var email = txtEmail.Text;
            var password = txtpassw.Password;
            var confirmPassword = txtRepPassw.Password;

            // Prosta walidacja
            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            // Wywołanie funkcji rejestracji
            var result = await RegisterAsync(firstName, lastName, username, email, password);

            if (result)
            {
                MessageBox.Show("Registration successful!");
                // Tu możesz przekierować użytkownika do innej części aplikacji
            }
            else
            {
                MessageBox.Show("Registration failed. Please try again.");
            }
        }

        // Metoda wysyłająca dane rejestracyjne do API
        private async Task<bool> RegisterAsync(string firstName, string lastName, string username, string email, string password)
        {
            using (var client = new HttpClient())
            {
                var url = "http://localhost:5079/api/register";  // Podaj URL swojego API

                var requestData = new
                {
                    firstName = firstName,
                    lastName = lastName,
                    username = username,
                    email = email,
                    password = password
                };

                var jsonContent = JsonConvert.SerializeObject(requestData);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(url, content);

                return response.IsSuccessStatusCode;
            }
        }

        // Metody obsługujące Placeholdery (analogicznie do tych w loginie)
        private void txtName_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            txtNamePlaceholder.Visibility = string.IsNullOrWhiteSpace(txtName.Text) ? Visibility.Visible : Visibility.Hidden;
        }

        private void txtLastName_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            txtLastNamePlaceholder.Visibility = string.IsNullOrWhiteSpace(txtLastName.Text) ? Visibility.Visible : Visibility.Hidden;
        }

        private void txtusername_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            txtusernamePlaceholder.Visibility = string.IsNullOrWhiteSpace(txtusername.Text) ? Visibility.Visible : Visibility.Hidden;
        }

        private void txtEmail_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            txtEmailPlaceholder.Visibility = string.IsNullOrWhiteSpace(txtEmail.Text) ? Visibility.Visible : Visibility.Hidden;
        }

        private void passwChanged(object sender, RoutedEventArgs e)
        {
            txtpasswPlaceholder.Visibility = string.IsNullOrWhiteSpace(txtpassw.Password) ? Visibility.Visible : Visibility.Hidden;
        }

        private void passwRepChanged(object sender, RoutedEventArgs e)
        {
            txtpasswRepPlaceholder.Visibility = string.IsNullOrWhiteSpace(txtRepPassw.Password) ? Visibility.Visible : Visibility.Hidden;
        }

        // Przejście do okna logowania
        private void ToLogIn_Click(object sender, RoutedEventArgs e)
        {
            // Tworzenie instancji okna logowania
            LogInWindow logInWindow = new LogInWindow();

            // Wyświetlenie okna logowania
            logInWindow.Show();

        }
    }
}

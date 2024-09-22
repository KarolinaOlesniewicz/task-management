using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using task_management_wpf.usercontrolpanel; // Import przestrzeni nazw dla kontrolki rejestracji

namespace task_management_wpf
{
    public partial class LogInWindow : Window
    {
        public LogInWindow()
        {
            InitializeComponent();
          
        }

        private async void LogIn_Click(object sender, RoutedEventArgs e)
        {
            var email = txtusername.Text; // Pobranie wartości z pola tekstowego username
            var password = txtpassw.Password; // Pobranie wartości z PasswordBox

            var result = await LogInAsync(email, password);
            if (result)
            {
                MessageBox.Show("Login successful!");
               
            }
            else
            {
                MessageBox.Show("Invalid credentials, please try again.");
            }
        }

        private async Task<bool> LogInAsync(string email, string password)
        {
            using (var client = new HttpClient())
            {
                var url = "http://localhost:5079/api/login";
                var requestData = new { email, password };
                var jsonContent = JsonConvert.SerializeObject(requestData);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(url, content);
                return response.IsSuccessStatusCode;
            }
        }

        private void txtusername_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            txtusernamePlaceholder.Visibility = string.IsNullOrWhiteSpace(txtusername.Text) ? Visibility.Visible : Visibility.Hidden;
        }

        private void passwChanged(object sender, RoutedEventArgs e)
        {
            txtpasswPlaceholder.Visibility = string.IsNullOrWhiteSpace(txtpassw.Password) ? Visibility.Visible : Visibility.Hidden;
        }

        private void SignUp_click(object sender, RoutedEventArgs e)
        {
            // Ustawienie kontrolki rejestracji jako zawartość
            MainContent.Content = new usercontrolpanel.singupControl();
        }

        private void MinimalizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void MaximalizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = this.WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ButtonState == System.Windows.Input.MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}

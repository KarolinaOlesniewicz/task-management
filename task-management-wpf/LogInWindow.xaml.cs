using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using task_management_wpf.dtos;
using task_management_wpf.usercontrolpanel;

namespace task_management_wpf
{
    /// <summary>
    /// Interaction logic for LogInWindow.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {
        public LogInWindow()
        {
            InitializeComponent();

        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private void MinimalizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void MaximalizeButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState != WindowState.Maximized)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void txtusername_TextChanged(Object sender, TextChangedEventArgs e)

        {

            if (txtusername.Text != "")
            {

                txtusernamePlaceholder.Visibility = Visibility.Hidden;

            }
            else
            {

                txtusernamePlaceholder.Visibility = Visibility.Visible;

            }

        }

        private void passwChanged(object sender, RoutedEventArgs e)
        {
            if (txtpassw.Password.Length != 0)
            {

                txtpasswPlaceholder.Visibility= Visibility.Hidden;

            }
            else
            {

                txtpasswPlaceholder.Visibility = Visibility.Visible;

            }
        }

        private async void LogIn(string username,string password)
        {
            string baseAddress = "http://localhost:5079";
            string endpoint = "api/user/login";

            LogInDto dto = new LogInDto(username, password);

            var json = JsonConvert.SerializeObject(dto);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                try
                {          
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response =  await client.PostAsync(endpoint, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MainGrid.Children.Clear();
                    }else
                    {
                        MessageBox.Show("1");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            if(txtpassw.Password.Length != 0 && txtusername.Text.Length != 0) {
                LogIn(txtusername.Text,txtpassw.Password);
            }
        }

        private void SignUp_click(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Clear();
            MainGrid.Children.Add(new singupControl(this));
        }
    }
}

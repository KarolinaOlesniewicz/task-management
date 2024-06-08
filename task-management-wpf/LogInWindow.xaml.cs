using System;
using System.Collections.Generic;
using System.Linq;
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

        private void txtemail_TextChanged(Object sender, TextChangedEventArgs e)

        {

            if (txtemail.Text != "")
            {

                txtemailPlaceholder.Visibility = Visibility.Hidden;

            }
            else
            {

                txtemailPlaceholder.Visibility = Visibility.Visible;

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
    }
}

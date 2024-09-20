using System.Windows.Controls;
using System.Windows;

namespace task_management_wpf.usercontrolpanel
{
    public partial class UsersProfile : UserControl
    {
        public UsersProfile()
        {
            InitializeComponent();
        }

        // Event handler for EditName_Click
        private void EditName_Click(object sender, RoutedEventArgs e)
        {
            txtName.IsReadOnly = false;   // Enable editing for the name field
            txtName.Focus();              // Set focus to the name TextBox
        }

        // Event handler for EditEmail_Click
        private void EditEmail_Click(object sender, RoutedEventArgs e)
        {
            txtEmail.IsReadOnly = false;  // Enable editing for the email field
            txtEmail.Focus();             // Set focus to the email TextBox
        }

        // Event handler for EditPassword_Click
        private void EditPassword_Click(object sender, RoutedEventArgs e)
        {
            txtPassword.IsEnabled = true; // Enable editing for the password field
            txtPassword.Focus();          // Set focus to the PasswordBox
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Create a new instance of the Menu
            var menu = new Menu(); // Use the correct name for your menu class
            menu.Show(); // Show the menu

            // Close the current window or user control (if needed)
            var currentWindow = Window.GetWindow(this);
            if (currentWindow != null)
            {
                currentWindow.Close(); // Close the current window
            }
        }
    }
}

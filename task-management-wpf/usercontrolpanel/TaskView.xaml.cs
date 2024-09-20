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

namespace task_management_wpf.usercontrolpanel
{
    /// <summary>
    /// Interaction logic for TaskView.xaml
    /// </summary>
    public partial class TaskView : Window
    {
        public TaskView()
        {
            InitializeComponent();
        }

        private void BackToMenu_Click(object sender, RoutedEventArgs e)
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

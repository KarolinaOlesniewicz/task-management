using System.Windows;
using task_management_wpf.usercontrolpanel;  // Import the correct namespace

namespace task_management_wpf.usercontrolpanel
{
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

        // Event handler to open AssignTaskView window
        private void OpenAssignTaskView_Click(object sender, RoutedEventArgs e)
        {
            AssignTaskView assignTaskView = new AssignTaskView();
            assignTaskView.Show();
            this.Close(); // Close the Menu window
        }

        // Event handler to open UsersProfile inside a new window
        private void OpenUserProfileView_Click(object sender, RoutedEventArgs e)
        {
            // Create a new window to host the UsersProfile user control
            Window userProfileWindow = new Window
            {
                Title = "User Profile",
                Content = new UsersProfile(),  // Embed UsersProfile UserControl
                Height = 600,
                Width = 800
            };
            userProfileWindow.Show();
            this.Close(); // Close the Menu window
        }

        // Event handler to open TaskView window
        private void OpenTaskView_Click(object sender, RoutedEventArgs e)
        {
            TaskView taskView = new TaskView();
            taskView.Show();
            this.Close(); // Close the Menu window
        }
    }
}

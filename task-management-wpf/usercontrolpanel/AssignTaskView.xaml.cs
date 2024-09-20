using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace task_management_wpf.usercontrolpanel
{
    public partial class AssignTaskView : Window
    {
        public AssignTaskView()
        {
            InitializeComponent();
        }

        private void BackToMenu_Click(object sender, RoutedEventArgs e)
        {
            var menu = new Menu();
            menu.Show();
            this.Close();
        }

        private void AssignTask_Click(object sender, RoutedEventArgs e)
        {
            // Gather data from the input fields
            string taskTitle = TaskTitleTextBox.Text;
            string assignedTo = (AssignToComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            string priority = (TaskPriorityComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            DateTime dueDate = DueDatePicker.SelectedDate ?? DateTime.Now;
            string description = DescriptionTextBox.Text;

            // Prepare the data to be saved
            string taskDetails = $"Title: {taskTitle}\nAssigned To: {assignedTo}\nPriority: {priority}\nDue Date: {dueDate.ToShortDateString()}\nDescription: {description}\n";

            // Define the file path
            string folderPath = Path.Combine(Environment.CurrentDirectory, "Tasks");
            Directory.CreateDirectory(folderPath); // Create folder if it doesn't exist
            string filePath = Path.Combine(folderPath, $"{taskTitle}.txt");

            // Save the task details to a file
            File.WriteAllText(filePath, taskDetails);

            // Optionally show a message
            MessageBox.Show("Task has been saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            // Clear the form or implement further logic as needed
        }

        private void ResetForm_Click(object sender, RoutedEventArgs e)
        {
            // Clear all input fields
            TaskTitleTextBox.Clear();
            AssignToComboBox.SelectedIndex = -1;
            TaskPriorityComboBox.SelectedIndex = -1;
            DueDatePicker.SelectedDate = null;
            DescriptionTextBox.Clear();
        }
    }
}

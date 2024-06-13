using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace task_management_wpf
{
    /// <summary>
    /// Logika interakcji dla klasy TaskColumnControl.xaml
    /// </summary>
    public partial class TaskColumnControl : UserControl
    {
        public static readonly DependencyProperty ColumnTitleProperty =
        DependencyProperty.Register("ColumnTitle", typeof(string), typeof(TaskColumnControl), new PropertyMetadata("TaskName"));

        public static readonly DependencyProperty TasksProperty =
            DependencyProperty.Register("Tasks", typeof(ObservableCollection<string>), typeof(TaskColumnControl), new PropertyMetadata(new ObservableCollection<string>()));

        public string ColumnTitle
        {
            get { return (string)GetValue(ColumnTitleProperty); }
            set { SetValue(ColumnTitleProperty, value); }
        }

        public ObservableCollection<string> Tasks
        {
            get { return (ObservableCollection<string>)GetValue(TasksProperty); }
            set { SetValue(TasksProperty, value); }
        }

        public TaskColumnControl()
        {
            InitializeComponent();
            DataContext = this;  // Ensure DataContext is set to the control itself
        }

        private void AddNewTask_Click(object sender, RoutedEventArgs e)
        {
            Tasks.Add("New Task");
        }
    }
}

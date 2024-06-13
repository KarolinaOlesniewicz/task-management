using System.Collections.ObjectModel;
using System.Text;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<string> TaskList1 { get; set; }
        public ObservableCollection<string> TaskList2 { get; set; }
        public ObservableCollection<string> TaskList3 { get; set; }
        public ObservableCollection<string> TaskList4 { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            // Initialize the task lists with sample data
            TaskList1 = new ObservableCollection<string> { "Task1", "Task2" };
            TaskList2 = new ObservableCollection<string> { "Task3", "Task4" };
            TaskList3 = new ObservableCollection<string> { "Task5", "Task6" };
            TaskList4 = new ObservableCollection<string> { "Task7", "Task8" };

            // Set the DataContext to this instance of MainWindow
            DataContext = this;
        }
    }
}
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace task_management_wpf
{
    /// <summary>
    /// Logika interakcji dla klasy TaskControl.xaml
    /// </summary>
    public partial class TaskControl : UserControl
    {
        public TaskControl()
        {
            InitializeComponent();
            TaskNameTextBlock.Text = TaskName;
        }

        public static readonly DependencyProperty TaskNameProperty =
        DependencyProperty.Register("TaskName", typeof(string), typeof(TaskControl), new PropertyMetadata("Task"));

        public string TaskName
        {
            get { return (string)GetValue(TaskNameProperty); }
            set { SetValue(TaskNameProperty, value); }
        }
    }
}

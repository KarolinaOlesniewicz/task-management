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
	/// Logika interakcji dla klasy LoginPage.xaml
	/// </summary>
	public partial class LoginPage : Window
	{
		public LoginPage()
		{
			InitializeComponent();
		}
		private void SignInButton_Click(object sender, RoutedEventArgs e)
		{
			// Utworzenie i otwarcie nowego okna (RegistrationWindow)
			RegistrationWindow registrationWindow = new RegistrationWindow();
			registrationWindow.Show();
			// Zamknięcie bieżącego okna (LoginWindow)
			this.Close();
		}
	}
}

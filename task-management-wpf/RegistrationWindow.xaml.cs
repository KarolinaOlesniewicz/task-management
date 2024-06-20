﻿using System;
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
	/// Logika interakcji dla klasy RegistrationWindow.xaml
	/// </summary>
	public partial class RegistrationWindow : Window
	{
		public RegistrationWindow()
		{
			InitializeComponent();
		}
		private void BackButton_Click(object sender, RoutedEventArgs e)
		{
			// Utworzenie i otwarcie nowego okna (RegistrationWindow)
			LoginPage loginPage = new LoginPage();
			loginPage.Show();
			// Zamknięcie bieżącego okna (LoginWindow)
			this.Close();
		}
	}
}

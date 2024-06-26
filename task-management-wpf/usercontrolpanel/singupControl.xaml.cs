using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
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
using task_management_wpf.dtos;

namespace task_management_wpf.usercontrolpanel
{
    /// <summary>
    /// Interaction logic for singupControl.xaml
    /// </summary>
    public partial class singupControl : UserControl
    {
        private LogInWindow logInWindow;
        public singupControl(LogInWindow _LogInWindow)
        {
            logInWindow = _LogInWindow;
            InitializeComponent();
        }

        private void txtusername_TextChanged(Object sender, TextChangedEventArgs e)
        {

            if (txtusername.Text != "")
            {

                txtusernamePlaceholder.Visibility = Visibility.Hidden;

            }
            else
            {

                txtusernamePlaceholder.Visibility = Visibility.Visible;

            }

        }

        private void passwChanged(object sender, RoutedEventArgs e)
        {
            if (txtpassw.Password.Length != 0)
            {

                txtpasswPlaceholder.Visibility = Visibility.Hidden;

            }
            else
            {

                txtpasswPlaceholder.Visibility = Visibility.Visible;

            }
        }

        private void passwRepChanged(object sender, RoutedEventArgs e)
        {
            if (txtRepPassw.Password.Length != 0)
            {

                txtpasswRepPlaceholder.Visibility = Visibility.Hidden;

            }
            else
            {

                txtpasswRepPlaceholder.Visibility = Visibility.Visible;

            }
        }

        private void SinUp_Click(object sender, RoutedEventArgs e)
        {
            if(PasswordEquals() && txtusername.Text.Length !=0) {
                SingUp(txtName.Text, txtLastName.Text, txtEmail.Text,txtusername.Text,txtpassw.Password);
            }
           
        }

        private async void SingUp(string firstname,string lastname,string email,string username ,string password)
        {
            string baseAddress = "http://localhost:5079";
            string endpoint = "api/user/register";

            var dto = new RegisterDto(firstname, lastname, username, email, password);

            var json = JsonConvert.SerializeObject(dto);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                
                try
                {
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(endpoint, content);
                    
                    if (response.IsSuccessStatusCode)
                    {
                        var responseMessage = await response.Content.ReadAsStringAsync();

                        ToLogIn_Click(null, null);
                    }
                    else {
                        MessageBox.Show("server error");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
        }

        private void ToLogIn_Click(object sender, RoutedEventArgs e)
        {
            logInWindow.MainGrid.Children.Clear();
            logInWindow.MainGrid.Children.Add(logInWindow.LogInGrid);
            logInWindow = new LogInWindow();

        }

        private bool PasswordEquals()
        {
            SecureString password = new SecureString();
            SecureString confimpassword = new SecureString();
            foreach (char c in txtpassw.Password)
            {
                password.AppendChar(c);
            }

            foreach (char c in txtRepPassw.Password)
            {
                confimpassword.AppendChar(c);
            }
            IntPtr bstr1 = IntPtr.Zero;
            IntPtr bstr2 = IntPtr.Zero;
            try
            {
                bstr1 = Marshal.SecureStringToBSTR(password);
                bstr2 = Marshal.SecureStringToBSTR(confimpassword);
                int length1 = Marshal.ReadInt32(bstr1, -4);
                int length2 = Marshal.ReadInt32(bstr2, -4);
                if (length1 == length2)
                {
                    for (int x = 0; x < length1; ++x)
                    {
                        byte b1 = Marshal.ReadByte(bstr1, x);
                        byte b2 = Marshal.ReadByte(bstr2, x);
                        if (b1 != b2)
                        {
                            MessageBox.Show("Hasla sa od siebie rozne");
                            return false;
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Hasla sa od siebie rozne");
                    return false;
                }
                return true;
            }
            finally
            {
                if (bstr2 != IntPtr.Zero) Marshal.ZeroFreeBSTR(bstr2);
                if (bstr1 != IntPtr.Zero) Marshal.ZeroFreeBSTR(bstr1);
            }
        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtName.Text.Length != 0)
            {

                txtNamePlaceholder.Visibility = Visibility.Hidden;

            }
            else
            {

                txtNamePlaceholder.Visibility = Visibility.Visible;

            }
        }

        private void txtLastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtLastName.Text.Length != 0)
            {

                txtLastNamePlaceholder.Visibility = Visibility.Hidden;

            }
            else
            {

                txtLastNamePlaceholder.Visibility = Visibility.Visible;

            }
        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtEmail.Text.Length != 0)
            {

                txtEmailPlaceholder.Visibility = Visibility.Hidden;

            }
            else
            {

                txtEmailPlaceholder.Visibility = Visibility.Visible;

            }
        }
    }
}

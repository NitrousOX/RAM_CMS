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

namespace RAM_CMS
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            TextBlock_Error.Visibility = Visibility.Hidden;
            TextBox_Username.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(TextBox_Username.Text.ToString()) || String.IsNullOrEmpty(PasswordBox_Password.Password))
            {
                TextBlock_Error.Visibility = Visibility.Visible;
                TextBlock_Error.Text = "Morate uneti username i password";

            }
            else
            {
                TextBlock_Error.Visibility = Visibility.Hidden;
                TextBlock_Error.Text = "";
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBox_Username_TextChanged(object sender, TextChangedEventArgs e)
        {
            string username = TextBox_Username.Text.ToString();
            if (!username.All(char.IsLetterOrDigit))
            {
                TextBox_Username.Text = username.Remove(username.Length - 1);
                TextBox_Username.SelectionStart = username.Length - 1;
                TextBlock_Error.Visibility = Visibility.Visible;
                TextBlock_Error.Text = "Mozete uneti samo slova i brojeve za username";
            }
            else
            {
                TextBlock_Error.Visibility = Visibility.Hidden;
                TextBlock_Error.Text = "";
            }
        }

        private void PasswordBox_Password_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }
    }
}

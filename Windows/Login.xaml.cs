﻿using RAM_CMS.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
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
using System.Xml.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Controls.Primitives;
using RAM_CMS.Services;

namespace RAM_CMS
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private List<User> users = new List<User>();

        public Login()
        {
            InitializeComponent();
            TextBlock_Error.Visibility = Visibility.Hidden;
            TextBox_Username.Focus();
            XMLRead read = new XMLRead();
            users = read.XML_Read_User_list(@"../../RAM_info/user_info.xml");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = TextBox_Username.Text.ToString();
            string password = PasswordBox_Password.Password;

            if (String.IsNullOrEmpty(username))
            {
                TextBox_Username.Focus();
                TextBlock_Error.Visibility = Visibility.Visible;
                TextBlock_Error.Text = "Username must not be empty";
                return;
            }
            if(String.IsNullOrEmpty(password))
            {
                PasswordBox_Password.Focus();
                TextBlock_Error.Visibility = Visibility.Visible;
                TextBlock_Error.Text = "Password must not be empty";
                return;
            }
            
            foreach (var item in users)
            {
                if(item.Name == username && item.Password == password)
                {
                    MainWindow mainWindow = new MainWindow(new User(username, password, item.Type , item.Theme));
                    mainWindow.Show();
                    this.Close();
                    return;
                }
            }

            TextBlock_Error.Text = "Wrong username or password";
            TextBox_Username.Focus();
            TextBlock_Error.Visibility = Visibility.Visible;

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
                TextBlock_Error.Text = "You can enter only alphanumeric in username space";
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
            else if (e.Key == Key.Enter)
            {
                Button_Login.Focus();
            }
        }

        private void TextBox_Username_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                PasswordBox_Password.Focus();
            }
        }
    }
}

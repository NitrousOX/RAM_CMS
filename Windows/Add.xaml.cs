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

namespace RAM_CMS.Windows
{
    /// <summary>
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        public Add()
        {
            InitializeComponent();
            TextBlock_Error.Visibility = Visibility.Hidden;
            TextBox_Name.Focus();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void TextBox_Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            string name = TextBox_Name.Text.ToString();
            if (!name.All(char.IsLetterOrDigit))
            {
                TextBox_Name.Text = name.Remove(name.Length - 1);
                TextBox_Name.SelectionStart = name.Length - 1;
                TextBlock_Error.Visibility = Visibility.Visible;
                TextBlock_Error.Text = "You can enter only alphanumeric in name space";
            }
            else
            {
                TextBlock_Error.Visibility = Visibility.Hidden;
                TextBlock_Error.Text = "";
            }
        }

        private void TextBox_Size_TextChanged(object sender, TextChangedEventArgs e)
        {
            string size = TextBox_Size.Text.ToString();
            if (!size.All(char.IsDigit))
            {
                TextBox_Size.Text = size.Remove(size.Length - 1);
                TextBox_Size.SelectionStart = size.Length - 1;
                TextBlock_Error.Visibility = Visibility.Visible;
                TextBlock_Error.Text = "You can enter only numbers in size space";
            }
            else
            {
                TextBlock_Error.Visibility = Visibility.Hidden;
                TextBlock_Error.Text = "";
            }
        }
        //TODO
        private void Button_browse_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

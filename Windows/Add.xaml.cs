using RAM_CMS.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        RAM newRam = new RAM();
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
            TextBox_Name.Text = "";
            TextBox_Size.Text = "";
            img_preview.Source = null;
            Color_picker_Editor.SelectedColor = Colors.White;
            

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

        private void Button_browse_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG";
            bool? opened = openFileDialog.ShowDialog();

            if (opened == true)
            {
                //string file_path = System.IO.Path.GetRelativePath(Directory.GetCurrentDirectory(), openFileDialog.FileName);
                string file_path = openFileDialog.FileName;
                if (Owner is MainWindow window)
                {
                    foreach (RAM ram in window.ram_info)
                    {
                        if (ram.Path_img == file_path)
                        {
                            MessageBox.Show("This picture is already used", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                    }
                    img_preview.Source = new BitmapImage(new Uri(file_path));
                }
            }
        }

        private void TextBox_fontSize_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TextBox_fontSize_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrEmpty(TextBox_fontSize.Text.ToString()))
            {
                int size = int.Parse(TextBox_fontSize.Text.ToString());
                if (size == 0 )
                {
                    TextBox_fontSize.Text = "1";
                }else if(size > 50)
                {
                    TextBox_fontSize.Text = "50";
                }
            }
        }
    }
}

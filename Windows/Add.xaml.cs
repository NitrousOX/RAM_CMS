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
using Xceed.Wpf.Toolkit;
using MessageBox = System.Windows.MessageBox;

namespace RAM_CMS.Windows
{
    /// <summary>
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        RAM newRam = new RAM();
        bool add_flag = false;
        public Add()
        {
            InitializeComponent();
            LoadIn();
            Button_ADD.Content = "ADD";
            add_flag = true;
        }
        public Add(RAM ram)
        {
            InitializeComponent();
            LoadIn();
            Button_ADD.Content = "CHANGE";
        }

        private void LoadIn()
        {
            List<double> numbers = new List<double>();
            for (double i = 1; i <= 50; i++)
            {
                numbers.Add(i);
            }
            TextBlock_Error.Visibility = Visibility.Hidden;
            TextBox_Name.Focus();
            FontFamilyComboBox.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            ComboBox_fontSize.ItemsSource = numbers;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            add_flag = false;
            TextBox_Name.Text = "";
            TextBox_Size.Text = "";
            RichTextBox_rtf.SelectAll();
            RichTextBox_rtf.Selection.Text = "";
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
                    newRam.Path_img = file_path;
                }
            }
        }

        private void RichTextBox_rtf_TextChanged(object sender, TextChangedEventArgs e)
        {
            string richText = new TextRange(RichTextBox_rtf.Document.ContentStart, RichTextBox_rtf.Document.ContentEnd).Text;
            int wordCount = CountWords(richText);
            TextBlock_WordCount.Text = "Words: " + wordCount;
        }
        static int CountWords(string input)
        {
            string pattern = @"\b\w+\b";
            MatchCollection matches = Regex.Matches(input, pattern);
            return matches.Count;
        }

        private void RichTextBox_rtf_SelectionChanged(object sender, RoutedEventArgs e)
        {
            object fontWeight = RichTextBox_rtf.Selection.GetPropertyValue(Inline.FontWeightProperty);
            object fontStyle = RichTextBox_rtf.Selection.GetPropertyValue(Inline.FontStyleProperty);
            object textDecoration = RichTextBox_rtf.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            object fontFamily = RichTextBox_rtf.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            object fontSize = RichTextBox_rtf.Selection.GetPropertyValue(Inline.FontSizeProperty);
            object textColor = RichTextBox_rtf.Selection.GetPropertyValue(Inline.ForegroundProperty);

            ToggleButton_Bold.IsChecked = (fontWeight != DependencyProperty.UnsetValue) && (fontWeight.Equals(FontWeights.Bold));
            ToggleButton_Italic.IsChecked = (fontStyle != DependencyProperty.UnsetValue) && (fontStyle.Equals(FontStyles.Italic));
            ToggleButton_Underline.IsChecked = (textDecoration != DependencyProperty.UnsetValue) && (textDecoration.Equals(TextDecorations.Underline));
            FontFamilyComboBox.SelectedItem = fontFamily;
            ComboBox_fontSize.SelectedItem = fontSize;
            if (textColor is SolidColorBrush)
            {
                SolidColorBrush brush = (SolidColorBrush)textColor;
                Color color = brush.Color;
                Color_picker_Editor.SelectedColor = color;
            }
        }

        private void FontFamilyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FontFamilyComboBox.SelectedItem != null && !RichTextBox_rtf.Selection.IsEmpty)
            {
                RichTextBox_rtf.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, FontFamilyComboBox.SelectedItem);
            }
        }


        private void ComboBox_fontSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox_fontSize.SelectedItem != null && !RichTextBox_rtf.Selection.IsEmpty)
            {
                RichTextBox_rtf.Selection.ApplyPropertyValue(Inline.FontSizeProperty, ComboBox_fontSize.SelectedItem);
            }
        }

        private void ColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<System.Windows.Media.Color?> e)
        {
            if (Color_picker_Editor.SelectedColor.HasValue)
            {
                Color selectedColor = Color_picker_Editor.SelectedColor.Value;

                SolidColorBrush newBrush = new SolidColorBrush(selectedColor);

                RichTextBox_rtf.Selection.ApplyPropertyValue(TextElement.ForegroundProperty, newBrush);
            }
        }

        private void Button_ADD_Click(object sender, RoutedEventArgs e)
        {
            if (CheckB4Adding() && add_flag)
            {
                Microsoft.Win32.SaveFileDialog myDlg = new Microsoft.Win32.SaveFileDialog();
                myDlg.DefaultExt = "*.rtf";
                myDlg.Filter = "RTF Files|*.rtf";
                Nullable<bool> myResult = myDlg.ShowDialog();

                RichTextBox_rtf.SelectAll();
                RichTextBox_rtf.Selection.Save(new FileStream(myDlg.FileName, FileMode.OpenOrCreate, FileAccess.Write), DataFormats.Rtf);


                newRam.Name = TextBox_Name.Text.ToString();
                newRam.Size = int.Parse(TextBox_Size.Text);
                newRam.Path_rtf = myDlg.FileName;
                newRam.Creation_date = DateTime.Now;

                if (Owner is MainWindow window)
                {
                    window.ram_info.Add(newRam);
                }

                Button_exit_Click(null, null);
            }
        }

        private bool CheckB4Adding()
        {
            if (String.IsNullOrEmpty(TextBox_Name.Text))
            {
                MessageBox.Show("Cant leave Name empty before adding/changing","Error",MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }else if (String.IsNullOrEmpty(TextBox_Size.Text))
            {
                MessageBox.Show("Cant leave Size empty before adding/changing","Error",MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }else if (img_preview.Source == null)
            {
                MessageBox.Show("Cant leave Image empty before adding/changing","Error",MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}

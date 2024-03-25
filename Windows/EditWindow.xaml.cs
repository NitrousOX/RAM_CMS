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
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        RAM changeRam = new RAM();
        public EditWindow(RAM ram)
        {
            InitializeComponent();
            changeRam = ram;
            TextBox_Name.Text = ram.Name;
            TextBox_Size.Text = ram.Size.ToString();
            img_preview.Source = new BitmapImage(new Uri(ram.Path_img));
            System.IO.FileStream streamToRtfFile = new System.IO.FileStream(ram.Path_rtf, System.IO.FileMode.Open);
            RichTextBox_rtf.Selection.Load(streamToRtfFile, DataFormats.Rtf);
            OnLoad();
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void OnLoad()
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

        private void Button_ADD_Click(object sender, RoutedEventArgs e)
        {
            if (CheckB4Adding())
            {
                changeRam.Name = TextBox_Name.Text.ToString();
                changeRam.Size = int.Parse(TextBox_Size.Text);
                changeRam.Creation_date = DateTime.Now;

                RichTextBox_rtf.SelectAll();
                RichTextBox_rtf.Selection.Save(new FileStream(changeRam.Path_rtf, FileMode.OpenOrCreate, FileAccess.Write), DataFormats.Rtf);

                MessageBox.Show("Successfuly changed item","Information",MessageBoxButton.OK,MessageBoxImage.Information);
            }
        }

        private void Button_exit_Click(object sender, RoutedEventArgs e)
        {
            if (Owner is MainWindow wind)
                wind.Show();
            this.Close();
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
                    changeRam.Path_img = file_path;
                }
            }
        }
        private bool CheckB4Adding()
        {
            if (String.IsNullOrEmpty(TextBox_Name.Text))
            {
                MessageBox.Show("Cant leave Name empty before adding/changing", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (String.IsNullOrEmpty(TextBox_Size.Text))
            {
                MessageBox.Show("Cant leave Size empty before adding/changing", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (img_preview.Source == null)
            {
                MessageBox.Show("Cant leave Image empty before adding/changing", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
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

    }
}

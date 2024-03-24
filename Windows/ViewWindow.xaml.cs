using RAM_CMS.Classes;
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
    /// Interaction logic for ChangeWindow.xaml
    /// </summary>
    public partial class ChangeWindow : Window
    {
        public ChangeWindow(RAM ram)
        {
            InitializeComponent();
            TextBox_Name.Text = ram.Name;
            TextBox_Size.Text = ram.Size.ToString();
            TextBox_Date.Text = ram.Creation_date.ToString("dd/MM/yyyy");
            img_preview.Source = new BitmapImage(new Uri(ram.Path_img));
            System.IO.FileStream streamToRtfFile = new System.IO.FileStream(ram.Path_rtf, System.IO.FileMode.Open);
            RTF_VIEW.Selection.Load(streamToRtfFile, DataFormats.Rtf);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(Owner is MainWindow win)
                win.Show();
            this.Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}

using RAM_CMS.Classes;
using RAM_CMS.Services;
using RAM_CMS.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace RAM_CMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LoadnWriteRaMService LWservice = new LoadnWriteRaMService();
        public ObservableCollection<RAM> ram_info = new ObservableCollection<RAM>();
        Theme theme = new Theme();
        private User user;
        public MainWindow(User user)
        {
            this.user = user; 
            InitializeComponent();
            User_logged();
            LWservice.LoadRam(ref ram_info);
            ListView_Table.DataContext = ram_info;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Logout_Click(object sender, RoutedEventArgs e)
        {
            if (Owner is Login win)
                win.Show();
            LWservice.WriteRam(ref ram_info);
            this.Close();
        }

        private void Light_mode_Checked(object sender, RoutedEventArgs e)
        {
            theme.LightMode();
        }

        private void Dark_mode_Checked(object sender, RoutedEventArgs e)
        {
            theme.DarkMode();
        }

        private void User_logged()
        {
            Label_User_Role_Type.Content = "Logged in as: " + user.Name;
            if(user.Type == User_Role.ADMIN)
            {
                Button_dodaj.IsEnabled = true;
                Button_izbrisi.IsEnabled = true;
                
            }
            else
            {
                Button_dodaj.IsEnabled = false;
                Button_dodaj.Background = Brushes.Gray;
                Button_izbrisi.IsEnabled = false;
                Button_izbrisi.Background = Brushes.Gray;
            }

            if (user.Theme == "Light")
                Light_mode.IsChecked = true;
            else
                Dark_mode.IsChecked = true;
        }
        private void Button_izbrisi_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in ram_info.ToList())
            {
                if(item.Checked == true)
                {
                    ram_info.Remove(item);
                    File.Delete(item.Path_rtf);
                }
            }
        }


        private void Button_dodaj_Click(object sender, RoutedEventArgs e)
        {
            Add addWindow = new Add();
            this.Hide();
            addWindow.Owner = this;
            addWindow.Show();
        }

        private void ListView_checkbox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox != null)
            {
                var bindingObject = (RAM)checkBox.DataContext;
                bindingObject.Checked = true;
            }
        }

        private void ListView_checkbox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox != null)
            {
                var bindingObject = (RAM)checkBox.DataContext;
                bindingObject.Checked = false;
            }
        }

        private void Button_dodaj_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Button_dodaj.IsEnabled)
            {
                ((Storyboard)Application.Current.Resources["MouseEnterAnimation"]).Begin(Button_dodaj);
            }
        }

        private void Button_dodaj_MouseLeave(object sender, MouseEventArgs e)
        {
            if (Button_dodaj.IsEnabled)
            {
                ((Storyboard)Application.Current.Resources["MouseLeaveAnimation"]).Begin(Button_dodaj);
            }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            if(user.Name == "admin")
            {
                Hyperlink link = sender as Hyperlink;
                var bindingObject = (RAM)link.DataContext;
                EditWindow edit = new EditWindow(bindingObject);
                edit.Owner = this;
                edit.Show();
                this.Hide();
            }
            else
            {
                Hyperlink link = sender as Hyperlink;
                var bindingObject = (RAM)link.DataContext;
                ChangeWindow View = new ChangeWindow(bindingObject);
                View.Owner = this;
                View.Show();
                this.Hide();
            }

        }
    }
}

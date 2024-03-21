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
        private ObservableCollection<RAM> ram_info = new ObservableCollection<RAM>();
        private LoadnWriteRaMService LWservice = new LoadnWriteRaMService();
        Theme theme = new Theme();
        private User user;
        Add addWindow = new Add();

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
            Login login = new Login();
            login.Show();
            addWindow.Close();
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
            if (user.Theme == "Light")
                Light_mode.IsChecked = true;
            else
                Dark_mode.IsChecked = true;



            if (user.Type == User_Role.ADMIN)
            {

            }
            else
            {

            }
        }
        private void Button_izbrisi_Click(object sender, RoutedEventArgs e)
        {

        }


        private void Button_dodaj_Click(object sender, RoutedEventArgs e)
        {
           addWindow.Show();
        }
    }
}

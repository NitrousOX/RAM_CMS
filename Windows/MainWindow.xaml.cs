using RAM_CMS.Classes;
using RAM_CMS.Services;
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
        private LoadnWriteRaMService LRservice = new LoadnWriteRaMService();
        public ObservableCollection<RAM> Ram_info
        {
            get { return ram_info; }
        }
        public MainWindow(User user)
        {
            InitializeComponent();
            Label_User_Role_Type.Content = "Logged in as: " + user.Name;
            LRservice.LoadRam(ref ram_info);
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
            this.Close();
        }
    }
}

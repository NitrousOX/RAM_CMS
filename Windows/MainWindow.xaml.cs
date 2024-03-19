using RAM_CMS.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
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
using System.Xml.Serialization;

namespace RAM_CMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<RAM> ram_info = new ObservableCollection<RAM>();
        public ObservableCollection<RAM> Ram_info
        {
            get { return ram_info; }
        }
        public MainWindow(User user)
        {
            InitializeComponent();
            Label_User_Role_Type.Content = "Logged in as: " + user.Name;
            LoadRAM_INFO(@"../../RAM_info/ram_info.xml");
            ListView_Table.DataContext = ram_info;


            //TODO: redovno upisivanje putanje do slika i rtf
            //RAM ram1 = new RAM(8256,"Kingston", "imgpath","rtfpath", DateTime.Now);
            //RAM ram2 = new RAM(16852,"Samsung", "imgpath","rtfpath", DateTime.Now);
            //RAM ram3 = new RAM(32659,"Fury", "imgpath","rtfpath", DateTime.Now);

            //List<RAM> ram_list = new List<RAM>();
            //ram_list.Add(ram1);
            //ram_list.Add(ram2);
            //ram_list.Add(ram3);

            //var serializer = new XmlSerializer(ram_list.GetType());
            //using (var writer = new StreamWriter(@"../../RAM_info/ram_info.xml"))
            //{
            //    serializer.Serialize(writer, ram_list);
            //}

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

        //TODO: ucitavanje
        private void LoadRAM_INFO(string Path)
        {
            int size;
            string name;
            string path_img;
            string path_rtf;
            DateTime creation_date;

            if(File.Exists(Path))
            {
                try
                {

                }catch (Exception) {
                    MessageBox.Show("Error while loading in RAM data");
                }
            }
        }
    }
}

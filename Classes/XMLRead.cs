using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace RAM_CMS.Classes
{
    public class XMLRead
    {
        public XMLRead() { }
       

        public bool XML_Read_into_RAM_collection(ref ObservableCollection<RAM>ram_collection, string File_path)
        {
            if (File.Exists(File_path))
            {
                try
                {
                    List<RAM> ram_list = new List<RAM>();
                    var serializer = new XmlSerializer(ram_list.GetType());
                    using (var reader = new StreamReader(File_path))
                    {
                        ram_list = (List<RAM>)serializer.Deserialize(reader);
                    }
                    ram_collection = new ObservableCollection<RAM>(ram_list);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while loading in RAM data: " + ex.Message.ToString(), "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }return false;
        }

        public List<RAM> XML_Read_Ram_list(string File_path)
        {
            if (File.Exists(File_path))
            {
                try
                {
                    List<RAM> ram_list = new List<RAM>();
                    var serializer = new XmlSerializer(ram_list.GetType());
                    using (var reader = new StreamReader(File_path))
                    {
                        ram_list = (List<RAM>)serializer.Deserialize(reader);
                    }
                    return ram_list;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while loading in RAM data: " + ex.Message.ToString(), "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }
            }
            return null;
        }


        public List<User> XML_Read_User_list(string File_path)
        {
            if (File.Exists(File_path))
            {
                try
                {
                    List<User> user_list = new List<User>();
                    var serializer = new XmlSerializer(user_list.GetType());
                    using (var reader = new StreamReader(File_path))
                    {
                        user_list = (List<User>)serializer.Deserialize(reader);
                    }
                    return user_list;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while loading in User data: " + ex.Message.ToString(), "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }
            }
            return null;
        }
    }
}

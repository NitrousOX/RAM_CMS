using RAM_CMS.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace RAM_CMS.Services
{
    public class XMLWrite
    {
        public bool XML_Write_RAM(List<RAM> ram_list, string File_path)
        {
            try
            {
                var serializer = new XmlSerializer(ram_list.GetType());
                using (var writer = new StreamWriter(File_path))
                {
                    serializer.Serialize(writer, ram_list);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while writing to xml document: " + ex.Message);
                return false;
            }
        }

        public bool XML_Write_User(List<User> user_list, string File_path)
        {
            try
            {
                var serializer = new XmlSerializer(user_list.GetType());
                using (var writer = new StreamWriter(File_path))
                {
                    serializer.Serialize(writer, user_list);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while writing to xml document: " + ex.Message);
                return false;
            }
        }
    }
}

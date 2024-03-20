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
    public class XMLReadWrite
    {
        private string Path = @"../../RAM_info/ram_info.xml";

        public bool XML_Write(List<RAM> ram_list) {
            try
            {
                var serializer = new XmlSerializer(ram_list.GetType());
                using (var writer = new StreamWriter(@"../../RAM_info/ram_info.xml"))
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


        public bool XML_Read_into_collection(ref ObservableCollection<RAM>ram_collection)
        {
            if (File.Exists(Path))
            {
                try
                {
                    var doc = XDocument.Load(Path);
                    var ram_list = doc.Root
                        .Descendants("RAM")
                        .Select(node => new RAM()
                        {
                            Size = (int)node.Element("Size"),
                            Name = (string)node.Element("Name"),
                            Path_img = (string)node.Element("Path_img"),
                            Path_rtf = (string)node.Element("Path_rtf"),
                            Creation_date = (DateTime)node.Element("Creation_date")

                        }).ToList();
                    ram_collection = new ObservableCollection<RAM>(ram_list);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while loading in RAM data: " + ex.Message.ToString());
                    return false;
                }
            }return false;
        }

        public List<RAM> XML_Read()
        {
            if (File.Exists(Path))
            {
                try
                {
                    var doc = XDocument.Load(Path);
                    var ram_list = doc.Root
                        .Descendants("RAM")
                        .Select(node => new RAM()
                        {
                            Size = (int)node.Element("Size"),
                            Name = (string)node.Element("Name"),
                            Path_img = (string)node.Element("Path_img"),
                            Path_rtf = (string)node.Element("Path_rtf"),
                            Creation_date = (DateTime)node.Element("Creation_date")

                        }).ToList();
                    return ram_list;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while loading in RAM data: " + ex.Message.ToString());
                    return null;
                }
            }
            return null;
        }


    }
}

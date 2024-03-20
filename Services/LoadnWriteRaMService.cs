using RAM_CMS.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAM_CMS.Services
{
    public class LoadnWriteRaMService
    {
        XMLReadWrite XmlReadWrite = new XMLReadWrite();

        public void LoadRam(ref ObservableCollection<RAM> observable)
        {
            XmlReadWrite.XML_Read_into_collection(ref observable);
        }

        public void WriteRam(ref ObservableCollection<RAM> observable)
        {
            XmlReadWrite.XML_Write(observable.ToList());
        }
    }
}

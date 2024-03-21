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
        private string Path = @"../../RAM_info/ram_info.xml";
        XMLRead Read = new XMLRead();
        XMLWrite Write = new XMLWrite();

        public void LoadRam(ref ObservableCollection<RAM> observable)
        {
            Read.XML_Read_into_RAM_collection(ref observable, Path);
        }

        public void WriteRam(ref ObservableCollection<RAM> observable)
        {
            Write.XML_Write_RAM(observable.ToList(),Path);
        }
    }
}

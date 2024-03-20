using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAM_CMS.Classes
{
    [Serializable()]
    public class RAM
    {
        private int size;
        private string name;
        private string path_img;
        private string path_rtf;
        private DateTime creation_date;

        public RAM()
        {
        }

        public RAM(int size, string name, string path_img, string path_rtf, DateTime creation_date)
        {
            this.size = size;
            this.name = name;
            this.path_img = path_img;
            this.path_rtf = path_rtf;
            this.creation_date = creation_date;
        }

        public int Size { get => size; set => size = value; }
        public string Name { get => name; set => name = value; }
        public string Path_img { get => path_img; set => path_img = value; }
        public string Path_rtf { get => path_rtf; set => path_rtf = value; }
        public DateTime Creation_date { get => creation_date; set => creation_date = value; }
    }
}

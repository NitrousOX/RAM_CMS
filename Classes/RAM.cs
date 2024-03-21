using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAM_CMS.Classes
{
    [Serializable()]
    public class RAM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
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

        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public override bool Equals(object obj)
        {
            return obj is RAM rAM &&
                   Size == rAM.Size &&
                   Name == rAM.Name &&
                   Path_img == rAM.Path_img &&
                   Path_rtf == rAM.Path_rtf &&
                   Creation_date == rAM.Creation_date;
        }

        public int Size { get => size; set { if (size != value) { size = value; OnPropertyChanged("Size"); } } }
        public string Name { get => name; set { if (name != value) { name = value; OnPropertyChanged("Name"); } } }
        public string Path_img { get => path_img; set { if (path_img != value) { path_img = value; OnPropertyChanged("Path_img"); } } }
        public string Path_rtf { get => path_rtf; set { if (path_rtf != value) { path_rtf = value; OnPropertyChanged("Path_rtf"); } } }
        public DateTime Creation_date { get => creation_date; set { if (creation_date != value) { creation_date = value; OnPropertyChanged("Creation_date"); } } }
    }
}

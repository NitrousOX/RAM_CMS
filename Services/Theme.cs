using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace RAM_CMS.Classes
{
    public class Theme
    {
       public void DarkMode()
        {
            Application.Current.Resources["White"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFDFFFF"));
            Application.Current.Resources["Window_Background"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2F2235"));
            Application.Current.Resources["Middle"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#A9ACA9"));
            Application.Current.Resources["Highlited_Background"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3F3244"));
            Application.Current.Resources["Highlight_color_less"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#60495A"));
            Application.Current.Resources["Highlight_color"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#5F5AA2"));
        }

        public void LightMode() {
            Application.Current.Resources["White"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFDFFFF"));
            Application.Current.Resources["Window_Background"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#DDD5D0"));
            Application.Current.Resources["Middle"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#CFC0BD"));
            Application.Current.Resources["Highlited_Background"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B8B8AA"));
            Application.Current.Resources["Highlight_color_less"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7F9183"));
            Application.Current.Resources["Highlight_color"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF586F6B"));
        }
    }
}

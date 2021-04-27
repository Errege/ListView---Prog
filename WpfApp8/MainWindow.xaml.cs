using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

namespace WpfApp8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Fra.frame = frame;
            Fra.text = text;
            Fra.frame.Navigate(new TableMaterial());
            //ImageImport();
        }
        /// <summary>
        /// Funkcia dobavlenia fotok
        /// </summary>
        //private void ImageImport()
        //{
        //    var fileData = File.ReadAllLines(@"C:\Apps\im\Tkan.txt");
        //    var image = Directory.GetFiles(@"C:\Apps\im\Tkani");
        //    foreach (var line in fileData)
        //    {
        //        var data = line.Split('\t');
        //        var materials = new MATERIAL
        //        {
        //            NAME = data[0].Replace("\"", " ")
        //        };
        //        try
        //        {
        //            materials.IMAGE = File.ReadAllBytes(image.FirstOrDefault(d => d.Contains(materials.NAME)));
        //            Fra.context.MATERIAL.Add(materials);
        //            Fra.context.SaveChanges();
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message.ToString());
        //        }
        //    }
        //}
    }
}

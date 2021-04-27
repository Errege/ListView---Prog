using Microsoft.Win32;
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
    /// Логика взаимодействия для InfoAddEddMaterials.xaml
    /// </summary>
    public partial class InfoAddEddMaterials : Page
    {
        MATERIAL mATERIAL = new MATERIAL();
        public InfoAddEddMaterials(MATERIAL settermaterial)
        {
            InitializeComponent();
            if (settermaterial != null)
                mATERIAL = settermaterial;
            TipPriduct.ItemsSource = Fra.context.TYPE_MATERIAL.ToList();
            SupplierADD.ItemsSource = Fra.context.SUPPLIER.ToList();
            EDIZMER.ItemsSource = Fra.context.UNIT_OF_MEASUREMENT.ToList();
            PRODUKTI.ItemsSource = Fra.context.PRODUCT.ToList();

            DataContext = mATERIAL;
        }

        private void Image_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void ADDPHOTO_Click(object sender, RoutedEventArgs e)
        {
            var file = new OpenFileDialog();
            file.Filter =
               "Image files (*.JPG, *.PNG)| *jpg; *.png;";
            if (file.ShowDialog() == true)
            {
                Photo.Source = new BitmapImage(new Uri(file.FileName));
                mATERIAL.IMAGE = File.ReadAllBytes(file.FileName);
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            if(mATERIAL.ID == 0)
            {
      
                Fra.context.MATERIAL.Add(mATERIAL);
            }
            try
            {
                Fra.context.SaveChanges();
                Fra.te.Text = $"Выведено {Fra.list.Items.Cast<MATERIAL>().Count().ToString()} из {Fra.context.MATERIAL.Count().ToString()}";
                Fra.frame.GoBack();
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}

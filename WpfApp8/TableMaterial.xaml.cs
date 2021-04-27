using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для TableMaterial.xaml
    /// </summary>
    public partial class TableMaterial : Page
    {
        public TableMaterial()
        {
            InitializeComponent();
            Fra.te = tee;
            
           
            LView.ItemsSource = Fra.context.MATERIAL.ToList();
            var alltypes = Fra.context.TYPE_MATERIAL.ToList();
            alltypes.Insert(0, new TYPE_MATERIAL
            { NAME = "Все типы"}

                );
            Tips.SelectedIndex = 0;
            Tips.ItemsSource = alltypes;
            Fra.te.Text = $"Выведено {LView.Items.Cast<MATERIAL>().Count().ToString()} из {Fra.context.MATERIAL.Count().ToString()}";
            Fra.list = LView;
            Fra.texxt = tee;
        }

        
        private void Del_Click(object sender, RoutedEventArgs e)
        {
            var delete = LView.SelectedItems.Cast<MATERIAL>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {delete.Count()} элементы?","Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question)== MessageBoxResult.Yes)
                try
                {
                    Fra.context.MATERIAL.RemoveRange(delete);
                    Fra.context.SaveChanges();
                    LView.ItemsSource = Fra.context.MATERIAL.ToList();
                    MessageBox.Show("Данные успешно удалены!");
                    Fra.te.Text = $"Выведено {LView.Items.Cast<MATERIAL>().Count().ToString()} из {Fra.context.MATERIAL.Count().ToString()}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Fra.frame.Navigate(new InfoAddEddMaterials(null));
            Fra.text.Text = ("Добаление");
            
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Fra.frame.Navigate(new InfoAddEddMaterials((sender as Button).DataContext as MATERIAL));
            Fra.text.Text = ("Изменение");
            Fra.te.Text = $"Выведено {LView.Items.Cast<MATERIAL>().Count().ToString()} из {Fra.context.MATERIAL.Count().ToString()}";
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if( Visibility == Visibility.Visible)
            {
                Fra.context.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                LView.ItemsSource = Fra.context.MATERIAL.ToList();
                Fra.te.Text = $"Выведено {LView.Items.Cast<MATERIAL>().Count().ToString()} из {Fra.context.MATERIAL.Count().ToString()}";
            }
        }
        

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var ser = Fra.context.MATERIAL.ToList();
            ser = ser.Where(d => d.NAME.ToString().ToLower().Contains(Search.Text.ToLower()) ||
                d.DESCRIPTION.ToString().ToLower().Contains(Search.Text.ToLower())).ToList();
            Fra.glob = ser.Where(d => d.ID_TYPE_MATERIAL == (Tips.SelectedIndex)).ToList();
            LView.ItemsSource = Fra.glob;

            Fra.te.Text = $"Выведено {LView.Items.Cast<MATERIAL>().Count().ToString()} из {Fra.context.MATERIAL.Count().ToString()}";
        }
       

        private void Tips_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var zar = Fra.context.MATERIAL.ToList();
            if (Tips.SelectedIndex > 0)
                zar = zar.Where(d => d.ID_TYPE_MATERIAL == (Tips.SelectedIndex)).ToList();
            Fra.glob = zar.Where(d => d.NAME.ToString().ToLower().Contains(Search.Text.ToLower()) ||
                d.DESCRIPTION.ToString().ToLower().Contains(Search.Text.ToLower())).ToList();
            LView.ItemsSource = Fra.glob;
            
            Fra.te.Text = $"Выведено {LView.Items.Cast<MATERIAL>().Count().ToString()} из {Fra.context.MATERIAL.Count().ToString()}";
        }
    }
}

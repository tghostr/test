using Microsoft.EntityFrameworkCore;
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
using System.Windows.Shapes;

namespace test_avto
{
    /// <summary>
    /// Логика взаимодействия для GlavnayaWindow.xaml
    /// </summary>
    public partial class GlavnayaWindow : Window
    {
        public GlavnayaWindow()
        {
            InitializeComponent();
            Update();
            
        }
        private void Update()
        {
            
            IEnumerable<Poseshenie> poseshenies = CoreModel.init().Poseshenies
                .Include(p => p.VrachIdVrachNavigation)
                .Include(p => p.PacientIdPacientNavigation)
                .Where(p => p.PacientIdPacientNavigation.PacientFamiliya.Contains(tbSearch.Text) || p.VrachIdVrachNavigation.VrachFamiliya.Contains(tbSearch.Text));
            lv.ItemsSource = poseshenies.ToList();
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddPage addPage = new AddPage(new Poseshenie());
            addPage.Show();
            this.Hide();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            if (lv.SelectedItems.Count > 1 || lv.SelectedItems.Count < 1)
            {
                MessageBox.Show("Выберите 1 элемент");
                return;
            }
            Poseshenie poseshenie = lv.SelectedItem as Poseshenie;
            AddPage addPag=new AddPage(poseshenie);
            addPag.Show();
            this.Hide();
        }
    }
}

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
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    public partial class AddPage : Window
    {
        Poseshenie Poseshenie;
        public AddPage(Poseshenie poseshenie)
        {
            InitializeComponent();
            this.Poseshenie = poseshenie;
            DataContext = Poseshenie;
            List<Vrach> vraches = CoreModel.init().Vraches.ToList();
            List<Pacient> pacients = CoreModel.init().Pacients.ToList();
            pacAdd.ItemsSource = pacients;
            vrAdd.ItemsSource = vraches;
            pacAdd.SelectedIndex = 0;
            vrAdd.SelectedIndex = 0;
            vraches.Insert(0, new Vrach { VrachFamiliya = "не выбрано" });
            pacients.Insert(0, new Pacient { PacientFamiliya = "не выбрано" });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Poseshenie.IdPoseshenie == 0)
            {
                CoreModel.init().Poseshenies.Add(Poseshenie);
                MessageBox.Show("Added");
            }
            CoreModel.init().SaveChanges();

            GlavnayaWindow glavnayaWindow = new GlavnayaWindow();
            glavnayaWindow.Show();
            this.Hide();
        }
    }
}

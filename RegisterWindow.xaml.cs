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
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        Sotrudnik Sotrudnik;
        public RegisterWindow(Sotrudnik sotrudnik)
        {
            InitializeComponent();
            this.Sotrudnik = sotrudnik;
            DataContext = Sotrudnik;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Sotrudnik.DostupIdDostup = 1;
            if (Sotrudnik.IdSotrudnik == 0)
                CoreModel.init().Sotrudniks.Add(Sotrudnik);
            CoreModel.init().SaveChanges();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show(); this.Hide();
        }
    }
}

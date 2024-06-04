using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace test_avto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btAuth_Click(object sender, RoutedEventArgs e)
        {
            Sotrudnik sotrudnik = CoreModel.init().Sotrudniks.FirstOrDefault(p => p.SotrudnikPass == tbPass.Text && p.SotrudnikLogin == tbLogin.Text);
            if (sotrudnik != null)
            {
                Global.GlobalVar = sotrudnik.DostupIdDostup;
                GlavnayaWindow glavnayaWindow = new GlavnayaWindow();
                glavnayaWindow.Show();
                this.Hide();
            }
        }

        private void RegisterBtn(object sender, MouseButtonEventArgs e)
        {
            RegisterWindow win = new RegisterWindow(new Sotrudnik());
            win.Show();
            this.Hide();
        }
    }
}
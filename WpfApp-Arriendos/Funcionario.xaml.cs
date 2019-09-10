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

namespace WpfApp_Arriendos
{
    /// <summary>
    /// Lógica de interacción para Funcionario.xaml
    /// </summary>
    public partial class Funcionario : Window
    {
        public Funcionario()
        {
            InitializeComponent();
        }

        private void BtnInicio_Click(object sender, RoutedEventArgs e)
        {
            Dashboard home = new Dashboard();
            home.Show();
            this.Close();
        }

        private void BtnFuncionario_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

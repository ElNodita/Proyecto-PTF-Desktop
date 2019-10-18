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
using WpfApp_Arriendos.DirDepartamentos;
using Negocio.Clases;
using System.IO;

namespace WpfApp_Arriendos
{
    /// <summary>
    /// Lógica de interacción para Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void BtnFuncionario_Click(object sender, RoutedEventArgs e)
        {
            Funcionario fun = new Funcionario();
            fun.Show();
            this.Close();
        }

        private void BtnDepartamento_Click(object sender, RoutedEventArgs e)
        {
            GestorDepartamentos depa = new GestorDepartamentos();
            depa.Show();
            this.Close();
        }

        private void BtnCarga_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg";


            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                txtRuta.Text = filename;
            }
        }

        private void BtnSubir_Click(object sender, RoutedEventArgs e)
        {
            DepartamentoCollection depa = new DepartamentoCollection();

            string ruta = System.IO.Path.GetDirectoryName(txtRuta.Text);

            string archivo = System.IO.Path.GetFileName(txtRuta.Text);

            string nuevaRuta = ruta + @"\"+"hola-" + archivo;

            System.IO.File.Move(ruta+@"\"+archivo, nuevaRuta);

            depa.CargaImagen(nuevaRuta);

        }
    }
}

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
    public partial class Dashboard : Window
    {
        //Constructor de la clase donde se indica como debe iniciar la vista.
        public Dashboard()
        {
            InitializeComponent();
        }

        //Boton que dirige a la vista Funcionario.
        private void BtnFuncionario_Click(object sender, RoutedEventArgs e)
        {
            Funcionario fun = new Funcionario();
            fun.Show();
            this.Close();
        }

        //Boton que dirige a la vista Servicios.
        private void btnServicios_Click(object sender, RoutedEventArgs e)
        {
            DirServicios.Servicio serv = new DirServicios.Servicio();
            serv.Show();
            this.Close();
        }

        //Boton que dirige a la vista Departamento.
        private void BtnDepartamento_Click(object sender, RoutedEventArgs e)
        {
            GestorDepartamentos depa = new GestorDepartamentos();
            depa.Show();
            this.Close();
        }

        //Boton que dirige a la vista de Inicio.
        private void BtnInicio_Click(object sender, RoutedEventArgs e)
        {

        }

        //botón que cierra la vista
        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Botón que minimiza la ventana
        private void btnMinimiza_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        //botón que recarga la vista;
        private void btnRecarga_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Normal;
        }
    }
}

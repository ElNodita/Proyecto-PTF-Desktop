﻿using System;
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

        private void btnServicios_Click(object sender, RoutedEventArgs e)
        {
            Servicio serv = new Servicio();
            serv.Show();
            this.Close();
        }
        private void BtnDepartamento_Click(object sender, RoutedEventArgs e)
        {
            GestorDepartamentos depa = new GestorDepartamentos();
            depa.Show();
            this.Close();
        }

        private void BtnInicio_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

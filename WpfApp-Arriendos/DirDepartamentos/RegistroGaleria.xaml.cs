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
using Negocio.Clases;

namespace WpfApp_Arriendos.DirDepartamentos
{
    /// <summary>
    /// Lógica de interacción para RegistroGaleria.xaml
    /// </summary>
    public partial class RegistroGaleria : Window
    {
        DepartamentoCollection depa;
        public RegistroGaleria()
        {
            InitializeComponent();
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
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

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtRuta.Text))
            {
                MessageBox.Show("El campo no debe estar vacío.");
            }
            else
            {
                depa = new DepartamentoCollection();

                string ruta = System.IO.Path.GetDirectoryName(txtRuta.Text);

                string archivo = System.IO.Path.GetFileName(txtRuta.Text);
                int idDepa = int.Parse(Application.Current.Resources["idDepartamento"].ToString());

                string nuevaRuta = ruta + @"\" + idDepa + "-" + archivo;

                System.IO.File.Move(ruta + @"\" + archivo, nuevaRuta);

                string nuevoArchivo = System.IO.Path.GetFileName(nuevaRuta);

                string ftp = "ftp://ftp.webcindario.com/imgDepartamentos/" + nuevoArchivo;

                depa.InsertaImagen(idDepa, nuevoArchivo, ftp);
                depa.CargaImagen(nuevaRuta);

                lblMensaje.Content = "Registrado correctamente!";
            }

        }
    }
}
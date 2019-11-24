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
using Negocio.Clases;

namespace WpfApp_Arriendos.DirDepartamentos
{
    public partial class RegistroGaleria : Window
    {
        //Atributos de la vista.
        DepartamentoCollection depa;

        //Constructor de la clase donde se indica como debe iniciar la vista.
        public RegistroGaleria()
        {
            InitializeComponent();
        }
        //Botón para minimizar la pestaña
        private void btnMinimiza_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        //Botón para cerrar la pestaña
        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Boton para buscar imagen que se desea subir al sistema.
        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error, contacte al administrador: " + ex.Message, "Excepción detectada", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        //Boton para realizar el ingreso de la imagen al sistema.
        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error, contacte al administrador: " + ex.Message, "Excepción detectada", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

    }
}

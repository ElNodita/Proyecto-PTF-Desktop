using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace WpfApp_Arriendos.DirServicios
{
    public partial class NuevoServicioExtra : Window
    {
        //Atributos de la vista.
        ServicioExtraCollection sc;

        //Constructor de la clase donde se indica como debe iniciar la vista.
        public NuevoServicioExtra()
        {
            InitializeComponent();
        }
        //Botón para minimizar la ventana
        private void btnMinimiza_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        //Botón paracerrar la ventana
        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Boton para realizar la accion de ingresar datos de Servicio extra.
        private void BtnRegistrarServicioExtra_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtDescripcionServicio.Text) || txtDescripcionServicio.Text.Length < 5 && txtDescripcionServicio.Text.Length > 200)
                {
                    MessageBox.Show("Descripción no debe estar vacío y tiene que estar entre 5 a 200 carácteres.");
                }
                else if (Regex.IsMatch(txtCostoServicio.Text, "^[a-zA-Z]"))
                {
                    MessageBox.Show("Costo debe ser numérico.");
                }
                else if (string.IsNullOrEmpty(txtCostoServicio.Text) || int.Parse(txtCostoServicio.Text) <= 0 && int.Parse(txtCostoServicio.Text) >= 999999)
                {
                    MessageBox.Show("Costo no debe estar vacío y debe ser mayor a 0 o menor a 999.999");
                }
                else
                {
                    sc = new ServicioExtraCollection();

                    string descripcion = txtDescripcionServicio.Text;
                    int costo = int.Parse(txtCostoServicio.Text);

                    var insercion = sc.InsertaServicioExtraC(descripcion, costo);

                    if (insercion == true)
                    {
                        this.Close();
                    }
                    else
                    {
                        lblmensaje.Content = "Error de inserción.";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error, contacte al administrador: " + ex.Message, "Excepción detectada", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}

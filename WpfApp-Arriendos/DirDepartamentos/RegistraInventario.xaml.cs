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

namespace WpfApp_Arriendos.DirDepartamentos
{
    /// <summary>
    /// Lógica de interacción para RegistraInventario.xaml
    /// </summary>
    public partial class RegistraInventario : Window
    {
        DepartamentoCollection inv;
        public RegistraInventario()
        {
            InitializeComponent();
        }

        private void BtnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(txtBaño.Text, "^[a-zA-Z]") || string.IsNullOrEmpty(txtBaño.Text) || int.Parse(txtBaño.Text) <= 0)
            {
                MessageBox.Show("La cantidad de baños debe ser númerica mayor a 0");
            }
            else if (Regex.IsMatch(txtDormitorio.Text, "^[a-zA-Z]") || string.IsNullOrEmpty(txtDormitorio.Text) || int.Parse(txtDormitorio.Text) <= 0)
            {
                MessageBox.Show("La cantidad de dormitorios debe ser númerica mayor a 0");
            }
            else if (Regex.IsMatch(txtTv.Text, "^[a-zA-Z]") || string.IsNullOrEmpty(txtTv.Text) || int.Parse(txtTv.Text) <= 0)
            {
                MessageBox.Show("La cantidad de televisores debe ser númerica mayor a 0");
            }
            else if (Regex.IsMatch(txtMesa.Text, "^[a-zA-Z]") || string.IsNullOrEmpty(txtMesa.Text) || int.Parse(txtMesa.Text) <= 0)
            {
                MessageBox.Show("La cantidad de mesas debe ser númerica mayor a 0");
            }
            else if (Regex.IsMatch(txtAsiento.Text, "^[a-zA-Z]") || string.IsNullOrEmpty(txtAsiento.Text) || int.Parse(txtAsiento.Text) <= 0)
            {
                MessageBox.Show("La cantidad de asientos debe ser númerica mayor a 0");
            }
            else if (Regex.IsMatch(txtMueble.Text, "^[a-zA-Z]") || string.IsNullOrEmpty(txtMueble.Text) || int.Parse(txtMueble.Text) <= 0)
            {
                MessageBox.Show("La cantidad de muebles debe ser númerica mayor a 0");
            }
            else
            {
                inv = new DepartamentoCollection();
                int depa = int.Parse(Application.Current.Resources["id_departamento"].ToString());

                char internet;
                if (chkInternet.IsChecked == true)
                {
                    internet = char.Parse(1.ToString());
                }
                else
                {
                    internet = char.Parse(0.ToString());
                }

                int baños = int.Parse(txtBaño.Text);
                int dormitorio = int.Parse(txtDormitorio.Text);
                int tv = int.Parse(txtTv.Text);
                int mesa = int.Parse(txtMesa.Text);
                int asiento = int.Parse(txtAsiento.Text);
                int mueble = int.Parse(txtMueble.Text);

                var resultado = inv.InsertaInventario(depa, internet, baños, dormitorio, tv, mesa, asiento, mueble);
                if (resultado == true)
                {

                    inv.CambiaEstado(depa, char.Parse(1.ToString()));
                    this.Close();
                }
                else
                {
                    lblMensaje.Content = "Error en el registro.";
                }
            }
        }
    }
}

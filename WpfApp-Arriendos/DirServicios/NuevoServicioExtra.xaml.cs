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
    /// <summary>
    /// Lógica de interacción para NuevoServicioExtra.xaml
    /// </summary>
    public partial class NuevoServicioExtra : Window
    {
        ServicioExtraCollection sc;
        public NuevoServicioExtra()
        {
            InitializeComponent();
        }

        private void BtnRegistrarServicioExtra_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescripcionServicio.Text))
            {
                MessageBox.Show("Campo descripción no debe estar vacío.");
            } else if (Regex.IsMatch(txtCostoServicio.Text, "^[a-zA-Z]"))
            {
                MessageBox.Show("El costo debe ser numérico.");
            } else if (string.IsNullOrEmpty(txtCostoServicio.Text) || int.Parse(txtCostoServicio.Text)<=0)
            {
                MessageBox.Show("Campo costo no debe estar vacío y debe ser mayor a 0.");
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
    }
}

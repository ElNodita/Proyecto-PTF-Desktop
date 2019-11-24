using System;
using System.Collections.Generic;
using System.Data;
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
    public partial class RegistroDepartamento : Window
    {
        //Atributos de la vista.
        DepartamentoCollection depa;

        //Constructor de la clase donde se indica como debe iniciar la vista.
        public RegistroDepartamento()
        {
            InitializeComponent();
            slcComuna.IsEnabled = false;
            CargaRegion();
            
        }
        //Botón que minimiza la pestaña
        private void btnMinimiza_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        //Botón que cierra la pestaña
        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #region Registro

        //Boton para realizar la accion de registrar datos de Departamento.
        private void BtnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (slcRegion.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe selecionar una región.");
                }
                else if (slcComuna.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar una comuna.");
                }
                else if (slcTipo.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un tipo.");
                }
                else if (string.IsNullOrEmpty(txtDireccion.Text) || txtDireccion.Text.Length < 5 && txtDireccion.Text.Length > 200)
                {
                    MessageBox.Show("Dirección no debe estar vacío y tiene que estar entre 5 a 200 carácteres.");
                }
                else if (Regex.IsMatch(txtCosto.Text, "^[a-zA-Z]") || string.IsNullOrEmpty(txtCosto.Text) || int.Parse(txtCosto.Text) <= 0 && int.Parse(txtCosto.Text) >= 9999999)
                {
                    MessageBox.Show("El costo debe ser numérico mayor a 0 o menor a 9.999.999.");
                }
                else
                {
                    depa = new DepartamentoCollection();

                    int costo = int.Parse(txtCosto.Text);
                    string tipo = slcTipo.Text;
                    int comuna = int.Parse(slcComuna.SelectedValue.ToString());
                    string direccion = txtDireccion.Text;

                    var resultado = depa.InsertaDepartamento(costo, tipo, comuna, direccion);

                    if (resultado == true)
                    {
                        lblMensaje.Content = "Registro existoso";
                        this.Close();
                    }
                    else
                    {
                        lblMensaje.Content = "Error de registro";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error, contacte al administrador: " + ex.Message, "Excepción detectada", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        //Combo box que muestra un listado de Regiones y Comunas.
        private void SlcRegion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (slcRegion.SelectedIndex>0)
            {
                slcComuna.IsEnabled = true;
                int region = int.Parse(slcRegion.SelectedValue.ToString());

                CargaComuna(region);
            }
            else
            {
                slcComuna.SelectedIndex = -1;
                slcComuna.IsEnabled = false;
            }
        }
        #endregion Registro

        #region Métodos Custom

        //Metodo que carga datos de Region.
        private void CargaRegion()
        {
            depa = new DepartamentoCollection();
            var region = depa.ListaRegion();

            slcRegion.ItemsSource = region.DefaultView;
            slcRegion.SelectedValuePath = "ID_REGION";
            slcRegion.DisplayMemberPath = "NOMBRE_REGION";

            slcRegion.Items.Refresh();
        }

        //Metodo que carga datos de Comuna.
        private void CargaComuna(int region)
        {
            depa = new DepartamentoCollection();

            var comuna = depa.ListaComunaPorRegion(region);

            slcComuna.ItemsSource = comuna.DefaultView;
            slcComuna.SelectedValuePath = "ID_COMUNA";
            slcComuna.DisplayMemberPath = "NOMBRE_COMUNA";

            slcComuna.Items.Refresh();
        }
        #endregion Métodos Custom

    }
}

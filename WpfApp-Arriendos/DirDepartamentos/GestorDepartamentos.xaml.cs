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
using System.Data;
using Negocio.Clases;
using System.Text.RegularExpressions;

namespace WpfApp_Arriendos.DirDepartamentos
{
    public partial class GestorDepartamentos : Window
    {
        //Atributos de la vista.
        DepartamentoCollection depa;

        //Constructor de la clase donde se indica como debe iniciar la vista.
        public GestorDepartamentos()
        {
            InitializeComponent();
            dtgDepartamento.IsReadOnly = true;
            InventarioInvisible();
            Datos();
            
        }

        #region Navbar
        
        //Boton que dirige a la vista Funcionario.
        private void BtnFuncionario_Click(object sender, RoutedEventArgs e)
        {
            Funcionario fun = new Funcionario();
            fun.Show();
            this.Close();
        }

        //Boton que dirige a la vista Departamento.
        private void BtnDepartamento_Click(object sender, RoutedEventArgs e)
        {
            this.InvalidateVisual();
            this.UpdateLayout();
            Datos();
        }

        //Boton que dirige a la vista de Inicio.
        private void BtnInicio_Click(object sender, RoutedEventArgs e)
        {
            Dashboard home = new Dashboard();
            home.Show();
            this.Close();
        }

        //Boton que dirige a la vista Finanzas.
        private void BtnFinanzas_Click(object sender, RoutedEventArgs e)
        {

        }

        //Boton que dirige a la vista Servicios.
        private void BtnServicios_Click(object sender, RoutedEventArgs e)
        {
            DirServicios.Servicio servicio = new DirServicios.Servicio();
            servicio.Show();
            this.Close();
        }

        //Boton que dirige a la vista de Registro Departamento.
        private void BtnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            RegistroDepartamento regDepa = new RegistroDepartamento();
            regDepa.Show();
        }
        #endregion Navbar

        #region Datos Departamento

        //Tabla que muestra los datos de Departamento en la vista.
        private void DtgDepartamento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            DataRowView seleccionado = gd.SelectedItem as DataRowView;
            
            if (seleccionado!=null)
            {
                CargaCBBEstado();
                CargaCBBTipo();
                txtId.Text = seleccionado.Row[0].ToString();
                txtDireccion.Text = seleccionado.Row[1].ToString();
                txtCosto.Text = seleccionado.Row[2].ToString();

                int inventario = int.Parse(seleccionado.Row[7].ToString());

                if (inventario > 0)
                {
                    InventarioVisible();
                    dtgGaleria.Visibility = Visibility.Visible;
                    lblMensajeInventario.Content = string.Empty;
                    btnRegistraInv.Visibility = Visibility.Hidden;
                    txtInventario.Text = inventario.ToString();

                    DepartamentoCollection inv = new DepartamentoCollection();
                    var listaInv = inv.ListaInventario(inventario);

                    if (int.Parse(listaInv.Rows[0]["INTERNET"].ToString()) == 1)
                    {
                        chkInternet.IsChecked = true;
                    }
                    else
                    {
                        chkInternet.IsChecked = false;
                    }
                    txtBaño.Text = listaInv.Rows[0]["BANIO"].ToString();
                    txtDormitorio.Text = listaInv.Rows[0]["DORMITORIO"].ToString();
                    txtTv.Text = listaInv.Rows[0]["TV"].ToString();
                    txtMesas.Text = listaInv.Rows[0]["MESA"].ToString();
                    txtAsiento.Text = listaInv.Rows[0]["ASIENTO"].ToString();
                    txtMuebles.Text = listaInv.Rows[0]["MUEBLE"].ToString();
                }
                else
                {
                    InventarioInvisible();
                    lblMensajeInventario.Content = "No posee inventario, registre uno";
                    btnRegistraInv.Visibility = Visibility.Visible;
                }
                btnGaleria.Visibility = Visibility.Visible;
                dtgGaleria.Visibility = Visibility.Visible;
                DatosGaleria(int.Parse(txtId.Text));
            }
        }
        
        //Boton para realizar la accion de actualizar datos de Departamento.
        private void BtnActualizarDepa_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtDireccion.Text) || txtDireccion.Text.Length < 5 && txtDireccion.Text.Length > 200)
                {
                    MessageBox.Show("Dirección no debe estar vacío y tiene que estar entre 5 a 200 carácteres.");

                }
                else if (string.IsNullOrEmpty(txtId.Text) )
                {
                    MessageBox.Show("Código del departamento no debe estar vacío.");

                }
                else if (Regex.IsMatch(txtId.Text, "^[a-zA-Z]"))
                {
                    MessageBox.Show("Código del departamento debe ser numérico.");

                }
                else if (Regex.IsMatch(txtCosto.Text, "^[a-zA-Z]"))
                {
                    MessageBox.Show("Costo debe ser numérico.");

                }
                else if (string.IsNullOrEmpty(txtCosto.Text) || int.Parse(txtCosto.Text) <= 0 && int.Parse(txtCosto.Text) >= 9999999)
                {
                    MessageBox.Show("Costo no debe estar vacío y debe ser mayor a 0 o menor a 9.999.999");

                }
                else if (slcEstado.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un valor en Estado.");

                }
                else if (slcTipo.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un valor en Tipo.");
                }
                else
                {
                    depa = new DepartamentoCollection();
                    int id = int.Parse(txtId.Text);
                    int costo = int.Parse(txtCosto.Text);
                    string direccion = txtDireccion.Text;
                    string tipo = slcTipo.SelectedValue.ToString();
                    char estado = char.Parse(slcEstado.SelectedValue.ToString());

                    depa.ActualizaDepartamento(id, costo, estado, tipo, direccion);

                    lblMensajeDatos.Content = "Actualización correcta";
                    Datos();
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error, contacte al administrador: " + ex.Message, "Excepción detectada", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        //Boton para realizar la accion de eliminar un Departamento.
        private void BtnEliminarDepa_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtId.Text))
                {
                    MessageBox.Show("Debe seleccionar un campo.");
                }
                else
                {
                    depa = new DepartamentoCollection();

                    int id = int.Parse(txtId.Text);

                    depa.EliminarDepartamento(id);

                    lblMensajeDatos.Content = "Eliminación correcta";

                    Datos();
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error, contacte al administrador: " + ex.Message, "Excepción detectada", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
        #endregion Datos Departamento

        #region Inventario

        //Boton que realizar la accion redireccionar a Inventario para registrar datos segun el Departamento.
        private void BtnRegistraInv_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RegistraInventario inv = new RegistraInventario();
                Application.Current.Resources["id_departamento"] = txtId.Text;
                inv.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error, contacte al administrador: " + ex.Message, "Excepción detectada", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        //Boton que elimina un Inventario de la base de datos.
        private void BtnEliminarInv_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtInventario.Text))
                {
                    MessageBox.Show("Debe seleccionar un valor.");
                }
                else
                {
                    DepartamentoCollection inv = new DepartamentoCollection();
                    int inventario = int.Parse(txtInventario.Text);
                    var resultado = inv.EliminaInventario(inventario);
                    if (resultado == true)
                    {
                        inv.CambiaEstado(int.Parse(txtId.Text), char.Parse(0.ToString()));
                        lblMensajeInventario.Content = "Eliminado corrrectamente!";
                    }
                    else
                    {
                        lblMensajeInventario.Content = "Error al eliminar";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error, contacte al administrador: " + ex.Message, "Excepción detectada", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        //Boton que actualiza datos de un Inventario de la base de datos.
        private void BtnActualizarInv_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Regex.IsMatch(txtBaño.Text, "^[a-zA-Z]") || string.IsNullOrEmpty(txtBaño.Text) || int.Parse(txtBaño.Text) <= 0 && int.Parse(txtBaño.Text) >=2)
                {
                    MessageBox.Show("La cantidad de baños debe ser númerica mayor a 0 y menor a 9");
                }
                else if (string.IsNullOrEmpty(txtInventario.Text))
                {
                    MessageBox.Show("Código de inventario no debe estar vacío.");
                }
                else if (Regex.IsMatch(txtInventario.Text, "^[a-zA-Z]"))
                {
                    MessageBox.Show("Código de inventario debe ser numérico.");
                }
                else if (Regex.IsMatch(txtDormitorio.Text, "^[a-zA-Z]") || string.IsNullOrEmpty(txtDormitorio.Text) || int.Parse(txtDormitorio.Text) <= 0 && int.Parse(txtDormitorio.Text) >= 2)
                {
                    MessageBox.Show("La cantidad de dormitorios debe ser númerica mayor a 0 y menor a 9");
                }
                else if (Regex.IsMatch(txtTv.Text, "^[a-zA-Z]") || string.IsNullOrEmpty(txtTv.Text) || int.Parse(txtTv.Text) <= 0 && int.Parse(txtTv.Text) >= 2)
                {
                    MessageBox.Show("La cantidad de televisores debe ser númerica mayor a 0 y menor a 9");
                }
                else if (Regex.IsMatch(txtMesas.Text, "^[a-zA-Z]") || string.IsNullOrEmpty(txtMesas.Text) || int.Parse(txtMesas.Text) <= 0 && int.Parse(txtMesas.Text) >= 2)
                {
                    MessageBox.Show("La cantidad de mesas debe ser númerica mayor a 0 y menor a 9");
                }
                else if (Regex.IsMatch(txtAsiento.Text, "^[a-zA-Z]") || string.IsNullOrEmpty(txtAsiento.Text) || int.Parse(txtAsiento.Text) <= 0 && int.Parse(txtAsiento.Text) >= 3)
                {
                    MessageBox.Show("La cantidad de asientos debe ser númerica mayor a 0 y menor a 99");
                }
                else if (Regex.IsMatch(txtMuebles.Text, "^[a-zA-Z]") || string.IsNullOrEmpty(txtMuebles.Text) || int.Parse(txtMuebles.Text) <= 0 && int.Parse(txtMuebles.Text) >= 3)
                {
                    MessageBox.Show("La cantidad de muebles debe ser númerica mayor a 0 y menor a 99");
                }
                else
                {
                    DepartamentoCollection inv = new DepartamentoCollection();

                    int id = int.Parse(txtInventario.Text);
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
                    int mesa = int.Parse(txtMesas.Text);
                    int asiento = int.Parse(txtAsiento.Text);
                    int mueble = int.Parse(txtMuebles.Text);

                    inv.ActualizaInventario(id, internet, baños, dormitorio, tv, mesa, asiento, mueble);

                    lblMensajeInventario.Content = "Actualización correcta!";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error, contacte al administrador: " + ex.Message, "Excepción detectada", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion Inventario

        #region Galeria

        //Boton que realiza la accion de redirigir a la vista galeria segun la id de Departamento.
        private void BtnGaleria_Click(object sender, RoutedEventArgs e)
        {
            RegistroGaleria galeria = new RegistroGaleria();
            Application.Current.Resources["idDepartamento"] = txtId.Text;
            galeria.Show();
        }
        #endregion Galeria

        #region Métodos Custom

        //Metodo para verificar estado de Departamento.
        private void CargaCBBEstado()
        {
            slcEstado.DisplayMemberPath = "Text";
            slcEstado.SelectedValuePath = "Value";

            var items = new[] {
                new {Text="Listo",Value=1},
                new { Text = "No Listo", Value = 0 }
            };
            slcEstado.ItemsSource = items;
        }

        //Metodo para verificar tipo de Departamento.
        private void CargaCBBTipo()
        {
            slcTipo.DisplayMemberPath = "Text";
            slcTipo.SelectedValuePath = "Value";

            var items = new[] {
                new {Text="Básico",Value="Básico"},
                new {Text="Estándar",Value = "Estándar"},
                new {Text="Premium",Value = "Premium"}
            };
            slcTipo.ItemsSource = items;
        }

        //Metodo para limpiar campos de textos.
        private void Limpiar()
        {
            txtId.Text = string.Empty;
            txtCosto.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            slcEstado.Text = string.Empty;
            slcTipo.Text = string.Empty;
        }

        //Metodo para ocultar campos de textos y botones de Inventario.
        private void InventarioInvisible()
        {
            txtInventario.Visibility = Visibility.Hidden;
            chkInternet.Visibility = Visibility.Hidden;
            txtBaño.Visibility = Visibility.Hidden;
            txtDormitorio.Visibility = Visibility.Hidden;
            txtTv.Visibility = Visibility.Hidden;
            txtMesas.Visibility = Visibility.Hidden;
            txtAsiento.Visibility = Visibility.Hidden;
            txtMuebles.Visibility = Visibility.Hidden;

            lblInventario.Visibility = Visibility.Hidden;
            lblBaño.Visibility = Visibility.Hidden;
            lblDormitorio.Visibility = Visibility.Hidden;
            lblTv.Visibility = Visibility.Hidden;
            lblMesas.Visibility = Visibility.Hidden;
            lblAsiento.Visibility = Visibility.Hidden;
            lblMueble.Visibility = Visibility.Hidden;

            btnActualizarInv.Visibility = Visibility.Hidden;
            btnEliminarInv.Visibility = Visibility.Hidden;
        }

        //Metodo para mostrar campos de textos y botones de Inventario.
        private void InventarioVisible()
        {
            txtInventario.Visibility = Visibility.Visible;
            chkInternet.Visibility = Visibility.Visible;
            txtBaño.Visibility = Visibility.Visible;
            txtDormitorio.Visibility = Visibility.Visible;
            txtTv.Visibility = Visibility.Visible;
            txtMesas.Visibility = Visibility.Visible;
            txtAsiento.Visibility = Visibility.Visible;
            txtMuebles.Visibility = Visibility.Visible;

            lblInventario.Visibility = Visibility.Visible;
            lblBaño.Visibility = Visibility.Visible;
            lblDormitorio.Visibility = Visibility.Visible;
            lblTv.Visibility = Visibility.Visible;
            lblMesas.Visibility = Visibility.Visible;
            lblAsiento.Visibility = Visibility.Visible;
            lblMueble.Visibility = Visibility.Visible;

            btnActualizarInv.Visibility = Visibility.Visible;
            btnEliminarInv.Visibility = Visibility.Visible;
        }

        //Metodo para mostrar los datos de Departamento.
        private void Datos()
        {
            depa =new DepartamentoCollection();
            dtgDepartamento.ItemsSource = depa.ListaDepartamento().DefaultView;
            dtgDepartamento.Items.Refresh();
        }

        //Metodo para mostrar los datos de Galeria.
        private void DatosGaleria(int id_departamento)
        {
            depa =new DepartamentoCollection();
            dtgGaleria.ItemsSource = depa.ListaGaleria(id_departamento).DefaultView;
            dtgGaleria.Items.Refresh();
        }
        #endregion Métodos Custom

    }
}

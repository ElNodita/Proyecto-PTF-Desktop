using System;
using System.Windows;
using System.Windows.Controls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using LiveCharts;
using LiveCharts.Wpf;
using Negocio.Clases;
using System.Windows.Media.Imaging;

namespace WpfApp_Arriendos.DirFinanzas
{
    /// <summary>
    /// Lógica de interacción para GestorFinanzas.xaml
    /// </summary>
    public partial class GestorFinanzas : Window
    {
        //Atributos de la vista
        FinanzasCollection Fc;
        DepartamentoCollection depa;
        //Constructor de la vista
        public GestorFinanzas()
        {
            InitializeComponent();
            CargaPieChart();
            CargaLineChart();
            CargaRegion();
            CargaCBBMes();
            slcComuna.IsEnabled = false;
            slcDepartamento.IsEnabled = false;
        }
        #region Navbar
        //Boton que dirige a la vista de Inicio.
        private void BtnInicio_Click(object sender, RoutedEventArgs e)
        {
            Dashboard home = new Dashboard();
            home.Show();
            this.Close();
        }

        //Boton que dirige a la vista Funcionario.
        private void BtnFuncionario_Click(object sender, RoutedEventArgs e)
        {
            Funcionario Gf = new Funcionario();
            Gf.Show();
            this.Close();
        }

        //Boton que dirige a la vista Departamento.
        private void BtnDepartamento_Click(object sender, RoutedEventArgs e)
        {
            DirDepartamentos.GestorDepartamentos dedpa = new DirDepartamentos.GestorDepartamentos();
            dedpa.Show();
            this.Close();
        }

        //Boton que dirige a la vista Servicios.
        private void btnServicios_Click(object sender, RoutedEventArgs e)
        {
            DirServicios.Servicio Gs = new DirServicios.Servicio();
            Gs.Show();
            this.Close();
        }
        //Botón para ir a finanzas
        private void btnFinanzas_Click(object sender, RoutedEventArgs e)
        {
            //PieChart();
        }
        //Botón que recarga la página
        private void btnRecarga_Click(object sender, RoutedEventArgs e)
        {
        }
        //Botón que minimiza la página
        private void btnMinimiza_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        //Botón que cierra la página
        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion Navbar
        #region Finanza
        //Método de efecto para el gráfico de torta
        private void PieChart_DataClick(object sender, ChartPoint chartPoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartPoint.ChartView;
            foreach (PieSeries pieSeries in chart.Series)
                pieSeries.PushOut = 0;
            var seleccionarSeries = (PieSeries)chartPoint.SeriesView;
            seleccionarSeries.PushOut = 5;
        }
        //Método que genera un archivo pdf
        private void btnInforme_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (slcRegion.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar una región.");
                }
                else if (slcComuna.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar una comuna.");
                }
                else if (string.IsNullOrEmpty(txtAño.Text))
                {
                    MessageBox.Show("Debe ingresar un año");
                }
                else if (System.Text.RegularExpressions.Regex.IsMatch(txtAño.Text, "^[a-zA-Z]"))
                {
                    MessageBox.Show("El campo Año debe ser numérico.");
                }
                else if (slcmes.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un mes");
                }
                else if (slcDepartamento.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un departamento");
                }
                else
                {
                    int codigoDepartamento = int.Parse(slcDepartamento.SelectedValue.ToString());
                    int comuna = int.Parse(slcComuna.SelectedValue.ToString());
                    int mes = int.Parse(slcmes.SelectedValue.ToString());
                    int anio = int.Parse(txtAño.Text);

                    string comunaDepa = slcComuna.Text;
                    string regionDepa = slcRegion.Text;
                    Fc = new FinanzasCollection();

                    var lista = Fc.DepartamentoFinanza(codigoDepartamento, mes, anio);

                    string depaCodigo = lista.Rows[0]["DEPARTAMENTO"].ToString();
                    int depaCosto = int.Parse(lista.Rows[0]["COSTO"].ToString());
                    string depaTipo = lista.Rows[0]["TIPO"].ToString();
                    string depaDireccion = lista.Rows[0]["DIRECCIÓN"].ToString();
                    int depaMonto = int.Parse(lista.Rows[0]["MONTO"].ToString());
                    
                    if (!Directory.Exists("C:\\Informes"))
                    {
                        DirectoryInfo di = Directory.CreateDirectory("C:\\Informes");
                        GeneratePDF(depaCodigo,depaCosto,depaTipo,depaDireccion,comunaDepa,regionDepa,anio,mes, depaMonto);
                    }
                    else
                    {
                        GeneratePDF(depaCodigo, depaCosto, depaTipo, depaDireccion,comunaDepa, regionDepa,anio,mes, depaMonto);
                    }
                        
                    lblMensaje.Content = "Informe generado en C:/Informes.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error, contacte al administrador: " + ex.Message, "Excepción detectada", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        //Combo box que muestra un listado de Regiones y Comunas.
        private void slcRegion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (slcRegion.SelectedIndex >= 0)
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
        //Combo box que carga comuna y permite habilitar el combo box de departamento
        private void slcComuna_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (slcComuna.SelectedIndex >= 0)
            {
                slcDepartamento.IsEnabled = true;
                int comuna = int.Parse(slcComuna.SelectedValue.ToString());

                CargaDepartamento(comuna);
            }
            else
            {
                slcDepartamento.SelectedIndex = -1;
                slcDepartamento.IsEnabled = false;
            }
        }
        #endregion Finanza
        #region Métodos Custom
        //Método para cargar el gráfico de torta
        private void CargaPieChart()
        {
            Fc = new FinanzasCollection();

            var lista = Fc.ListMontoPorRegion();

            foreach (var lt in lista)
            {
                Graf1pc.Series.Add(
                    new PieSeries
                    {
                        Title = lt.Region,
                        StrokeThickness = 0,
                        DataLabels = true,
                        Values = new ChartValues<double> { lt.Monto }
                    });
            }
            DataContext = this;
        }
        //Método para cargar el gráfico de columnas
        private void CargaLineChart()
        {
            Fc = new FinanzasCollection();
            var lista = Fc.IngresoMensual();
            foreach (var lt in lista)
            {
                Graflc.Series.Add(
                    new ColumnSeries
                    {
                        Title = lt.Fecha,
                        StrokeThickness = 0,
                        DataLabels = true,
                        Values = new ChartValues<double> { lt.Ingreso }
                    });
            }
            DataContext = this;
        }

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

        private void CargaDepartamento(int comuna)
        {
            Fc = new FinanzasCollection();

            var departamento = Fc.ListaDepartamentosComuna(comuna);

            slcDepartamento.ItemsSource = departamento.DefaultView;
            slcDepartamento.SelectedValuePath = "DEPARTAMENTO";
            slcDepartamento.DisplayMemberPath = "DIRECCIÓN";

            slcDepartamento.Items.Refresh();
        }

        //Metodo para verificar estado de Departamento.
        private void CargaCBBMes()
        {
            slcmes.DisplayMemberPath = "Text";
            slcmes.SelectedValuePath = "Value";

            var items = new[] {
                new {Text="Enero",Value=1},
                new { Text = "Febrero", Value = 2 },
                new { Text = "Marzo", Value = 3 },
                new { Text = "Abril", Value = 4},
                new { Text = "Mayo", Value = 5 },
                new { Text = "Junio", Value = 6 },
                new { Text = "Julio", Value = 7 },
                new { Text = "Agosto", Value = 8 },
                new { Text = "Septiembre", Value = 9 },
                new { Text = "Octubre", Value = 10 },
                new { Text = "Noviembre", Value = 11},
                new { Text = "Diciembre", Value = 12}
            };
            slcmes.ItemsSource = items;
        }

        //Método que genera el archivo pdf
        public void GeneratePDF(string depaCodigo, int depaCosto,string depaTipo,string depaDireccion, string comunaDepa,string regionDepa, int anioDepa,int mesDepa,int montoDepa)
        {
            DateTime hoy = DateTime.Now;
            string fecha = DateTime.Now.Day+""+DateTime.Now.Month + "" + DateTime.Now.Year+""+DateTime.Now.Hour+""+DateTime.Now.Minute+""+DateTime.Now.Second;
            Document doc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            
            // Indicamos donde vamos a guardar el documento
            PdfWriter writer = PdfWriter.GetInstance(doc,
                        new FileStream(@"C:\Informes\"+comunaDepa+depaCodigo+fecha+ ".pdf", FileMode.Create));
            // Le colocamos el título y el autor
            // **Nota: Esto no será visible en el documento
            doc.AddTitle("Reporte Departamento");
            doc.AddCreator("Turismo Real");

            // Abrimos el archivo
            doc.Open();

            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            Paragraph parrafo2 = new Paragraph(string.Format("              REPORTE DEPARTAMENTO"), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16));
            parrafo2.SpacingBefore = 200;
            parrafo2.SpacingAfter = 0;
            parrafo2.Alignment = 1; //0-Left, 1 middle,2 Right
            doc.Add(parrafo2);

            var para = new Paragraph(hoy.ToString());
            para.Alignment = 2;
            para.Font.Size = 12;
            doc.Add(para);

            // Escribimos el encabezamiento en el documento
            doc.Add(new Paragraph("Datos Generales"));
            doc.Add(Chunk.NEWLINE);

            // Creamos una tabla que contendrá el nombre, apellido y país
            // de nuestros visitante.
            PdfPTable tblPrueba = new PdfPTable(6);
            tblPrueba.WidthPercentage = 80;

            // Configuramos el título de las columnas de la tabla
            PdfPCell codigo = new PdfPCell(new Phrase("Código", _standardFont));
            codigo.BorderWidth = 0;
            codigo.BorderWidthBottom = 0.75f;

            PdfPCell costo = new PdfPCell(new Phrase("Costo", _standardFont));
            costo.BorderWidth = 0;
            costo.BorderWidthBottom = 0.75f;

            PdfPCell tipo = new PdfPCell(new Phrase("Tipo", _standardFont));
            tipo.BorderWidth = 0;
            tipo.BorderWidthBottom = 0.75f;

            PdfPCell direccion = new PdfPCell(new Phrase("Dirección", _standardFont));
            direccion.BorderWidth = 0;
            direccion.BorderWidthBottom = 0.75f;

            PdfPCell comuna = new PdfPCell(new Phrase("Comuna", _standardFont));
            comuna.BorderWidth = 0;
            comuna.BorderWidthBottom = 0.75f;

            PdfPCell region = new PdfPCell(new Phrase("Región", _standardFont));
            region.BorderWidth = 0;
            region.BorderWidthBottom = 0.75f;

            // Añadimos las celdas a la tabla
            tblPrueba.AddCell(codigo);
            tblPrueba.AddCell(costo);
            tblPrueba.AddCell(tipo);
            tblPrueba.AddCell(direccion);
            tblPrueba.AddCell(comuna);
            tblPrueba.AddCell(region);

            // Llenamos la tabla con información
            codigo = new PdfPCell(new Phrase(depaCodigo, _standardFont));
            codigo.BorderWidth = 0;

            costo = new PdfPCell(new Phrase(depaCosto.ToString(), _standardFont));
            costo.BorderWidth = 0;

            tipo = new PdfPCell(new Phrase(depaTipo, _standardFont));
            tipo.BorderWidth = 0;

            direccion = new PdfPCell(new Phrase(depaDireccion, _standardFont));
            direccion.BorderWidth = 0;

            comuna = new PdfPCell(new Phrase(comunaDepa, _standardFont));
            comuna.BorderWidth = 0;

            region = new PdfPCell(new Phrase(regionDepa, _standardFont));
            region.BorderWidth = 0;

            // Añadimos las celdas a la tabla
            tblPrueba.AddCell(codigo);
            tblPrueba.AddCell(costo);
            tblPrueba.AddCell(tipo);
            tblPrueba.AddCell(direccion);
            tblPrueba.AddCell(comuna);
            tblPrueba.AddCell(region);

            doc.Add(tblPrueba);

            doc.Add(new Paragraph("Ingresos"));
            doc.Add(Chunk.NEWLINE);

            PdfPTable tblIngreso = new PdfPTable(3);
            tblIngreso.WidthPercentage = 80;

            PdfPCell Anio = new PdfPCell(new Phrase("Año", _standardFont));
            Anio.BorderWidth = 0;
            Anio.BorderWidthBottom = 0.75f;

            PdfPCell Mes = new PdfPCell(new Phrase("Mes", _standardFont));
            Mes.BorderWidth = 0;
            Mes.BorderWidthBottom = 0.75f;

            PdfPCell Monto = new PdfPCell(new Phrase("Monto", _standardFont));
            Monto.BorderWidth = 0;
            Monto.BorderWidthBottom = 0.75f;

            tblIngreso.AddCell(Anio);
            tblIngreso.AddCell(Mes);
            tblIngreso.AddCell(Monto);

            Anio = new PdfPCell(new Phrase(anioDepa.ToString(), _standardFont));
            Anio.BorderWidth = 0;

            Mes = new PdfPCell(new Phrase(mesDepa.ToString(), _standardFont));
            Mes.BorderWidth = 0;

            Monto = new PdfPCell(new Phrase(montoDepa.ToString(), _standardFont));
            Monto.BorderWidth = 0;

            tblIngreso.AddCell(Anio);
            tblIngreso.AddCell(Mes);
            tblIngreso.AddCell(Monto);

            doc.Add(tblIngreso);

            doc.Close();
            writer.Close();
             
        }
        #endregion Métodos Custom
    }
}

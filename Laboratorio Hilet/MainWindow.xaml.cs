using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using T.P_sqlserver;

namespace Laboratorio_Hilet
{   
    partial class MainWindow : Window
    {
        readonly private static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        readonly SqlConnection conexion = new(connectionString);
        Insert Agregar;
        Update Modificar;
        Delete Eliminar;
        int selectedview;
        public MainWindow()
        {
            InitializeComponent();
            Agregar = new(conexion);
            Modificar = new(conexion);
            Eliminar = new(conexion);
            ActualizarPacientes();
            CargarComboBox.CargarCiudades(conexion, cmboxciudad);
            ViewPacientes();
            selectedview = 1;
            Verbotones();
        }
//------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//Carga de vistas segun boton que se presione
        private void btnpacientes_Click(object sender, RoutedEventArgs e)
        {
            ActualizarPacientes();
            CargarComboBox.CargarCiudades(conexion, cmboxciudad);
            ViewPacientes();
            selectedview = 1;
        }

        private void btningresos_Click(object sender, RoutedEventArgs e)
        {
            ActualizarIngresos();
            ViewIngresos();
            CargarComboBox.CargarPacientes(conexion, cmboxPaciente, IDPaciente);
            CargarComboBox.CargarProfesionales(conexion, cmboxProfesional, IDProfesional);
            Datefechaingreso.SelectedDate = DateTime.Now;
            selectedview = 2;
        }
        private void btnLaboratorio_Click(object sender, RoutedEventArgs e)
        {
            ViewLaboratorio();
        }
        private void btnLocalidades_Click(object sender, RoutedEventArgs e)
        {
            ActualizarLocalidades();
            ViewLocalidades();
            selectedview = 3;
        }
        private void btnPersonalMedico_Click(object sender, RoutedEventArgs e)
        {
            ActualizarPersonalMedico();
            ViewMedicos();
            CargarComboBox.CargarServicios(conexion, cmboxservicios);
            selectedview = 4;
        }
        private void btnPersonalLaboratorio_Click(object sender, RoutedEventArgs e)
        {
            ActualizarPersonalLaboratorio();
            ViewPersonalLaboratorio();
            CargarComboBox.CargarCategorias(conexion, cmboxcategoriapersonal);
            CargarComboBox.CargarEspecialidades(conexion, cmboxespecialidadespersonal);
            selectedview=5;
        }
        private void btnCategorias_Click(object sender, RoutedEventArgs e)
        {
            ActualizarCategorias();
            ViewCategorias();
            selectedview=6;
        }
        private void btnEspecialidades_Click(object sender, RoutedEventArgs e)
        {
            ActualizarEspecialidades();
            ViewEspecialidades();
            selectedview=7;
        }
        private void btnPracticas_Click(object sender, RoutedEventArgs e)
        {
            ActualizarPracticas();
            ViewPracticas();
            CargarComboBox.CargarEspecialidades(conexion, cmboxespecialidadespracticas);
            CargarComboBox.CargarMuestra(conexion, cmboxmuestra);
            selectedview=8;
        }
        private void btnPracticasxIngreso_Click(object sender, RoutedEventArgs e)
        {
            ActualizarPracticasIngreso();
            ViewPracticasxIngreso();
            CargarComboBox.CargarIngresos(conexion, cmboxingresos, IDIngresos);
            CargarComboBox.CargarPracticas(conexion, cmboxpracticas, IDPracticas);
            selectedview=9;
        }
//------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //Funcionamiento de botones Agregar, Modificar, Eliminar
        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (banderaingreso)
            {
                switch (selectedview)
                {
                    case 1:
                        Agregar.Pacientes(boxnombre, boxapellido, cmboxciudad, DateNacimiento, boxdni, boxdireccion, boxaltura, boxpiso, boxdepartamento, boxcorreo, boxtelefono);
                        ActualizarPacientes();
                        break;
                    case 2:
                        Agregar.Ingresos(IDPaciente, IDProfesional, Datefechaingreso, Datefecharetiro);
                        ActualizarIngresos();
                        break;
                    case 3:
                        Agregar.Localidades(boxciudad, boxcodigopostal);
                        ActualizarLocalidades();
                        break;
                    case 4:
                        Agregar.Medicos(boxnombreprofesional, boxapellidoprofesional, cmboxservicios, boxmatriculaprofesional);
                        ActualizarPersonalMedico();
                        break;
                    case 5:
                        Agregar.PersonalLaboratorio(boxnombrepersonal, boxapellidopersonal, cmboxcategoriapersonal, cmboxespecialidadespersonal, boxmatriculapersonal);
                        ActualizarPersonalLaboratorio();
                        break;
                    case 6:
                        Agregar.Categoria(boxcategoria);
                        ActualizarCategorias();
                        break;
                    case 7:
                        Agregar.Especialidades(boxspecialidades);
                        ActualizarEspecialidades();
                        break;
                    case 8:
                        Agregar.Practicas(boxpractica, cmboxespecialidadespracticas, cmboxmuestra, boxdemora);
                        ActualizarPracticas();
                        break;
                    case 9:
                        Agregar.PracticasIngresos(IDPracticas, IDIngresos, boxresultado);
                        ActualizarPracticasIngreso();
                        break;
                }
            }
            else
            {
                banderaingreso = true;
                Verbotones(btnAgregar);
            }
        }
        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (banderaingreso)
            {
                switch (selectedview)
                {
                    case 1:
                        Modificar.Pacientes(DGPacientes, boxnombre, boxapellido, cmboxciudad, DateNacimiento, boxdni, boxdireccion, boxaltura, boxpiso, boxdepartamento, boxcorreo, boxtelefono);
                        ActualizarPacientes();
                        LimpiarPacientes();
                        break;
                    case 2:
                        Modificar.Ingresos(DGIngresos, IDPaciente, IDProfesional, Datefechaingreso, Datefechaingreso);
                        ActualizarIngresos();
                        LimpiarIngresos();
                        break;
                    case 3:
                        Modificar.Localidades(DGLocalidades, boxciudad, boxcodigopostal);
                        ActualizarLocalidades();
                        LimpiarLocalidades();
                        break;
                    case 4:
                        Modificar.Medicos(DGMedicos, boxnombreprofesional, boxapellidoprofesional, cmboxservicios, boxmatriculaprofesional);
                        ActualizarPersonalMedico();
                        LimpiarPersonalMedico();
                        break;
                    case 5:
                        Modificar.PersonalLaboratorio(DGPersonalLaboratorio, boxnombrepersonal, boxapellidopersonal, cmboxcategoriapersonal, cmboxespecialidadespersonal, boxmatriculapersonal);
                        ActualizarPersonalLaboratorio();
                        LimpiarPersonalLaboratorio();
                        break;
                    case 6:
                        Modificar.Categoria(DGCategorias, boxcategoria);
                        ActualizarCategorias();
                        LimpiarCategorias();
                        break;
                    case 7:
                        Modificar.Especialidades(DGEspecialidades, boxspecialidades);
                        ActualizarEspecialidades();
                        LimpiarEspecialidades();
                        break;
                    case 8:
                        Modificar.Practicas(DGPracticas ,boxpractica, cmboxespecialidadespracticas, cmboxmuestra, boxdemora);
                        ActualizarPracticas();
                        LimpiarPracticas();
                        break;
                    case 9:
                        Modificar.PracticasxIngreso(DGPracticasIngresos, IDPracticas, IDIngresos, boxresultado);
                        ActualizarPracticasIngreso();
                        LimpiarPracticasxIngreso();
                        break;
                }
            }
            else
            {
                banderaingreso = true;
                Verbotones(btnModificar);
            }
        }
        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (banderaingreso)
            {
                switch (selectedview)
                {
                    case 1:
                        DataRowView selectedRow = (DataRowView)DGPacientes.SelectedItem;
                        Eliminar.Pacientes(selectedRow);
                        ActualizarPacientes();
                        LimpiarPacientes();
                        break;
                    case 2:
                        selectedRow = (DataRowView)DGIngresos.SelectedItem;
                        Eliminar.Ingresos(selectedRow);
                        ActualizarIngresos();
                        LimpiarIngresos();
                        break;
                    case 3:
                        selectedRow = (DataRowView)DGLocalidades.SelectedItem;
                        Eliminar.Localidades(selectedRow);
                        ActualizarLocalidades();
                        LimpiarLocalidades();
                        break;
                    case 4:
                        selectedRow = (DataRowView)DGMedicos.SelectedItem;
                        Eliminar.Medico(selectedRow);
                        ActualizarPersonalMedico();
                        LimpiarPersonalMedico();
                        break;
                    case 5:
                        selectedRow = (DataRowView)DGPersonalLaboratorio.SelectedItem;
                        Eliminar.PersonaLaboratorio(selectedRow);
                        ActualizarPersonalLaboratorio();
                        LimpiarPersonalLaboratorio();
                        break;
                    case 6:
                        selectedRow = (DataRowView)DGCategorias.SelectedItem;
                        Eliminar.Categoria(selectedRow);
                        ActualizarCategorias();
                        LimpiarCategorias();
                        break;
                    case 7:
                        selectedRow = (DataRowView)DGEspecialidades.SelectedItem;
                        Eliminar.Especialidades(selectedRow);
                        ActualizarEspecialidades();
                        LimpiarEspecialidades();
                        break;
                    case 8:
                        selectedRow = (DataRowView)DGPracticas.SelectedItem;
                        Eliminar.Practicas(selectedRow);
                        ActualizarPracticas();
                        LimpiarPracticas();
                        break;
                    case 9:
                        selectedRow = (DataRowView)DGPracticasIngresos.SelectedItem;
                        Eliminar.PracticasIngreso(selectedRow);
                        ActualizarPracticasIngreso();
                        LimpiarPracticasxIngreso();
                        break;
                }
            }
            else
            {
                banderaingreso = true;
                Verbotones(btnEliminar);
                btnLimpiar.Visibility = Visibility.Hidden;
                DeshabilitarIngreso();
            }
        }
        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            switch (selectedview)
            {
                case 1:
                    LimpiarPacientes();
                    break;
                case 2:
                    LimpiarIngresos();
                    break;
                case 3:
                    LimpiarLocalidades();
                    break;
                case 4:
                    LimpiarPersonalMedico();                   
                    break;
                case 5:
                    LimpiarPersonalLaboratorio();
                    break;
                case 6:
                    LimpiarCategorias();
                    break;
                case 7:
                    LimpiarEspecialidades();
                    break;
                case 8:
                    LimpiarPracticas();
                    break;
                case 9:
                    LimpiarPracticasxIngreso();
                    break;
            }
        }
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Verbotones();
            banderaingreso = false;
        }
        private void DateNacimiento_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }
        private void cmboxPaciente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IDPaciente.SelectedIndex = cmboxPaciente.SelectedIndex;
        }
        private void cmboxProfesional_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IDProfesional.SelectedIndex = cmboxProfesional.SelectedIndex;
        }
        private void cmboxpracticas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IDPracticas.SelectedIndex = cmboxpracticas.SelectedIndex;
        }
        private void cmboxingresos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IDIngresos.SelectedIndex = cmboxingresos.SelectedIndex;
        }
        private void Datefechaingreso_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }
        private void Datefecharetiro_PreviewKeyDown(object sender, KeyEventArgs e)
        {
           e.Handled = true;
        }
        private void Datefechaingreso_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
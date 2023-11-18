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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;
using System.Diagnostics;
using System.Collections;

namespace T.P_sqlserver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-QT2ACQ6\\AGUSSSTIN;user id=sa;password=1234;Initial Catalog=TP_FINAL_HOSPITAL;Integrated Security=false");
        public MainWindow ()
        {
            InitializeComponent();
            Actualizar.Todo(DataPacientes, DataIngresos, DataLocalidades, DataMedicos, DataPEXL, DataCategorias, DataEspecialidades, DataPracticas, DataPRXI);
        }
        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            box1.Text = ""; CmBox1.SelectedIndex = -1; box2.Text = ""; CmBox2.SelectedIndex = -1; box3.Text = "";
            CmBox3.SelectedIndex = -1; box4.Text = ""; CmBox4.SelectedIndex = -1; box5.Text = ""; box6.Text = "";
            box7.Text = ""; box8.Text = ""; box9.Text = ""; box10.Text = ""; box11.Text = "";
        }
        bool banderaagregar = false;
        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (banderaagregar == false)
            {
                btnModificar.Visibility = Visibility.Hidden;
                btnEliminar.Visibility = Visibility.Hidden;
                btnLimpiar.Visibility = Visibility.Hidden;
                banderaagregar = true;

            }
            else
            {
                try
                {
                    int tabindex = TabControl1.SelectedIndex;
                    string query;
                    MessageBoxResult result = MessageBox.Show("¿Desea agregar este nuevo registro?", "Agregar", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    switch (result)
                    {
                        case MessageBoxResult.OK:
                            switch (tabindex)
                            {
                                case 0:
                                    query = "INSERT INTO Pacientes(nombre_paciente, apellido_paciente, id_localidades, fecha_nacimiento, dni, direccion_nombre, direccion_numero, direccion_piso, direccion_departamento, correo, telefono) VALUES (@nombre_paciente, @apellido_paciente, (SELECT id_localidades FROM Localidades WHERE nombre_localidad = @nombre_localidad), @fecha_nacimiento, @dni, @direccion_nombre, @direccion_numero, @direccion_piso, @direccion_departamento, @correo, @telefono)";
                                    using (DataTable dt = new DataTable())
                                    using (SqlCommand Command = new(query, conexion))
                                    {
                                        DateTime fechaNacimiento;
                                        Command.Parameters.AddWithValue("@nombre_paciente", string.IsNullOrWhiteSpace(box1.Text) ? DBNull.Value : box1.Text); // ?Verdadero   :Falso
                                        Command.Parameters.AddWithValue("@apellido_paciente", string.IsNullOrWhiteSpace(box2.Text) ? DBNull.Value : box2.Text);
                                        Command.Parameters.AddWithValue("@nombre_localidad", string.IsNullOrWhiteSpace(CmBox3.Text) ? DBNull.Value : CmBox3.Text);
                                        Command.Parameters.AddWithValue("@fecha_nacimiento", DateTime.TryParse(box4.Text, out fechaNacimiento) ? fechaNacimiento : DBNull.Value);
                                        Command.Parameters.AddWithValue("@dni", string.IsNullOrWhiteSpace(box5.Text) ? DBNull.Value : box5.Text);
                                        Command.Parameters.AddWithValue("@direccion_nombre", string.IsNullOrWhiteSpace(box6.Text) ? DBNull.Value : box6.Text);
                                        Command.Parameters.AddWithValue("@direccion_numero", string.IsNullOrWhiteSpace(box7.Text) ? DBNull.Value : box7.Text);
                                        Command.Parameters.AddWithValue("@direccion_piso", string.IsNullOrWhiteSpace(box8.Text) ? DBNull.Value : box8.Text);
                                        Command.Parameters.AddWithValue("@direccion_departamento", string.IsNullOrWhiteSpace(box9.Text) ? DBNull.Value : box9.Text);
                                        Command.Parameters.AddWithValue("@correo", string.IsNullOrWhiteSpace(box10.Text) ? DBNull.Value : box10.Text);
                                        Command.Parameters.AddWithValue("@telefono", string.IsNullOrWhiteSpace(box11.Text) ? DBNull.Value : box11.Text);
                                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(Command))
                                        {
                                            dataAdapter.Fill(dt);
                                        }
                                    }
                                    Actualizar.Pacientes(DataPacientes);
                                    break;
                                case 1:
                                    query = "INSERT INTO Ingresos(id_pacientes, id_profesionales, fecha_ingreso, fecha_retiro) VALUES ((SELECT id_pacientes FROM Pacientes WHERE nombre_paciente = @nombre_paciente AND apellido_paciente = @apellido_paciente AND dni = @dni), (SELECT id_profesionales FROM Profesionales WHERE nombre_profesional = @nombre_profesional AND apellido_profesional = @apellido_profesional), @fecha_ingreso, @fecha_retiro)";
                                    using (DataTable dt = new DataTable())
                                    using (SqlCommand Command = new(query, conexion))
                                    {
                                        DateTime fechaNacimiento;
                                        Command.Parameters.AddWithValue("@nombre_paciente", string.IsNullOrWhiteSpace(box1.Text) ? DBNull.Value : box1.Text); // ?Verdadero   :Falso
                                        Command.Parameters.AddWithValue("@apellido_paciente", string.IsNullOrWhiteSpace(box2.Text) ? DBNull.Value : box2.Text);
                                        Command.Parameters.AddWithValue("@dni", string.IsNullOrWhiteSpace(box3.Text) ? DBNull.Value : box3.Text);
                                        Command.Parameters.AddWithValue("@nombre_profesional", string.IsNullOrWhiteSpace(box4.Text) ? DBNull.Value : box4.Text);
                                        Command.Parameters.AddWithValue("@apellido_profesional", string.IsNullOrWhiteSpace(box5.Text) ? DBNull.Value : box5.Text);
                                        Command.Parameters.AddWithValue("@fecha_ingreso", DateTime.TryParse(box6.Text, out fechaNacimiento) ? fechaNacimiento : DBNull.Value);
                                        Command.Parameters.AddWithValue("@fecha_retiro", DateTime.TryParse(box7.Text, out fechaNacimiento) ? fechaNacimiento : DBNull.Value);
                                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(Command))
                                        {
                                            dataAdapter.Fill(dt);
                                        }
                                    }
                                    Actualizar.Ingresos(DataIngresos);
                                    break;
                                case 2:
                                    int tabindex2 = TabControl2.SelectedIndex;
                                    switch (tabindex2)
                                    {
                                        case 0:
                                            try
                                            {
                                                query = "INSERT INTO Localidades(nombre_localidad, codigo_postal) VALUES (@nombre_localidad, @codigo_postal)";
                                                using (DataTable dt = new DataTable())
                                                using (SqlCommand Command = new(query, conexion))
                                                {
                                                    Command.Parameters.AddWithValue("@nombre_localidad", string.IsNullOrWhiteSpace(box1.Text) ? DBNull.Value : box1.Text);
                                                    Command.Parameters.AddWithValue("@codigo_postal", string.IsNullOrWhiteSpace(box2.Text) ? DBNull.Value : box2.Text);
                                                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(Command))
                                                    {
                                                        dataAdapter.Fill(dt);
                                                    }
                                                }
                                                Actualizar.Localidades(DataLocalidades);
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show(ex.Message);
                                            }
                                            break;
                                        case 1:
                                            try
                                            {
                                                query = "INSERT INTO Profesionales(nombre_profesional, apellido_profesional, id_servicios, matricula_profesional) VALUES (@nombre_profesional, @apellido_profesional, (SELECT id_servicios FROM Servicios WHERE nombre_servicio = @nombre_servicio), @matricula_profesional)";
                                                using (DataTable dt = new DataTable())
                                                using (SqlCommand Command = new(query, conexion))
                                                {
                                                    Command.Parameters.AddWithValue("@nombre_profesional", string.IsNullOrWhiteSpace(box1.Text) ? DBNull.Value : box1.Text);
                                                    Command.Parameters.AddWithValue("@apellido_profesional", string.IsNullOrWhiteSpace(box2.Text) ? DBNull.Value : box2.Text);
                                                    Command.Parameters.AddWithValue("@nombre_servicio", string.IsNullOrWhiteSpace(CmBox3.Text) ? DBNull.Value : CmBox3.Text);
                                                    Command.Parameters.AddWithValue("@matricula_profesional", string.IsNullOrWhiteSpace(box4.Text) ? DBNull.Value : box4.Text);
                                                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(Command))
                                                    {
                                                        dataAdapter.Fill(dt);
                                                    }
                                                }
                                                Actualizar.PersonalMedico(DataMedicos);
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show(ex.Message);
                                            }
                                            break;
                                        case 2:
                                            try
                                            {
                                                query = "INSERT INTO Personal_Laboratorio(nombre_personal, apellido_personal, id_categorias, id_especialidades, matricula_personal) VALUES (@nombre_personal, @apellido_personal, (SELECT id_categorias FROM Categoria WHERE nombre_categoria = @nombre_categoria), (SELECT id_especialidades FROM Especialidades WHERE nombre_especialidad = @nombre_especialidad), @matricula_personal)";
                                                using (DataTable dt = new DataTable())
                                                using (SqlCommand Command = new(query, conexion))
                                                {
                                                    Command.Parameters.AddWithValue("@nombre_personal", string.IsNullOrWhiteSpace(box1.Text) ? DBNull.Value : box1.Text);
                                                    Command.Parameters.AddWithValue("@apellido_personal", string.IsNullOrWhiteSpace(box2.Text) ? DBNull.Value : box2.Text);
                                                    Command.Parameters.AddWithValue("@nombre_categoria", string.IsNullOrWhiteSpace(CmBox3.Text) ? DBNull.Value : CmBox3.Text);
                                                    Command.Parameters.AddWithValue("@nombre_especialidad", string.IsNullOrWhiteSpace(CmBox4.Text) ? DBNull.Value : CmBox4.Text);
                                                    Command.Parameters.AddWithValue("@matricula_personal", string.IsNullOrWhiteSpace(box5.Text) ? DBNull.Value : box5.Text);
                                                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(Command))
                                                    {
                                                        dataAdapter.Fill(dt);
                                                    }
                                                }
                                                Actualizar.PersonalLaboratorio(DataPEXL);
                                                Actualizar.Especialidades(DataEspecialidades);
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show(ex.Message);
                                            }
                                            break;
                                        case 3:
                                            try
                                            {
                                                query = "INSERT INTO Categoria(nombre_categoria) VALUES (@nombre_categoria)";
                                                using (DataTable dt = new DataTable())
                                                using (SqlCommand Command = new(query, conexion))
                                                {
                                                    Command.Parameters.AddWithValue("@nombre_categoria", string.IsNullOrWhiteSpace(box1.Text) ? DBNull.Value : box1.Text);

                                                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(Command))
                                                    {
                                                        dataAdapter.Fill(dt);
                                                    }
                                                }
                                                Actualizar.Categorias(DataCategorias);
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show(ex.Message);
                                            }
                                            break;
                                        case 4:
                                            try
                                            {
                                                query = "INSERT INTO Especialidades(nombre_especialidad) VALUES (@nombre_especialidad)";
                                                using (DataTable dt = new DataTable())
                                                using (SqlCommand Command = new(query, conexion))
                                                {
                                                    Command.Parameters.AddWithValue("@nombre_especialidad", string.IsNullOrWhiteSpace(box1.Text) ? DBNull.Value : box1.Text);
                                                    //Command.Parameters.AddWithValue("@nombre_categoria", string.IsNullOrWhiteSpace(CmBox2.Text) ? DBNull.Value : CmBox2.Text);
                                                    //Command.Parameters.AddWithValue("@nombre_personal", string.IsNullOrWhiteSpace(box3.Text) ? DBNull.Value : box3.Text);
                                                    //Command.Parameters.AddWithValue("@apellido_personal", string.IsNullOrWhiteSpace(box4.Text) ? DBNull.Value : box4.Text);
                                                    //Command.Parameters.AddWithValue("@matricula_personal", string.IsNullOrWhiteSpace(box5.Text) ? DBNull.Value : box5.Text);
                                                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(Command))
                                                    {
                                                        dataAdapter.Fill(dt);
                                                    }
                                                }
                                                Actualizar.Especialidades(DataEspecialidades);
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show(ex.Message);
                                            }
                                            break;
                                        case 5:
                                            try
                                            {
                                                query = "INSERT INTO Practicas(nombre_practica, id_especialidades, id_muestras, tiempo_demora_practica) VALUES (@nombre_practica, (SELECT id_especialidades FROM Especialidades WHERE nombre_especialidad = @nombre_especialidad), (SELECT id_muestras FROM Tipos_de_Muestras WHERE nombre_muestra = @nombre_muestra), @tiempo_demora_practica)";
                                                using (DataTable dt = new DataTable())
                                                using (SqlCommand Command = new(query, conexion))
                                                {
                                                    Command.Parameters.AddWithValue("@nombre_practica", string.IsNullOrWhiteSpace(box1.Text) ? DBNull.Value : box1.Text);
                                                    Command.Parameters.AddWithValue("@nombre_especialidad", string.IsNullOrWhiteSpace(CmBox2.Text) ? DBNull.Value : CmBox2.Text);
                                                    Command.Parameters.AddWithValue("@nombre_muestra", string.IsNullOrWhiteSpace(CmBox3.Text) ? DBNull.Value : CmBox3.Text);
                                                    Command.Parameters.AddWithValue("@tiempo_demora_practica", string.IsNullOrWhiteSpace(box4.Text) ? DBNull.Value : box4.Text);
                                                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(Command))
                                                    {
                                                        dataAdapter.Fill(dt);
                                                    }
                                                }
                                                Actualizar.Practicas(DataPracticas);
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show(ex.Message);
                                            }
                                            break;
                                    }
                                    break;
                            }
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        bool banderaModificar = false;
        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (banderaModificar == false)
            {
                btnAgregar.Visibility = Visibility.Hidden;
                btnEliminar.Visibility = Visibility.Hidden;
                btnLimpiar.Visibility = Visibility.Hidden;
                banderaModificar = true;
            }
            else
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("¿Desea modificar el registro?", "Modificar", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    switch (result)
                    {
                        case MessageBoxResult.OK:
                            int tabindex = TabControl1.SelectedIndex;
                            DateTime fechaNacimiento;
                            switch (tabindex)
                            {
                                case 0:
                                    DataRowView selectedRow = (DataRowView)DataPacientes.SelectedItem;
                                    string query = "UPDATE Pacientes SET nombre_paciente=@nombre_paciente, apellido_paciente=@apellido_paciente, id_localidades=@id_localidades, fecha_nacimiento=@fecha_nacimiento, dni=@dni," +
                                    " direccion_nombre=@direccion_nombre, direccion_numero=@direccion_numero, direccion_piso=@direccion_piso, direccion_departamento=@direccion_departamento, correo=@correo, telefono=@telefono WHERE id_pacientes=@id_pacientes;";
                                    using (SqlCommand command = new SqlCommand(query, conexion))
                                    {
                                        command.Parameters.AddWithValue("@nombre_paciente", string.IsNullOrWhiteSpace(box1.Text) ? DBNull.Value : box1.Text);
                                        command.Parameters.AddWithValue("@apellido_paciente", string.IsNullOrWhiteSpace(box2.Text) ? DBNull.Value : box2.Text);
                                        command.Parameters.AddWithValue("@id_localidades", CmBox3.SelectedIndex > 0 ? CmBox3.SelectedIndex : "0");
                                        command.Parameters.AddWithValue("@fecha_nacimiento", DateTime.TryParse(box4.Text, out fechaNacimiento) ? fechaNacimiento : DBNull.Value);
                                        command.Parameters.AddWithValue("@dni", string.IsNullOrWhiteSpace(box5.Text) ? DBNull.Value : box5.Text);
                                        command.Parameters.AddWithValue("@direccion_nombre", string.IsNullOrWhiteSpace(box6.Text) ? DBNull.Value : box6.Text);
                                        command.Parameters.AddWithValue("@direccion_numero", string.IsNullOrWhiteSpace(box7.Text) ? DBNull.Value : box7.Text);
                                        command.Parameters.AddWithValue("@direccion_piso", string.IsNullOrWhiteSpace(box8.Text) ? DBNull.Value : box8.Text);
                                        command.Parameters.AddWithValue("@direccion_departamento", string.IsNullOrWhiteSpace(box9.Text) ? DBNull.Value : box9.Text);
                                        command.Parameters.AddWithValue("@correo", string.IsNullOrWhiteSpace(box10.Text) ? DBNull.Value : box10.Text);
                                        command.Parameters.AddWithValue("@telefono", string.IsNullOrWhiteSpace(box11.Text) ? DBNull.Value : box11.Text);
                                        command.Parameters.AddWithValue("@id_pacientes", selectedRow.Row["ID"].ToString());
                                        using (SqlDataAdapter dataAdapter = new(command))
                                        using (DataTable dt = new DataTable())
                                        {
                                            dataAdapter.Fill(dt);
                                        }
                                    }
                                    Actualizar.Pacientes(DataPacientes);
                                    Actualizar.PracticasIngreso(DataPRXI);
                                    DataPacientes.SelectedIndex = 0;
                                    break;
                                case 1:
                                    selectedRow = (DataRowView)DataIngresos.SelectedItem;
                                    query = "UPDATE Ingresos SET nombre_paciente=@nombre_paciente, apellido_paciente=@apellido_paciente, dni=@dni, nombre_profesional=@nombre_profesional, apellido_profesional=@apellido_profesional, fecha_ingreso=@fecha_ingreso, fecha_retiro=@fecha_retiro WHERE id_practicas=@id_practicas";
                                    using (DataTable dt = new DataTable())
                                    using (SqlCommand Command = new(query, conexion))
                                    {
                                        Command.Parameters.AddWithValue("@nombre_paciente", string.IsNullOrWhiteSpace(box1.Text) ? DBNull.Value : box1.Text);
                                        Command.Parameters.AddWithValue("@apellido_paciente", string.IsNullOrWhiteSpace(box2.Text) ? DBNull.Value : box2.Text);
                                        Command.Parameters.AddWithValue("@dni", string.IsNullOrWhiteSpace(box3.Text) ? DBNull.Value : box3.Text);
                                        Command.Parameters.AddWithValue("@nombre_profesional", string.IsNullOrWhiteSpace(box4.Text) ? DBNull.Value : box4.Text);
                                        Command.Parameters.AddWithValue("@apellido_profesional", string.IsNullOrWhiteSpace(box5.Text) ? DBNull.Value : box5.Text);
                                        Command.Parameters.AddWithValue("@fecha_ingreso", DateTime.TryParse(box6.Text, out fechaNacimiento) ? fechaNacimiento : DBNull.Value);
                                        Command.Parameters.AddWithValue("@fecha_retiro", DateTime.TryParse(box7.Text, out fechaNacimiento) ? fechaNacimiento : DBNull.Value);
                                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(Command))
                                        {
                                            dataAdapter.Fill(dt);
                                        }
                                    }
                                    Actualizar.Ingresos(DataIngresos);
                                    DataIngresos.SelectedIndex = 0;
                                    break;
                                case 2:
                                    switch (TabControl2.SelectedIndex)
                                    {
                                        case 0:
                                            selectedRow = (DataRowView)DataLocalidades.SelectedItem;
                                            query = "UPDATE Localidades SET nombre_localidad=@nombre_localidad, codigo_postal=@codigo_postal WHERE id_localidades=@id_localidades";
                                            using (DataTable dt = new DataTable())
                                            using (SqlCommand Command = new(query, conexion))
                                            {
                                                Command.Parameters.AddWithValue("@nombre_localidad", string.IsNullOrWhiteSpace(box1.Text) ? DBNull.Value : box1.Text);
                                                Command.Parameters.AddWithValue("@codigo_postal", string.IsNullOrWhiteSpace(box2.Text) ? DBNull.Value : box2.Text);
                                                Command.Parameters.AddWithValue("@id_localidades", selectedRow.Row["ID"].ToString());
                                                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(Command))
                                                {
                                                    dataAdapter.Fill(dt);
                                                }
                                            }
                                            Actualizar.Localidades(DataLocalidades);
                                            DataLocalidades.SelectedIndex = 0;
                                            break;
                                        case 1:
                                            selectedRow = (DataRowView)DataMedicos.SelectedItem;
                                            query = "UPDATE Profesionales SET nombre_profesional=@nombre_profesional, apellido_profesional=@apellido_profesional, id_servicios=(SELECT DISTINCT id_servicios FROM Servicios WHERE nombre_servicio = @nombre_servicio), matricula_profesional=@matricula_profesional WHERE id_profesionales=@id_profesionales";
                                            using (DataTable dt = new DataTable())
                                            using (SqlCommand Command = new(query, conexion))
                                            {
                                                Command.Parameters.AddWithValue("@nombre_profesional", string.IsNullOrWhiteSpace(box1.Text) ? DBNull.Value : box1.Text);
                                                Command.Parameters.AddWithValue("@apellido_profesional", string.IsNullOrWhiteSpace(box2.Text) ? DBNull.Value : box2.Text);
                                                Command.Parameters.AddWithValue("@nombre_servicio", string.IsNullOrWhiteSpace(CmBox3.Text) ? DBNull.Value : CmBox3.Text);
                                                Command.Parameters.AddWithValue("@matricula_profesional", string.IsNullOrWhiteSpace(box4.Text) ? DBNull.Value : box4.Text);
                                                Command.Parameters.AddWithValue("@id_profesionales", selectedRow.Row["ID"].ToString());

                                                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(Command))
                                                {
                                                    dataAdapter.Fill(dt);
                                                }
                                            }
                                            Actualizar.PersonalMedico(DataMedicos);
                                            DataMedicos.SelectedIndex = 0;
                                            break;
                                        case 2:
                                            selectedRow = (DataRowView)DataPEXL.SelectedItem;
                                            query = "UPDATE Personal_Laboratorio SET nombre_personal=@nombre_personal, apellido_personal=@apellido_personal, id_categorias=(SELECT DISTINCT id_categorias FROM Categoria WHERE nombre_categoria = @nombre_categoria), id_especialidades=(SELECT DISTINCT id_especialidades FROM Especialidades WHERE nombre_especialidad = @nombre_especialidad), matricula_personal=@matricula_personal WHERE id_personal=@id_personal";
                                            using (DataTable dt = new DataTable())
                                            using (SqlCommand Command = new(query, conexion))
                                            {
                                                Command.Parameters.AddWithValue("@nombre_personal", string.IsNullOrWhiteSpace(box1.Text) ? DBNull.Value : box1.Text);
                                                Command.Parameters.AddWithValue("@apellido_personal", string.IsNullOrWhiteSpace(box2.Text) ? DBNull.Value : box2.Text);
                                                Command.Parameters.AddWithValue("@nombre_categoria", string.IsNullOrWhiteSpace(CmBox3.Text) ? DBNull.Value : CmBox3.Text);
                                                Command.Parameters.AddWithValue("@nombre_especialidad", string.IsNullOrWhiteSpace(CmBox4.Text) ? DBNull.Value : CmBox4.Text);
                                                Command.Parameters.AddWithValue("@matricula_personal", string.IsNullOrWhiteSpace(box5.Text) ? DBNull.Value : box5.Text);
                                                Command.Parameters.AddWithValue("@id_personal", selectedRow.Row["ID"].ToString());
                                                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(Command))
                                                {
                                                    dataAdapter.Fill(dt);
                                                }
                                            }
                                            Actualizar.PersonalLaboratorio(DataPEXL);
                                            DataPEXL.SelectedIndex = 0;
                                            break;
                                        case 3:
                                            selectedRow = (DataRowView)DataCategorias.SelectedItem;
                                            query = "UPDATE Categoria SET nombre_categoria=@nombre_categoria WHERE id_categorias=@id_categorias";
                                            using (DataTable dt = new DataTable())
                                            using (SqlCommand Command = new(query, conexion))
                                            {
                                                Command.Parameters.AddWithValue("@nombre_categoria", string.IsNullOrWhiteSpace(box1.Text) ? DBNull.Value : box1.Text);
                                                Command.Parameters.AddWithValue("@id_categorias", selectedRow.Row["ID"].ToString());
                                                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(Command))
                                                {
                                                    dataAdapter.Fill(dt);
                                                }
                                            }
                                            Actualizar.Categorias(DataCategorias);
                                            DataCategorias.SelectedIndex = 0;
                                            break;
                                        case 4:
                                            selectedRow = (DataRowView)DataEspecialidades.SelectedItem;
                                            query = "UPDATE Especialidades SET nombre_especialidad=@nombre_especialidad WHERE id_especialidades=@id_especialidades";
                                            using (DataTable dt = new DataTable())
                                            using (SqlCommand Command = new(query, conexion))
                                            {
                                                Command.Parameters.AddWithValue("@nombre_especialidad", string.IsNullOrWhiteSpace(box1.Text) ? DBNull.Value : box1.Text);
                                                Command.Parameters.AddWithValue("@id_especialidades", selectedRow.Row["ID"].ToString());
                                                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(Command))
                                                {
                                                    dataAdapter.Fill(dt);
                                                }
                                            }
                                            Actualizar.Especialidades(DataEspecialidades);
                                            DataEspecialidades.SelectedIndex = 0;
                                            break;
                                        case 5:
                                            selectedRow = (DataRowView)DataPracticas.SelectedItem;
                                            query = "UPDATE Practicas SET nombre_practica=@nombre_practica, id_especialidades=(SELECT DISTINCT id_especialidades FROM Especialidades WHERE nombre_especialidad = @nombre_especialidad), id_muestras=(SELECT DISTINCT id_muestras FROM Tipos_de_Muestras WHERE nombre_muestra = @nombre_muestra) WHERE id_practicas=@id_practicas";
                                            using (DataTable dt = new DataTable())
                                            using (SqlCommand Command = new(query, conexion))
                                            {
                                                Command.Parameters.AddWithValue("@nombre_practica", string.IsNullOrWhiteSpace(box1.Text) ? DBNull.Value : box1.Text);
                                                Command.Parameters.AddWithValue("@nombre_especialidad", string.IsNullOrWhiteSpace(CmBox2.Text) ? DBNull.Value : CmBox2.Text);
                                                Command.Parameters.AddWithValue("@nombre_muestra", string.IsNullOrWhiteSpace(CmBox3.Text) ? DBNull.Value : CmBox3.Text);
                                                Command.Parameters.AddWithValue("@tiempo_demora_practica", string.IsNullOrWhiteSpace(box4.Text) ? DBNull.Value : box4.Text);
                                                Command.Parameters.AddWithValue("@id_practicas", selectedRow.Row["ID"].ToString());
                                                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(Command))
                                                {
                                                    dataAdapter.Fill(dt);
                                                }
                                            }
                                            Actualizar.Practicas(DataPracticas);
                                            DataPracticas.SelectedIndex = 0;
                                            break;
                                        case 6:
                                            selectedRow = (DataRowView)DataPRXI.SelectedItem;
                                            query = "UPDATE PracticasxIngreso SET resultado=@resultado WHERE id_practicasxingreso=@id_practicasxingreso";
                                            using (DataTable dt = new DataTable())
                                            using (SqlCommand Command = new(query, conexion))
                                            {
                                                Command.Parameters.AddWithValue("@resultado", string.IsNullOrWhiteSpace(box1.Text) ? DBNull.Value : box1.Text);
                                                Command.Parameters.AddWithValue("@id_practicasxingreso", selectedRow.Row["ID"].ToString());
                                                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(Command))
                                                {
                                                    dataAdapter.Fill(dt);
                                                }
                                            }
                                            Actualizar.Practicas(DataPRXI);
                                            DataPRXI.SelectedIndex = 0;
                                            break;
                                    }
                                    break;
                            }
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        bool banderaEliminar = false;
        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (banderaEliminar == false)
            {
                btnAgregar.Visibility = Visibility.Hidden;
                btnModificar.Visibility = Visibility.Hidden;
                btnLimpiar.Visibility = Visibility.Hidden;
                banderaEliminar = true;
            }
            else
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("¿Desea eliminar el registro?", "Eliminar", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    switch (result)
                    {
                        case MessageBoxResult.OK:
                            int tabindex = TabControl1.SelectedIndex;
                            switch (tabindex)
                            {
                                case 0:
                                    DataRowView selectedRow = (DataRowView)DataPacientes.SelectedItem;
                                    string query = "DELETE FROM Pacientes WHERE id_pacientes=@id_pacientes";
                                    using (SqlCommand command = new SqlCommand(query, conexion))
                                    {
                                        command.Parameters.AddWithValue("@id_pacientes", selectedRow.Row["ID"].ToString());
                                        using (SqlDataAdapter dataAdapter = new(command))
                                        using (DataTable dt = new DataTable())
                                        {
                                            dataAdapter.Fill(dt);
                                        }
                                    }
                                    Actualizar.Pacientes(DataPacientes);
                                    break;
                                case 1:
                                    selectedRow = (DataRowView)DataIngresos.SelectedItem;
                                    query = "DELETE FROM Ingresos WHERE id_ingresos=@id_ingresos";
                                    using (SqlCommand command = new SqlCommand(query, conexion))
                                    {
                                        command.Parameters.AddWithValue("@id_ingresos", selectedRow.Row["ID"].ToString());
                                        using (SqlDataAdapter dataAdapter = new(command))
                                        using (DataTable dt = new DataTable())
                                        {
                                            dataAdapter.Fill(dt);
                                        }
                                    }
                                    Actualizar.Ingresos(DataIngresos);
                                    break;
                                case 2:
                                    switch (TabControl2.SelectedIndex)
                                    {
                                        case 0:
                                            selectedRow = (DataRowView)DataIngresos.SelectedItem;
                                            query = "DELETE FROM Localidades WHERE id_localidades=@id_localidades";
                                            using (SqlCommand command = new SqlCommand(query, conexion))
                                            {
                                                command.Parameters.AddWithValue("@id_localidades", selectedRow.Row["ID"].ToString());
                                                using (SqlDataAdapter dataAdapter = new(command))
                                                using (DataTable dt = new DataTable())
                                                {
                                                    dataAdapter.Fill(dt);
                                                }
                                            }
                                            Actualizar.Localidades(DataLocalidades);
                                            break;
                                        case 1:
                                            selectedRow = (DataRowView)DataMedicos.SelectedItem;
                                            query = "DELETE FROM Profesionales WHERE id_Profesionales=@id_Profesionales";
                                            using (SqlCommand command = new SqlCommand(query, conexion))
                                            {
                                                command.Parameters.AddWithValue("@id_Profesionales", selectedRow.Row["ID"].ToString());
                                                using (SqlDataAdapter dataAdapter = new(command))
                                                using (DataTable dt = new DataTable())
                                                {
                                                    dataAdapter.Fill(dt);
                                                }
                                            }
                                            Actualizar.PersonalMedico(DataMedicos);
                                            break;
                                        case 2:
                                            selectedRow = (DataRowView)DataPEXL.SelectedItem;
                                            query = "DELETE FROM Personal_Laboratorio WHERE id_personal=@id_personal";
                                            using (SqlCommand command = new SqlCommand(query, conexion))
                                            {
                                                command.Parameters.AddWithValue("@id_personal", selectedRow.Row["ID"].ToString());
                                                using (SqlDataAdapter dataAdapter = new(command))
                                                using (DataTable dt = new DataTable())
                                                {
                                                    dataAdapter.Fill(dt);
                                                }
                                            }
                                            Actualizar.PersonalLaboratorio(DataPEXL);
                                            break;
                                        case 3:
                                            selectedRow = (DataRowView)DataCategorias.SelectedItem;
                                            query = "DELETE FROM Categorias WHERE id_categoria=@id_categoria";
                                            using (SqlCommand command = new SqlCommand(query, conexion))
                                            {
                                                command.Parameters.AddWithValue("@id_categoria", selectedRow.Row["ID"].ToString());
                                                using (SqlDataAdapter dataAdapter = new(command))
                                                using (DataTable dt = new DataTable())
                                                {
                                                    dataAdapter.Fill(dt);
                                                }
                                            }
                                            Actualizar.Categorias(DataCategorias);
                                            break;
                                        case 4:
                                            selectedRow = (DataRowView)DataEspecialidades.SelectedItem;
                                            query = "DELETE FROM Especialidades WHERE id_especialidades=@id_especialidades";
                                            using (SqlCommand command = new SqlCommand(query, conexion))
                                            {
                                                command.Parameters.AddWithValue("@id_especialidades", selectedRow.Row["ID"].ToString());
                                                using (SqlDataAdapter dataAdapter = new(command))
                                                using (DataTable dt = new DataTable())
                                                {
                                                    dataAdapter.Fill(dt);
                                                }
                                            }
                                            Actualizar.Especialidades(DataEspecialidades);
                                            break;
                                        case 5:
                                            selectedRow = (DataRowView)DataPracticas.SelectedItem;
                                            query = "DELETE FROM Practicas WHERE id_practicas=@id_practicas";
                                            using (SqlCommand command = new SqlCommand(query, conexion))
                                            {
                                                command.Parameters.AddWithValue("@id_practicas", selectedRow.Row["ID"].ToString());
                                                using (SqlDataAdapter dataAdapter = new(command))
                                                using (DataTable dt = new DataTable())
                                                {
                                                    dataAdapter.Fill(dt);
                                                }
                                            }
                                            Actualizar.Practicas(DataPracticas);
                                            break;
                                        case 6:
                                            selectedRow = (DataRowView)DataIngresos.SelectedItem;
                                            query = "DELETE FROM Localidades WHERE id_localidades=@id_localidades";
                                            using (SqlCommand command = new SqlCommand(query, conexion))
                                            {
                                                command.Parameters.AddWithValue("@id_localidades", selectedRow.Row["ID"].ToString());
                                                using (SqlDataAdapter dataAdapter = new(command))
                                                using (DataTable dt = new DataTable())
                                                {
                                                    dataAdapter.Fill(dt);
                                                }
                                            }
                                            Actualizar.Localidades(DataLocalidades);
                                            break;
                                    }
                                    break;
                            }
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            btnAgregar.Visibility = Visibility.Visible;
            btnModificar.Visibility = Visibility.Visible;
            btnEliminar.Visibility = Visibility.Visible;
            btnLimpiar.Visibility = Visibility.Visible;
            banderaagregar = false;
            banderaModificar = false;
            banderaEliminar = false;
        }
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            conexion.Dispose();
            this.Close();
        }
        private void DataPacientes_Loaded(object sender, RoutedEventArgs e)
        {
            btnLimpiar_Click(sender, e);
            if (DataPacientes.Columns.Count > 0)
            {
                Label1.Content = DataPacientes.Columns[0].Header.ToString(); Label1.Visibility = Visibility.Visible; box1.Visibility = Visibility.Visible; CmBox1.Visibility = Visibility.Hidden;
                Label2.Content = DataPacientes.Columns[1].Header.ToString(); Label2.Visibility = Visibility.Visible; box2.Visibility = Visibility.Visible; CmBox2.Visibility = Visibility.Hidden;
                Label3.Content = DataPacientes.Columns[2].Header.ToString(); Label3.Visibility = Visibility.Visible; box3.Visibility = Visibility.Hidden; CmBox3.Visibility = Visibility.Visible;
                CargarComboBox.CargarCiudades(CmBox3);
                Label4.Content = DataPacientes.Columns[3].Header.ToString(); Label4.Visibility = Visibility.Visible; box4.Visibility = Visibility.Visible; CmBox4.Visibility = Visibility.Hidden;
                Label5.Content = DataPacientes.Columns[4].Header.ToString(); Label5.Visibility = Visibility.Visible; box5.Visibility = Visibility.Visible;
                Label6.Content = DataPacientes.Columns[5].Header.ToString(); Label6.Visibility = Visibility.Visible; box6.Visibility = Visibility.Visible;
                Label7.Content = DataPacientes.Columns[6].Header.ToString(); Label7.Visibility = Visibility.Visible; box7.Visibility = Visibility.Visible;
                Label8.Content = DataPacientes.Columns[7].Header.ToString(); Label8.Visibility = Visibility.Visible; box8.Visibility = Visibility.Visible;
                Label9.Content = DataPacientes.Columns[8].Header.ToString(); Label9.Visibility = Visibility.Visible; box9.Visibility = Visibility.Visible;
                Label10.Content = DataPacientes.Columns[9].Header.ToString(); Label10.Visibility = Visibility.Visible; box10.Visibility = Visibility.Visible;
                Label11.Content = DataPacientes.Columns[10].Header.ToString(); Label11.Visibility = Visibility.Visible; box11.Visibility = Visibility.Visible;
                btnAgregar.Visibility = Visibility.Visible;
            }
        }
        private void DataIngresos_Loaded(object sender, RoutedEventArgs e)
        {
            btnLimpiar_Click(sender, e);
            if (DataIngresos.Columns.Count > 0)
            {
                Label1.Content = "Pacientes"; Label1.Visibility = Visibility.Visible; box1.Visibility = Visibility.Hidden; CmBox1.Visibility = Visibility.Visible;
                CargarComboBox.CargarPacientes(CmBox1, CmBox3);
                Label2.Content = "Profesionales"; Label2.Visibility = Visibility.Visible; box2.Visibility = Visibility.Hidden; CmBox2.Visibility = Visibility.Visible;
                CargarComboBox.CargarProfesionales(CmBox2, CmBox4);
                Label3.Content = DataIngresos.Columns[5].Header.ToString(); Label3.Visibility = Visibility.Visible; box3.Visibility = Visibility.Visible; CmBox3.Visibility = Visibility.Hidden;
                Label4.Content = DataIngresos.Columns[6].Header.ToString(); Label4.Visibility = Visibility.Visible; box4.Visibility = Visibility.Visible; CmBox4.Visibility = Visibility.Hidden;
                Label5.Visibility = Visibility.Hidden; box5.Visibility = Visibility.Hidden;
                Label6.Visibility = Visibility.Hidden; box6.Visibility = Visibility.Hidden;
                Label7.Visibility = Visibility.Hidden; box7.Visibility = Visibility.Hidden;
                Label8.Visibility = Visibility.Hidden; box8.Visibility = Visibility.Hidden;
                Label9.Visibility = Visibility.Hidden; box9.Visibility = Visibility.Hidden;
                Label10.Visibility = Visibility.Hidden; box10.Visibility = Visibility.Hidden;
                Label11.Visibility = Visibility.Hidden; box11.Visibility = Visibility.Hidden;
                btnAgregar.Visibility = Visibility.Visible;
            }
        }
        private void DataLocalidades_Loaded(object sender, RoutedEventArgs e)
        {
            btnLimpiar_Click(sender, e);
            if (DataLocalidades.Columns.Count > 0)
            {
                Label1.Content = DataLocalidades.Columns[0].Header.ToString(); Label1.Visibility = Visibility.Visible; box1.Visibility = Visibility.Visible; CmBox1.Visibility = Visibility.Hidden;
                Label2.Content = DataLocalidades.Columns[1].Header.ToString(); Label2.Visibility = Visibility.Visible; box2.Visibility = Visibility.Visible; CmBox2.Visibility = Visibility.Hidden;
                Label3.Visibility = Visibility.Hidden; box3.Visibility = Visibility.Hidden; CmBox3.Visibility = Visibility.Hidden;
                Label4.Visibility = Visibility.Hidden; box4.Visibility = Visibility.Hidden; CmBox4.Visibility = Visibility.Hidden;
                Label5.Visibility = Visibility.Hidden; box5.Visibility = Visibility.Hidden;
                Label6.Visibility = Visibility.Hidden; box6.Visibility = Visibility.Hidden;
                Label7.Visibility = Visibility.Hidden; box7.Visibility = Visibility.Hidden;
                Label8.Visibility = Visibility.Hidden; box8.Visibility = Visibility.Hidden;
                Label9.Visibility = Visibility.Hidden; box9.Visibility = Visibility.Hidden;
                Label10.Visibility = Visibility.Hidden; box10.Visibility = Visibility.Hidden;
                Label11.Visibility = Visibility.Hidden; box11.Visibility = Visibility.Hidden;
                btnAgregar.Visibility = Visibility.Visible;
            }
        }
        private void DataMedicos_Loaded(object sender, RoutedEventArgs e)
        {
            btnLimpiar_Click(sender, e);
            if (DataMedicos.Columns.Count > 0)
            {
                Label1.Content = DataMedicos.Columns[0].Header.ToString(); Label1.Visibility = Visibility.Visible; box1.Visibility = Visibility.Visible; CmBox1.Visibility = Visibility.Hidden;
                Label2.Content = DataMedicos.Columns[1].Header.ToString(); Label2.Visibility = Visibility.Visible; box2.Visibility = Visibility.Visible; CmBox2.Visibility = Visibility.Hidden;
                Label3.Content = DataMedicos.Columns[2].Header.ToString(); Label3.Visibility = Visibility.Visible; box3.Visibility = Visibility.Hidden; CmBox3.Visibility = Visibility.Visible;
                CargarComboBox.CargarServicios(CmBox3);
                Label4.Content = DataMedicos.Columns[3].Header.ToString(); Label4.Visibility = Visibility.Visible; box4.Visibility = Visibility.Visible; CmBox4.Visibility = Visibility.Hidden;
                Label5.Visibility = Visibility.Hidden; box5.Visibility = Visibility.Hidden;
                Label6.Visibility = Visibility.Hidden; box6.Visibility = Visibility.Hidden;
                Label7.Visibility = Visibility.Hidden; box7.Visibility = Visibility.Hidden;
                Label8.Visibility = Visibility.Hidden; box8.Visibility = Visibility.Hidden;
                Label9.Visibility = Visibility.Hidden; box9.Visibility = Visibility.Hidden;
                Label10.Visibility = Visibility.Hidden; box10.Visibility = Visibility.Hidden;
                Label11.Visibility = Visibility.Hidden; box11.Visibility = Visibility.Hidden;
                btnAgregar.Visibility = Visibility.Visible;
            }
        }
        private void DataPEXL_Loaded(object sender, RoutedEventArgs e)
        {
            btnLimpiar_Click(sender, e);
            if (DataPEXL.Columns.Count > 0)
            {
                Label1.Content = DataPEXL.Columns[0].Header.ToString(); Label1.Visibility = Visibility.Visible; box1.Visibility = Visibility.Visible; CmBox1.Visibility = Visibility.Hidden;
                Label2.Content = DataPEXL.Columns[1].Header.ToString(); Label2.Visibility = Visibility.Visible; box2.Visibility = Visibility.Visible; CmBox2.Visibility = Visibility.Hidden;
                Label3.Content = DataPEXL.Columns[2].Header.ToString(); Label3.Visibility = Visibility.Visible; box3.Visibility = Visibility.Hidden; CmBox3.Visibility = Visibility.Visible;
                CargarComboBox.CargarCategorias(CmBox3);
                Label4.Content = DataPEXL.Columns[3].Header.ToString(); Label4.Visibility = Visibility.Visible; box4.Visibility = Visibility.Hidden; CmBox4.Visibility = Visibility.Visible;
                CargarComboBox.CargarEspecialidades(CmBox4);
                Label5.Content = DataPEXL.Columns[4].Header.ToString(); Label5.Visibility = Visibility.Visible; box5.Visibility = Visibility.Visible;
                Label6.Visibility = Visibility.Hidden; box6.Visibility = Visibility.Hidden;
                Label7.Visibility = Visibility.Hidden; box7.Visibility = Visibility.Hidden;
                Label8.Visibility = Visibility.Hidden; box8.Visibility = Visibility.Hidden;
                Label9.Visibility = Visibility.Hidden; box9.Visibility = Visibility.Hidden;
                Label10.Visibility = Visibility.Hidden; box10.Visibility = Visibility.Hidden;
                Label11.Visibility = Visibility.Hidden; box11.Visibility = Visibility.Hidden;
                btnAgregar.Visibility = Visibility.Visible;
            }
        }
        private void DataCategorias_Loaded(object sender, RoutedEventArgs e)
        {
            btnLimpiar_Click(sender, e);
            if (DataCategorias.Columns.Count > 0)
            {
                Label1.Content = DataCategorias.Columns[0].Header.ToString(); Label1.Visibility = Visibility.Visible; box1.Visibility = Visibility.Visible; CmBox1.Visibility = Visibility.Hidden;
                Label2.Visibility = Visibility.Hidden; box2.Visibility = Visibility.Hidden; CmBox2.Visibility = Visibility.Hidden;
                Label3.Visibility = Visibility.Hidden; box3.Visibility = Visibility.Hidden; CmBox3.Visibility = Visibility.Hidden;
                Label4.Visibility = Visibility.Hidden; box4.Visibility = Visibility.Hidden; CmBox4.Visibility = Visibility.Hidden;
                Label5.Visibility = Visibility.Hidden; box5.Visibility = Visibility.Hidden;
                Label6.Visibility = Visibility.Hidden; box6.Visibility = Visibility.Hidden;
                Label7.Visibility = Visibility.Hidden; box7.Visibility = Visibility.Hidden;
                Label8.Visibility = Visibility.Hidden; box8.Visibility = Visibility.Hidden;
                Label9.Visibility = Visibility.Hidden; box9.Visibility = Visibility.Hidden;
                Label10.Visibility = Visibility.Hidden; box10.Visibility = Visibility.Hidden;
                Label11.Visibility = Visibility.Hidden; box11.Visibility = Visibility.Hidden;
                btnAgregar.Visibility = Visibility.Visible;
            }
        }
        private void DataEspecialidades_Loaded(object sender, RoutedEventArgs e)
        {
            btnLimpiar_Click(sender, e);
            if (DataEspecialidades.Columns.Count > 0)
            {
                Label1.Content = DataEspecialidades.Columns[0].Header.ToString(); Label1.Visibility = Visibility.Visible; box1.Visibility = Visibility.Visible; CmBox1.Visibility = Visibility.Hidden;
                Label2.Visibility = Visibility.Hidden; box2.Visibility = Visibility.Hidden; CmBox2.Visibility = Visibility.Hidden;
                Label3.Visibility = Visibility.Hidden; box3.Visibility = Visibility.Hidden; CmBox3.Visibility = Visibility.Hidden;
                Label4.Visibility = Visibility.Hidden; box4.Visibility = Visibility.Hidden; CmBox4.Visibility = Visibility.Hidden;
                Label5.Visibility = Visibility.Hidden; box5.Visibility = Visibility.Hidden;
                Label6.Visibility = Visibility.Hidden; box6.Visibility = Visibility.Hidden;
                Label7.Visibility = Visibility.Hidden; box7.Visibility = Visibility.Hidden;
                Label8.Visibility = Visibility.Hidden; box8.Visibility = Visibility.Hidden;
                Label9.Visibility = Visibility.Hidden; box9.Visibility = Visibility.Hidden;
                Label10.Visibility = Visibility.Hidden; box10.Visibility = Visibility.Hidden;
                Label11.Visibility = Visibility.Hidden; box11.Visibility = Visibility.Hidden;
                btnAgregar.Visibility = Visibility.Visible;
            }
        }
        private void DataPracticas_Loaded(object sender, RoutedEventArgs e) {
            try {
                btnLimpiar_Click(sender, e);
                if (DataPracticas.Columns.Count > 0) {
                    Label1.Content = DataPracticas.Columns [0].Header.ToString(); Label1.Visibility = Visibility.Visible; box1.Visibility = Visibility.Visible; CmBox1.Visibility = Visibility.Hidden;
                    Label2.Content = DataPracticas.Columns [1].Header.ToString(); Label2.Visibility = Visibility.Visible; box2.Visibility = Visibility.Hidden; CmBox2.Visibility = Visibility.Visible;
                    CargarComboBox.CargarEspecialidades(CmBox2);
                    Label3.Content = DataPracticas.Columns [2].Header.ToString(); Label3.Visibility = Visibility.Visible; box3.Visibility = Visibility.Hidden; CmBox3.Visibility = Visibility.Visible;
                    CargarComboBox.CargarMuestra(CmBox3);
                    Label4.Content = DataPracticas.Columns [3].Header.ToString(); Label4.Visibility = Visibility.Visible; box4.Visibility = Visibility.Visible; CmBox4.Visibility = Visibility.Hidden;
                    Label5.Visibility = Visibility.Hidden; box5.Visibility = Visibility.Hidden;
                    Label6.Visibility = Visibility.Hidden; box6.Visibility = Visibility.Hidden;
                    Label7.Visibility = Visibility.Hidden; box7.Visibility = Visibility.Hidden;
                    Label8.Visibility = Visibility.Hidden; box8.Visibility = Visibility.Hidden;
                    Label9.Visibility = Visibility.Hidden; box9.Visibility = Visibility.Hidden;
                    Label10.Visibility = Visibility.Hidden; box10.Visibility = Visibility.Hidden;
                    Label11.Visibility = Visibility.Hidden; box11.Visibility = Visibility.Hidden;
                    btnAgregar.Visibility = Visibility.Visible;
                }
            }
            catch { }
        }
        private void DataPRXI_Loaded(object sender, RoutedEventArgs e)
        {
            try {
                btnLimpiar_Click(sender, e);
                if (DataPRXI.Columns.Count > 0)
            {
                Label1.Content = DataPRXI.Columns[0].Header.ToString(); Label1.Visibility = Visibility.Visible; box1.Visibility = Visibility.Visible; CmBox1.Visibility = Visibility.Hidden;
                Label2.Content = DataPRXI.Columns[1].Header.ToString(); Label2.Visibility = Visibility.Hidden; box2.Visibility = Visibility.Hidden; CmBox2.Visibility = Visibility.Hidden;
                Label3.Content = DataPRXI.Columns[2].Header.ToString(); Label3.Visibility = Visibility.Hidden; box3.Visibility = Visibility.Hidden; CmBox3.Visibility = Visibility.Hidden;
                Label4.Content = DataPRXI.Columns[3].Header.ToString(); Label4.Visibility = Visibility.Hidden; box4.Visibility = Visibility.Hidden; CmBox4.Visibility = Visibility.Hidden;
                Label5.Content = DataPRXI.Columns[4].Header.ToString(); Label5.Visibility = Visibility.Hidden; box5.Visibility = Visibility.Hidden;
                Label6.Content = DataPRXI.Columns[5].Header.ToString(); Label6.Visibility = Visibility.Hidden; box6.Visibility = Visibility.Hidden;
                Label7.Visibility = Visibility.Hidden; box7.Visibility = Visibility.Hidden;
                Label8.Visibility = Visibility.Hidden; box8.Visibility = Visibility.Hidden;
                Label9.Visibility = Visibility.Hidden; box9.Visibility = Visibility.Hidden;
                Label10.Visibility = Visibility.Hidden; box10.Visibility = Visibility.Hidden;
                Label11.Visibility = Visibility.Hidden; box10.Visibility = Visibility.Hidden;
                btnAgregar.Visibility = Visibility.Hidden;
            }
            } catch { }
        }
        private void DataPacientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try {
                btnLimpiar_Click(sender, e);
                if (DataPacientes.SelectedItem != null) {

                    DataRowView selectedRow = (DataRowView)DataPacientes.SelectedItem;
                    box1.Text = selectedRow.Row [0].ToString();
                    box2.Text = selectedRow.Row [1].ToString();
                    CmBox3.SelectedItem = selectedRow.Row[2].ToString();
                    box4.Text = selectedRow.Row [3].ToString();
                    box5.Text = selectedRow.Row [4].ToString();
                    box6.Text = selectedRow.Row [5].ToString();
                    box7.Text = selectedRow.Row [6].ToString();
                    box8.Text = selectedRow.Row [7].ToString();
                    box9.Text = selectedRow.Row [8].ToString();
                    box10.Text = selectedRow.Row [9].ToString();
                    box11.Text = selectedRow.Row [10].ToString();
                }
            }
            catch{}

        }
        private void DataIngresos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try {
                btnLimpiar_Click(sender, e);
                if (DataIngresos.SelectedItem != null)
                {
                    DataRowView selectedRow = (DataRowView)DataIngresos.SelectedItem;
                    CmBox1.SelectedItem = selectedRow.Row[0].ToString() + " " + selectedRow.Row[1].ToString() + " " + selectedRow.Row[2].ToString();
                    CmBox2.SelectedItem = selectedRow.Row[3].ToString() + " " + selectedRow.Row[4].ToString();
                    box3.Text = selectedRow.Row[5].ToString();
                    box4.Text = selectedRow.Row[6].ToString();

                }
            }catch { }
        }
        private void DataLocalidades_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try {
                btnLimpiar_Click(sender, e);
                if (DataLocalidades.SelectedItem != null) {
                    DataRowView selectedRow = (DataRowView)DataLocalidades.SelectedItem;
                    box1.Text = selectedRow.Row[0].ToString();
                    box2.Text = selectedRow.Row[1].ToString();
                }
            }catch { }
        }
        private void DataMedicos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try {
                btnLimpiar_Click(sender, e);
                if (DataMedicos.SelectedItem != null)
                {
                    DataRowView selectedRow = (DataRowView)DataMedicos.SelectedItem;
                    box1.Text = selectedRow.Row[0].ToString();
                    box2.Text = selectedRow.Row[1].ToString();
                    CmBox3.SelectedItem = selectedRow.Row[2].ToString();
                    box4.Text = selectedRow.Row[3].ToString();
                }
            }
            catch { }
        }
        private void DataPEXL_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnLimpiar_Click(sender, e);
            if (DataPEXL.SelectedItem != null)
            {
                try
                {
                    DataRowView selectedRow = (DataRowView)DataPEXL.SelectedItem;
                    box1.Text = selectedRow.Row[0].ToString();
                    box2.Text = selectedRow.Row[1].ToString();
                    CmBox3.SelectedItem = selectedRow.Row[2].ToString();
                    CmBox4.Text = selectedRow.Row[3].ToString();
                    box5.Text = selectedRow.Row [4].ToString();
                }
                catch { }
            }
        }
        private void DataCategorias_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnLimpiar_Click(sender, e);
            if (DataCategorias.SelectedItem != null)
            {
                try
                {
                    DataRowView selectedRow = (DataRowView)DataCategorias.SelectedItem;
                    box1.Text = selectedRow.Row[0].ToString();
                }
                catch { }
            }
        }
        private void DataEspecialidades_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnLimpiar_Click(sender, e);
            if (DataEspecialidades.SelectedItem != null)
            {
                try
                {
                    DataRowView selectedRow = (DataRowView)DataEspecialidades.SelectedItem;
                    box1.Text = selectedRow.Row[0].ToString();
                    CmBox2.SelectedItem = selectedRow.Row[1].ToString();
                    box3.Text = selectedRow.Row[0].ToString();
                    box4.Text = selectedRow.Row[0].ToString();
                    box5.Text = selectedRow.Row[0].ToString();
                }
                catch { }
            }
        }
        private void DataPracticas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnLimpiar_Click(sender, e);
            if (DataPracticas.SelectedItem != null)
            {
                try
                {
                    DataRowView selectedRow = (DataRowView)DataPracticas.SelectedItem;
                    box1.Text = selectedRow.Row[0].ToString();
                    CmBox2.SelectedItem = selectedRow.Row[1].ToString();
                    CmBox3.SelectedItem = selectedRow.Row[2].ToString();
                    box4.Text = selectedRow.Row[3].ToString();
                    box5.Text = selectedRow.Row[4].ToString();
                }
                catch { }
            }
        }
        private void DataPRXI_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnLimpiar_Click(sender, e);
            if (DataPRXI.SelectedItem != null)
            {
                try
                {
                    DataRowView selectedRow = (DataRowView)DataPRXI.SelectedItem;
                    box1.Text = selectedRow.Row[0].ToString();
                }
                catch { }
            }
        }
        private void TabControl1_SelectionChanged(object sender, SelectionChangedEventArgs? e)
        {

        }
        private void TabControl2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void DataPacientes_Auto(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if(e.Column.Header.ToString() == "ID")
            {
                e.Column.Visibility = Visibility.Hidden;
            }
        }

        private void DataIngresos_Auto(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "ID")
            {
                e.Column.Visibility = Visibility.Hidden;
            }
        }

        private void DataLocalidades_Auto(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "ID")
            {
                e.Column.Visibility = Visibility.Hidden;
            }
        }

        private void DataMedicos_Auto(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "ID")
            {
                e.Column.Visibility = Visibility.Hidden;
            }
        }

        private void DataPEXL_Auto(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "ID")
            {
                e.Column.Visibility = Visibility.Hidden;
            }
        }

        private void DataCategorias_Auto(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "ID")
            {
                e.Column.Visibility = Visibility.Hidden;
            }
        }

        private void DataEspecialidades_Auto(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "ID")
            {
                e.Column.Visibility = Visibility.Hidden;
            }
        }

        private void DataPracticas_Auto(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "ID")
            {
                e.Column.Visibility = Visibility.Hidden;
            }
        }
        private void DataPRXI_Auto(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "ID")
            {
                e.Column.Visibility = Visibility.Hidden;
            }
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CmBox3.SelectedIndex = CmBox1.SelectedIndex;
        }
        private void ComboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}

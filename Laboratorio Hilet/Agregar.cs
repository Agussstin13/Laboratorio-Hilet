using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Laboratorio_Hilet
{
    class Insert
    {
        SqlConnection conexion;
        public Insert(SqlConnection conexion)
        {
            this.conexion = conexion;
        }

        public void Pacientes(TextBox nombre, TextBox apellido, ComboBox localidad, DatePicker fecha, TextBox dni, TextBox direccion, TextBox altura, TextBox piso, TextBox departamento, TextBox correo, TextBox telefono)
        {
            if (nombre.Text == "" || apellido.Text == "" || localidad.SelectedIndex == -1 || fecha.Text == "" || dni.Text == "" || direccion.Text == "" || altura.Text == "" || correo.Text == "" || telefono.Text == "")
            {
                MessageBox.Show("Compruebe que todos los casilleros obligatorios contengan datos");
            }
            else
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("¿Desea agregar este nuevo registro?", "Agregar", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    if (result == MessageBoxResult.OK)
                    {
                        string query = "INSERT INTO Pacientes(nombre_paciente, apellido_paciente, id_localidades, fecha_nacimiento, dni, direccion_nombre, direccion_numero, direccion_piso, direccion_departamento, correo, telefono) VALUES (@nombre_paciente, @apellido_paciente, (SELECT id_localidades FROM Localidades WHERE nombre_localidad = @nombre_localidad), @fecha_nacimiento, @dni, @direccion_nombre, @direccion_numero, @direccion_piso, @direccion_departamento, @correo, @telefono)";
                        using (SqlCommand Command = new(query, conexion))
                        {
                            DateTime fechaNacimiento;
                            Command.Parameters.AddWithValue("@nombre_paciente", string.IsNullOrWhiteSpace(nombre.Text) ? DBNull.Value : nombre.Text); // ?Verdadero   :Falso
                            Command.Parameters.AddWithValue("@apellido_paciente", string.IsNullOrWhiteSpace(apellido.Text) ? DBNull.Value : apellido.Text);
                            Command.Parameters.AddWithValue("@nombre_localidad", string.IsNullOrWhiteSpace(localidad.Text) ? DBNull.Value : localidad.Text);
                            Command.Parameters.AddWithValue("@fecha_nacimiento", DateTime.TryParse(fecha.Text, out fechaNacimiento) ? fechaNacimiento : DBNull.Value);
                            Command.Parameters.AddWithValue("@dni", string.IsNullOrWhiteSpace(dni.Text) ? DBNull.Value : dni.Text);
                            Command.Parameters.AddWithValue("@direccion_nombre", string.IsNullOrWhiteSpace(direccion.Text) ? DBNull.Value : direccion.Text);
                            Command.Parameters.AddWithValue("@direccion_numero", string.IsNullOrWhiteSpace(altura.Text) ? DBNull.Value : altura.Text);
                            Command.Parameters.AddWithValue("@direccion_piso", string.IsNullOrWhiteSpace(piso.Text) ? DBNull.Value : piso.Text);
                            Command.Parameters.AddWithValue("@direccion_departamento", string.IsNullOrWhiteSpace(departamento.Text) ? DBNull.Value : departamento.Text);
                            Command.Parameters.AddWithValue("@correo", string.IsNullOrWhiteSpace(correo.Text) ? DBNull.Value : correo.Text);
                            Command.Parameters.AddWithValue("@telefono", string.IsNullOrWhiteSpace(telefono.Text) ? DBNull.Value : telefono.Text);
                            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(Command))
                            using (DataTable dt = new DataTable())
                            {
                                dataAdapter.Fill(dt);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public void Ingresos(ComboBox Paciente, ComboBox profesional, DatePicker fechaingreso, DatePicker fecharetiro)
        {
            if (Paciente.SelectedIndex == -1 || profesional.SelectedIndex == -1 || fechaingreso.Text == "" || fecharetiro.Text == "")
            {
                MessageBox.Show("Ingrese datos en todas las casillas");
            }
            else
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("¿Desea agregar este nuevo registro?", "Agregar", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    if (result == MessageBoxResult.OK)
                    {
                        string query = "INSERT INTO Ingresos(id_pacientes, id_profesionales, fecha_ingreso, fecha_retiro) VALUES (@id_pacientes, @id_profesionales, @fecha_ingreso, @fecha_retiro)";
                        using (SqlCommand Command = new(query, conexion))
                        {
                            DateTime fecha;
                            Command.Parameters.AddWithValue("@id_pacientes", string.IsNullOrWhiteSpace(Paciente.Text) ? DBNull.Value : Paciente.Text); // ? Verdadero   :Falso
                            Command.Parameters.AddWithValue("@id_profesionales", string.IsNullOrWhiteSpace(profesional.Text) ? DBNull.Value : profesional.Text);
                            Command.Parameters.AddWithValue("@fecha_ingreso", DateTime.TryParse(fechaingreso.Text, out fecha) ? fecha : DBNull.Value);
                            Command.Parameters.AddWithValue("@fecha_retiro", DateTime.TryParse(fecharetiro.Text, out fecha) ? fecha : DBNull.Value);
                            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(Command))
                            using (DataTable dt = new DataTable())
                            {
                                dataAdapter.Fill(dt);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
        public void Localidades(TextBox Ciudad, TextBox CodigoPostal)
        {
            if (Ciudad.Text == "" || CodigoPostal.Text == "")
            {
                MessageBox.Show("Ingrese datos en todas las casillas");
            }
            else
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("¿Desea agregar este nuevo registro?", "Agregar", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    if (result == MessageBoxResult.OK)
                    {
                        string query = "INSERT INTO Localidades(nombre_localidad, codigo_postal) VALUES (@nombre_localidad, @codigo_postal)";
                        using (SqlCommand Command = new(query, conexion))
                        {
                            Command.Parameters.AddWithValue("@nombre_localidad", string.IsNullOrWhiteSpace(Ciudad.Text) ? DBNull.Value : Ciudad.Text); // ? Verdadero   :Falso
                            Command.Parameters.AddWithValue("@codigo_postal", string.IsNullOrWhiteSpace(CodigoPostal.Text) ? DBNull.Value : CodigoPostal.Text);
                            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(Command))
                            using (DataTable dt = new DataTable())
                            {
                                dataAdapter.Fill(dt);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
        public void Medicos(TextBox NombreMedico, TextBox ApellidoMedico, ComboBox Servicios, TextBox Matricula)
        {
            if (NombreMedico.Text == "" || ApellidoMedico.Text == "" || Servicios.SelectedIndex == -1 || Matricula.Text == "")
            {
                MessageBox.Show("Ingrese datos en todas las casillas");
            } 
            else
            { 
                try
                {
                    MessageBoxResult result = MessageBox.Show("¿Desea agregar este nuevo registro?", "Agregar", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    if (result == MessageBoxResult.OK) 
                    {
                        string query = "INSERT INTO Profesionales(nombre_profesional, apellido_profesional, id_servicios, matricula_profesional) VALUES (@nombre_profesional, @apellido_profesional, (SELECT id_servicios FROM Servicios WHERE nombre_servicio = @nombre_servicio), @matricula_profesional)";
                        using (DataTable dt = new DataTable())
                        using (SqlCommand Command = new(query, conexion))
                        {
                            Command.Parameters.AddWithValue("@nombre_profesional", string.IsNullOrWhiteSpace(NombreMedico.Text) ? DBNull.Value : NombreMedico.Text);
                            Command.Parameters.AddWithValue("@apellido_profesional", string.IsNullOrWhiteSpace(ApellidoMedico.Text) ? DBNull.Value : ApellidoMedico.Text);
                            Command.Parameters.AddWithValue("@nombre_servicio", string.IsNullOrWhiteSpace(Servicios.Text) ? DBNull.Value : Servicios.Text);
                            Command.Parameters.AddWithValue("@matricula_profesional", string.IsNullOrWhiteSpace(Matricula.Text) ? DBNull.Value : Matricula.Text);
                            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(Command))
                            {
                                dataAdapter.Fill(dt);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
        public void PersonalLaboratorio(TextBox NombrePersonal, TextBox ApellidoPersonal, ComboBox Categoria, ComboBox Especialidades, TextBox Matricula)
        {
            if (NombrePersonal.Text == "" || ApellidoPersonal.Text == "" || Categoria.SelectedIndex == -1 || Especialidades.SelectedIndex == -1 || Matricula.Text == "")
            {
                MessageBox.Show("Ingrese datos en todas las casillas");
            }
            else
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("¿Desea agregar este nuevo registro?", "Agregar", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    if (result == MessageBoxResult.OK)
                    {
                        string query = "INSERT INTO Personal_Laboratorio(nombre_personal, apellido_personal, id_categorias, id_especialidades, matricula_personal) VALUES (@nombre_personal, @apellido_personal, (SELECT id_categorias FROM Categoria WHERE nombre_categoria = @nombre_categoria), (SELECT id_especialidades FROM Especialidades WHERE nombre_especialidad = @nombre_especialidad), @matricula_personal)";
                        using (DataTable dt = new DataTable())
                        using (SqlCommand Command = new(query, conexion))
                        {
                            Command.Parameters.AddWithValue("@nombre_personal", string.IsNullOrWhiteSpace(NombrePersonal.Text) ? DBNull.Value : NombrePersonal.Text);
                            Command.Parameters.AddWithValue("@apellido_personal", string.IsNullOrWhiteSpace(ApellidoPersonal.Text) ? DBNull.Value : ApellidoPersonal.Text);
                            Command.Parameters.AddWithValue("@nombre_categoria", string.IsNullOrWhiteSpace(Categoria.Text) ? DBNull.Value : Categoria.Text);
                            Command.Parameters.AddWithValue("@nombre_especialidad", string.IsNullOrWhiteSpace(Especialidades.Text) ? DBNull.Value : Especialidades.Text);
                            Command.Parameters.AddWithValue("@matricula_personal", string.IsNullOrWhiteSpace(Matricula.Text) ? DBNull.Value : Matricula.Text);
                            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(Command))
                            {
                                dataAdapter.Fill(dt);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
        public void Categoria(TextBox NombreCategoria)
        {
            if (NombreCategoria.Text == "")
            {
                MessageBox.Show("Ingrese datos en todas las casillas");
            }
            else
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("¿Desea agregar este nuevo registro?", "Agregar", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    if (result == MessageBoxResult.OK)
                    {
                        string query = "INSERT INTO Categoria(nombre_categoria) VALUES (@nombre_categoria)";
                        using (DataTable dt = new DataTable())
                        using (SqlCommand Command = new(query, conexion))
                        {
                            Command.Parameters.AddWithValue("@nombre_categoria", string.IsNullOrWhiteSpace(NombreCategoria.Text) ? DBNull.Value : NombreCategoria.Text);

                            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(Command))
                            {
                                dataAdapter.Fill(dt);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
        public void Especialidades(TextBox NombreEspecialidad)
        {
            if (NombreEspecialidad.Text == "")
            {
                MessageBox.Show("Ingrese datos en todas las casillas");
            }
            else
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("¿Desea agregar este nuevo registro?", "Agregar", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    if (result == MessageBoxResult.OK)
                    {
                        string query = "INSERT INTO Especialidades(nombre_especialidad) VALUES (@nombre_especialidad)";
                        using (DataTable dt = new DataTable())
                        using (SqlCommand Command = new(query, conexion))
                        {
                            Command.Parameters.AddWithValue("@nombre_especialidad", string.IsNullOrWhiteSpace(NombreEspecialidad.Text) ? DBNull.Value : NombreEspecialidad.Text);
                            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(Command))
                            {
                                dataAdapter.Fill(dt);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
        public void Practicas(TextBox NombrePractica, ComboBox  Especialidades, ComboBox Muestras, TextBox Tiempo_Demora)
        {
            if (NombrePractica.Text == "" || Especialidades.SelectedIndex == -1 || Muestras.SelectedIndex == -1 || Tiempo_Demora.Text == "")
            {
                MessageBox.Show("Ingrese datos en todas las casillas");
            }
            else
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("¿Desea agregar este nuevo registro?", "Agregar", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    if (result == MessageBoxResult.OK)
                    {
                        string query = "INSERT INTO Practicas(nombre_practica, id_especialidades, id_muestras, tiempo_demora_practica) VALUES (@nombre_practica, (SELECT id_especialidades FROM Especialidades WHERE nombre_especialidad = @nombre_especialidad), (SELECT id_muestras FROM Tipos_de_Muestras WHERE nombre_muestra = @nombre_muestra), @tiempo_demora_practica)";
                        using (DataTable dt = new DataTable())
                        using (SqlCommand Command = new(query, conexion))
                        {
                            Command.Parameters.AddWithValue("@nombre_practica", string.IsNullOrWhiteSpace(NombrePractica.Text) ? DBNull.Value : NombrePractica.Text);
                            Command.Parameters.AddWithValue("@nombre_especialidad", string.IsNullOrWhiteSpace(Especialidades.Text) ? DBNull.Value : Especialidades.Text);
                            Command.Parameters.AddWithValue("@nombre_muestra", string.IsNullOrWhiteSpace(Muestras.Text) ? DBNull.Value : Muestras.Text);
                            Command.Parameters.AddWithValue("@tiempo_demora_practica", string.IsNullOrWhiteSpace(Tiempo_Demora.Text) ? DBNull.Value : Tiempo_Demora.Text);
                            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(Command))
                            {
                                dataAdapter.Fill(dt);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
        public void PracticasIngresos(ComboBox Practica, ComboBox Ingreso, TextBox Resultado)
        {
            if (Practica.SelectedIndex == -1 || Ingreso.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar al menos un ingreso y una practica");
            }
            else
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("¿Desea agregar este nuevo registro?", "Agregar", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    if (result == MessageBoxResult.OK)
                    {
                        string query = "INSERT INTO PracticasxIngreso(id_practicas, id_ingresos, resultado) VALUES (@id_practicas, @id_ingresos, @resultado)";
                        using (DataTable dt = new DataTable())
                        using (SqlCommand Command = new(query, conexion))
                        {
                            Command.Parameters.AddWithValue("@id_practicas", string.IsNullOrWhiteSpace(Practica.Text) ? DBNull.Value : Practica.Text);
                            Command.Parameters.AddWithValue("@id_ingresos", string.IsNullOrWhiteSpace(Ingreso.Text) ? DBNull.Value : Ingreso.Text);
                            Command.Parameters.AddWithValue("@resultado", string.IsNullOrWhiteSpace(Resultado.Text) ? DBNull.Value : Resultado.Text);
                            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(Command))
                            {
                                dataAdapter.Fill(dt);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
        //Agregar PracticasxIngreso, modificar de donde se toman los datos y Controlar si se puede ingresar nuevos servicios y nuevas muestras
        //No lo pidio pero habria q ver eso
    }
}

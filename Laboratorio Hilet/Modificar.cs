using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using T.P_sqlserver;
using System.Collections;

namespace Laboratorio_Hilet
{
    class Update
    {
        public bool banderamodificar { get; set; } = false;
        SqlConnection conexion;

        public Update(SqlConnection conexion)
        {
            this.conexion = conexion;
        }

        public void Pacientes(DataGrid DGPacientes, TextBox nombre, TextBox apellido, ComboBox localidad, DatePicker fecha, TextBox dni, TextBox direccion, TextBox altura, TextBox piso, TextBox departamento, TextBox correo, TextBox telefono)
        {
            DataRowView selectedRow = (DataRowView)DGPacientes.SelectedItem;
            if (selectedRow != null)
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("¿Desea modificar el registro?", "Modificar", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    if (result == MessageBoxResult.OK)
                    {
                        DateTime fechaNacimiento;
                        string query = "UPDATE Pacientes SET nombre_paciente=@nombre_paciente, apellido_paciente=@apellido_paciente, id_localidades=@id_localidades, fecha_nacimiento=@fecha_nacimiento, dni=@dni," +
                        " direccion_nombre=@direccion_nombre, direccion_numero=@direccion_numero, direccion_piso=@direccion_piso, direccion_departamento=@direccion_departamento, correo=@correo, telefono=@telefono WHERE id_pacientes=@id_pacientes;";
                        using (SqlCommand command = new SqlCommand(query, conexion))
                        {
                            command.Parameters.AddWithValue("@nombre_paciente", string.IsNullOrWhiteSpace(nombre.Text) ? DBNull.Value : nombre.Text);
                            command.Parameters.AddWithValue("@apellido_paciente", string.IsNullOrWhiteSpace(apellido.Text) ? DBNull.Value : apellido.Text);
                            command.Parameters.AddWithValue("@id_localidades", localidad.SelectedIndex > 0 ? localidad.SelectedIndex : "0");
                            command.Parameters.AddWithValue("@fecha_nacimiento", DateTime.TryParse(fecha.SelectedDate.ToString(), out fechaNacimiento) ? fechaNacimiento : DBNull.Value);
                            command.Parameters.AddWithValue("@dni", string.IsNullOrWhiteSpace(dni.Text) ? DBNull.Value : dni.Text);
                            command.Parameters.AddWithValue("@direccion_nombre", string.IsNullOrWhiteSpace(direccion.Text) ? DBNull.Value : direccion.Text);
                            command.Parameters.AddWithValue("@direccion_numero", string.IsNullOrWhiteSpace(altura.Text) ? DBNull.Value : altura.Text);
                            command.Parameters.AddWithValue("@direccion_piso", string.IsNullOrWhiteSpace(piso.Text) ? DBNull.Value : piso.Text);
                            command.Parameters.AddWithValue("@direccion_departamento", string.IsNullOrWhiteSpace(departamento.Text) ? DBNull.Value : departamento.Text);
                            command.Parameters.AddWithValue("@correo", string.IsNullOrWhiteSpace(correo.Text) ? DBNull.Value : correo.Text);
                            command.Parameters.AddWithValue("@telefono", string.IsNullOrWhiteSpace(telefono.Text) ? DBNull.Value : telefono.Text);
                            command.Parameters.AddWithValue("@id_pacientes", selectedRow.Row["ID"].ToString());
                            using (SqlDataAdapter dataAdapter = new(command))
                            using (DataTable dt = new DataTable())
                            {
                                dataAdapter.Fill(dt);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un registro");
            }
        }
        public void Ingresos(DataGrid DGIngresos, ComboBox Paciente, ComboBox Profesional, DatePicker fechaingreso, DatePicker fecharetiro)
        {
            DataRowView selectedRow = (DataRowView)DGIngresos.SelectedItem;
            if (selectedRow != null)
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("¿Desea modificar el registro?", "Modificar", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    if (result == MessageBoxResult.OK)
                    {
                        DateTime fecha;
                        string query = "UPDATE Ingresos SET id_pacientes=@id_pacientes, id_profesionales=@id_profesionales, fecha_ingreso=@fecha_ingreso, fecha_retiro=@fecha_retiro WHERE id_ingresos=@id_ingresos";
                            
                        using (SqlCommand command = new SqlCommand(query, conexion))
                        {
                            command.Parameters.AddWithValue("@id_pacientes", string.IsNullOrWhiteSpace(Paciente.SelectedItem.ToString()) ? DBNull.Value : Paciente.SelectedItem.ToString());
                            command.Parameters.AddWithValue("@id_profesionales", string.IsNullOrWhiteSpace(Profesional.SelectedItem.ToString()) ? DBNull.Value : Profesional.SelectedItem.ToString());
                            command.Parameters.AddWithValue("@fecha_ingreso", DateTime.TryParse(fechaingreso.Text, out fecha) ? fecha : DBNull.Value);
                            command.Parameters.AddWithValue("@fecha_retiro", DateTime.TryParse(fecharetiro.Text, out fecha) ? fecha : DBNull.Value);
                            command.Parameters.AddWithValue("@id_ingresos", selectedRow.Row["ID"].ToString());
                            using (SqlDataAdapter dataAdapter = new(command))
                            using (DataTable dt = new DataTable())
                            {
                                dataAdapter.Fill(dt);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un registro");
            }
        }
        public void Localidades(DataGrid DGLocalidades, TextBox Ciudad,TextBox CodigoPostal)
        {
            DataRowView selectedRow = (DataRowView)DGLocalidades.SelectedItem;
            if (selectedRow != null)
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("¿Desea modificar el registro?", "Modificar", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    if (result == MessageBoxResult.OK)
                    {
                            
                        string query = "UPDATE Localidades SET nombre_localidad=@nombre_localidad, codigo_postal=@codigo_postal WHERE id_localidades=@id_localidades";
                        using (DataTable dt = new DataTable())
                        using (SqlCommand Command = new(query, conexion))
                        {
                            Command.Parameters.AddWithValue("@nombre_localidad", string.IsNullOrWhiteSpace(Ciudad.Text) ? DBNull.Value : Ciudad.Text);
                            Command.Parameters.AddWithValue("@codigo_postal", string.IsNullOrWhiteSpace(CodigoPostal.Text) ? DBNull.Value : CodigoPostal.Text);
                            Command.Parameters.AddWithValue("@id_localidades", selectedRow.Row["ID"].ToString());
                            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(Command))
                            {
                                dataAdapter.Fill(dt);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un registro");
            }
        }
        public void Medicos(DataGrid DGMedicos, TextBox NombreMedico, TextBox ApellidoMedico, ComboBox Servicio, TextBox Matricula)
        {
            DataRowView selectedRow = (DataRowView)DGMedicos.SelectedItem;
            if (selectedRow != null)
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("¿Desea modificar el registro?", "Modificar", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    if (result == MessageBoxResult.OK)
                    {

                        string query = "UPDATE Profesionales SET nombre_profesional=@nombre_profesional, apellido_profesional=@apellido_profesional, id_servicios=(SELECT id_servicios FROM Servicios WHERE nombre_servicio = @nombre_servicio), matricula_profesional=@matricula_profesional WHERE id_profesionales=@id_profesionales";
                        using (DataTable dt = new DataTable())
                        using (SqlCommand Command = new(query, conexion))
                        {
                            Command.Parameters.AddWithValue("@nombre_profesional", string.IsNullOrWhiteSpace(NombreMedico.Text) ? DBNull.Value : NombreMedico.Text);
                            Command.Parameters.AddWithValue("@apellido_profesional", string.IsNullOrWhiteSpace(ApellidoMedico.Text) ? DBNull.Value : ApellidoMedico.Text);
                            Command.Parameters.AddWithValue("@nombre_servicio", string.IsNullOrWhiteSpace(Servicio.SelectedItem.ToString()) ? DBNull.Value : Servicio.SelectedItem.ToString());     
                            Command.Parameters.AddWithValue("@matricula_profesional", string.IsNullOrWhiteSpace(Matricula.Text) ? DBNull.Value : Matricula.Text);
                            Command.Parameters.AddWithValue("@id_profesionales", selectedRow.Row["ID"].ToString());
                            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(Command))
                            {
                                dataAdapter.Fill(dt);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un registro");
            }
        }
        public void PersonalLaboratorio(DataGrid DGPersonalLaboratorio, TextBox NombrePersonal, TextBox ApellidoPersonal, ComboBox Categoria, ComboBox Especialidad,TextBox Matricula)
        {
            DataRowView selectedRow = (DataRowView)DGPersonalLaboratorio.SelectedItem;
            if (selectedRow != null)
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("¿Desea modificar el registro?", "Modificar", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    if (result == MessageBoxResult.OK)
                    {

                        string query = "UPDATE Personal_Laboratorio SET nombre_personal=@nombre_personal, apellido_personal=@apellido_personal, id_categorias=(SELECT id_categorias FROM Categoria WHERE nombre_categoria = @nombre_categoria), id_especialidades=(SELECT DISTINCT id_especialidades FROM Especialidades WHERE nombre_especialidad = @nombre_especialidad), matricula_personal=@matricula_personal WHERE id_personal=@id_personal";
                        using (DataTable dt = new DataTable())
                        using (SqlCommand Command = new(query, conexion))
                        {
                            Command.Parameters.AddWithValue("@nombre_personal", string.IsNullOrWhiteSpace(NombrePersonal.Text) ? DBNull.Value : NombrePersonal.Text);
                            Command.Parameters.AddWithValue("@apellido_personal", string.IsNullOrWhiteSpace(ApellidoPersonal.Text) ? DBNull.Value : ApellidoPersonal.Text);
                            Command.Parameters.AddWithValue("@nombre_categoria", string.IsNullOrWhiteSpace(Categoria.SelectedItem.ToString()) ? DBNull.Value : Categoria.SelectedItem.ToString());
                            Command.Parameters.AddWithValue("@nombre_especialidad", string.IsNullOrWhiteSpace(Especialidad.SelectedItem.ToString()) ? DBNull.Value : Especialidad.SelectedItem.ToString());
                            Command.Parameters.AddWithValue("@matricula_personal", string.IsNullOrWhiteSpace(Matricula.Text) ? DBNull.Value : Matricula.Text);
                            Command.Parameters.AddWithValue("@id_personal", selectedRow.Row["ID"].ToString());
                            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(Command))
                            {
                                dataAdapter.Fill(dt);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un registro");
            }
        }
        public void Categoria(DataGrid DGCategorias, TextBox NombreCategoria)
        {
            DataRowView selectedRow = (DataRowView)DGCategorias.SelectedItem;
            if (selectedRow != null)
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("¿Desea modificar el registro?", "Modificar", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    if (result == MessageBoxResult.OK)
                    {
                        string query = "UPDATE Categoria SET nombre_categoria=@nombre_categoria WHERE id_categorias=@id_categorias";
                        using (DataTable dt = new DataTable())
                        using (SqlCommand Command = new(query, conexion))
                        {
                            Command.Parameters.AddWithValue("@nombre_categoria", string.IsNullOrWhiteSpace(NombreCategoria.Text) ? DBNull.Value : NombreCategoria.Text);
                            Command.Parameters.AddWithValue("@id_categorias", selectedRow.Row["ID"].ToString());
                            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(Command))
                            {
                                dataAdapter.Fill(dt);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un registro");
            }
        }
        public void Especialidades (DataGrid DGEspecialidades, TextBox NombreEspecialidad)
        {
            DataRowView selectedRow = (DataRowView)DGEspecialidades.SelectedItem;
            if (selectedRow != null)
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("¿Desea modificar el registro?", "Modificar", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    if (result == MessageBoxResult.OK)
                    {
                        string query = "UPDATE Especialidades SET nombre_especialidad=@nombre_especialidad WHERE id_especialidades=@id_especialidades";
                        using (DataTable dt = new DataTable())
                        using (SqlCommand Command = new(query, conexion))
                        {
                            Command.Parameters.AddWithValue("@nombre_especialidad", string.IsNullOrWhiteSpace(NombreEspecialidad.Text) ? DBNull.Value : NombreEspecialidad.Text);
                            Command.Parameters.AddWithValue("@id_especialidades", selectedRow.Row["ID"].ToString());
                            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(Command))
                            {
                                dataAdapter.Fill(dt);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un registro");
            }
        }
        public void Practicas(DataGrid DGPracticas, TextBox NombrePractica, ComboBox Especialidad, ComboBox Muestra, TextBox Demora)
        {
            DataRowView selectedRow = (DataRowView)DGPracticas.SelectedItem;
            if (selectedRow != null)
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("¿Desea modificar el registro?", "Modificar", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    if (result == MessageBoxResult.OK)
                    {
                        string query = "UPDATE Practicas SET nombre_practica=@nombre_practica, id_especialidades=(SELECT id_especialidades FROM Especialidades WHERE nombre_especialidad = @nombre_especialidad), id_muestras=(SELECT DISTINCT id_muestras FROM Tipos_de_Muestras WHERE nombre_muestra = @nombre_muestra),tiempo_demora_practica = @tiempo_demora_practica WHERE id_practicas=@id_practicas";
                        using (DataTable dt = new DataTable())
                        using (SqlCommand Command = new(query, conexion))
                        {
                            Command.Parameters.AddWithValue("@nombre_practica", string.IsNullOrWhiteSpace(NombrePractica.Text) ? DBNull.Value : NombrePractica.Text);
                            Command.Parameters.AddWithValue("@nombre_especialidad", string.IsNullOrWhiteSpace(Especialidad.SelectedItem.ToString()) ? DBNull.Value : Especialidad.SelectedItem.ToString());                               
                            Command.Parameters.AddWithValue("@nombre_muestra", string.IsNullOrWhiteSpace(Muestra.SelectedItem.ToString()) ? DBNull.Value : Muestra.SelectedItem.ToString());
                            Command.Parameters.AddWithValue("@tiempo_demora_practica", string.IsNullOrWhiteSpace(Demora.Text) ? DBNull.Value : Demora.Text);
                            Command.Parameters.AddWithValue("@id_practicas", selectedRow.Row["ID"].ToString());
                            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(Command))
                            {
                                dataAdapter.Fill(dt);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un registro");
            }
        }
        //Agregar PracticasxIngreso, Controlar nombres de donde se toman los datos y Controlar si se puede ingresar nuevos servicios y nuevas muestras
        //No lo pidio pero habria q ver eso
        public void PracticasxIngreso(DataGrid DGPracticasIngresos, ComboBox Practicas, ComboBox Ingresos, TextBox Resultado)
        {
            DataRowView selectedRow = (DataRowView)DGPracticasIngresos.SelectedItem;
            if (selectedRow != null)
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("¿Desea modificar el registro?", "Modificar", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    if (result == MessageBoxResult.OK)
                    {
                        string query = "UPDATE PracticasxIngreso SET id_ingresos = (SELECT id_ingresos FROM Ingresos WHERE id_ingresos = @id_ingresos), id_practicas = (SELECT id_practicas FROM Practicas WHERE id_practicas = @id_practicas), resultado=@resultado WHERE id_practicasxingreso=@id_practicasxingreso";
                        using (DataTable dt = new DataTable())
                        using (SqlCommand Command = new(query, conexion))
                        {
                            Command.Parameters.AddWithValue("@id_practicas", string.IsNullOrWhiteSpace(Practicas.Text) ? DBNull.Value : Practicas.Text);
                            Command.Parameters.AddWithValue("@id_ingresos", string.IsNullOrWhiteSpace(Ingresos.Text) ? DBNull.Value : Ingresos.Text);
                            Command.Parameters.AddWithValue("@resultado", string.IsNullOrWhiteSpace(Resultado.Text) ? DBNull.Value : Resultado.Text);
                            Command.Parameters.AddWithValue("@id_practicasxingreso", selectedRow.Row["ID"].ToString());
                            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(Command))
                            {
                                dataAdapter.Fill(dt);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un registro");
            }
        }
    }
}

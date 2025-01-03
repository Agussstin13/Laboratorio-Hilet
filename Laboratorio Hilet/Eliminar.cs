using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Laboratorio_Hilet
{
    class Delete
    {
        public bool banderaeliminar { get; set; } = false;
        SqlConnection conexion;
        public Delete(SqlConnection conexion)
        {
            this.conexion = conexion;
        }

        public void Pacientes(DataRowView selectedRow)
        {
            if(selectedRow != null)
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("¿Desea eliminar el registro?", "Eliminar", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.OK)
                    {
                        string query = "DELETE FROM Pacientes WHERE id_pacientes=@id_pacientes";
                        using (SqlCommand Command = new(query, conexion))
                        {
                            Command.Parameters.AddWithValue("@id_pacientes", selectedRow.Row["ID"].ToString());
                            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(Command))
                            using (DataTable dt = new DataTable())
                            {
                                dataAdapter.Fill(dt);
                            }
                        }
                    }
                }
                catch { }
            }
            else
            {
                MessageBox.Show("Seleccione un registro");
            }
        }
        public void Ingresos(DataRowView selectedRow)
        {
            if (selectedRow != null)
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("¿Desea eliminar el registro?", "Eliminar", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.OK)
                    {
                        string query = "DELETE FROM Ingresos WHERE id_ingresos=@id_ingresos";
                        using (SqlCommand command = new SqlCommand(query, conexion))
                        {
                            command.Parameters.AddWithValue("@id_ingresos", selectedRow.Row["ID"].ToString());
                            using (SqlDataAdapter dataAdapter = new(command))
                            using (DataTable dt = new DataTable())
                            {
                                dataAdapter.Fill(dt);
                            }
                        }
                    }
                }
                catch { }
            }
            else
            {
                MessageBox.Show("Seleccione un registro");
            }
        }
        public void Localidades (DataRowView selectedRow)
        {
            if (selectedRow != null)
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("¿Desea eliminar el registro?", "Eliminar", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.OK)
                    {
                        string query = "DELETE FROM Localidades WHERE id_localidades=@id_localidades";
                        using (SqlCommand command = new SqlCommand(query, conexion))
                        {
                            command.Parameters.AddWithValue("@id_localidades", selectedRow.Row["ID"].ToString());
                            using (SqlDataAdapter dataAdapter = new(command))
                            using (DataTable dt = new DataTable())
                            {
                                dataAdapter.Fill(dt);
                            }
                        }
                    }
                }
                catch { }
            }
            else
            {
                MessageBox.Show("Seleccione un registro");
            }
        }
        public void Medico(DataRowView selectedRow)
        {
            if (selectedRow != null)
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("¿Desea eliminar el registro?", "Eliminar", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.OK)
                    {
                        string query = "DELETE FROM Profesionales WHERE id_Profesionales=@id_Profesionales";
                        using (SqlCommand command = new SqlCommand(query, conexion))
                        {
                            command.Parameters.AddWithValue("@id_Profesionales", selectedRow.Row["ID"].ToString());
                            using (SqlDataAdapter dataAdapter = new(command))
                            using (DataTable dt = new DataTable())
                            {
                                dataAdapter.Fill(dt);
                            }
                        }
                    }
                }
                catch { }
            }
            else
            {
                MessageBox.Show("Seleccione un registro");
            }
        }
        public void PersonaLaboratorio(DataRowView selectedRow)
        {
            if (selectedRow != null)
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("¿Desea eliminar el registro?", "Eliminar", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.OK)
                    {
                        string query = "DELETE FROM Personal_Laboratorio WHERE id_personal=@id_personal";
                        using (SqlCommand command = new SqlCommand(query, conexion))
                        {
                            command.Parameters.AddWithValue("@id_personal", selectedRow.Row["ID"].ToString());
                            using (SqlDataAdapter dataAdapter = new(command))
                            using (DataTable dt = new DataTable())
                            {
                                dataAdapter.Fill(dt);
                            }
                        }
                    }
                }
                catch { }
            }
            else
            {
                MessageBox.Show("Seleccione un registro");
            }
        }
        public void Categoria(DataRowView selectedRow)
        {
            if (selectedRow != null)
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("¿Desea eliminar el registro?", "Eliminar", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.OK)
                    {
                        string query = "DELETE FROM Categoria WHERE id_categorias=@id_categorias";
                        using (SqlCommand command = new SqlCommand(query, conexion))
                        {
                            command.Parameters.AddWithValue("@id_categorias", selectedRow.Row["ID"].ToString());
                            using (SqlDataAdapter dataAdapter = new(command))
                            using (DataTable dt = new DataTable())
                            {
                                dataAdapter.Fill(dt);
                            }
                        }
                    }
                }
                catch { }
            }
            else
            {
                MessageBox.Show("Seleccione un registro");
            }
        }
        public void Especialidades(DataRowView selectedRow)
        {
            if (selectedRow != null)
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("¿Desea eliminar el registro?", "Eliminar", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.OK)
                    {
                        string query = "DELETE FROM Especialidades WHERE id_especialidades=@id_especialidades";
                        using (SqlCommand command = new SqlCommand(query, conexion))
                        {
                            command.Parameters.AddWithValue("@id_especialidades", selectedRow.Row["ID"].ToString());
                            using (SqlDataAdapter dataAdapter = new(command))
                            using (DataTable dt = new DataTable())
                            {
                                dataAdapter.Fill(dt);
                            }
                        }
                    }
                }
                catch { }
            }
            else
            {
                MessageBox.Show("Seleccione un registro");
            }
        }
        public void Practicas(DataRowView selectedRow)
        {
            if (selectedRow != null)
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("¿Desea eliminar el registro?", "Eliminar", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.OK)
                    {
                        string query = "DELETE FROM Practicas WHERE id_practicas=@id_practicas";
                        using (SqlCommand command = new SqlCommand(query, conexion))
                        {
                            command.Parameters.AddWithValue("@id_practicas", selectedRow.Row["ID"].ToString());
                            using (SqlDataAdapter dataAdapter = new(command))
                            using (DataTable dt = new DataTable())
                            {
                                dataAdapter.Fill(dt);
                            }
                        }
                    }
                }
                catch { }
            }
            else
            {
                MessageBox.Show("Seleccione un registro");
            }
        }
        public void PracticasIngreso(DataRowView selectedRow)
        {
            if (selectedRow != null)
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("¿Desea eliminar el registro?", "Eliminar", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.OK)
                    {
                        string query = "DELETE FROM PracticasxIngreso WHERE id_practicasxingreso = @id_practicasxingreso ";
                        using (SqlCommand command = new SqlCommand(query, conexion))
                        {
                            command.Parameters.AddWithValue("@id_practicasxingreso ", selectedRow.Row["ID"].ToString());
                            using (SqlDataAdapter dataAdapter = new(command))
                            using (DataTable dt = new DataTable())
                            {
                                dataAdapter.Fill(dt);
                            }
                        }
                    }
                }
                catch { }
            }
            else
            {
                MessageBox.Show("Seleccione un registro");
            }
        }
        //Agregar PracticasxIngreso, modificar de donde se toman los datos y Controlar si se puede ingresar nuevos servicios y nuevas muestras
        //No lo pidio pero habria q ver eso
    }
}

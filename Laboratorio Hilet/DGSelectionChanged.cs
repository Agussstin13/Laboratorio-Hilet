using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Laboratorio_Hilet
{
    partial class MainWindow
    {
        //Esto permite pararse en un primer dato en caso de que no se haya seleccionado nada

        private void DGPacientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (DGPacientes.SelectedItem != null)
                {
                    DataRowView selectedRow = (DataRowView)DGPacientes.SelectedItem;
                    boxnombre.Text = selectedRow.Row[0].ToString();
                    boxapellido.Text = selectedRow.Row[1].ToString();
                    cmboxciudad.SelectedItem = selectedRow.Row[2].ToString();
                    DateNacimiento.Text = selectedRow.Row[3].ToString();
                    boxdni.Text = selectedRow.Row[4].ToString();
                    boxdireccion.Text = selectedRow.Row[5].ToString();
                    boxaltura.Text = selectedRow.Row[6].ToString();
                    boxpiso.Text = selectedRow.Row[7].ToString();
                    boxdepartamento.Text = selectedRow.Row[8].ToString();
                    boxcorreo.Text = selectedRow.Row[9].ToString();
                    boxtelefono.Text = selectedRow.Row[10].ToString();
                }
            }
            catch { }
        }
        private void DGIngresos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (DGIngresos.SelectedItem != null)
                {
                    DataRowView selectedRow = (DataRowView)DGIngresos.SelectedItem;
                    cmboxPaciente.SelectedItem = selectedRow.Row[0].ToString() + " " + selectedRow.Row[1].ToString() + " " + selectedRow.Row[2].ToString();
                    cmboxProfesional.SelectedItem = selectedRow.Row[3].ToString() + " " + selectedRow.Row[4].ToString();
                    Datefechaingreso.Text = selectedRow.Row[5].ToString();
                    Datefecharetiro.Text = selectedRow.Row[6].ToString();
                }
            }
            catch { }
        }
        private void DGLocalidades_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (DGLocalidades.SelectedItem != null)
                {
                    DataRowView selectedRow = (DataRowView)DGLocalidades.SelectedItem;
                    boxciudad.Text = selectedRow.Row[0].ToString();
                    boxcodigopostal.Text = selectedRow.Row[1].ToString();
                }
            }
            catch { }
        }
        private void DGMedicos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (DGMedicos.SelectedItem != null)
                {
                    DataRowView selectedRow = (DataRowView)DGMedicos.SelectedItem;
                    boxnombreprofesional.Text = selectedRow.Row[0].ToString();
                    boxapellidoprofesional.Text = selectedRow[1].ToString();
                    boxmatriculaprofesional.Text = selectedRow.Row[2].ToString();
                    cmboxservicios.SelectedItem = selectedRow.Row[3].ToString(); 
                }
            }
            catch { }
        }
        private void DGPersonalLaboratorio_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (DGPersonalLaboratorio.SelectedItem != null)
                {
                    DataRowView selectedRow = (DataRowView)DGPersonalLaboratorio.SelectedItem;
                    boxnombrepersonal.Text = selectedRow.Row[0].ToString();
                    boxapellidopersonal.Text = selectedRow[1].ToString();
                    boxmatriculapersonal.Text = selectedRow.Row[2].ToString();
                    cmboxcategoriapersonal.SelectedItem = selectedRow.Row[3].ToString();
                    cmboxespecialidadespersonal.SelectedItem = selectedRow.Row[4].ToString();
                }
            }
            catch { }
        }
        private void DGCategorias_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (DGCategorias.SelectedItem != null)
                {
                    DataRowView selectedRow = (DataRowView)DGCategorias.SelectedItem;
                    boxcategoria.Text = selectedRow.Row[0].ToString();
                }
            }
            catch { }
        }
        private void DGEspecialidades_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (DGEspecialidades.SelectedItem != null)
                {
                    DataRowView selectedRow = (DataRowView)DGEspecialidades.SelectedItem;
                    boxspecialidades.Text = selectedRow.Row[0].ToString();
                }
            }
            catch { }
        }
        private void DGPracticas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (DGPracticas.SelectedItem != null)
                {
                    DataRowView selectedRow = (DataRowView)DGPracticas.SelectedItem;
                    boxpractica.Text = selectedRow.Row[0].ToString();
                    cmboxespecialidadespracticas.SelectedItem = selectedRow.Row[1].ToString();
                    cmboxmuestra.SelectedItem = selectedRow.Row[2].ToString();
                    boxdemora.Text = selectedRow.Row[3].ToString();
                }
            }
            catch { }
        }
        private void DGPracticasIngresos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (DGPracticasIngresos.SelectedItem != null)
                {
                    DataRowView selectedRow = (DataRowView)DGPracticasIngresos.SelectedItem;
                    cmboxpracticas.SelectedItem = selectedRow.Row[0].ToString() + " " + selectedRow.Row[1].ToString() + " " + selectedRow.Row[2].ToString();
                    cmboxingresos.SelectedItem = selectedRow.Row[3].ToString() + " " + selectedRow.Row[4].ToString() + " " + selectedRow.Row[5].ToString() + " " + selectedRow.Row[6].ToString() + " " + selectedRow.Row[7].ToString();
                    boxresultado.Text = selectedRow.Row[8].ToString();
                }
            }
            catch { }
        }
    }
}

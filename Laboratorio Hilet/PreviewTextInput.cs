using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Laboratorio_Hilet
{
    public partial class MainWindow
    {
        //Control de caracteres en cada campo
        private Regex OnlyText = new("[^a-zA-Z]+"); //Solo letras
        private Regex OnlyNumbers = new("[^0-9]+"); //Solo Numeros
        private Regex OnlyEmail = new(@"^[a-zA-Z0-9@\.\-_]+$"); // Permite letras, números, espacios y algunos caracteres de puntuación
        private Regex OnlyNumbersAndText = new("^[a-zA-Z0-9]+");

        private void boxnombre_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (OnlyText.IsMatch(e.Text))
            {
                e.Handled = true;
            }
        }
        //apellido
        private void boxapellido_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (OnlyText.IsMatch(e.Text))
            {
                e.Handled = true;
            }
        }
        //dni
        private void boxdni_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (OnlyNumbers.IsMatch(e.Text))
            {
                e.Handled = true;
            }
        }
        //direccion
        private void boxdireccion_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }
        // altura
        private void boxaltura_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (OnlyNumbers.IsMatch(e.Text))
            {
                e.Handled = true;
            }
        }
        //piso
        private void boxpiso_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            
        }
        //departamento
        private void boxdepartamento_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (OnlyText.IsMatch(e.Text) || boxdepartamento.Text.Length == 1)
            {
                e.Handled = true;
            }
        }
        //correo
        private void boxcorreo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //Control de caracteres especialies
            if (!OnlyEmail.IsMatch(e.Text))
            {
                e.Handled = true;
            }
            // Limitar la longitud del correo a 20 caracteres
            if (boxcorreo.Text.Length >= 40)
            {
                e.Handled = true;
            }
        }
        private void boxtelefono_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (OnlyNumbers.IsMatch(e.Text)) 
            {
                e.Handled = true;
            }
        }
        private void boxciudad_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (OnlyText.IsMatch(e.Text))
            {
                e.Handled = true;
            }
        }
        private void boxcodigopostal_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (OnlyNumbers.IsMatch(e.Text))
            {
                e.Handled = true;
            }
        }
        private void boxnombreprofesional_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (OnlyText.IsMatch(e.Text))
            {
                e.Handled = true;
            }
        }
        private void boxapellidoprofesional_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (OnlyText.IsMatch(e.Text))
            {
                e.Handled = true;
            }
        }
        private void boxmatriculaprofesional_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (OnlyNumbers.IsMatch(e.Text))
            {
                e.Handled = true;
            }
        }
        private void boxnombrepersonal_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (OnlyText.IsMatch(e.Text))
            {
                e.Handled = true;
            }
        }
        private void boxapellidopersonal_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (OnlyText.IsMatch(e.Text))
            {
                e.Handled = true;
            }
        }
        private void boxmatriculapersonal_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (OnlyNumbers.IsMatch(e.Text))
            {
                e.Handled = true;
            }
        }
        private void boxcategoria_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (OnlyText.IsMatch(e.Text))
            {
                e.Handled = true;
            }
        }
        private void boxspecialidades_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (OnlyText.IsMatch(e.Text))
            {
                e.Handled = true;
            }
        }
        private void boxpractica_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (OnlyText.IsMatch(e.Text))
            {
                e.Handled = true;
            }
        }
        private void boxdemora_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }
        private void boxresultado_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }
    }
}

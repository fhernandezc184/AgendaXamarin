using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;


namespace Base
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        static int count;
        public MainPage()
        {
            InitializeComponent();

            suma.Clicked += Suma_Clicked;
            resta.Clicked += Resta_Clicked;
            multiplicacion.Clicked += Multiplicacion_Clicked;
            division.Clicked += Division_Clicked;
            limpiar.Clicked += Limpiar_Clicked;
            
            count = 1;
        }

        private void Limpiar_Clicked(object sender, EventArgs e)
        {
            txt1.Text = "";
            txt2.Text = "";
            lblRespuesta.Text = "";
        }

        private void Division_Clicked(object sender, EventArgs e)
        {
            try
            {
                int numero1 = Int32.Parse(txt1.Text);
                int numero2 = Int32.Parse(txt2.Text);
                lblRespuesta.Text = numero1.ToString() + " / " + numero2.ToString() + " = " + (numero1 / numero2).ToString();
      
            }
            catch
            {
                DisplayAlert("Error", "Llene todos los campos", "Aceptar");
            }


        }

        private void Multiplicacion_Clicked(object sender, EventArgs e)
        {
            try
            {
                int numero1 = Int32.Parse(txt1.Text);
                int numero2 = Int32.Parse(txt2.Text);
                lblRespuesta.Text = numero1.ToString() + " * " + numero2.ToString() + " = " + (numero1 * numero2).ToString();

            }
            catch
            {
                DisplayAlert("Error", "Llene todos los campos", "Aceptar");
            }


        }

        private void Resta_Clicked(object sender, EventArgs e)
        {
            try
            {

                int numero1 = Int32.Parse(txt1.Text);
                int numero2 = Int32.Parse(txt2.Text);
                lblRespuesta.Text = numero1.ToString() + " - " + numero2.ToString() + " = " + (numero1 - numero2).ToString();

            }
            catch
            {
                DisplayAlert("Error", "Llene todos los campos", "Aceptar");
            }


        }

        private void Suma_Clicked(object sender, EventArgs e)
        {
            try
            {
               
                int numero1 = Int32.Parse(txt1.Text);
                int numero2 = Int32.Parse(txt2.Text);
                lblRespuesta.Text = numero1.ToString() +  " + " + numero2.ToString() + " = " + ((numero1 + numero2).ToString());

            }
            catch
            {
                DisplayAlert("Error", "Llene todos los campos", "Aceptar");
            }
        }

        private void Guardar_Clicked(object sender, EventArgs e)
        {
          
            if (String.IsNullOrWhiteSpace(txt1.Text) || String.IsNullOrWhiteSpace(txt2.Text) || String.IsNullOrWhiteSpace(lblRespuesta.Text))
            {

                DisplayAlert("Error", "Llene todos los campos", "Aceptar");
            }
            else { 
              
                //Guardar en txt
                String nombrearchivo = "prueba.txt";
                String ruta = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                String rutaCompleta = Path.Combine(ruta, nombrearchivo);

                if (File.Exists(rutaCompleta))
                {

                    using (var escritor = File.AppendText(rutaCompleta))
                    {
                        escritor.Write(count + ". " + lblRespuesta.Text + "\n");
                    }

                }
                else
                {
                    using (var escritor = File.CreateText(rutaCompleta))
                    {
                        escritor.Write(count + ". " + lblRespuesta.Text + "\n");
                    }
                }
                count++;

                //Limpia los entry y lblRespuesta
                txt1.Text = "";
                txt2.Text = "";
                lblRespuesta.Text = "";

                DisplayAlert("Guardado!", "", "Aceptar");
            }


        }

        private void Ver_Clicked(object sender, EventArgs e)
        {

            ((NavigationPage)this.Parent).PushAsync(new Ver());

        }
    }
}

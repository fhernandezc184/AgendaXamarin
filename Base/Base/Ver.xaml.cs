using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Base
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Ver : ContentPage
    {
        public Ver()
        {
            InitializeComponent();
            Mostrar_Datos();
            btnLimpiar.Clicked += btnLimpiar_Clicked;
        }

        private void btnLimpiar_Clicked(object sender, EventArgs e)
        {
            String nombrearchivo = "prueba.txt";
            String ruta = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            String rutaCompleta = Path.Combine(ruta, nombrearchivo);

            File.Delete(rutaCompleta);

            Mostrar_Datos();
        }

        private void Mostrar_Datos()
        {
            List<String> list = new List<String>();

            String nombreArchivo = "prueba.txt";
            String ruta = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            String rutaCompleta = Path.Combine(ruta, nombreArchivo);

            if (File.Exists(rutaCompleta))
            {
                using (var lector = new StreamReader(rutaCompleta, true))
                {
                    String TextoLeido;
                    while ((TextoLeido = lector.ReadLine()) != null)
                    {
                        list.Add(TextoLeido);

                    }
                }
            }

            listView.ItemsSource = list;

        }
       
    }
}
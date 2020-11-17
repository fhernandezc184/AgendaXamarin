using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using Base.Modelo;

namespace Base
{
    public partial class App : Application
    {
        public App(string filename)
        {
            InitializeComponent();
            AgendaRepository.Inicializador(filename);
            MainPage = new NavigationPage(new Agenda());
        }

        protected override void OnStart()
        {
            String nombrearchivo = "prueba.txt";
            String ruta = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            String rutaCompleta = Path.Combine(ruta, nombrearchivo);

            File.Delete(rutaCompleta);

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

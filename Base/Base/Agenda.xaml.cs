using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base.Modelo;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Base
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Agenda : ContentPage
    {
        public Agenda()
        {
            InitializeComponent();
        }

        private void btnGuardar_Clicked(object sender, EventArgs e)
        {
            StatusMessage.Text = string.Empty;
            var import = picker.SelectedItem.ToString();
            AgendaRepository.Instancia.AddNewAgenda(entryLinea.Text, import);
            StatusMessage.Text = AgendaRepository.Instancia.EstadoMensaje;

        }

        private void btnLeer_Clicked(object sender, EventArgs e)
        {
            var allUsers = AgendaRepository.Instancia.GetAgenda();
            userList.ItemsSource = allUsers;
            StatusMessage.Text = AgendaRepository.Instancia.EstadoMensaje;
        }

        private void btnLimpiar_Clicked(object sender, EventArgs e)
        {
            entryLinea.Text = string.Empty;
            picker.SelectedItem = null;
        }

        public void Button_Clicked(object sender, EventArgs e)
        {
            var x = sender;
            DisplayAlert("Mensaje", "Desea borra este registro", "Si", "No");
        }
    }
}
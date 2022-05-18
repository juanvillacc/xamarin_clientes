using LocalStorageDb.Data;
using LocalStorageDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LocalStorageDb.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListadoClientesPage : ContentPage
    {
        public ListadoClientesPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            /*ClientesDatabase clientesDatabase = await ClientesDatabase.Instance;
            LVClientes.ItemsSource = await clientesDatabase.ClientesObtenerTodos();*/

            LVClientes.ItemsSource =  await ObtenerClientesAsync();
        }

        private async void LVClientes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {   
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new DetalleClientePage
                {
                    BindingContext = e.SelectedItem as Cliente
                });
            }
        }

        private async void  ToolbarItem_Clicked(object sender, EventArgs e)
        {
            var cliente = new Cliente();
            await Navigation.PushAsync(new DetalleClientePage
            {
                BindingContext = cliente
            });
        }


        private async Task<List<Cliente>> ObtenerClientesAsync()
        {
            RestService service = new RestService();
            return await service.ObtenerClientes();
        }
    }
}
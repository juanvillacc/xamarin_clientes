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
    public partial class DetalleClientePage : ContentPage
    {
        RestService service = new RestService();
        public  DetalleClientePage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var cliente = (Cliente)BindingContext;
            this.BindingContext = await ObtenerClientePorId(cliente.ID);
        }

        async void GuadarButton_Clicked(object sender, EventArgs e)
        {
            var cliente = (Cliente)BindingContext;
            /*ClientesDatabase clientesDatabase = await ClientesDatabase.Instance;
            await clientesDatabase.GuardarCliente(cliente);*/
            await service.GuardarCliente(cliente);
            await CerrarPagina();
        }

        private async void CancelarButton_Clicked(object sender, EventArgs e)
        {
            await CerrarPagina();
        }

        private async void btnBorrar_Clicked(object sender, EventArgs e)
        {
            var cliente = (Cliente)BindingContext;
            //ClientesDatabase clientesDatabase = await ClientesDatabase.Instance;
            //await clientesDatabase.BorrarCliente(cliente);
            await service.BorrarCliente(cliente);
            await CerrarPagina();
        }

        private async Task<bool> CerrarPagina()
        {
            await Navigation.PopAsync();
            return true;
            
        }

        private async Task<Cliente> ObtenerClientePorId(int ID)
        {
           return await service.ObtenerClientePorId(ID);
        }
    }
}
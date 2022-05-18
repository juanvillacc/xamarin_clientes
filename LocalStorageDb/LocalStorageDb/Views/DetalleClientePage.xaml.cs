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
        public DetalleClientePage()
        {
            InitializeComponent();
        }

        async void GuadarButton_Clicked(object sender, EventArgs e)
        {
            var cliente = (Cliente)BindingContext;
            ClientesDatabase clientesDatabase = await ClientesDatabase.Instance;
            await clientesDatabase.GuardarCliente(cliente);
        }
    }
}
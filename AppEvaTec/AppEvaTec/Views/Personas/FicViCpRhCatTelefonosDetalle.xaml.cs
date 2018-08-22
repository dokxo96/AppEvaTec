using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppEvaTec.ViewModels.Personas;

namespace AppEvaTec.Views.Personas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FicViCpRhCatTelefonosDetalle : ContentPage
    {
        private object FicLoParameter { get; set; }

        public FicViCpRhCatTelefonosDetalle(object ficPaParameter)
        {
            InitializeComponent();
            FicLoParameter = ficPaParameter;

            BindingContext = App.FicMetLocator.FicVmRhCatTelefonosDetalle;

            var layout = stack;
            var scroll = new ScrollView { Content = layout };
            Content = scroll;

            Dictionary<int, string> valuess = new Dictionary<int, string>();
            valuess.Add(50, "Celular");
            valuess.Add(51, "Oficina");
            valuess.Add(52, "Casa");
            valuess.Add(53, "Otro");

            foreach (var item in valuess.Values)
            {
                GenTelefono.Items.Add(item);
            }

            GenTelefono.SelectedIndexChanged += (sender, args) =>
            {

                uno.Text = (GenTelefono.SelectedIndex + 50).ToString();

            };
        }
        protected override void OnAppearing()
        {
            //FIC: Aqui se declara una variable de tipo ViewModel Item
            var FicViewModel = BindingContext as FicVmRhCatTelefonosDetalle;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);
        }

        protected override void OnDisappearing()
        {
            var FicViewModel = BindingContext as FicVmRhCatTelefonosDetalle;
            if (FicViewModel != null) FicViewModel.OnDisappearing();
        }

    }
}
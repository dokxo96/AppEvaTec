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
    public partial class FicViCpRhCatTelefonosList : ContentPage
    {
        private object FicLoParameter { get; set; }

        public FicViCpRhCatTelefonosList(object ficPaParameter)
        {
            InitializeComponent();
            FicLoParameter = ficPaParameter;

            BindingContext = App.FicMetLocator.FicVmRhCatTelefonosList;


        }
        protected override void OnAppearing()
        {
            //FIC: Aqui se declara una variable de tipo ViewModel Item

            var FicViewModel = BindingContext as FicVmRhCatTelefonosList;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);


        }

        protected override void OnDisappearing()
        {
            var FicViewModel = BindingContext as FicVmRhCatTelefonosList;
            if (FicViewModel != null) FicViewModel.OnDisappearing();
        }
    }
}
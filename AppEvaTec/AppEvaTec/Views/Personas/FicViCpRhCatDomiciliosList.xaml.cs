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
    public partial class FicViCpRhCatDomiciliosList : ContentPage
    {
        private object FicLoParameter { get; set; }

        public FicViCpRhCatDomiciliosList(object ficPaParameter)
        {
            InitializeComponent();
            FicLoParameter = ficPaParameter;

            BindingContext = App.FicMetLocator.FicVmRhCatDomiciliosList;


        }
        protected override void OnAppearing()
        {
            //FIC: Aqui se declara una variable de tipo ViewModel Item

            var FicViewModel = BindingContext as FicVmRhCatDomiciliosList;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);


        }

        protected override void OnDisappearing()
        {
            var FicViewModel = BindingContext as FicVmRhCatDomiciliosList;
            if (FicViewModel != null) FicViewModel.OnDisappearing();
        }
    }
}
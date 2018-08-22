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
    public partial class FicViCpRhCatDirWebList : ContentPage
    {
        private object FicLoParameter { get; set; }

        public FicViCpRhCatDirWebList(object ficPaParameter)
        {
            InitializeComponent();
            FicLoParameter = ficPaParameter;

            BindingContext = App.FicMetLocator.FicVmRhCatDirWebList;


        }
        protected override void OnAppearing()
        {
            //FIC: Aqui se declara una variable de tipo ViewModel Item

            var FicViewModel = BindingContext as FicVmRhCatDirWebList;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);


        }

        protected override void OnDisappearing()
        {
            var FicViewModel = BindingContext as FicVmRhCatDirWebList;
            if (FicViewModel != null) FicViewModel.OnDisappearing();
        }
    }
}
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
    public partial class FicViCpRhCatDirWebItem : ContentPage
    {
        private object FicLoParameter { get; set; }
        public FicViCpRhCatDirWebItem(object ficPaParameter)
        {
            InitializeComponent();

            FicLoParameter = ficPaParameter;

            BindingContext = App.FicMetLocator.FicVmRhCatDirWebItem;

            var layout = stack;
            var scroll = new ScrollView { Content = layout };
            Content = scroll;

            Dictionary<int, string> lista = new Dictionary<int, string>();
            lista.Add(44, "Faceboook");
            lista.Add(45, "Google +");
            lista.Add(46, "Twitter");
            lista.Add(47, "Youtube");
            lista.Add(48, "Instagram");
            lista.Add(49, "Otro");


            foreach (var item in lista.Values)
            {
                GenDirWeb.Items.Add(item);
            }

            GenDirWeb.SelectedIndexChanged += (sender, args) =>
            {

                uno.Text = (GenDirWeb.SelectedIndex + 44).ToString();

            };



        }
        protected override void OnAppearing()
        {
            //FIC: Aqui se declara una variable de tipo ViewModel Item
            var FicViewModel = BindingContext as FicVmRhCatDirWebItem;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);
        }

        protected override void OnDisappearing()
        {
            var FicViewModel = BindingContext as FicVmRhCatDirWebItem;
            if (FicViewModel != null) FicViewModel.OnDisappearing();
        }
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppEvaTec.Interfaces.Navigation;
using AppEvaTec.Services.Navigation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppEvaTec.ViewModels.Personas;
using Plugin.Media;

namespace AppEvaTec.Views.Personas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FicViCpRegister : ContentPage
    {

        private object FicLoParameter { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }

        public FicViCpRegister(object ficPaParameter)
        {
            InitializeComponent();
            FicLoParameter = ficPaParameter;

            BindingContext = App.FicMetLocator.FicVmRegister;

            cargafoto.Clicked += NewUser_ClickedAsync;

            var lista4 = new List<string>()
            {
                "MASCULINO",
                "FEMENINO"
            };

            Sex.ItemsSource = lista4;

            Sex.SelectedIndexChanged += (sender, args) =>
            {

                esex.Text = Sex.SelectedItem.ToString();

            };
        }

        protected override void OnAppearing()
        {
            //FIC: Aqui se declara una variable de tipo ViewModel Item
            var FicViewModel = BindingContext as FicVmRegister;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);
        }

        protected override void OnDisappearing()
        {
            var FicViewModel = BindingContext as FicVmRegister;
            if (FicViewModel != null) FicViewModel.OnDisappearing();
        }

        private async void NewUser_ClickedAsync(object sender, EventArgs e)
        {

            Usuario = user.Text;
            Contrasena = contra.Text;

            var file = await CrossMedia.Current.PickPhotoAsync();
            if (file == null)
                return;

            var im = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                //file.Dispose();
                return stream;
            });

            img.Source = im;
            rutaf.Text = file.Path;
        }
    }
}
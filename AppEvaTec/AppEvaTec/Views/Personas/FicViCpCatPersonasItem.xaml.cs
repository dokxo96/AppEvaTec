using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppEvaTec.ViewModels.Personas;
using Plugin.Media;

namespace AppEvaTec.Views.Personas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FicViCpCatPersonasItem : ContentPage
    {
        private object FicLoParameter { get; set; }
        public FicViCpCatPersonasItem(object ficPaParameter)
        {
            InitializeComponent();

            FicLoParameter = ficPaParameter;

            BindingContext = App.FicMetLocator.FicVmCatPersonasItem;

            var layout = stack;
            var scroll = new ScrollView { Content = layout };
            Content = scroll;

            cargafoto.Clicked += NewUser_ClickedAsync;

            Dictionary<int, string> lista = new Dictionary<int, string>();
            lista.Add(13, "Maestro");
            lista.Add(14, "Administrador Finanzas");
            lista.Add(15, "Analista de Negocios");
            lista.Add(16, "Archivero");
            lista.Add(17, "Arquitecto");
            lista.Add(18, "Asesor");
            lista.Add(19, "Contador");
            lista.Add(20, "Director");
            lista.Add(21, "Economistas");
            lista.Add(22, "Desarrollador");
            lista.Add(23, "Otros");

            Dictionary<int, string> lista2 = new Dictionary<int, string>();
            lista2.Add(24, "Soltero");
            lista2.Add(25, "Casado");
            lista2.Add(26, "Viudo");
            lista2.Add(27, "Divorciado");
            lista2.Add(28, "Union Libre");
            lista2.Add(29, "Concubinato");
            lista2.Add(30, "Otro");

            var lista3 = new List<string>()
            {
                "F",
                "E"
            };

            var lista4 = new List<string>()
            {
                "M",
                "F"
            };

            Sex.ItemsSource = lista4;
            TP.ItemsSource = lista3;

            foreach (var item in lista.Values)
            {
                GenOcupacion.Items.Add(item);
            }

            foreach (var item in lista2.Values)
            {
                GenEstadoCivil.Items.Add(item);
            }

            GenOcupacion.SelectedIndexChanged += (sender, args) =>
            {

                uno.Text = (GenOcupacion.SelectedIndex + 13).ToString();

            };

            GenEstadoCivil.SelectedIndexChanged += (sender, args) =>
            {

                dos.Text = (GenEstadoCivil.SelectedIndex + 24).ToString();

            };

            TP.SelectedIndexChanged += (sender, args) =>
            {

                etp.Text = TP.SelectedItem.ToString();

            };

            Sex.SelectedIndexChanged += (sender, args) =>
            {

                esex.Text = Sex.SelectedItem.ToString();

            };

        }
        protected override void OnAppearing()
        {
            //FIC: Aqui se declara una variable de tipo ViewModel Item
            var FicViewModel = BindingContext as FicVmCatPersonasItem;
            // var usuario = BindingContext as FicVmRegister;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);
            //IdUsuario.Text = usuario.Item.IdUsuario.ToString();
        }

        private async void NewUser_ClickedAsync(object sender, EventArgs e)
        {

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

        protected override void OnDisappearing()
        {
            var FicViewModel = BindingContext as FicVmCatPersonasItem;
            if (FicViewModel != null) FicViewModel.OnDisappearing();
        }
    }
}
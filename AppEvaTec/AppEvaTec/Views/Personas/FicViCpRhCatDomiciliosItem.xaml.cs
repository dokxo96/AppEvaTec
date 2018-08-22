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
    public partial class FicViCpRhCatDomiciliosItem : ContentPage
    {
        private object FicLoParameter { get; set; }
        public FicViCpRhCatDomiciliosItem(object ficPaParameter)
        {
            InitializeComponent();

            FicLoParameter = ficPaParameter;

            BindingContext = App.FicMetLocator.FicVmRhCatDomiciliosItem;

            var layout = stack;
            var scroll = new ScrollView { Content = layout };
            Content = scroll;

            var pais = new List<string>(){
                "Cuba",
                "México"
            };

            Pais.ItemsSource = pais;

            var EC = new List<string>() {
                "Las Tunas",
                "Holguin"
            };

            var CL = new List<string>()
            {
                "Matani",
                "Jobabo",
                "Amancio"
            };

            var CH = new List<string>()
            {
                "Antilla",
                "Banes",
                "Moa"
            };

            var EM = new List<string>()
            {
                "Nayarit",
                 "Sinaloa"
            };

            var CS = new List<string>() {
                "Culiacan",
                "Mazatlan",
                 "Escuinapa",
                 "Cosala"
            };

            var CN = new List<string>()
            {
                "Tecuala",
                "Tepic",
                "Acaponeta",
                "Ixtlan del Rio"
            };

            Pais.SelectedIndexChanged += (sender, args) =>
            {

                string pais1 = Pais.SelectedItem.ToString();
                Epais.Text = pais1;
                if (pais1 == "Cuba")
                {
                    Estado.ItemsSource = EC;
                }
                if (pais1 == "México")
                {
                    Estado.ItemsSource = EM;
                }

            };

            Estado.SelectedIndexChanged += (sender, args) =>
            {
                String estado = Estado.SelectedItem.ToString();
                Eestado.Text = estado;
                if (estado == "Las Tunas")
                {
                    Municipio.ItemsSource = CL;
                }

                if (estado == "Holguin")
                {
                    Municipio.ItemsSource = CH;
                }

                if (estado == "Sinaloa")
                {
                    Municipio.ItemsSource = CS;
                }

                if (estado == "Nayarit")
                {
                    Municipio.ItemsSource = CN;
                }
            };

            Municipio.SelectedIndexChanged += (sender, args) =>
            {
                String muni = Municipio.SelectedItem.ToString();
                Emunicipo.Text = muni;
            };

            Dictionary<int, string> valuess = new Dictionary<int, string>();
            valuess.Add(37, "Real");
            valuess.Add(38, "Leal");
            valuess.Add(39, "Especial o Contractual");
            valuess.Add(40, "Conyugal");
            valuess.Add(41, "Procesal o Constituido");
            valuess.Add(42, "Otro");

            foreach (var item in valuess.Values)
            {
                GenDom.Items.Add(item);
            }

            GenDom.SelectedIndexChanged += (sender, args) =>
            {

                uno.Text = (GenDom.SelectedIndex + 37).ToString();

            };

            var lista = new List<string>()
            {
                "Federal",
                "Estatal"
            };

            TipoD.ItemsSource = lista;

            TipoD.SelectedIndexChanged += (sender, args) =>
            {

                etd.Text = TipoD.SelectedItem.ToString();

            };

        }
        protected override void OnAppearing()
        {
            //FIC: Aqui se declara una variable de tipo ViewModel Item
            var FicViewModel = BindingContext as FicVmRhCatDomiciliosItem;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);
        }

        protected override void OnDisappearing()
        {
            var FicViewModel = BindingContext as FicVmRhCatDomiciliosItem;
            if (FicViewModel != null) FicViewModel.OnDisappearing();
        }
    }
}

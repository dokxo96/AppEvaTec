using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppEvaTec.ViewModels.Personas;
using System.Net.Http;
using Newtonsoft.Json;
using Plugin.Connectivity;

namespace AppEvaTec.Views.Personas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FicViCpLogin : ContentPage
    {
        private object FicLoParameter { get; set; }
        public FicViCpLogin(object ficPaParameter)
        {
            InitializeComponent();
            FicLoParameter = ficPaParameter;
            BindingContext = App.FicMetLocator.FicVmLogin;

            NewUser.Clicked += NewUser_Clicked;
            BtnOc.Clicked += BtnOc_Clicked;
            BtnEntrar.Clicked += BtnEntrar_Clicked;
            
        }
        public void CheckInternet(object sender, EventArgs e)
        {
            statusInternet.Text = CrossConnectivity.Current.IsConnected ? "Connected" : "Disconnected";
        }
        private async void BtnEntrar_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(User.Text))
            {
                var j = new modal();
                await j.DisplayAlert("Error", "El usuario está vacio", "ok");
                User.Focus();
                return;

            }
            if (string.IsNullOrEmpty(Pass.Text))
            {
                var j = new modal();
                await j.DisplayAlert("Error", "La contraseña  está vacia", "ok");
                Pass.Focus();
                return;
            }

            if (statusInternet.Text == "Connected")
            {
                if (User.Text == "Admin" && Pass.Text == "admin")
                    {
                                     await MainProgress.ProgressTo(1, 2000, Easing.Linear);
                                     Device.BeginInvokeOnMainThread(async () => {

                                     //string dir ="http: //localhost:60304/api/usuarios?user"+Usuario+ "&password="+Contraseña;
                                     //HttpClient FicHttpClient = new HttpClient();

                                     //var response = await FicHttpClient.GetStringAsync("http://localhost:60304/api/usuarios?user=DMORAA&password=Dany01");
                                     try
                                         {
                                            //var test = JsonConvert.SerializeObject(response, Formatting.Indented);

                                            await ((NavigationPage)this.Parent).PushAsync(new FicViCpMainPage(null));

                                         }
                                     catch (Exception ex)
                                         {
                                            var j = new modal();
                                            await j.DisplayAlert("pruebas", "Servidor desactivado", "ok");
                                         }

                            });
                    }
            }
            else
            {
                //metodo local
                MainProgress.ProgressTo(1, 1000, Easing.SinIn);
                await ((NavigationPage)this.Parent).PushAsync(new FicViCpMainPage(null));
            }

           
            //((NavigationPage)this.Parent).PushAsync(new FicViCpMainPage(null));
        }
        private void BtnOc_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new FicViCpMainPage(null));
        }

        private void NewUser_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new FicViCpRegister(null));
        }

        private class modal : Page
        {

        }


    }
}
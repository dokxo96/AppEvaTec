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
using AppEvaTec.Views.Menu1;
using AppEvaTec.WebApi;

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
            CheckInternet(null, null);


        }

        

        public void CheckInternet(object sender, EventArgs e)
        {
            statusInternet.Text = CrossConnectivity.Current.IsConnected ? "Connected" : "Disconnected";
        }
        private async void BtnEntrar_Clicked(object sender, EventArgs e)
        {
           Device.BeginInvokeOnMainThread(async () => {
                EsperarAc.IsRunning = true;

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

                                     
                                     Device.BeginInvokeOnMainThread(async () => {
                                         string dir = "http://localhost:60304/api/verifica?user="+User.Text+"&password="+Pass.Text;
                                         RestClient cliente = new RestClient();
                                         var result = await cliente.Get<LoginModel>(dir+"");
                                         
                                        // http://localhost:60304/api/verifica?user=BARIASP&password=Brayan01
                                         if(result != null)
                                         {
                                            EsperarAc.IsRunning =false;

                                             await ((NavigationPage)this.Parent).PushAsync(new FicMasterPage());
                                         }
                                         else
                                         {
                                             var j = new modal();
                                             await j.DisplayAlert("pruebas", "JSon Vacio", "ok");
                                         }
                                             

                                     
                            });
                    
            }
            else if(statusInternet.Text == "Disconnected")
            {
                //metodo local
                
                if (User.Text == "Admin" && Pass.Text == "admin")
                {
                    var j = new modal();
                    await j.DisplayAlert("Aletra¡", "Estas Conectado sin conexion,por lo que los datos vizualizados podrian no ser los actuales", "ok");
                    EsperarAc.IsRunning = false;
                    await ((NavigationPage)this.Parent).PushAsync(new FicMasterPage());
                }
            }

            });
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
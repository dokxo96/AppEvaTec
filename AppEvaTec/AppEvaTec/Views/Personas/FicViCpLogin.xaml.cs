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

        }

        private void BtnOc_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new FicViMainPage(null));
        }

        private void NewUser_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new FicViCpRegister(null));
        }


    }
}
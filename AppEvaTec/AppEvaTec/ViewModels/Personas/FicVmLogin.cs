using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using AppEvaTec.Models.Personas;
using AppEvaTec.Interfaces.Navigation;
using AppEvaTec.Interfaces.Personas;
using AppEvaTec.ViewModels.Base;
using Xamarin.Forms;
using AppEvaTec.Views;
using System.Net.Http;
using Newtonsoft.Json;
using AppEvaTec.Views.Personas;
using System.Net.Http.Headers;
using System.Diagnostics;

namespace AppEvaTec.ViewModels.Personas
{
    public class FicVmLogin : FicViewModelBase
    {
        //private ObservableCollection<cat_personas> FicOcZt_cat_personas_Items;

        private IFicSrvNavigationCatPersonas FicLoSrvNavigationCatPersonas;
        private IFicSrvCatPersonas FicLoSrvCatPersonas;
        private string _Usuario;
        private string _Contraseña;
        private Boolean _Verdadero;

        private ICommand FicLoginCommand;
        private ICommand FicUserCommand;

        public FicVmLogin(
           IFicSrvNavigationCatPersonas ficPaSrvNavigationCatPersonas,
           IFicSrvCatPersonas ficPaSrvCatPersonas)
        {
            //FIC: se asigna el objeto que se recibe como parametro de tipo navigation services
            FicLoSrvNavigationCatPersonas = ficPaSrvNavigationCatPersonas;
            //FIC: se asigna el objeto que se recibe como parametro de tipo SqlServices 
            FicLoSrvCatPersonas = ficPaSrvCatPersonas;
        }

        public string Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }

        public string Contraseña
        {
            get { return _Contraseña; }
            set { _Contraseña = value; }
        }

        public Boolean Verdadero
        {
            get { return _Verdadero; }
            set { _Verdadero = value; }
        }
        /*public ICommand FicMetLoginCommand
        {
            // get { return FicLoginCommand = FicLoginCommand ?? new FicVmDelegateCommand(Login); }
            get { return FicLoginCommand = FicLoginCommand ?? new FicVmDelegateCommand(LoginWebApi); }
        }*/

        public ICommand FicMetUserCommand
        {
            get { return FicUserCommand = FicUserCommand ?? new FicVmDelegateCommand(User); }
        }

        public void User()
        {
            var ficZt_cat_productos = new cat_usuarios();
            FicLoSrvNavigationCatPersonas.FicMetNavigateTo<FicVmRegister>(ficZt_cat_productos);
        }

       
        private class modal : Page
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using AppEvaTec.Models.Personas;
using AppEvaTec.Interfaces.Navigation;
using AppEvaTec.Interfaces.Personas;
using AppEvaTec.ViewModels.Base;
using AppEvaTec.Helpers;
using SQLite;
using System.Threading.Tasks;

namespace AppEvaTec.ViewModels.Personas
{
    public class FicVmRegister : FicViewModelBase
    {

        private cat_usuarios Fic_Zt_Cat_Personas_Item;

        private IFicSrvNavigationCatPersonas FicLoSrvNavigationCatPersonas;
        private IFicSrvCatPersonas FicLoSrvCatPersonas;
        private string _Usuario;
        private string _Contrasena;
        private Boolean _Verdadero;

        private ICommand FicLoginCommand;

        public FicVmRegister(
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

        public string Contrasena
        {
            get { return _Contrasena; }
            set { _Contrasena = value; }
        }

        public Boolean Verdadero
        {
            get { return _Verdadero; }
            set { _Verdadero = value; }
        }

        public cat_usuarios Item
        {
            get
            {
                return Fic_Zt_Cat_Personas_Item;
            }
            set
            {
                Fic_Zt_Cat_Personas_Item = value;
                RaisePropertyChanged();
            }
        }

        public override void OnAppearing(object FicPaNavigationContext)
        {
            var FicLoZt_inventarios = FicPaNavigationContext as cat_usuarios;

            if (FicLoZt_inventarios != null)
            {
                Item = FicLoZt_inventarios;
            }

            base.OnAppearing(FicPaNavigationContext);
        }

        public ICommand FicMetLoginCommand
        {
            get { return FicLoginCommand = FicLoginCommand ?? new FicVmDelegateCommand(Login); }
        }


        public async void Login()
        {
            Verdadero = false;
            await FicLoSrvCatPersonas.FicMetInsertNewCatUsuarios(Item);
            FicLoSrvNavigationCatPersonas.FicMetNavigateBack();

        }
    }
}

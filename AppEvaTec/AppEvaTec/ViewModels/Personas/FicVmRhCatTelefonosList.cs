using System;
using System.Collections.Generic;
using System.Text;
using AppEvaTec.ViewModels.Base;
using System.Windows.Input;
using AppEvaTec.Models.Personas;
using AppEvaTec.Interfaces.Navigation;
using AppEvaTec.Interfaces.Personas;
using System.Collections.ObjectModel;
using AppEvaTec.Views;

namespace AppEvaTec.ViewModels.Personas
{
    public class FicVmRhCatTelefonosList : FicViewModelBase
    {
        private ObservableCollection<rh_cat_telefonos> FicOcZt_rh_cat_telefonos_Items;
        private rh_cat_telefonos FicZt_rh_cat_telefonos_SelectedItem;
        private string _busqueda;

        private ICommand ficAddCommand;
        private ICommand ficSearch;

        private IFicSrvNavigationCatPersonas FicLoSrvNavigationCatPersonas;
        private IFicSrvCatPersonas FicLoSrvCatPersonas;

        //FIC: Constructor
        public FicVmRhCatTelefonosList(
            IFicSrvNavigationCatPersonas ficPaSrvNavigationCatPersonas,
            IFicSrvCatPersonas ficPaSrvCatPersonas)
        {
            //FIC: se asigna el objeto que se recibe como parametro de tipo navigation services
            FicLoSrvNavigationCatPersonas = ficPaSrvNavigationCatPersonas;
            //FIC: se asigna el objeto que se recibe como parametro de tipo SqlServices 
            FicLoSrvCatPersonas = ficPaSrvCatPersonas;
        }
        public string busqueda
        {
            get { return _busqueda; }
            set { _busqueda = value; }
        }

        //FIC: Metodo para obtener la lista de registros de inventarios
        public ObservableCollection<rh_cat_telefonos> FicMetZt_rh_cat_telefonos_Items
        {
            get { return FicOcZt_rh_cat_telefonos_Items; }
            set
            {
                FicOcZt_rh_cat_telefonos_Items = value;
                RaisePropertyChanged();
            }
        }

        //FIC: Metodo para tomar solo un registro de la lista de registros de inventarios
        public rh_cat_telefonos FicMetZt_rh_cat_telefonos_SelectedItem
        {
            get { return FicZt_rh_cat_telefonos_SelectedItem; }
            set
            {
                FicZt_rh_cat_telefonos_SelectedItem = value;
                FicLoSrvNavigationCatPersonas.FicMetNavigateTo<FicVmRhCatTelefonosDetalle>(FicZt_rh_cat_telefonos_SelectedItem);
            }
        }

        //FIC: Metodo de tipo comando para agregar un registro 
        public ICommand ficMetAddCommand
        {
            get { return ficAddCommand = ficAddCommand ?? new FicVmDelegateCommand(AddCommandExecute); }
        }

        public ICommand ficMetSearch
        {
            get { return ficSearch = ficSearch ?? new FicVmDelegateCommand(Find); }
        }

        public override async void OnAppearing(object navigationContext)
        {
            base.OnAppearing(navigationContext);

            //FIC: Ejecuto uno de los metodos definidos en los servicios de Interfaz de inventarios
            var result = await FicLoSrvCatPersonas.FicMetGetListRhCatTelefonos(Global.ClaveReferencia);

            FicMetZt_rh_cat_telefonos_Items = new ObservableCollection<rh_cat_telefonos>();
            foreach (var ficPaItem in result)
            {
                FicMetZt_rh_cat_telefonos_Items.Add(ficPaItem);
            }
        }

        private void AddCommandExecute()
        {
            var ficZt_cat_productos = new rh_cat_telefonos();
            FicLoSrvNavigationCatPersonas.FicMetNavigateTo<FicVmRhCatTelefonosItem>(ficZt_cat_productos);
        }

        private async void Find()
        {



            if (busqueda.Equals(""))
            {
                var result1 = await FicLoSrvCatPersonas.FicMetGetListRhCatTelefonos(Global.ClaveReferencia);
                FicMetZt_rh_cat_telefonos_Items = new ObservableCollection<rh_cat_telefonos>();
                foreach (var ficPaItem in result1)
                {
                    FicMetZt_rh_cat_telefonos_Items.Add(ficPaItem);
                }

            }
            else
            {
                var result = await FicLoSrvCatPersonas.FicSearchRhCatTelefonos(busqueda);

                FicMetZt_rh_cat_telefonos_Items = new ObservableCollection<rh_cat_telefonos>();

                if (FicMetZt_rh_cat_telefonos_Items == null) { return; }
                else
                {
                    foreach (var ficPaItem in result)
                    {
                        FicMetZt_rh_cat_telefonos_Items.Add(ficPaItem);
                    }
                }
            }
        }
    }
}

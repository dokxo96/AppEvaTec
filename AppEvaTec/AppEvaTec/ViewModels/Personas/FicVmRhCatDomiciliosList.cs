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
    public class FicVmRhCatDomiciliosList : FicViewModelBase
    {
        private ObservableCollection<rh_cat_domicilios> FicOcZt_rh_cat_domicilios_Items;
        private rh_cat_domicilios FicZt_rh_cat_domicilios_SelectedItem;
        private string _busqueda;

        private ICommand ficAddCommand;
        private ICommand ficSearch;

        private IFicSrvNavigationCatPersonas FicLoSrvNavigationCatPersonas;
        private IFicSrvCatPersonas FicLoSrvCatPersonas;

        //FIC: Constructor
        public FicVmRhCatDomiciliosList(
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
        public ObservableCollection<rh_cat_domicilios> FicMetZt_rh_cat_domicilios_Items
        {
            get { return FicOcZt_rh_cat_domicilios_Items; }
            set
            {
                FicOcZt_rh_cat_domicilios_Items = value;
                RaisePropertyChanged();
            }
        }

        //FIC: Metodo para tomar solo un registro de la lista de registros de inventarios
        public rh_cat_domicilios FicMetZt_rh_cat_domicilios_SelectedItem
        {
            get { return FicZt_rh_cat_domicilios_SelectedItem; }
            set
            {
                FicZt_rh_cat_domicilios_SelectedItem = value;
                FicLoSrvNavigationCatPersonas.FicMetNavigateTo<FicVmRhCatDomiciliosDetalle>(FicZt_rh_cat_domicilios_SelectedItem);
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
            var result = await FicLoSrvCatPersonas.FicMetGetListRhCatDomicilios(Global.ClaveReferencia);

            FicMetZt_rh_cat_domicilios_Items = new ObservableCollection<rh_cat_domicilios>();
            foreach (var ficPaItem in result)
            {
                FicMetZt_rh_cat_domicilios_Items.Add(ficPaItem);
            }
        }

        private void AddCommandExecute()
        {
            var ficZt_cat_productos = new rh_cat_domicilios();
            FicLoSrvNavigationCatPersonas.FicMetNavigateTo<FicVmRhCatDomiciliosItem>(ficZt_cat_productos);
        }

        private async void Find()
        {



            if (busqueda.Equals(""))
            {
                var result1 = await FicLoSrvCatPersonas.FicMetGetListRhCatDomicilios(Global.ClaveReferencia);
                FicMetZt_rh_cat_domicilios_Items = new ObservableCollection<rh_cat_domicilios>();
                foreach (var ficPaItem in result1)
                {
                    FicMetZt_rh_cat_domicilios_Items.Add(ficPaItem);
                }

            }
            else
            {
                var result = await FicLoSrvCatPersonas.FicSearchRhCatDomicilios(busqueda);

                FicMetZt_rh_cat_domicilios_Items = new ObservableCollection<rh_cat_domicilios>();

                if (FicMetZt_rh_cat_domicilios_Items == null) { return; }
                else
                {
                    foreach (var ficPaItem in result)
                    {
                        FicMetZt_rh_cat_domicilios_Items.Add(ficPaItem);
                    }
                }
            }
        }
    }
}

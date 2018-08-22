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
    public class FicVmRhCatDomiciliosItem : FicViewModelBase
    {
        private rh_cat_domicilios Fic_Zt_rh_cat_domicilios_Item;
        private ObservableCollection<cat_personas> Fic_Items_Persona;
        public cat_personas Fic_Item_Persona;

        private ICommand FicSaveCommand;
        private ICommand FicDeleteCommand;
        private ICommand FicCancelCommand;


        private IFicSrvNavigationCatPersonas FicLoSrvNavigationCatPersonas;
        private IFicSrvCatPersonas FicLoSrvCatPersonas;

        public FicVmRhCatDomiciliosItem(
           IFicSrvNavigationCatPersonas FicPaSrvNavigationCatPersonas,
           IFicSrvCatPersonas FicPaSrvCatPersonas)
        {
            //FIC: se asigna el objeto que se recibe como parametro de tipo navigation services
            FicLoSrvNavigationCatPersonas = FicPaSrvNavigationCatPersonas;
            //FIC: se asigna el objeto que se recibe como parametro de tipo SqlServices 
            FicLoSrvCatPersonas = FicPaSrvCatPersonas;
        }

        public rh_cat_domicilios Item
        {
            get { return Fic_Zt_rh_cat_domicilios_Item; }
            set
            {
                Fic_Zt_rh_cat_domicilios_Item = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<cat_personas> FicMetItemsPersona
        {
            get { return Fic_Items_Persona; }
            set
            {
                Fic_Items_Persona = value;
                RaisePropertyChanged();
            }
        }

        public cat_personas SelectedPersona
        {
            get { return Fic_Item_Persona; }
            set
            {
                Fic_Item_Persona = value;
                RaisePropertyChanged();
            }
        }


        public ICommand FicMetSaveCommand
        {
            get { return FicSaveCommand = FicSaveCommand ?? new FicVmDelegateCommand(SaveCommandExecute); }
        }

        public ICommand FicMetDeleteCommand
        {
            get { return FicDeleteCommand = FicDeleteCommand ?? new FicVmDelegateCommand(DeleteCommandExecute); }
        }

        public ICommand FicMetCancelCommand
        {
            get { return FicCancelCommand = FicCancelCommand ?? new FicVmDelegateCommand(CancelCommandExecute); }
        }

        public async override void OnAppearing(object FicPaNavigationContext)
        {
            var FicLoZt_inventarios = FicPaNavigationContext as rh_cat_domicilios;

            if (FicLoZt_inventarios != null)
            {
                Item = FicLoZt_inventarios;
            }
            /*
            var result = await FicLoSrvCatPersonas.FicMetGetListCatPersonas();

            FicMetItemsPersona = new ObservableCollection<cat_personas>();
            foreach (var ficPaItem in result)
            {
                FicMetItemsPersona.Add(ficPaItem);
            }

            var resultCedi = await FicLoSrvCatPersonas.FitMetGetPersona(FicLoZt_inventarios);
            SelectedPersona = new cat_personas();
            if (resultCedi != null)
            {
                SelectedPersona = resultCedi;
            }
            */
            base.OnAppearing(FicPaNavigationContext);
        }


        private async void SaveCommandExecute()
        {
            Item.ClaveReferencia = Global.ClaveReferencia;
            Item.UsuarioReg = Global.UsuarioReg;
            await FicLoSrvCatPersonas.FicMetInsertNewRhCatDomicilios(Item);
            FicLoSrvNavigationCatPersonas.FicMetNavigateBack();
        }

        private async void DeleteCommandExecute()
        {
            await FicLoSrvCatPersonas.FicMetRemoveRhCatDomicilios(Item);
            FicLoSrvNavigationCatPersonas.FicMetNavigateBack();
        }

        private void CancelCommandExecute()
        {
            FicLoSrvNavigationCatPersonas.FicMetNavigateBack();
        }
    }
}

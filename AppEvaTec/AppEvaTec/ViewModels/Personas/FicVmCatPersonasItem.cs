using System;
using System.Collections.Generic;
using System.Text;
using AppEvaTec.ViewModels.Base;
using System.Windows.Input;
using AppEvaTec.Models.Personas;
using AppEvaTec.Interfaces.Navigation;
using AppEvaTec.Interfaces.Personas;
using System.Collections.ObjectModel;

namespace AppEvaTec.ViewModels.Personas
{
    public class FicVmCatPersonasItem : FicViewModelBase
    {
        private cat_personas Fic_Zt_Cat_Personas_Item;
        private ObservableCollection<cat_institutos> Fic_Items_Instituto;
        private cat_institutos Fic_Item_Instituto;

        private ICommand FicSaveCommand;
        private ICommand FicDeleteCommand;
        private ICommand FicCancelCommand;


        private IFicSrvNavigationCatPersonas FicLoSrvNavigationCatPersonas;
        private IFicSrvCatPersonas FicLoSrvCatPersonas;

        public FicVmCatPersonasItem(
           IFicSrvNavigationCatPersonas FicPaSrvNavigationCatPersonas,
           IFicSrvCatPersonas FicPaSrvCatPersonas)
        {
            //FIC: se asigna el objeto que se recibe como parametro de tipo navigation services
            FicLoSrvNavigationCatPersonas = FicPaSrvNavigationCatPersonas;
            //FIC: se asigna el objeto que se recibe como parametro de tipo SqlServices 
            FicLoSrvCatPersonas = FicPaSrvCatPersonas;
        }


        public cat_personas Item
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

        public ObservableCollection<cat_institutos> FicMetItemsInstituto
        {
            get { return Fic_Items_Instituto; }
            set
            {
                Fic_Items_Instituto = value;
                RaisePropertyChanged();
            }
        }

        public cat_institutos SelectedInstituto
        {
            get { return Fic_Item_Instituto; }
            set
            {
                Fic_Item_Instituto = value;
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
            var FicLoZt_inventarios = FicPaNavigationContext as cat_personas;

            if (FicLoZt_inventarios != null)
            {
                Item = FicLoZt_inventarios;
            }

            var result = await FicLoSrvCatPersonas.FicMetGetListInstitutos();

            FicMetItemsInstituto = new ObservableCollection<cat_institutos>();
            foreach (var ficPaItem in result)
            {
                FicMetItemsInstituto.Add(ficPaItem);
            }

            var resultCedi = await FicLoSrvCatPersonas.FitMetGetInstituto(FicLoZt_inventarios);
            SelectedInstituto = new cat_institutos();
            if (resultCedi != null)
            {
                SelectedInstituto = resultCedi;
            }

            base.OnAppearing(FicPaNavigationContext);
        }


        private async void SaveCommandExecute()
        {
            await FicLoSrvCatPersonas.FicMetInsertNewCatPersonas(Item);
            FicLoSrvNavigationCatPersonas.FicMetNavigateBack();
        }

        private async void DeleteCommandExecute()
        {
            await FicLoSrvCatPersonas.FicMetRemoveCatPersonas(Item);
            FicLoSrvNavigationCatPersonas.FicMetNavigateBack();
        }

        private void CancelCommandExecute()
        {
            FicLoSrvNavigationCatPersonas.FicMetNavigateBack();
        }


    }
}

using System.Collections.ObjectModel;
using System.Windows.Input;
using AppEvaTec.Models.Personas;
using AppEvaTec.Interfaces.Navigation;
using AppEvaTec.Interfaces.Personas;
using AppEvaTec.ViewModels.Base;


namespace AppEvaTec.ViewModels.Personas
{
    public class FicVmCatPersonasList : FicViewModelBase
    {
        private ObservableCollection<cat_personas> FicOcZt_cat_personas_Items;
        private cat_personas FicZt_cat_personas_SelectedItem;
        private string _busqueda;

        private ICommand ficAddCommand;
        private ICommand ficSearch;
        private ICommand ficDirWeb;
        private ICommand ficTelefonos;
        private ICommand ficDomicilios;

        private IFicSrvNavigationCatPersonas FicLoSrvNavigationCatPersonas;
        private IFicSrvCatPersonas FicLoSrvCatPersonas;

        //FIC: Constructor
        public FicVmCatPersonasList(
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
        public ObservableCollection<cat_personas> FicMetZt_cat_personas_Items
        {
            get { return FicOcZt_cat_personas_Items; }
            set
            {
                FicOcZt_cat_personas_Items = value;
                RaisePropertyChanged();
            }
        }

        //FIC: Metodo para tomar solo un registro de la lista de registros de inventarios
        public cat_personas FicMetZt_cat_personas_SelectedItem
        {
            get { return FicZt_cat_personas_SelectedItem; }
            set
            {
                FicZt_cat_personas_SelectedItem = value;
                FicLoSrvNavigationCatPersonas.FicMetNavigateTo<FicVmCatPersonasDetalle>(FicZt_cat_personas_SelectedItem);
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

        public ICommand ficMetDirWeb
        {
            get { return ficDirWeb = ficDirWeb ?? new FicVmDelegateCommand(DirWeb); }
        }

        public ICommand ficMetTelefonos
        {
            get { return ficTelefonos = ficTelefonos ?? new FicVmDelegateCommand(Telefonos); }
        }

        public ICommand ficMetDomicilios
        {
            get { return ficDomicilios = ficDomicilios ?? new FicVmDelegateCommand(Domicilios); }
        }

        public override async void OnAppearing(object navigationContext)
        {
            base.OnAppearing(navigationContext);

            //FIC: Ejecuto uno de los metodos definidos en los servicios de Interfaz de inventarios
            var result = await FicLoSrvCatPersonas.FicMetGetListCatPersonas();

            FicMetZt_cat_personas_Items = new ObservableCollection<cat_personas>();
            foreach (var ficPaItem in result)
            {
                FicMetZt_cat_personas_Items.Add(ficPaItem);
            }
        }

        private void AddCommandExecute()
        {
            var ficZt_cat_productos = new cat_personas();
            FicLoSrvNavigationCatPersonas.FicMetNavigateTo<FicVmCatPersonasItem>(ficZt_cat_productos);
        }

        private void DirWeb()
        {
            var ficZt_Dirweb = new rh_cat_dir_web();
            FicLoSrvNavigationCatPersonas.FicMetNavigateTo<FicVmRhCatDirWebList>(ficZt_Dirweb);
        }

        private void Domicilios()
        {
            var ficZt_Domicilios = new rh_cat_domicilios();
            FicLoSrvNavigationCatPersonas.FicMetNavigateTo<FicVmRhCatDomiciliosList>(ficZt_Domicilios);
        }

        private void Telefonos()
        {
            var ficZt_Telefonos = new rh_cat_telefonos();
            FicLoSrvNavigationCatPersonas.FicMetNavigateTo<FicVmRhCatTelefonosList>(ficZt_Telefonos);
        }

        private async void Find()
        {



            if (busqueda.Equals(""))
            {
                var result1 = await FicLoSrvCatPersonas.FicMetGetListCatPersonas();
                FicMetZt_cat_personas_Items = new ObservableCollection<cat_personas>();
                foreach (var ficPaItem in result1)
                {
                    FicMetZt_cat_personas_Items.Add(ficPaItem);
                }

            }
            else
            {
                var result = await FicLoSrvCatPersonas.FicSearchCatPersonas(busqueda);

                FicMetZt_cat_personas_Items = new ObservableCollection<cat_personas>();

                if (FicMetZt_cat_personas_Items == null) { return; }
                else
                {
                    foreach (var ficPaItem in result)
                    {
                        FicMetZt_cat_personas_Items.Add(ficPaItem);
                    }
                }
            }
        }
    }
}

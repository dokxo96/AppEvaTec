using AppEvaTec.Views.Personas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppEvaTec.Views.Menu1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FicMasterPageMaster : ContentPage
    {
        public ListView ListView;

        public FicMasterPageMaster()
        {
            InitializeComponent();

            BindingContext = new FicMasterPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class FicMasterPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<FicMasterPageMenuItem> MenuItems { get; }

            public FicMasterPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<FicMasterPageMenuItem>(new[]
                {
                    new FicMasterPageMenuItem { Id = 0, Title = "Lista  Personas",
                                                Icon ="ficAlmacen20x20.png",
                                                FicPageName ="FicViCpCatPersonasList",
                                                TargetType = typeof(FicViCpCatPersonasList)
                                                },
                    new FicMasterPageMenuItem { Id = 0, Title = "Detalle de Inventario",
                                                Icon ="ficAlmacen20x20.png",
                                                FicPageName ="FicViCpConteoInventarioItem",
                                                //TargetType = typeof(FicViCpConteoInventarioItem)
                                                },
                    new FicMasterPageMenuItem { Id = 0, Title = "Realizar Conteo",
                                                Icon ="ficAlmacen20x20.png",
                                                FicPageName ="FicViCpConteoInventarioItemInsert"//,
                                                //TargetType = typeof(FicViCpConteoInventarioItemIsert)
                                                },
                    new FicMasterPageMenuItem { Id = 0, Title = "Realizar Conteo",
                                                Icon ="ficAlmacen20x20.png",
                                                FicPageName ="FicViCpConteoInventarioItemInsert"//,
                                                //TargetType = typeof(FicViCpConteoInventarioItemIsert)
                                                },




                    new FicMasterPageMenuItem { Id = 4, Title = "Salir", Icon="ficAlmacen20x20.png" },
                });



            }


            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;

            void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            #endregion
        }
    }
}
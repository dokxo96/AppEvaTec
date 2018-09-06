using AppEvaTec.Views.Personas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppEvaTec.Views.Menu1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FicMasterPage : MasterDetailPage
    {
        public FicMasterPage()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var FicItemMenu = e.SelectedItem as FicMasterPageMenuItem;
            if (FicItemMenu == null)
                return;

            var FicPagina = FicItemMenu.FicPageName as string;
            switch (FicPagina)
            {
                case "FicViCpCatPersonasList":
                     FicItemMenu.TargetType = typeof(FicViCpCatPersonasList);
                    break;
                case "FicViCpConteoInventarioItem":
                   // FicItemMenu.TargetType = typeof(FicViCpConteoInventarioItem);
                    break;
                default:
                    break;
            }

            object[] FicObjeto = new object[1];
            //FIC: Sin enviar parametro
            var FicPageOpen = (Page)Activator.CreateInstance(FicItemMenu.TargetType);
            //var FicPageOpen = Activator.CreateInstance(typeof(FicViCpConteoInventarioList)) as Page;

            //FIC: Enviando como parametro un objeto vacio
            //var FicPageOpen = (Page)Activator.CreateInstance(FicItemMenu.TargetType,FicObjeto);
            //var FicPageOpen = (Page)Activator.CreateInstance(FicItemMenu.TargetType);
            FicPageOpen.Title = FicItemMenu.Title;

            Detail = new NavigationPage(FicPageOpen);
            //Detail = new NavigationPage((Page)Activator.CreateInstance(FicItemMenu.TargetType));
            IsPresented = false;
            MasterPage.ListView.SelectedItem = null;


        }
    }
}
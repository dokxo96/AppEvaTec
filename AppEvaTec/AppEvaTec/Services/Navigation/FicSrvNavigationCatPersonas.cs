using System;
using System.Collections.Generic;
using System.Text;
using AppEvaTec.Interfaces.Navigation;
using Xamarin.Forms;
using AppEvaTec.ViewModels.Personas;
using AppEvaTec.Views.Personas;


namespace AppEvaTec.Services.Navigation
{
    public class FicSrvNavigationCatPersonas : IFicSrvNavigationCatPersonas
    {
        private IDictionary<Type, Type> viewModelRouting = new Dictionary<Type, Type>()
        {

            { typeof(FicVmCatPersonasDetalle), typeof(FicViCpCatPersonasDetalle)},
            { typeof(FicVmCatPersonasItem), typeof(FicViCpCatPersonasItem)},
            { typeof(FicVmCatPersonasList), typeof(FicViCpCatPersonasList)},
            { typeof(FicVmRhCatDirWebDetalle), typeof(FicViCpRhCatDirWebDetalle)},
            { typeof(FicVmRhCatDirWebItem), typeof(FicViCpRhCatDirWebItem)},
            { typeof(FicVmRhCatDirWebList), typeof(FicViCpRhCatDirWebList)},
            { typeof(FicVmRhCatDomiciliosDetalle), typeof(FicViCpRhCatDomiciliosDetalle)},
            { typeof(FicVmRhCatDomiciliosItem), typeof(FicViCpRhCatDomiciliosItem)},
            { typeof(FicVmRhCatDomiciliosList), typeof(FicViCpRhCatDomiciliosList)},
            { typeof(FicVmRhCatTelefonosDetalle), typeof(FicViCpRhCatTelefonosDetalle)},
            { typeof(FicVmRhCatTelefonosItem), typeof(FicViCpRhCatTelefonosItem)},
            { typeof(FicVmRhCatTelefonosList), typeof(FicViCpRhCatTelefonosList)},
            { typeof(FicVmLogin), typeof(FicViCpLogin)},
            { typeof(FicVmRegister), typeof(FicViCpRegister)},
            { typeof(FicVmMainPage), typeof(MainPage)}

        };

        public void FicMetNavigateTo<TDestinationViewModel>(object navigationContext = null)
        {
            Type pageType = viewModelRouting[typeof(TDestinationViewModel)];
            var page = Activator.CreateInstance(pageType, navigationContext) as Page;

            if (page != null)
                Application.Current.MainPage.Navigation.PushAsync(page);
        }

        public void FicMetNavigateTo(Type destinationType, object navigationContext = null)
        {
            Type pageType = viewModelRouting[destinationType];
            var page = Activator.CreateInstance(pageType, navigationContext) as Page;

            if (page != null)
                Application.Current.MainPage.Navigation.PushAsync(page);
        }

        public void FicMetNavigateBack()
        {
            Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}

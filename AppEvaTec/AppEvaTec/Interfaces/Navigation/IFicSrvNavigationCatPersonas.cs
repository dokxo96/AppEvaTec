using System;
using System.Collections.Generic;
using System.Text;

namespace AppEvaTec.Interfaces.Navigation
{
    public interface IFicSrvNavigationCatPersonas
    {
        void FicMetNavigateTo<TDestinationViewModel>(object navigationContext = null);

        void FicMetNavigateTo(Type destinationType, object navigationContext = null);

        void FicMetNavigateBack();
    }
}

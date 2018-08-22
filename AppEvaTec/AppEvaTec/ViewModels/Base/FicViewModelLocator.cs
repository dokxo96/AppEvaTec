using Autofac;
using AppEvaTec.Services.Navigation;
using AppEvaTec.Services.Personas;
using AppEvaTec.Interfaces.Navigation;
using AppEvaTec.Interfaces.Personas;
using AppEvaTec.ViewModels.Personas;

namespace AppEvaTec.ViewModels.Base
{
    public class FicViewModelLocator
    {
        private static IContainer FicContainer;

        public FicViewModelLocator()
        {
            var builder = new ContainerBuilder();

            // ViewModels ++++++++++++++++++++++++++++++++++++++++++++


            //Catalogo de PERSONAS --------------------------
            builder.RegisterType<FicVmCatPersonasItem>();
            builder.RegisterType<FicVmCatPersonasList>();
            builder.RegisterType<FicVmCatPersonasDetalle>();


            //Catalogo de Domicilios
            builder.RegisterType<FicVmRhCatDomiciliosDetalle>();
            builder.RegisterType<FicVmRhCatDomiciliosList>();
            builder.RegisterType<FicVmRhCatDomiciliosItem>();

            //Catalogo de Telefonos
            builder.RegisterType<FicVmRhCatTelefonosDetalle>();
            builder.RegisterType<FicVmRhCatTelefonosList>();
            builder.RegisterType<FicVmRhCatTelefonosItem>();

            //Catalogo de DirWeb
            builder.RegisterType<FicVmRhCatDirWebDetalle>();
            builder.RegisterType<FicVmRhCatDirWebList>();
            builder.RegisterType<FicVmRhCatDirWebItem>();

            //etc
            builder.RegisterType<FicVmLogin>();
            builder.RegisterType<FicVmRegister>();
            builder.RegisterType<FicVmMainPage>();
            // Services ++++++++++++++++++++++++++++++++++++++++++++

            //Catalogo de PERSONAS
            builder.RegisterType<FicSrvNavigationCatPersonas>().As<IFicSrvNavigationCatPersonas>().SingleInstance();
            builder.RegisterType<FicSrvCatPersonasList>().As<IFicSrvCatPersonas>();

            if (FicContainer != null)
            {
                FicContainer.Dispose();
            }

            FicContainer = builder.Build();
        }


        //-------------------- CATALOGO DE PERSONAS ---------------------------
        //FIC: se manda llamar desde el backend de la View de List
        public FicVmCatPersonasItem FicVmCatPersonasItem
        {
            get { return FicContainer.Resolve<FicVmCatPersonasItem>(); }
        }

        public FicVmCatPersonasList FicVmCatPersonasList
        {
            get { return FicContainer.Resolve<FicVmCatPersonasList>(); }
        }

        public FicVmCatPersonasDetalle FicVmCatPersonasDetalle
        {
            get { return FicContainer.Resolve<FicVmCatPersonasDetalle>(); }
        }

        //--------------------- CATALOGO DE DOMICILIOS --------------------
        public FicVmRhCatDomiciliosItem FicVmRhCatDomiciliosItem
        {
            get { return FicContainer.Resolve<FicVmRhCatDomiciliosItem>(); }
        }

        public FicVmRhCatDomiciliosList FicVmRhCatDomiciliosList
        {
            get { return FicContainer.Resolve<FicVmRhCatDomiciliosList>(); }
        }

        public FicVmRhCatDomiciliosDetalle FicVmRhCatDomiciliosDetalle
        {
            get { return FicContainer.Resolve<FicVmRhCatDomiciliosDetalle>(); }
        }

        //Telefonos
        public FicVmRhCatTelefonosItem FicVmRhCatTelefonosItem
        {
            get { return FicContainer.Resolve<FicVmRhCatTelefonosItem>(); }
        }

        public FicVmRhCatTelefonosList FicVmRhCatTelefonosList
        {
            get { return FicContainer.Resolve<FicVmRhCatTelefonosList>(); }
        }

        public FicVmRhCatTelefonosDetalle FicVmRhCatTelefonosDetalle
        {
            get { return FicContainer.Resolve<FicVmRhCatTelefonosDetalle>(); }
        }

        //Dirweb
        public FicVmRhCatDirWebItem FicVmRhCatDirWebItem
        {
            get { return FicContainer.Resolve<FicVmRhCatDirWebItem>(); }
        }

        public FicVmRhCatDirWebList FicVmRhCatDirWebList
        {
            get { return FicContainer.Resolve<FicVmRhCatDirWebList>(); }
        }

        public FicVmRhCatDirWebDetalle FicVmRhCatDirWebDetalle
        {
            get { return FicContainer.Resolve<FicVmRhCatDirWebDetalle>(); }
        }

        //Otros
        public FicVmLogin FicVmLogin
        {
            get { return FicContainer.Resolve<FicVmLogin>(); }
        }

        public FicVmRegister FicVmRegister
        {
            get { return FicContainer.Resolve<FicVmRegister>(); }
        }

        public FicVmMainPage FicVmMainPage
        {
            get { return FicContainer.Resolve<FicVmMainPage>(); }
        }
    }
}

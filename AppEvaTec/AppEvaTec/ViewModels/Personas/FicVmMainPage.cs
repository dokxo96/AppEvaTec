using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using AppEvaTec.Models.Personas;
using AppEvaTec.Interfaces.Navigation;
using AppEvaTec.Interfaces.Personas;
using AppEvaTec.ViewModels.Base;
using Xamarin.Forms;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

namespace AppEvaTec.ViewModels.Personas
{
    public class FicVmMainPage : FicViewModelBase
    {
        // private ObservableCollection<cat_personas> FicOcZt_cat_personas_Items;

        private IFicSrvNavigationCatPersonas FicLoSrvNavigationCatPersonas;
        private IFicSrvCatPersonas FicLoSrvCatPersonas;
        private string _Correo;

        private ICommand FicCorreoCommand;

        public FicVmMainPage(
           IFicSrvNavigationCatPersonas ficPaSrvNavigationCatPersonas,
           IFicSrvCatPersonas ficPaSrvCatPersonas)
        {
            //FIC: se asigna el objeto que se recibe como parametro de tipo navigation services
            FicLoSrvNavigationCatPersonas = ficPaSrvNavigationCatPersonas;
            //FIC: se asigna el objeto que se recibe como parametro de tipo SqlServices 
            FicLoSrvCatPersonas = ficPaSrvCatPersonas;
        }

        public string Correo
        {
            get { return _Correo; }
            set { _Correo = value; }
        }

        public ICommand FicMetCorreoCommand
        {
            get { return FicCorreoCommand = FicCorreoCommand ?? new FicVmDelegateCommand(Correos); }
        }

        public async void Correos()
        {
            var p = new modal();

            var R_Correo = await FicLoSrvCatPersonas.FitMetGetUsuario(Correo);
            await p.DisplayAlert("Prueba", R_Correo.Correo, "Aceptar", "Cancelar");

            var emailValue = Correo;
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Contraseña Temporal", "sysnewpass@gmail.com"));
            message.To.Add(new MailboxAddress("Usuario", "" + emailValue));
            message.Subject = "Contraseña";


            String NewPass = CrearPassword(6);
            message.Body = new TextPart("plain")
            {
                Text = @"Tu contraseña temporal para ingresar al sistema es: " + NewPass
            };

            R_Correo.Contrasena = NewPass;

            await FicLoSrvCatPersonas.FicMetInsertNewCatUsuarios(R_Correo);

            using (var client = new SmtpClient())
            {

                client.Connect("smtp.gmail.com", 587, false);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate("sysnewpass@gmail.com", "contra1234");
                client.Send(message);
                client.Disconnect(true);
                var m = new modal();
                await m.DisplayAlert("Aviso", "Tu contraseña temporal se envió de forma correcta al correo: " + emailValue, "Aceptar");
                //((NavigationPage)this.Parent).PushAsync(new FicViCpLogin(null));

            }

        }

        public string CrearPassword(int longitud)
        {
            string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < longitud--)
            {
                res.Append(caracteres[rnd.Next(caracteres.Length)]);
            }
            return res.ToString();
        }

        private class modal : Page
        {

        }
    }
}

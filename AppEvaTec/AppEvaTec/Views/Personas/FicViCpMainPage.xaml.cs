using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using AppEvaTec.Views.Personas;
using AppEvaTec.ViewModels.Personas;


namespace AppEvaTec.Views.Personas
{
    public partial class FicViCpMainPage : ContentPage
    {
        private object FicLoParameter { get; set; }
        public MainPage(object ficPaParameter)
        {
            InitializeComponent();
            FicLoParameter = ficPaParameter;

            BindingContext = App.FicMetLocator.FicVmMainPage;
        }
        protected override void OnAppearing()
        {
            //FIC: Aqui se declara una variable de tipo ViewModel Item

            var FicViewModel = BindingContext as FicVmMainPage;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);


        }

        protected override void OnDisappearing()
        {
            var FicViewModel = BindingContext as FicVmMainPage;
            if (FicViewModel != null) FicViewModel.OnDisappearing();
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

        private void Enviar_Clicked(object sender, EventArgs e)
        {
            var emailValue = getEmail.Text;
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Contraseña Temporal", "sysnewpass@gmail.com"));
            message.To.Add(new MailboxAddress("Usuario", "" + emailValue));
            message.Subject = "Contraseña";

            String NewPass = CrearPassword(6);
            message.Body = new TextPart("plain")
            {
                Text = @"Tu contraseña temporal para ingresar al sistema es: " + NewPass
            };

            using (var client = new SmtpClient())
            {

                client.Connect("smtp.gmail.com", 587, false);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate("sysnewpass@gmail.com", "contra1234");
                client.Send(message);
                client.Disconnect(true);
                var m = new modal();
                m.DisplayAlert("Aviso", "Tu contraseña temporal se envió de forma correcta al correo: " + emailValue, "Aceptar");
                ((NavigationPage)this.Parent).PushAsync(new FicViCpLogin(null));

            }
        }

        private class modal : Page
        {

        }
    }

}
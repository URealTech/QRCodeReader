using qrReader.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace qrReader.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            var vm = new LoginViewModel();
            this.BindingContext = new LoginViewModel();
            vm.DisplayInvalidLoginPrompt += () => DisplayAlert("Hata", "Geçersiz Email & şifre, tekrar deneyin", "Tamam");

            Email.Completed += (object sender, EventArgs e) =>
            {
                Password.Focus();
            };

            Password.Completed += (object sender, EventArgs e) =>
            {
                vm.SubmitCommand.Execute(null);
            };
        }
        private void loginSubmitButton_Clicked(object sender, EventArgs e)
        {
            Password.Text = "";
            Email.Text = "";
        }
    }
}
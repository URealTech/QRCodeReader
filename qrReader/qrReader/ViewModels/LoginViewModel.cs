using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using qrReader.Views;

namespace qrReader.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public Action DisplayInvalidLoginPrompt;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        public ICommand SubmitCommand { protected set; get; }
        public LoginViewModel()
        {
            SubmitCommand = new Command(OnSubmit);
        }
        public async void OnSubmit()
        {
            if (email == "admin" || password == "admin")
            {
                await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
            }
            else
            {
                DisplayInvalidLoginPrompt();
            }
        }
    }
}

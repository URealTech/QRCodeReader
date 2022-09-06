using System.Windows.Input;

namespace qrReader.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "QRCode";
        }
        public ICommand OpenWebCommand { get; }
    }
}
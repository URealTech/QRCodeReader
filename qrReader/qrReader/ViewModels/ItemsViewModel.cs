using System.Windows.Input;

namespace qrReader.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ItemsViewModel()
        {
            Title = "Gecmis";
        }
        public ICommand OpenWebCommand { get; }
    }
}
using Xamarin.Forms;
using qrReader.Models;

namespace qrReader
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();

            connClass.Conn = DependencyService.Get<DBConnectionInterface>().GetConnection();
            connClass.Conn.CreateTable<historyDescription>();
        }
        protected override void OnStart()
        {
        }
        protected override void OnSleep()
        {
        }
        protected override void OnResume()
        {
        }
    }
}

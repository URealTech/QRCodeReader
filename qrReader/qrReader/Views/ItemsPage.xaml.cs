using qrReader.Models;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace qrReader.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
        private int selectedItemPk = -1;

        public ItemsPage()
        {
            InitializeComponent();
            var data = (from use in connClass.Conn.Table<historyDescription>() select use);
            historyXAMList.ItemsSource = data;
        }
        private void historyXAMList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var desc = e.Item as historyDescription;

            selectedItemPk = desc.Id;
        }
        private void showButton_Clicked(object sender, EventArgs e)
        {
            selectedItemPk = -1;
            var data = (from use in connClass.Conn.Table<historyDescription>() select use);
            historyXAMList.ItemsSource = data;
        }
        private void deleteButton_Clicked(object sender, EventArgs e)
        {
            if (selectedItemPk != -1)
            {
                connClass.Conn.Delete<historyDescription>(selectedItemPk);
                selectedItemPk = -1;
                var data = (from use in connClass.Conn.Table<historyDescription>() select use);
                historyXAMList.ItemsSource = data;
            }
        }
    }
}
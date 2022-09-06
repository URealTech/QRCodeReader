using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Security.Cryptography;
using System.IO;
using qrReader.Models;
using System.Text;

namespace qrReader.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        private int selectedItemPk = -1;

        private static byte[] IV = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public string SQLSymetricKey = "ePPhSSJIguIlaLys";
        public AboutPage()
        {
            InitializeComponent();
            zxing.OnScanResult += (result) => Device.BeginInvokeOnMainThread(async () =>
            {
                lblResult.Text = result.Text;
                try
                {
                    lblDecrypt.Text = Decrypt(lblResult.Text, SQLSymetricKey, IV);
                }
                catch
                {
                    lblDecrypt.Text = result.Text;
                }
            });
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            zxing.IsScanning = true;
        }
        protected override void OnDisappearing()
        {
            zxing.IsScanning = false;
            base.OnDisappearing();
        }
        private void addButton_Clicked(object sender, EventArgs e)
        {
            historyDescription USE_Rec = new historyDescription();
            USE_Rec.descriptionHistory = lblDecrypt.Text;

            connClass.Conn.Insert(USE_Rec);
        }
        private void historyXAMList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var desc = e.Item as historyDescription;

            selectedItemPk = desc.Id;
            lblDecrypt.Text = desc.descriptionHistory;
        }
        private void clearButton_Clicked(object sender, EventArgs e)
        {
            lblDecrypt.Text = "";
        }
        private string Decrypt(string plaintext, string lblResult, byte[] IV)
        {
            byte[] Key = Encoding.UTF8.GetBytes(lblResult);


            AesManaged aes = new AesManaged();
            aes.Key = Key;
            aes.IV = IV;

            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write);

            byte[] InputBytes = Convert.FromBase64String(plaintext);
            cryptoStream.Write(InputBytes, 0, InputBytes.Length);
            cryptoStream.FlushFinalBlock();

            byte[] Decrypted = memoryStream.ToArray();

            return UTF8Encoding.UTF8.GetString(Decrypted, 0, Decrypted.Length);
        }
    }
}
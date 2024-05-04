using MBussinesLayer;

using MEntityLayer;

namespace MauiAppNLayered1
{
    public partial class MainPage : ContentPage
    {
        string ErrorMessage="";

        public MainPage()
        {
            InitializeComponent();

            if (!BL.MusterileriYukle(ref ErrorMessage))
                DisplayAlert("Hata", ErrorMessage, "OK");
            else
                listMusteriler.ItemsSource = BL.Musteriler;
        }


        private async void MusteriEkleClicked(object sender, EventArgs e)
        {
            MusteriEditPage page = new MusteriEditPage()
            {
                Title = "Müşteri Ekle",
                AddUserMethod = this.AddUser
            };
            await Navigation.PushModalAsync(page);
        }

        void AddUser(string ad, string soy, string tel, string mail, string adr)
        {
            Musteri musteri = new Musteri(){ Ad = ad, Soyad = soy, Telefon = tel, Email=mail, Adres = adr };

            bool res = BL.MusteriEkle(musteri, ref ErrorMessage);
            if(!res)
                DisplayAlert("Hata", ErrorMessage, "OK");

        }



        private async void MusteriDuzenleClicked(object sender, EventArgs e)
        {
            var bt = sender as Button;
            var musteri = BL.Musteriler.First(o=>o.ID == bt.CommandParameter.ToString());
            MusteriEditPage page = new MusteriEditPage(musteri)
            {
                Title = "Müşteri Düzenle",
                EditUserMethod = this.EditUser
            };
            await Navigation.PushModalAsync(page);

        }

        void EditUser(Musteri musteri)
        {
            bool res = BL.MusteriDuzenle(musteri, ref ErrorMessage);
            if (!res)
                DisplayAlert("Hata", ErrorMessage, "OK");

        }

        private void MusteriResimClicked(object sender, EventArgs e)
        {

        }



        private async void MusteriSilClicked(object sender, EventArgs e)
        {
            var bt = sender as Button;
            var musteri = BL.Musteriler.First(o=>o.ID == bt.CommandParameter.ToString());

            var result =  await DisplayAlert("Silinsin mi", "Silmeyi Onayla", "OK", "İptal");
            if (result)
            {
                bool res = BL.MusteriSil(musteri, ref ErrorMessage);
                if (!res)
                    DisplayAlert("Hata", ErrorMessage, "OK");
            }

        }

      
    }

}

using MEntityLayer;

namespace MauiAppNLayered1;

public partial class MusteriEditPage : ContentPage
{
    Musteri musteri = null;
	public MusteriEditPage(Musteri mus=null)
	{
		InitializeComponent();
        musteri = mus;

        BindingContext = musteri;

        /*if(musteri!=null)
        {
            musteriID = musteri.ID;

            txtAd.Text = musteri.Ad;
            txtSoy.Text = musteri.Soyad;
            txtTel.Text = musteri.Telefon;
            txtAdr.Text = musteri.Adres;
            txtMai.Text = musteri.Email;
        }*/
	}

    public Action<string,string ,string,string,string> AddUserMethod;
    public Action<Musteri> EditUserMethod;

    private void OkButton_Clicked(object sender, EventArgs e)
    {
        if (AddUserMethod != null)
            AddUserMethod(txtAd.Text, txtSoy.Text, txtTel.Text, txtMai.Text, txtAdr.Text);
        if (EditUserMethod != null)
            EditUserMethod(musteri);


        Navigation.PopModalAsync();
    }

    private void CancelButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }
}
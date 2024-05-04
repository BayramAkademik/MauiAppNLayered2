using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MEntityLayer
{
    /// <summary>
    /// Müşteri
    /// </summary>
    public class Musteri : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        private string id, ad, soy, tel,mail,adres,resim;


        /// <summary>
        /// Müşteri ID için kullanılır.
        /// </summary>
        public string ID
        {
            get
            {
                if (id == null)
                    id = Guid.NewGuid().ToString();
                return id;
            }
            set { id = value; }
        }

        /// <summary>
        /// Müşteri Adı için kullanılır
        /// </summary>
        public string Ad
        {
            get => ad;
            set
            {
                ad = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged("AdSoyad");
            }
        }

        /// <summary>
        /// Müşteri Soyadı için kullanılır
        /// </summary>
        public string Soyad
        {
            get => soy;
            set
            {
                soy = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged("AdSoyad");
            }
        }

        /// <summary>
        /// Müşteri Adı ve Soyadı
        /// </summary>
        public string AdSoyad { get => ad + " " + soy; }


        /// <summary>
        /// Müşteri Telefon Numarası
        /// </summary>
        public string Telefon
        {
            get => tel;
            set
            {
                tel = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Müşteri E-Mail adresi
        /// </summary>
        public string Email
        {
            get => mail;
            set
            {
                mail = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Müşteri Adresi
        /// </summary>
        public string Adres
        {
            get => adres;
            set
            {
                adres = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Müşteri resmi
        /// </summary>
        public string Resim
        {
            get => resim;
            set
            {
                resim = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Müşteri işlemleri
        /// </summary>
        public List<MusteriIslem> Islemler { get; set; } = new();

        public double ToplamBorc => Islemler.Sum(o => o.Tutar);
    }
}

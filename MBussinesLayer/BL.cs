using MDataLayer;
using MEntityLayer;

using System.Collections.ObjectModel;

namespace MBussinesLayer
{
    // All the code in this file is included in all platforms.
    public static class BL
    {
        public static ObservableCollection<Musteri> Musteriler;

        /// <summary>
        /// Veritabanındaki müşterileri Koleksiyona yükler
        /// </summary>
        /// <param name="mesaj">Hata oluşursa hata mesajını buradan alın</param>
        public static bool MusterileriYukle(ref string mesaj)
        {
            Musteriler = DL.MusterileriYukle(ref mesaj);
            return Musteriler != null;
        }

        /// <summary>
        /// Koleksiyona ve veritabanına müşteri ekler, eğer hata oluşursa hatayı üst katmana taşır.
        /// </summary>
        /// <param name="m">Müşteri</param>
        /// <param name="mesaj">Hata oluşursa hata mesajını buradan alın</param>
        /// <returns>Başarılı olursa true, aksi halde false</returns>
        public static bool MusteriEkle(Musteri m, ref string mesaj)
        {
            if (m == null)
                return false;

            bool res= DL.MusteriEkle(m, ref mesaj);
            if(res)
                Musteriler.Add(m);

            return res;
        }

        /// <summary>
        /// Koleksiyondaki ve veritabanındaki müşteriyi günceller, eğer hata oluşursa hatayı üst katmana taşır.
        /// </summary>
        /// <param name="m">Müşteri</param>
        /// <param name="mesaj">Hata oluşursa hata mesajını buradan alın</param>
        /// <returns>Başarılı olursa true, aksi halde false</returns>
        public static bool MusteriDuzenle(Musteri m, ref string mesaj)
        {
            if(m == null)
               return false;

            bool res = DL.MusteriDuzenle(m, ref mesaj);
            if (res)
            {
                var mus = Musteriler.First(o=>o.ID == m.ID);
                mus = m;
            }

            return res;

        }

        /// <summary>
        /// Koleksiyondaki ve veritabanındaki müşteriyi siler, eğer hata oluşursa hatayı üst katmana taşır.
        /// </summary>
        /// <param name="m">Müşteri</param>
        /// <param name="mesaj">Hata oluşursa hata mesajını buradan alın</param>
        /// <returns>Başarılı olursa true, aksi halde false</returns>
        public static bool MusteriSil(Musteri m, ref string mesaj)
        {
            if (m == null)
                return false;

            bool res= DL.MusteriSil(m, ref mesaj);
            if( res)
            {
                var mus = Musteriler.First(o=>o.ID == m.ID);
                Musteriler.Remove(mus);
            }

            return res;
        }
    }
}

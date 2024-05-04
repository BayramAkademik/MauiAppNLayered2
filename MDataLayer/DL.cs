#define MYSQL



using MEntityLayer;

using System.Collections.ObjectModel;

#if MYSQL
using DBConnection = MySql.Data.MySqlClient.MySqlConnection;
using DBCommand = MySql.Data.MySqlClient.MySqlCommand;
using DBDataReader = MySql.Data.MySqlClient.MySqlDataReader;
using DBConnectionStringBuilder = MySql.Data.MySqlClient.MySqlConnectionStringBuilder;

#elif MSSQL

#elif FIREBASE
#endif



namespace MDataLayer
{
    // All the code in this file is included in all platforms.
    public static class DL
    {

        static DBConnection connection =
            new DBConnection(
            new DBConnectionStringBuilder()
            {
#if MYSQL
                // Dikkat kendi server ip'niz
               Server = "172.28.96.1",
               Database = "veresiye",
               UserID = "user1",
               Password = "WfnXy123",
               Port = 3306,
#elif MSSQL
                
#endif
            }.ConnectionString
        );


        /// <summary>
        /// Veritabanına müşteri ekler.
        /// </summary>
        /// <param name="m">Müşteri</param>
        /// <param name="mesaj">Eğer hata oluşursa hata mesajını buradan alın</param>
        /// <returns>Başarılı olursa true, aksi halde false</returns>
        public static bool MusteriEkle(Musteri m, ref string mesaj)
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                DBCommand command = new DBCommand("musteri_ekle", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@mid", m.ID);
                command.Parameters.AddWithValue("@adi", m.Ad);
                command.Parameters.AddWithValue("@soy", m.Soyad);
                command.Parameters.AddWithValue("@tel", m.Telefon);
                command.Parameters.AddWithValue("@mai", m.Email);
                command.Parameters.AddWithValue("@adr", m.Adres);
                command.Parameters.AddWithValue("@res", m.Resim);

                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                mesaj = e.Message;
                return false;
            }
            finally
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                    connection.Close();
            }

            return true;
        }

        /// <summary>
        /// Veritabanındaki müşteriyi günceller.
        /// </summary>
        /// <param name="m">Müşteri</param>
        /// <param name="mesaj">Eğer hata oluşursa hata mesajını buradan alın</param>
        /// <returns>Başarılı olursa true, aksi halde false</returns>
        public static bool MusteriDuzenle(Musteri m, ref string mesaj)
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                DBCommand command = new DBCommand("musteri_duzenle", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@mid", m.ID);
                command.Parameters.AddWithValue("@adi", m.Ad);
                command.Parameters.AddWithValue("@soy", m.Soyad);
                command.Parameters.AddWithValue("@tel", m.Telefon);
                command.Parameters.AddWithValue("@mai", m.Email);
                command.Parameters.AddWithValue("@adr", m.Adres);
                command.Parameters.AddWithValue("@res", m.Resim);

                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                mesaj = e.Message;
                return false;
            }
            finally
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                    connection.Close();
            }
            return true;
        }

        /// <summary>
        /// Veritabanındaki müşteriyi siler.
        /// </summary>
        /// <param name="m">Müşteri</param>
        /// <param name="mesaj">Eğer hata oluşursa hata mesajını buradan alın</param>
        /// <returns>Başarılı olursa true, aksi halde false</returns>
        public static bool MusteriSil(Musteri m, ref string mesaj)
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                DBCommand command = new DBCommand("musteri_sil", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@mid", m.ID);

                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                mesaj = e.Message;
                return false;
            }
            finally
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                    connection.Close();
            }
            return true;
        }

        /// <summary>
        /// Veritabanından müşterileri yükler.
        /// </summary>
        /// <param name="mesaj">Eğer hata oluşursa hata mesajını buradan alın</param>
        /// <returns>Müşretilerin listesi</returns>
        public static ObservableCollection<Musteri> MusterileriYukle(ref string mesaj)
        {
            ObservableCollection < Musteri >  Liste = null; 
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                DBCommand command = new DBCommand("musteri_listele", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                DBDataReader reader = command.ExecuteReader();
                Liste = new ObservableCollection<Musteri>();
                while(reader.Read())
                {
                    Musteri m = new Musteri()
                    {
                        ID = reader["id"].ToString(),
                        Ad = reader["ad"].ToString(),
                        Soyad = reader["soyad"].ToString(),
                        Telefon = reader["telefon"].ToString(),
                        Email = reader["mail"].ToString(),
                        Adres = reader["adres"].ToString(),
                        Resim = reader["resim"].ToString(),
                    };
                    Liste.Add(m);
                }

            }
            catch (Exception e)
            {
                mesaj = e.Message;
                return null;
            }
            finally
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                    connection.Close();
            }


            return Liste;

            
        }
    }
}

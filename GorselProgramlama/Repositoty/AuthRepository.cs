using GorselProgramlama.Business;
using GorselProgramlama.Data;
using GorselProgramlama.Properties;
using Microsoft.Data.SqlClient;

namespace GorselProgramlama.Repositoty;

public class AuthRepository : IAuthRepository
{
    public AuthRepository()
    {
        
    }

    public void CreateUser(tblUser user)
    {
        // Using bloğu bağlantıyı iş bitince otomatik kapatır.
        using (var conn = new SqlConnection(AuthService._connString))
        {
            conn.Open();

            // Sütun isimlerini açıkça belirtmek zorundayız.
            string query = "INSERT INTO dbo.tblUser (PlateNumber, Password, Name, Surname) VALUES (@plaka, @sifre, @ad, @soyad)";

            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@plaka", user.PlateNumber);
                cmd.Parameters.AddWithValue("@sifre", user.Password);
                cmd.Parameters.AddWithValue("@ad", user.Name);
                cmd.Parameters.AddWithValue("@soyad", user.Surname);

                cmd.ExecuteNonQuery();
            }
        }
    }

    // Kullanıcıyı Plaka numarasına veya Kullanıcı Adına göre çekmeliyiz. 
    // ID ile değil, çünkü Login ekranında ID girilmez.
    public tblUser GetUser(string plateNumber)
    {
        tblUser u = null; // Başlangıçta null olsun.

        using (var conn = new SqlConnection(AuthService._connString))
        {
            conn.Open();
            // Sorguyu PlateNumber'a göre yapıyoruz
            var cmd = new SqlCommand("SELECT * FROM dbo.tblUser WHERE PlateNumber = @p", conn);
            cmd.Parameters.AddWithValue("@p", plateNumber);

            using (var dr = cmd.ExecuteReader())
            {
                if (dr.Read())
                {
                    u = new tblUser();
                    // Veritabanı sütun isimlerinizin doğru olduğundan emin olun
                    u.ID = Convert.ToInt32(dr["Id"]);
                    u.PlateNumber = dr["PlateNumber"].ToString();
                    u.Password = dr["Password"].ToString(); // DB'deki hashli şifre
                    u.Name = dr["Name"].ToString();
                    u.Surname = dr["Surname"].ToString();
                }
            }
        }
        return u;
    }

    public class ParkingRepository
    {
        

        // Belirli bir kattaki DOLU park yerlerini getirir
        public List<tblParkIslemleri> GetDoluParkYerleri(int katNo)
        {
            List<tblParkIslemleri> doluYerListesi = new List<tblParkIslemleri>();

            using (SqlConnection conn = new SqlConnection(AuthService._connString))
            {
               
                    conn.Open();

                    // Sadece Çıkış Saati NULL olanları (Hala içeridekileri) getir
                    // Eğer Plaka bilgisini de çekmek istersen JOIN kullanman gerekir.
                    // Şimdilik sadece UserID ve ParkYeriNumarasi çekiyoruz.
                    string query = @"
                        SELECT ParkYeriNumarasi, UserID, GirisSaati 
                        FROM tblParkIslemleri 
                        WHERE KatNumarasi = @kat AND CikisSaati IS NULL";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@kat", katNo);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                tblParkIslemleri kayit = new tblParkIslemleri();

                                // Veritabanından gelenleri class'a doldur
                                kayit.ParkYeriNumarasi = Convert.ToInt32(reader["ParkYeriNumarasi"]);
                                kayit.UserID = Convert.ToInt32(reader["UserID"]);
                                kayit.GirisSaati = Convert.ToDateTime(reader["GirisSaati"]);

                                doluYerListesi.Add(kayit);
                            }
                        }
                    }
               
            }
            return doluYerListesi;
        }
    }

    public void VeritabaniniKompleSifirla()
    {
        using (SqlConnection conn = new SqlConnection(AuthService._connString))
        {
            conn.Open();

            // SQL Kodu: Önce Park İşlemleri, Sonra Kullanıcılar silinir.
            // ID sayaçları (Identity) 0'a eşitlenir.
            string query = @"
            DELETE FROM tblParkIslemleri;
            DBCC CHECKIDENT ('tblParkIslemleri', RESEED, 0);

            DELETE FROM tblUser;
            DBCC CHECKIDENT ('tblUser', RESEED, 0);";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}
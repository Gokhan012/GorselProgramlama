using GorselProgramlama.Data;
using Microsoft.Data.SqlClient;

namespace GorselProgramlama.Repositoty;

internal class AuthRepository : IAuthRepository
{
    private string _connString;
    public AuthRepository(string connectionString)
    {
        _connString = connectionString;
    }

    public void CreateUser(tblUser user)
    {
        // Using bloğu bağlantıyı iş bitince otomatik kapatır.
        using (var conn = new SqlConnection(_connString))
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

        using (var conn = new SqlConnection(_connString))
        {
            conn.Open();
            // Sorguyu PlateNumber'a göre yapıyoruz
            var cmd = new SqlCommand("SELECT * FROM dbo.Users WHERE PlateNumber = @p", conn);
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
}
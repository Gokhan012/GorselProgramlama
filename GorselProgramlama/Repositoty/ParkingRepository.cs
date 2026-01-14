using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using GorselProgramlama.Business;
using GorselProgramlama.Data;

namespace GorselProgramlama.Repositoty
{
    public class ParkingRepository
    {
        public DataTable GetDoluParkYerleri(int katNo)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(AuthService._connString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT p.ParkYeriNumarasi, p.UserID, u.PlateNumber
                        FROM tblParkIslemleri p
                        INNER JOIN tblUser u ON p.UserID = u.ID
                        WHERE p.KatNumarasi = @kat AND p.CikisSaati IS NULL";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@kat", katNo);
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Veri hatası: " + ex.Message);
                }
            }
            return dt;
        }

        public void ParkEt(int userId, int katNo, int parkNo)
        {
            using (SqlConnection conn = new SqlConnection(AuthService._connString))
            {
                conn.Open();
                string query = @"INSERT INTO tblParkIslemleri (UserID, KatNumarasi, ParkYeriNumarasi, GirisSaati, Durum) 
                                 VALUES (@uid, @kat, @park, @tarih, 1)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@uid", userId);
                    cmd.Parameters.AddWithValue("@kat", katNo);
                    cmd.Parameters.AddWithValue("@park", parkNo);
                    cmd.Parameters.AddWithValue("@tarih", DateTime.Now);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool BuParkYeriBenimMi(int userId, int katNo, int parkNo)
        {
            using (SqlConnection conn = new SqlConnection(AuthService._connString))
            {
                conn.Open();
                string query = @"SELECT COUNT(*) FROM tblParkIslemleri 
                                 WHERE UserID = @uid AND KatNumarasi = @kat 
                                 AND ParkYeriNumarasi = @park AND CikisSaati IS NULL";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@uid", userId);
                    cmd.Parameters.AddWithValue("@kat", katNo);
                    cmd.Parameters.AddWithValue("@park", parkNo);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public bool KullanicininIcerideAraciVarMi(int userId)
        {
            using (SqlConnection conn = new SqlConnection(AuthService._connString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM tblParkIslemleri WHERE UserID = @uid AND CikisSaati IS NULL";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@uid", userId);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public DateTime GetGirisSaati(int userId, int katNo, int parkNo)
        {
            using (SqlConnection conn = new SqlConnection(AuthService._connString))
            {
                conn.Open();
                string query = @"SELECT GirisSaati FROM tblParkIslemleri 
                                 WHERE UserID = @uid 
                                 AND KatNumarasi = @kat 
                                 AND ParkYeriNumarasi = @park 
                                 AND CikisSaati IS NULL";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@uid", userId);
                    cmd.Parameters.AddWithValue("@kat", katNo);
                    cmd.Parameters.AddWithValue("@park", parkNo);

                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToDateTime(result) : DateTime.Now;
                }
            }
        }

        public void AracCikisYap(int userId, int katNo, int parkNo)
        {
            using (SqlConnection conn = new SqlConnection(AuthService._connString))
            {
                conn.Open();
                string query = @"UPDATE tblParkIslemleri 
                                 SET CikisSaati = @cikis, Durum = 0 
                                 WHERE UserID = @uid 
                                 AND KatNumarasi = @kat 
                                 AND ParkYeriNumarasi = @park 
                                 AND CikisSaati IS NULL";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@cikis", DateTime.Now);
                    cmd.Parameters.AddWithValue("@uid", userId);
                    cmd.Parameters.AddWithValue("@kat", katNo);
                    cmd.Parameters.AddWithValue("@park", parkNo);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public string PlakadanKonumBul(string plaka)
        {
            using (SqlConnection conn = new SqlConnection(AuthService._connString))
            {
                try
                {
                    conn.Open();

                    int userId = 0;
                    string userQuery = "SELECT ID FROM tblUser WHERE PlateNumber = @plaka";

                    using (SqlCommand cmdUser = new SqlCommand(userQuery, conn))
                    {
                        cmdUser.Parameters.AddWithValue("@plaka", plaka);
                        object result = cmdUser.ExecuteScalar();

                        if (result == null)
                        {
                            return "";
                        }
                        userId = Convert.ToInt32(result);
                    }

                    string parkQuery = "SELECT KatNumarasi, ParkYeriNumarasi, GirisSaati FROM tblParkIslemleri WHERE UserID = @uid AND CikisSaati IS NULL";

                    using (SqlCommand cmdPark = new SqlCommand(parkQuery, conn))
                    {
                        cmdPark.Parameters.AddWithValue("@uid", userId);

                        using (SqlDataReader reader = cmdPark.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int kat = Convert.ToInt32(reader["KatNumarasi"]);
                                int no = Convert.ToInt32(reader["ParkYeriNumarasi"]);
                                DateTime giris = Convert.ToDateTime(reader["GirisSaati"]);

                                return $"Aracınız {kat}. Kat, {no} Numaralı park yerindedir.\nGiriş Saati: {giris.ToShortTimeString()}";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    return "Hata: " + ex.Message;
                }
            }
            return "";
        }


    }
}
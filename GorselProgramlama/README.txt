1. PROJE HAKKINDA
---------------------------------------------------------
Bu proje, C# Windows Forms ve SQL Server kullanılarak geliştirilmiş bir Otopark Takip Sistemidir. 

2. VERİTABANI KURULUMU VE BAĞLANTI AYARLARI 
---------------------------------------------------------
Projenin çalışması için "Gorsel" isimli bir veritabanına ihtiyaç duyulmaktadır. 

YÖNTEM A (Varsayılan - LocalDB):
Proje, "AttachDbFilename" yöntemiyle "Data/Gorsel.mdf" dosyasına bağlanacak şekilde ayarlanmıştır.

YÖNTEM B (Yedek - SQL Script):
Sürüm uyuşmazlığı nedeniyle .mdf dosyası açılmazsa, ana klasördeki "Veritabani_Kurulum.sql" dosyasını SSMS üzerinde çalıştırarak veritabanını sisteminize kurabilirsiniz.

ÖNEMLİ NOT: Yöntem B'yi kullanırsanız, AuthService içerisindeki bağlantı adresini (Connection String) aşağıdaki gibi güncellemeniz gerekmektedir:

MEVCUT KOD (MDF Odaklı):
public static string _connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Data\Gorsel.mdf;Integrated Security=True;Connect Timeout=30";

DEĞİŞTİRİLMESİ GEREKEN KOD (Script Kurulumu Sonrası):
public static string _connString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Gorsel;Integrated Security=True;";

3. SİSTEME GİRİŞ
---------------------------------------------------------
Veritabanı güvenlik ve temiz kurulum amacıyla "BOŞ" olarak yapılandırılmıştır. 
Lütfen uygulamayı başlattıktan sonra "KAYIT OL" butonunu kullanarak yeni bir kullanıcı oluşturunuz.

4. TEKNİK ÖZELLİKLER
---------------------------------------------------------
- Şifreleme: Kullanıcı şifreleri SHA-256 algoritması ile hashlenerek saklanır.
- Ücretlendirme: İlk 15 dakika ücretsiz, sonrası saatlik tarife üzerinden hesaplanır.
- Görsel Arayüz: Dolu/Boş park yerleri dinamik renkli butonlarla takip edilir.
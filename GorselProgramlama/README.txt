1. PROJE HAKKINDA
---------------------------------------------------------
Bu proje, C# Windows Forms ve SQL Server kullanılarak geliştirilmiş bir Otopark Takip Sistemidir. 

2. VERİ TABANI KURULUMU VE BAĞLANTI AYARLARI 
---------------------------------------------------------
Projenin çalışması için "Gorsel" isimli bir veritabanına ihtiyaç duyulmaktadır. 

YÖNTEM A (Varsayılan - LocalDB):
Proje, "AttachDbFilename" yöntemiyle "Data/Gorsel.mdf" dosyasına bağlanacak şekilde ayarlanmıştır.

YÖNTEM B (Yedek):
Sürüm uyuşmazlığı nedeniyle veya başka sebeplerden ötürü veri tabanı bağlantısı sağlanaazsa, ana klasördeki "Veritabani_Kurulum.sql" dosyasını SSMS üzerinde çalıştırarak veritabanını sisteminize kurabilirsiniz.

NOT: Yöntem B'yi kullanırsanız, AuthService içerisindeki bağlantı adresini (Connection String) aşağıdaki gibi güncellemeniz gerekmektedir:

MEVCUT KOD (LocalDB Odaklı):
public static string _connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Data\Gorsel.mdf;Integrated Security=True;Connect Timeout=30";

DEĞİŞTİRİLMESİ GEREKEN KOD (Script Kurulumu Sonrası):
public static string _connString = @"Data Source=.;Initial Catalog=Gorsel;Integrated Security=True;TrustServerCertificate=True";

NOT: Yöntem B'yi kullanırsanız, AuthService.cs içerisindeki bağlantı adresini (Connection String) kendi bilgisayarınızın
sunucu adına göre güncellemeniz gerekmektedir

NOT2: Scripti çalıştırmadan önce, hedef SQL sunucusunda aynı isimde ("Gorsel") 
olan başka bir veri tabanı bulunmadığından emin olunuz.

3. SİSTEME GİRİŞ
---------------------------------------------------------
Veritabanı güvenlik ve temiz kurulum amacıyla "BOŞ" olarak yapılandırılmıştır. 
Lütfen uygulamayı başlattıktan sonra "KAYIT OL" butonunu kullanarak yeni bir kullanıcı oluşturunuz.

4. TEKNİK ÖZELLİKLER
---------------------------------------------------------
- Şifreleme: Kullanıcı şifreleri SHA-512 algoritması ile hashlenerek saklanır.

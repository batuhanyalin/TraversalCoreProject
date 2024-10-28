# Asp.Net Core 6 MVC CodeFirst - Traver Seyahat Sitesi Rezervasyon Projesi
Murat YÜCEDAĞ' ın youtubeda sunduğu 38 saatlik Traversal Tatil Seyahat Rezervasyon Sitesi eğitimi kapsamında geliştirmiş olduğum projeyi tam anlamıyla tamamlayıp canlıya taşımış bulunmaktayım. Projenin tanıtım videosuna <a href="https://www.youtube.com/watch?v=S6IFD3fg1_4&ab_channel=BatuhanYALIN">buraya</a> tıklayarak ulaşabilirsiniz. Proje tatil seyahat sitesinin bütün ihtiyaçlarına cevap vermektedir. Turlar incelenebilir, üye olunup rezervasyon oluşturulabilir.
##### Proje Tanıtım Linki: https://www.youtube.com/watch?v=S6IFD3fg1_4&ab_channel=BatuhanYALIN
## Projeye Ait Bazı Özellikler;
* Proje Asp.Net 6.0 MVC mimarisinde CodeFirst yaklaşımıyla yapıldı.
* Identity kütüphanesiyle login-logout-register-role sistemi kullanıldı.
* Projede bol bol iç içe layout ve ViewComponent yapısı kullanıldı.
* Proje Admin ve Member-Guide olmak üzere 2 Areaya sahiptir, giriş yapan kullanıcın rolüne göre sistem ilgili Areya yönlendirmektedir.
* Kullanıcı panelindeki bütün alanlarda İngilizce, Almanca, İspanyolca, Fransızca dil desteği mevcuttur.
* Kullanıcı kendi profil bilgilerini kendisi güncelleyebilmektedir. 
* Kullanıcı panel üzerinden kendi attığı yorumları, sistemden gelen duyuruları, rezervasyonlarını ve durumlarını, aktif açık olan turları görüntüleyebilmektedir ve rezervason oluşturabilmektedir.
* Kullanıcılar profil fotoğraflarını sisteme dahil edebilmektedirler. İlk üyelik sırasında alınmayan profil fotoğrafı yerine yeni kullanıcıya varsayılan olarak bir görsel atanmaktadır. 
* Sisteme Rehber başvurusu yapılabilmektedir ve sistem yöneticisi tarafından onaylanmadan üyelik beklemede kalmaktadır.
* Admin panelinde istenen maile sunucu üzerinden mail gönderebilmektedir. Gerekli olan bütün listeleme ve güncelleme işlemleri yapılabilmektedir. Tur oluştururken Cascading yöntemiyle bütün dünya üzerindeki kıta-ülke ve şehir bilgileri birbirlerine bağlantılı şekilde gelmektedir. Rehber başvuruları bu panelden onaylanmaktadır.
* Turlarla rehberler ve etiketler eşlenebilmektedir, etikete göre turlar listelenebilmektedir.
* Sistemdeki oluşabilecek bütün mantık hataları kontrol edildi ve giderildi, kontrollü ve kullanıcı odaklı çalışması sağlandı.
* Projede diğer teknolojilerle birlikte yoğunluklu olarak AJAX - Javascript yapısı kullanılmıştır.

### Kullanılan Bazı Teknolojiler
* Structural Repository design pattern ile oluşturulmuştur.
* Cascading ile 3lü dropdownlist listelemesi yapıldı.
* Ana projeye ek olarak eğitim içerisinde SignalR ve API teknolojileri proje içerisinde çalışılmıştır.
* DbCodeFirst ile MSSQL veritabanı oluşturulup yönetimi sağlandı.
* MimeKit ve Smtp ile mail gönderme sistemi oluşturuldu.
* Identity kütüphanesiyle login-logout-role-register sistemi kullanıldı.
* Entity Framework 6.0 Veritabanı etkileşimi ve ORM için kullanıldı.
* AJAX - JAVASCRIPT ile sayfa içinde açılan paneller, alert ve CRUD işlemleri ve API listelemeleri yapıldı.
* Area sistemiyle paneller birbirinden ayrılıp yönetimi kolaylaştırıldı.
* Dto katmanıyla veri yönetimi kolaylaştırıldı.	
* Verilerin PDF-Excel olarak listelenmesi sağlandı.
* HTML-CSS Bootstrap ile arayüzler tasarlandı.
* Fluent Validation - kontrol sistemi kullanılarak veirlerin belli kurallara göre alınması sağlandı.
* ViewBaglerle verilerin taşınması.
* 403 - 404 sayfalarının bulunması.
* Authentication - authorize oturum yönetim sistemi.
* AutoMapper nesneyle nesnenin eşleşmesi sağlandı.
* Login sistemi
* Linq sorguları


# Veritabanı
![Veritabanı](https://github.com/batuhanyalin/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/images/projectScreenshots/database.png?raw=true)
### Giriş
![](https://github.com/batuhanyalin/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/images/projectScreenshots/login.png?raw=true)
### Onay Bekleyen Kullanıcı
![](https://github.com/batuhanyalin/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/images/projectScreenshots/onay.png?raw=true)
### Yetkisiz Giriş
![](https://github.com/batuhanyalin/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/images/projectScreenshots/error403forbidden.png?raw=true)
### Sayfa Bulunamadı
![](https://github.com/batuhanyalin/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/images/projectScreenshots/error404.png?raw=true)
### Yeni Üyelik
![](https://github.com/batuhanyalin/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/images/projectScreenshots/registerValidation.png?raw=true)
### Parola Sıfırlama
![](https://github.com/batuhanyalin/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/images/projectScreenshots/forgetPassword.png?raw=true)

####
![](https://github.com/batuhanyalin/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/images/projectScreenshots/1.png?raw=true)
#### 
![](https://github.com/batuhanyalin/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/images/projectScreenshots/2.png?raw=true)
#### 
![](https://github.com/batuhanyalin/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/images/projectScreenshots/3.png?raw=true)
####
![](https://github.com/batuhanyalin/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/images/projectScreenshots/4.png?raw=true)
####
![](https://github.com/batuhanyalin/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/images/projectScreenshots/5.png?raw=true)
####
![](https://github.com/batuhanyalin/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/images/projectScreenshots/6.png?raw=true)
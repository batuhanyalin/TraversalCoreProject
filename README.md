# Asp.Net Core 6 MVC CodeFirst - Traver Seyahat Sitesi Rezervasyon Projesi
Murat YÜCEDAĞ' ın youtubeda sunduğu 38 saatlik Traversal Tatil Seyahat Rezervasyon Sitesi eğitimi kapsamında geliştirmiş olduğum projeyi tam anlamıyla tamamlayıp canlıya taşımış bulunmaktayım. Projenin tanıtım videosuna <a href="https://www.youtube.com/watch?v=S6IFD3fg1_4&ab_channel=BatuhanYALIN">buraya</a> tıklayarak ulaşabilirsiniz. Proje tatil seyahat sitesinin bütün ihtiyaçlarına cevap vermektedir. Turlar incelenebilir, üye olunup rezervasyon oluşturulabilir.
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

#### Dashboard
![Dashboard](https://github.com/batuhanyalin/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/images/projectScreenshots/1.png?raw=true)
#### Kullanıcı Listesi
![Kullanıcı Listesi](https://github.com/batuhanyalin/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/images/projectScreenshots/userList.png?raw=true)
#### Kullanıcı Silme
![Profilim](https://github.com/batuhanyalin/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/images/projectScreenshots/deleteUser.png?raw=true)
#### Kullanıcı Güncelleme
![Kullanıcı Güncelleme](https://github.com/batuhanyalin/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/images/projectScreenshots/updateUser.png?raw=true)
##### Kullanıcı Detay
![Bütün Mesajlar](https://github.com/batuhanyalin/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/images/projectScreenshots/userDetail.png?raw=true)
#### Profilim - Kullanıcı Paneli
![Profilim](https://github.com/batuhanyalin/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/images/projectScreenshots/myProfileUserPanel.png?raw=true)
#### Şifre Değiştirme
![Profilim](https://github.com/batuhanyalin/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/images/projectScreenshots/updatePassword.png?raw=true)
#### Şifre Değiştirme 
###### Güncel Parola Yanlış
![Profilim](https://github.com/batuhanyalin/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/images/projectScreenshots/updatePasswordError.png?raw=true)
#### Şifre Değiştirme
###### Girilen Şifreler Birbirleriyle Eşleşmiyor
![Profilim](https://github.com/batuhanyalin/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/images/projectScreenshots/updatePasswordError2.png?raw=true)
#### Gelen Mesajlar
![Profilim](https://github.com/batuhanyalin/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/images/projectScreenshots/inboxMessageList.png?raw=true)
#### Gelen Mesajlar - Kullanıcı Paneli
![Profilim](https://github.com/batuhanyalin/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/images/projectScreenshots/inboxUserPanel.png?raw=true)
#### Gönderilen Mesajlar
![Profilim](https://github.com/batuhanyalin/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/images/projectScreenshots/sentMessageList.png?raw=true)
#### Taslak Mesajlar
![Profilim](https://github.com/batuhanyalin/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/images/projectScreenshots/draftMessageList.png?raw=true)
#### Mesaj Okuma
![Profilim](https://github.com/batuhanyalin/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/images/projectScreenshots/readMessage.png?raw=true)
#### Mesajları Çöp Kutusuna Taşı
![Profilim](https://github.com/batuhanyalin/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/images/projectScreenshots/moveTrash.png?raw=true)
#### Mesajlar Çöp Kutusuna Taşındı
![Profilim](https://github.com/batuhanyalin/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/images/projectScreenshots/correctTrash.png?raw=true)
#### Mesajlar Çöp Kutusundan Alma
![Profilim](https://github.com/batuhanyalin/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/images/projectScreenshots/moveInbox.png?raw=true)
#### Mesajları Önemli Kutusuna Taşı
![Profilim](https://github.com/batuhanyalin/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/images/projectScreenshots/moveImport.png?raw=true)
#### Mesajlar Önemli Kutusuna Taşındı
![Profilim](https://github.com/batuhanyalin/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/images/projectScreenshots/correctImport.png?raw=true)
#### Yeni Mesaj Gönderme İşlemi
![Profilim](https://github.com/batuhanyalin/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/images/projectScreenshots/correctSendingMessageUserPanel.png?raw=true)
#### Yeni Mesaj Gönderme - Kendine Mesaj Gönderemezsin Hatası
![Profilim](https://github.com/batuhanyalin/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/images/projectScreenshots/cantSendingYourselfError.png?raw=true)
#### Taslak Mesaj Kaydetme
![Profilim](https://github.com/batuhanyalin/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/images/projectScreenshots/editDraftMessageSave.png?raw=true)
#### Taslak Mesajı Gönderme
![Profilim](https://github.com/batuhanyalin/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/images/projectScreenshots/editDraftMessageSending.png?raw=true)
##### Yeni Rol Ekleme
![Yeni Rol Ekleme](https://github.com/batuhanyalin/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/images/projectScreenshots/newRole.png?raw=true)
##### Rol Güncelleme
![Rol Güncelleme](https://github.com/batuhanyalin/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/images/projectScreenshots/updateRole.png?raw=true)
##### Rol Silme
![Rol Silme](https://github.com/batuhanyalin/TraversalCoreProject/blob/master/TraversalCoreProject/wwwroot/images/projectScreenshots/deleteRole.png?raw=true)




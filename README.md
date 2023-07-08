# TraversalApp
Herkese Merhaba 😃
Murat Yücedağ hocamla eşzamanlı ve üstüne koyarak geliştirdiğim Traversal projesini paylaşmak istedim.

Traversal projesi, bir gezi-seyehat projesidir. Proje .Net Core 7.0 kullanılarak yapılmıştır. Veri tabanı olarak MS SQL tercih edilmiştir. Projenin back-end'i çok güçlü olmakla beraber kullanıcılara çok güçlü bir arayüz de sunmaktadır.

Projede Kullanılan Teknolojiler ve Kullanım Alanları:
-Veritabanı olarak MsSql kullanıldı.
-Entity Framework Core kullanıldı.
-Identity Core kütüphanesi kullanılarak rolleme ve sayfa bazlı yetkilendirme yapıldı.
-Ajax ve RapidAPI kullanılarak tur detayları sayfasına tavsiye edilen oteller dinamik olarak çekildi.
-Mimekit kütüphanesi kullanılarak kullanıcılara mail yollanabilir.
-EPPlus kütüphanesi kullanılarak adminlerin excel raporları alınması sağlandı.
-Fluent Validation kütüphanesi kullanılarak veri girişleri denetlendi ve kullanıcılara özelleştirilmiş hata mesajları verildi.
-Serilog kütüphanesi kullanılarak loglama yapıldı.

Projenin teknik özellikleri:
-Veritabanı: MsSql kullanıldı.
-Mimari: N Katmanlı mimari kullanıldı.
-Design Pattern: Repository Design Pattern, UnitOfWork Design Pattern, Command Query Responsibility Segregation (CQRS) ve MediatR kullanıldı.
-Arayüz: HTML/CSS - BOOTSTRAP kullanıldı.

Projenin Kullanıcılarına Sundukları: 

--Sisteme kayıt olarak giriş yapabilir.
--Kendilerine ait profillerini güncelleyebilir.
--Kişisel fotoğraflarını sisteme yükleyebilir.
--Kişisel seyahat bloglarını paylaşabilir.
--Yeni rezervasyon yapabilir.
--Aktif/onay bekleyen/geçmiş rezervasyonlarını görebilir.
--Paylaşılan rotalar hakkında yorum yapabilir.
--Adminlere mesaj gönderebilir. 


Adminler ;
--Admin paneli içerisinde siteye ait verilerin özetine Dashboard üzerinden erişebilirler.
--Admin kullanıcılardan gelen mesajları görebilir, sistem üzerinden bu mesajı yanıtlayarak kullanıcının mail adresine mail gönderebilir.
--Admin rezervasyonları onaylabilir.
--Rezervasyon oluşturma işlemleri.
--Rota oluşturma işlemleri.
--Rehber oluşturma işlemleri.
--Kullanıcı kayıt gerçekleştirme işlemleri.
--Admin yeni rol ekleyebilir, varolan bir rolü düzenleyebilir ve kullanıcılara rol verebilir.


Kayıt Olma Paneli
![signup](https://github.com/honurbu/TraversalApp/assets/78691441/323a8c38-947a-4d2a-bda7-9e40d0fbb644)


Üye Giriş Paneli
![signin](https://github.com/honurbu/TraversalApp/assets/78691441/c5c60ef5-a42d-4921-82c8-977f86311a70)


Site İçerisinden Karanlık Tema Görünümü
![defaultdark](https://github.com/honurbu/TraversalApp/assets/78691441/65b29679-1793-40b6-b3af-fb1bcf33fa2c)


Site İçerisinden Aydınlık Tema Görünümü
![defaultwhite](https://github.com/honurbu/TraversalApp/assets/78691441/e789ff93-dff7-4ac1-8d12-86df1f4dbc2f)


Tur Rotaları Sayfası
![dest](https://github.com/honurbu/TraversalApp/assets/78691441/e25eb898-52fc-4d3e-94d2-03a0cbf97e12)


Hakkımızda Sayfası
![aboutdark](https://github.com/honurbu/TraversalApp/assets/78691441/b7578635-5c68-445b-9335-7124af8e7ddd)


İletişim Sayfası
![contact](https://github.com/honurbu/TraversalApp/assets/78691441/b565cfcf-d266-474c-a645-791214b6ed26)


Şehir Blogu Sayfası
![kutahya](https://github.com/honurbu/TraversalApp/assets/78691441/88fa8f04-cc94-4269-8972-333745460ba8)


 Bloga Ait Yorumların Listelenmesi
![kutahya2yorum](https://github.com/honurbu/TraversalApp/assets/78691441/2d3faccb-2ae9-48af-b71a-9376346bc4c1)


Üyelerin Profil Sayfası
![profilesetting](https://github.com/honurbu/TraversalApp/assets/78691441/dba127cb-f09e-4794-aa90-113b6fa98d7b)


Rehber Rota Ekleme Sayfası
![addrotation](https://github.com/honurbu/TraversalApp/assets/78691441/45c6b66a-39f9-4b15-a043-62dc1fbc9370)


Rehberlerin Listelenmesi
![guide](https://github.com/honurbu/TraversalApp/assets/78691441/4099c6cb-aea0-4064-8344-ad8cdf8f9ca6)


Admin Rolleme Paneli
![role](https://github.com/honurbu/TraversalApp/assets/78691441/44745008-93f6-468d-89ae-59428fb00721)


Admin Rehber Listeleme Sayfası
![guide](https://github.com/honurbu/TraversalApp/assets/78691441/1a429bdb-c577-421a-9e0c-06e66a8319a3)



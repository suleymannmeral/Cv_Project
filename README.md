# 📚 Kişisel Web Sitesi

Bu proje, N Katmanlı mimaride ASP.NET Core teknolojisi kullanılarak geliştirilen bir MVC projesidir. 
Admin, Ana sayfa üzerinde bulunan hakkımda, servisler,deneyimler, iletişim kısımları üzerinde crud işlemlerini admin paneli üzerinden gerçekleştirebilmektedir. 
Admin sisteme üye olan kullanıcılara toplu bir şekilde duyuru gönderebilmektedir. Duyuru hem kullanıcı sayfasında görüntülenebilir hem de üyelere mail yolu ile bildirilmektedir.
Ana sayfa üzerinden admine iletişim mesajı gönderilmektedir. Mesaj admin paneli üzerinden görüntülenip aynı zamanda adminin mail adresine gönderilmektedir.
Admin sisteme kayıtlı olan kullanıcılara ban atabilir, banı kaldırabilir ve kullanıcıları silebilir. 
Documents sayfasında admin pdf paylaşımı yapabilmektedir.

Detaylar görseller ile açıklanacaktır.

## 🛠 Kullanılan Teknolojiler

| Teknoloji              | Açıklama                                              |
|------------------------|--------------------------------------------------------|
| **ASP.NET Core Web API** | Projenin backend altyapısı                            |
| **MSSQL**              | Veritabanı yönetimi için                              |
| **Entity Framework Core** | ORM aracı olarak                                     |
| **Identity **          | Kimlik doğrulama ve yetkilendirme işlemleri için      |
| **AJAX & Bootstrap**   | UI tarafında dinamiklik ve responsive tasarım için    |

---

## 🔐 Özellikler

### 👤 Kullanıcı İşlemleri
- Kullanıcı kayıt ve giriş
- Mesaj Gönderme
- Testimonials Ekleme

### 🔐 Admin Paneli
- Ana sayfadaki bölümleri dinamik olarak değiştirebilme.
- Kullanıcı yönetimi
- Duyuru Yapabilme

## 📌 Notlar

- Proje `N KATMANLI MİMARİ` yapısında modüler olarak organize edilmiştir.
- Bu projeyi geliştirdiğim tarihte çok fazla teknik yetkinliğim olmadığı için solid prensipleri, clean code yaklaşımları ezilmiş olabilir.
- İletişim yöntemleri için Factory Design patternı öğrenmek adına bu design pattern uygulanmaya çalışılmıştır.

---

PROJE Görselleri ve Detayları: 
(Tasarım bana ait değildir. Hazır bir bootstrap template'i kullanılmıştır. Üzerinde değişiklik yapılmıştır)
<img width="1883" height="911" alt="image" src="https://github.com/user-attachments/assets/07a092c5-d465-4a5d-958d-606f33d74f14" />
<img width="1870" height="907" alt="image" src="https://github.com/user-attachments/assets/dee2d624-95d7-40ae-a403-d1efbef216f1" />
<img width="1885" height="732" alt="image" src="https://github.com/user-attachments/assets/26b6808c-37ff-4d53-810f-d0f2d1a93480" />
<img width="1882" height="612" alt="image" src="https://github.com/user-attachments/assets/c50b3298-2a40-4689-8a67-a2c27ec09c0e" />
<img width="1867" height="902" alt="image" src="https://github.com/user-attachments/assets/801e2fd8-98fd-4a26-b23b-9eee50f8d69d" />
<img width="1882" height="663" alt="image" src="https://github.com/user-attachments/assets/01de6a39-2333-4fe6-ab0b-4af798302f1a" />
<img width="1903" height="715" alt="image" src="https://github.com/user-attachments/assets/a33024a7-661d-46e3-b186-77191ddce365" />



Projenin ana sayfası bu şekildedir. Görüntülen her alanı admin paneli üzerinden değiştirebilmekteyiz.

<img width="1903" height="915" alt="image" src="https://github.com/user-attachments/assets/0149c1fa-cb79-4fa0-8009-e0fc97795c81" />

Login ekranımız üzerinden kullanıcılar ve admin sisteme giriş yapabilmektedir.
<img width="1885" height="897" alt="image" src="https://github.com/user-attachments/assets/c1660a35-0fc1-4980-a839-67ee7b7f72a8" />

 Kullanıcılar şifrelerini unuttuğu taktirder kullanıcı adlarını girerek, mail adreslerine şifre değiştirme linki gönderilmektedir.

 <img width="1887" height="900" alt="image" src="https://github.com/user-attachments/assets/34914064-d822-4a14-9a23-c89a16850773" />

 ### - Yeni üyeler register sayfasından kayıt olabilmektedirler. Kayıt başarılı olduğunda mail yoluyla bilgilendirilirler.

 <img width="1202" height="725" alt="image" src="https://github.com/user-attachments/assets/3f03f7fc-6971-438d-b4a4-1f297ad2ae76" />

### - Kullanıcılar aynı kullanıcı adını alamamaktadırlar. Bu yapı Identity kütüphanesi ile kurulmuştur.

<img width="652" height="178" alt="image" src="https://github.com/user-attachments/assets/cdfb0c27-177c-4612-8184-6b399efd8332" />

### - Kayıt başarılı ise mail adresinize mail gelmektedir.

<img width="1888" height="793" alt="image" src="https://github.com/user-attachments/assets/0f923917-f20f-46fb-aaad-5ac85f12456d" />

### - Giriş yapan kullanıcıları böle bir dashboard karşılamaktadır. Panel üzerinden çeşitli işlemler gerçekleştirebilemktedirler.


 <img width="1898" height="912" alt="image" src="https://github.com/user-attachments/assets/fd1a1bf8-1491-4681-9afb-c9d6200fee60" />

 ### "Received Messages" sayfası üzerinden kullanıcılar kendilerine gönderilen mesajları görebilmektedirler.

 <img width="1902" height="913" alt="image" src="https://github.com/user-attachments/assets/3fab15bd-3dc9-4c99-b768-494e8702d060" />
 
<img width="1902" height="901" alt="image" src="https://github.com/user-attachments/assets/c3f19d07-76d6-4232-94f2-60808774705a" />

 ### "Create Message" sayfası üzerinden kullanıcılar mesaj gönderebilmektedirler.

<img width="1897" height="912" alt="image" src="https://github.com/user-attachments/assets/d5146e0f-e46c-4a59-a97b-c26fadc0d5bd" />

 ### "Sent Messages" sayfası üzerinden kullanıcılar gönderdikleri  mesajı gönderebilmektedirler.

<img width="1896" height="898" alt="image" src="https://github.com/user-attachments/assets/34592faf-f51d-44f8-a55d-6574fd5423ba" />

 ### "Announcements" sayfası üzerinden kullanıcılar adminin yaptığı duyuruları görüntüleyebilmektedir.

<img width="1897" height="898" alt="image" src="https://github.com/user-attachments/assets/08646a17-541f-4711-a993-ad7543d6af17" />

<img width="1907" height="953" alt="image" src="https://github.com/user-attachments/assets/a2d750ea-b7fb-4cf4-a823-398e4a7f35fb" />

 ### "Profile" sayfası üzerinden kullanıcılar profilleri üzerinden işlemler yapabilmektedirler.

<img width="1881" height="915" alt="image" src="https://github.com/user-attachments/assets/16aa44b9-946c-424f-8d25-6749fbb4f8f9" />

 ### "Testimonial" sayfası üzerinden kullanıcılar referans oluşturabilir. Bunu homepage üzerinden görebiliriz.

<img width="1907" height="902" alt="image" src="https://github.com/user-attachments/assets/811cbeac-baf2-44c9-8fd6-47755c60b83e" />

<img width="1872" height="557" alt="image" src="https://github.com/user-attachments/assets/fa790109-ddd1-41e9-8e15-660b6d8e303d" />


 ### Admin sisteme giriş yaptığından ona özel olarak admin paneli yer almaktadır.Bu link üzerinden admin paneline erişebilir.

<img width="1867" height="787" alt="image" src="https://github.com/user-attachments/assets/e3560ed3-3019-4d93-bdc5-c02e9ed8059a" />


 ### Anasayfada yer alan bilgileri admin, panel üzerinden değiştirebilmektedir.

<img width="1873" height="906" alt="image" src="https://github.com/user-attachments/assets/8d09d214-272e-46ce-ae3e-99c50a59180a" />

 ### Anasayfada yer alan contact kısmından mesaj gönderen ziyaretçilerin mesajları "contact messages" kısmından görüntülenebilir.Ayrıca bu mesaj admine bildirim olarak gitmektedir.
 
<img width="1862" height="832" alt="image" src="https://github.com/user-attachments/assets/2ef31d79-c02a-456b-b689-f2365e560792" />

<img width="1795" height="841" alt="image" src="https://github.com/user-attachments/assets/eaaa4115-8c18-4f09-9428-1470744b004a" />

<img width="1568" height="777" alt="image" src="https://github.com/user-attachments/assets/ad80e492-c0a3-456a-89d3-39b50881637b" />

<img width="1570" height="548" alt="image" src="https://github.com/user-attachments/assets/6b118cb6-7fdc-48ea-9016-6ae9f89b9703" />

 ### Anasayfada yer alan documents alanını admin, panel üzerinden yönetebilir. Yeni dosyalar ekleyebilir.

<img width="1895" height="652" alt="image" src="https://github.com/user-attachments/assets/c4907bbc-4df5-400f-a0fa-ca9b5865ab2d" />

<img width="1585" height="871" alt="image" src="https://github.com/user-attachments/assets/c4707444-66a0-4a81-bfdb-1c26f825170c" />

<img width="1571" height="857" alt="image" src="https://github.com/user-attachments/assets/af899a34-daa1-4f73-a0bb-8e7ea19aa48a" />

<img width="1571" height="717" alt="image" src="https://github.com/user-attachments/assets/de677acd-601e-4bdc-b18a-b9b4faa0c942" />

<img width="1888" height="697" alt="image" src="https://github.com/user-attachments/assets/75945213-dc81-40b0-96cf-865cc6998749" />

<img width="1888" height="622" alt="image" src="https://github.com/user-attachments/assets/822d9525-3093-4f15-bfa8-c054122119f8" />

<img width="1875" height="907" alt="image" src="https://github.com/user-attachments/assets/9f2d9b51-7bf2-48d9-b872-ad226e90ec1e" />

 ### Admin, duyurular sayfası üzerinden duyuru yapabilir.Bu duyurular hem kullanıcıların panelinde gözükür, hem de onlara mail yolu ile gider.

<img width="1571" height="865" alt="image" src="https://github.com/user-attachments/assets/27987535-fe2a-47ee-b8b5-9e7c8401712f" />

<img width="1582" height="863" alt="image" src="https://github.com/user-attachments/assets/8fe25942-41ea-4aab-afdc-d290b4290269" />

<img width="576" height="1280" alt="image" src="https://github.com/user-attachments/assets/54af0687-4708-4d95-910e-53939db5f65f" />

 ### Admin, User sayfası üzerinden kullanıcıları yönetebilir. Kullanıcıların yanlış şifre girmesi durumunda "Access Failed Count" sayısı artar. Bu 5 olduğu zaman hesap kilitlenir. Admin tarafından açılır. Ayrıca admin kullanıcıların hesabımı kitleyip,giriş yapmalarını engelleyebilir.

<img width="1570" height="783" alt="image" src="https://github.com/user-attachments/assets/1581a546-9bb9-4b42-a42b-c423e3676345" />

<img width="1903" height="891" alt="image" src="https://github.com/user-attachments/assets/cba10d69-bd5e-4104-8fb3-c5d4b9eecc14" />

<img width="1532" height="97" alt="image" src="https://github.com/user-attachments/assets/e0c52b7c-9139-4fc4-be08-3f0d633dfc43" />

<img width="1523" height="86" alt="image" src="https://github.com/user-attachments/assets/c9172e04-cda6-477a-8a65-cecd1a680d87" />

<img width="1895" height="900" alt="image" src="https://github.com/user-attachments/assets/30fc2c28-d302-42a7-b365-57c0b44601c8" />

<img width="576" height="1280" alt="image" src="https://github.com/user-attachments/assets/7e86d5dc-3460-4cec-b01f-15bce728742d" />

 ### Admin, banı kaldırdığı anda kullanııc tekrar sisteme giriş yapabilir.

 <img width="576" height="1280" alt="image" src="https://github.com/user-attachments/assets/7af02319-f798-4c1a-83f8-0230ee7770da" />

 
 ### Admin, yazılan referansalrı görüntüleyebilir ve silebilir.

 <img width="1587" height="738" alt="image" src="https://github.com/user-attachments/assets/1aa748fc-454f-44b6-9a2f-607f4a7d3d12" />
 
 <img width="1553" height="847" alt="image" src="https://github.com/user-attachments/assets/28141a73-7631-4081-ac76-c0e607187c32" />

 ### Kullanıcılar şifrelerini unuttukları zaman şifrelerini sıfırlama linki alırlar.

 <img width="1907" height="893" alt="image" src="https://github.com/user-attachments/assets/b6b97272-b537-4ef3-ae06-9b971dd36f12" />

 <img width="576" height="1280" alt="image" src="https://github.com/user-attachments/assets/fd2acbc8-f0b4-4dcc-8851-b1c0c9aa8f0d" />



## 💡 Ekstra Notlar

- Bu proje, **ASP.NET Core ile geliştirdiğim ilk projedir. Bu yüzden mimari yapısı ve kod kalitesi için iyi seviye olduğu söylenemez **.
- Clean Architecture, SOLID prensipleri, Low Coupling & High Cohesion gibi mimari prensipler uygulanıp daha iyi hale getirilebilir.
- Kodları yorumlayıp anlayabilen (Kod okuyabilmek yazmak kadar önemlidir) her geliştirici adayı projeyi istediği şekilde kullanabilir. 🤝






























## 📬 İletişim

Her türlü soru, görüş veya öneriniz için bana GitHub üzerinden ulaşabilirsiniz.

---

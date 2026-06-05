# 🌐 Kişisel Portfolio Web Sitesi

> ASP.NET Core MVC ile geliştirilmiş, N-Katmanlı Mimari kullanan tam özellikli dinamik kişisel CV/Portfolio web uygulaması.

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet)](https://dotnet.microsoft.com/)
[![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-MVC-blue?style=for-the-badge&logo=dotnet)](https://docs.microsoft.com/en-us/aspnet/core/)
[![MSSQL](https://img.shields.io/badge/MSSQL-Database-CC2927?style=for-the-badge&logo=microsoftsqlserver)](https://www.microsoft.com/en-us/sql-server/)
[![Entity Framework](https://img.shields.io/badge/Entity_Framework_Core-8.0-purple?style=for-the-badge)](https://docs.microsoft.com/en-us/ef/core/)

---

## 📖 Proje Hakkında

Bu proje, **N-Katmanlı Mimari** (N-Layer Architecture) kullanılarak **ASP.NET Core MVC** ile geliştirilmiş bir kişisel portfolio/CV web uygulamasıdır. Admin paneli üzerinden sitenin tüm içerikleri dinamik olarak yönetilebilmektedir.

### ✨ Temel Özellikler

- 🔒 **Identity tabanlı kimlik doğrulama** — Kullanıcı kayıt, giriş, şifre sıfırlama
- 👨‍💼 **Admin Paneli** — Tüm site içeriklerini yönetme (CRUD)
- 📢 **Duyuru Sistemi** — Mail + Telegram entegrasyonu ile toplu bildirim
- 📨 **Mesajlaşma** — Ziyaretçi → Admin ve Kullanıcılar arası mesajlaşma
- 📄 **Doküman Yönetimi** — PDF yükleme ve paylaşım
- 🛡️ **Kullanıcı Yönetimi** — Ban/unban, hesap kilitleme, kullanıcı silme
- 💬 **Testimonial Sistemi** — Kullanıcı referans oluşturma
- 📧 **E-posta Bildirimleri** — Kayıt, duyuru ve mesaj için otomatik e-posta
- 🏭 **Factory Design Pattern** — Mesaj gönderme servisleri için

---

## 🛠 Kullanılan Teknolojiler

| Teknoloji | Sürüm | Açıklama |
|---|---|---|
| **ASP.NET Core MVC** | .NET 8.0 | Ana web framework |
| **Entity Framework Core** | 8.0.10 | ORM — Veritabanı işlemleri |
| **ASP.NET Core Identity** | 8.0.10 | Kimlik doğrulama & yetkilendirme |
| **MSSQL Server** | — | İlişkisel veritabanı |
| **FluentValidation** | 11.3.0 | Model doğrulama kuralları |
| **RestSharp** | 112.1.0 | HTTP istemcisi (Telegram API) |
| **Newtonsoft.Json** | 13.0.3 | JSON serileştirme |
| **Bootstrap** | — | Responsive UI tasarım |
| **AJAX** | — | Sayfa yenilenmeden dinamik işlemler |

---

## 🏗 Mimari Yapı

Proje **N-Katmanlı Mimari** prensibiyle 4 ayrı katmana bölünmüştür:

```
Core_Project.sln
│
├── 📦 EntityLayer          → Varlık/Model sınıfları (POCO)
├── 📦 DataAccessLayer      → Veritabanı erişim katmanı (Repository Pattern)
├── 📦 BusinessLayer        → İş mantığı katmanı (Services, Validations, Factories)
└── 🌐 Core_Project         → Sunum katmanı (ASP.NET Core MVC)
```

### Katman Detayları

#### 📦 EntityLayer
Veritabanı tablolarını temsil eden model sınıflarını içerir:

| Entity | Açıklama |
|---|---|
| `About` | Hakkımda bölümü bilgileri |
| `Contact` | İletişim form mesajları |
| `Education` | Eğitim bilgileri |
| `Experience` | İş deneyimleri |
| `Feature` | Ana sayfa özellik kartları |
| `Message` | Kullanıcılar arası mesajlar |
| `Portfolio` | Portföy projeleri |
| `Service` | Sunulan hizmetler |
| `Skill` | Beceriler |
| `SocialMedia` | Sosyal medya linkleri |
| `Testimonial` | Kullanıcı referansları |
| `Announcements` | Admin duyuruları |
| `Documents` | Paylaşılan PDF/dokümanlar |
| `WriterUser` | Identity kullanıcı modeli |
| `WriterRole` | Identity rol modeli |
| `WriterMessage` | Kullanıcılar arası mesajlaşma |
| `Todolist` | Yapılacaklar listesi |

#### 📦 DataAccessLayer
- `Context.cs` — `IdentityDbContext<WriterUser, WriterRole, int>` ile EF Core DbContext
- `Repository/` — Generic repository pattern implementasyonu
- `EntityFramework/` — Her entity için EF tabanlı DAL sınıfları (16 adet)
- `Abstract/` — DAL arayüzleri
- `Migrations/` — Veritabanı migration dosyaları

#### 📦 BusinessLayer
- `Abstract/` — Servis arayüzleri (IGenericService dahil 18 adet)
- `Concrete/` — Servis implementasyonları
- `ValidationRules/` — FluentValidation ile doğrulama kuralları
- `Factories/` — Factory Design Pattern implementasyonu

**Factory Design Pattern:**
```csharp
// MessageServiceFactory — Mesaj servisini tip bazlı oluşturur
public IMessageSendService CreateMessageService(MessageType type)
{
    return type switch
    {
        MessageType.Telegram => _serviceProvider.GetRequiredService<TelegramMessageService>(),
        MessageType.WhatsApp => _serviceProvider.GetRequiredService<WhatsappMessageService>(),
        _ => throw new NotSupportedException("Geçersiz mesaj tipi")
    };
}
```

#### 🌐 Core_Project (Sunum Katmanı)
- `Controllers/` — 20 adet MVC controller (admin + genel)
- `Areas/Writer/` — Kimlik doğrulama alanı (Login, Register, Profile, Dashboard, Mesajlaşma)
- `Areas/Document/` — Doküman yönetim alanı
- `ViewComponents/` — Yeniden kullanılabilir view bileşenleri
- `Views/` — Razor view dosyaları
- `wwwroot/` — Statik dosyalar (CSS, JS, Görseller)
- `EmailSender.cs` — E-posta gönderme servisi

---

## 🔐 Özellikler Detayı

### 👤 Kullanıcı İşlemleri

| Özellik | Açıklama |
|---|---|
| Kayıt (Register) | Yeni üye kaydı; başarılı olursa e-posta ile bilgilendirme |
| Giriş (Login) | Identity tabanlı cookie authentication |
| Şifre Sıfırlama | Kullanıcı adı ile şifre sıfırlama linki e-posta ile gönderilir |
| Profil Yönetimi | Profil güncelleme ve resim yükleme |
| Testimonial | Referans/yorum oluşturma |
| Mesajlaşma | Diğer kullanıcılara mesaj gönderme/alma |
| Duyurular | Admin tarafından yayımlanan duyuruları görüntüleme |

### 🔐 Admin Paneli

| Özellik | Açıklama |
|---|---|
| İçerik Yönetimi | Hakkımda, Servisler, Deneyimler, Eğitim, Beceriler, Portföy CRUD |
| İletişim Mesajları | Anasayfadan gelen mesajlar; admin'e e-posta bildirimi |
| Duyuru Sistemi | Duyuru oluşturma → Tüm üyelere e-posta + Telegram bildirimi |
| Kullanıcı Yönetimi | Kullanıcı listeleme, ban/unban, hesap kilitleme, silme |
| Doküman Yönetimi | PDF yükleme, listeleme ve silme |
| Testimonial Yönetimi | Kullanıcı referanslarını görüntüleme ve silme |

### 🛡 Güvenlik

- 5 başarısız giriş denemesinde hesap otomatik kilitlenir
- Kilitli hesaplar yalnızca admin tarafından açılabilir
- Admin kullanıcıları manuel olarak ban'layabilir
- Cookie tabanlı güvenli oturum yönetimi (`HttpOnly`, `SecurePolicy: Always`)
- Rol tabanlı yetkilendirme (Admin / Writer rolleri)
- Hata sayfası yönlendirmesi (`/Error/{statusCode}`)

---

## 📁 Proje Yapısı

```
Cv_Project/
│
├── Core_Project.sln                 # Çözüm dosyası
│
├── EntityLayer/
│   └── Concrete/                    # 17 entity sınıfı
│
├── DataAccessLayer/
│   ├── Concrete/Context.cs          # EF Core DbContext (IdentityDbContext)
│   ├── Abstract/                    # DAL arayüzleri
│   ├── EntityFramework/             # 16 EF DAL implementasyonu
│   ├── Repository/                  # Generic Repository
│   └── Migrations/                  # DB Migration dosyaları
│
├── BusinessLayer/
│   ├── Abstract/                    # 18 servis arayüzü
│   ├── Concrete/                    # Servis implementasyonları
│   ├── Factories/
│   │   └── MessageServiceFactory.cs # Factory Design Pattern
│   └── ValidationRules/             # FluentValidation kuralları
│
└── Core_Project/                    # Ana MVC Projesi
    ├── Controllers/                 # 20 MVC Controller
    │   ├── AboutController.cs
    │   ├── AdminAnnouncementsController.cs
    │   ├── AdminDashboardController.cs
    │   ├── AdminMessageController.cs
    │   ├── AdminUserController.cs
    │   ├── ContactController.cs
    │   ├── DocumentController.cs
    │   ├── EducationController.cs
    │   ├── ExperienceController.cs
    │   ├── PortfolioController.cs
    │   ├── ServicesController.cs
    │   ├── SkillController.cs
    │   └── ...
    ├── Areas/
    │   ├── Writer/                  # Kullanıcı/Auth alanı
    │   │   ├── Controllers/
    │   │   │   ├── LoginController.cs
    │   │   │   ├── RegisterController.cs
    │   │   │   ├── ProfileController.cs
    │   │   │   ├── MessageController.cs
    │   │   │   ├── WriterDashboardController.cs
    │   │   │   └── WriterTestimonialController.cs
    │   │   └── Views/
    │   └── Document/                # Doküman yönetim alanı
    ├── EmailSender.cs               # E-posta servisi
    ├── Program.cs                   # DI konfigürasyonu ve middleware
    ├── Views/                       # Razor Views
    ├── ViewComponents/              # View Components
    └── wwwroot/                     # Statik dosyalar
```

---

## 🚀 Kurulum ve Çalıştırma

### Gereksinimler

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (LocalDB veya Express yeterlidir)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) veya [VS Code](https://code.visualstudio.com/)

### Adımlar

1. **Repoyu klonlayın:**
   ```bash
   git clone <repo-url>
   cd Cv_Project
   ```

2. **Veritabanı bağlantı dizesini düzenleyin:**

   `DataAccessLayer/Concrete/Context.cs` dosyasında bağlantı dizesini kendi SQL Server bilgilerinize göre güncelleyin:
   ```csharp
   optionsBuilder.UseSqlServer("Server=.;Database=CoreProjectDB;Integrated Security=True;TrustServerCertificate=True");
   ```

3. **Migration'ları uygulayın:**
   ```bash
   cd Core_Project
   dotnet ef database update
   ```
   veya Visual Studio'da **Package Manager Console**'da:
   ```powershell
   Update-Database
   ```

4. **E-posta ayarlarını yapılandırın:**

   `appsettings.json` dosyasına SMTP bilgilerinizi ekleyin:
   ```json
   {
     "EmailSettings": {
       "SmtpServer": "smtp.gmail.com",
       "SmtpPort": 587,
       "SenderEmail": "your-email@gmail.com",
       "SenderPassword": "your-app-password"
     }
   }
   ```

5. **Projeyi çalıştırın:**
   ```bash
   dotnet run --project Core_Project
   ```
   veya Visual Studio'da `F5`.

---

## 🏭 Design Pattern

### Factory Pattern — Mesaj Servisleri

İletişim kanallarını soyutlamak için **Factory Design Pattern** uygulanmıştır. Yeni bir mesajlaşma kanalı eklemek (WhatsApp, SMS vb.) mevcut kodu değiştirmeden yapılabilir:

```csharp
// Kullanım
var service = _messageServiceFactory.CreateMessageService(MessageType.Telegram);
await service.SendAsync(message);
```

Şu an desteklenen kanallar:
- 📱 **Telegram** — `TelegramMessageService` (aktif)
- 💬 **WhatsApp** — `WhatsappMessageService` (altyapı hazır)

---

## 🗄 Veritabanı Şeması

`Context` sınıfı `IdentityDbContext<WriterUser, WriterRole, int>` üzerinde türemektedir. Aşağıdaki tablolar mevcuttur:

| Tablo | Açıklama |
|---|---|
| `AspNetUsers` | Identity kullanıcı tablosu |
| `AspNetRoles` | Identity rol tablosu |
| `Abouts` | Hakkımda içeriği |
| `Contacts` | İletişim formu mesajları |
| `Educations` | Eğitim kayıtları |
| `Experiences` | Deneyim kayıtları |
| `Features` | Özellik kartları |
| `Messages` | Kullanıcılar arası mesajlar |
| `Portfolios` | Portfolio projeleri |
| `Services` | Sunulan hizmetler |
| `Skills` | Beceriler |
| `SocialMedias` | Sosyal medya linkleri |
| `Testimonials` | Referanslar |
| `Announcements` | Duyurular |
| `Documents` | Yüklenen dokümanlar |
| `WriterMessage` | Kullanıcı mesajları |
| `Todolist` | Yapılacaklar |

---

## 📝 Proje Görselleri

<details>
<summary>🖼 Görselleri Göster/Gizle</summary>

### Ana Sayfa
<img width="1883" alt="Ana Sayfa" src="https://github.com/user-attachments/assets/07a092c5-d465-4a5d-958d-606f33d74f14" />
<img width="1870" alt="Ana Sayfa 2" src="https://github.com/user-attachments/assets/dee2d624-95d7-40ae-a403-d1efbef216f1" />
<img width="1885" alt="Ana Sayfa 3" src="https://github.com/user-attachments/assets/26b6808c-37ff-4d53-810f-d0f2d1a93480" />

### Giriş / Kayıt Ekranları
<img width="1885" alt="Login" src="https://github.com/user-attachments/assets/c1660a35-0fc1-4980-a839-67ee7b7f72a8" />
<img width="1887" alt="Şifre Sıfırlama" src="https://github.com/user-attachments/assets/34914064-d822-4a14-9a23-c89a16850773" />
<img width="1202" alt="Kayıt" src="https://github.com/user-attachments/assets/3f03f7fc-6971-438d-b4a4-1f297ad2ae76" />
<img width="1888" alt="Kayıt E-posta" src="https://github.com/user-attachments/assets/0f923917-f20f-46fb-aaad-5ac85f12456d" />

### Kullanıcı Paneli
<img width="1898" alt="Kullanıcı Dashboard" src="https://github.com/user-attachments/assets/fd1a1bf8-1491-4681-9afb-c9d6200fee60" />
<img width="1902" alt="Gelen Mesajlar" src="https://github.com/user-attachments/assets/3fab15bd-3dc9-4c99-b768-494e8702d060" />
<img width="1897" alt="Mesaj Oluşturma" src="https://github.com/user-attachments/assets/d5146e0f-e46c-4a59-a97b-c26fadc0d5bd" />
<img width="1897" alt="Duyurular" src="https://github.com/user-attachments/assets/08646a17-541f-4711-a993-ad7543d6af17" />
<img width="1881" alt="Profil" src="https://github.com/user-attachments/assets/16aa44b9-946c-424f-8d25-6749fbb4f8f9" />
<img width="1907" alt="Testimonial" src="https://github.com/user-attachments/assets/811cbeac-baf2-44c9-8fd6-47755c60b83e" />

### Admin Paneli
<img width="1867" alt="Admin Panel" src="https://github.com/user-attachments/assets/e3560ed3-3019-4d93-bdc5-c02e9ed8059a" />
<img width="1873" alt="İçerik Yönetimi" src="https://github.com/user-attachments/assets/8d09d214-272e-46ce-ae3e-99c50a59180a" />
<img width="1862" alt="İletişim Mesajları" src="https://github.com/user-attachments/assets/2ef31d79-c02a-456b-b689-f2365e560792" />
<img width="1571" alt="Duyuru Yönetimi" src="https://github.com/user-attachments/assets/27987535-fe2a-47ee-b8b5-9e7c8401712f" />
<img width="1570" alt="Kullanıcı Yönetimi" src="https://github.com/user-attachments/assets/1581a546-9bb9-4b42-a42b-c423e3676345" />
<img width="1895" alt="Doküman Yönetimi" src="https://github.com/user-attachments/assets/c4907bbc-4df5-400f-a0fa-ca9b5865ab2d" />

</details>

---

## 💡 Notlar ve Geliştirme Önerileri

> **Not:** Bu proje, ASP.NET Core ile geliştirilmiş ilk projelerden biridir. Aşağıdaki iyileştirmeler yapılabilir:

| İyileştirme | Açıklama |
|---|---|
| **Clean Architecture** | Domain/Application/Infrastructure katman ayrımı |
| **SOLID Prensipleri** | Single Responsibility, Dependency Inversion uygulaması |
| **Generic Repository** | Daha soyut bir repository implementasyonu |
| **Bağlantı Dizesi** | `appsettings.json` üzerinden yapılandırma (hardcoded yerine) |
| **JWT Auth** | API projesi için JWT tabanlı kimlik doğrulama |
| **Unit Testler** | xUnit/NUnit ile test kapsamı |
| **Docker Desteği** | Containerization |
| **Logging** | Serilog/NLog ile kapsamlı loglama |

> **Tasarım Notu:** Ön yüz tasarımı bir Bootstrap template'i üzerine özelleştirilmiştir. Tasarımın orijinal sahipliği template geliştiricisine aittir.

---

## 📬 İletişim

Her türlü soru, görüş veya katkı için GitHub üzerinden ulaşabilirsiniz.

---

<div align="center">
  <sub>⭐ Beğendiyseniz yıldızlamayı unutmayın!</sub>
</div>

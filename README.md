# ContactsAPI

Kişi kayıtlarını yönetmek için geliştirilmiş, ASP.NET Core tabanlı bir REST API projesidir. Uygulama; kişi ekleme, listeleme, güncelleme ve silme işlemlerini SQL Server üzerinde gerçekleştirir.

## Özellikler

- Kişi kayıtlarını listeleme
- ID üzerinden kişi detayı görüntüleme
- Yeni kişi ekleme
- Mevcut kişi bilgilerini güncelleme
- Kişi silme
- Development ortamında OpenAPI/Swagger desteği
- Entity Framework Core ile SQL Server veri erişimi

## Teknoloji Altyapısı

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core 10
- Microsoft SQL Server / LocalDB
- OpenAPI ve Swagger UI

## Proje Yapısı

```text
ContactsAPI/
├── Controllers/       # API endpoint'leri
├── Data/              # Entity Framework Core DbContext'i
├── Models/            # Veritabanı modeli ve istek modelleri
├── Migrations/        # EF Core migration dosyaları
├── Program.cs         # Uygulama ve servis yapılandırması
└── appsettings.json   # Uygulama ve veritabanı ayarları
```

## Gereksinimler

- .NET 10 SDK
- Visual Studio 2026 veya .NET CLI
- SQL Server LocalDB ya da erişilebilir bir SQL Server instance'ı

## Kurulum ve Çalıştırma

1. Projeyi klonlayın ve proje klasörüne geçin:

   ```bash
   git clone <repository-url>
   cd ContactsAPI
   ```

2. `appsettings.json` içindeki `DefaultConnection` değerini kendi SQL Server bağlantınıza göre düzenleyin.

3. Veritabanını migration'lar ile oluşturun veya güncelleyin:

   ```bash
   dotnet ef database update --project ContactsAPI/ContactsAPI.csproj
   ```

4. Uygulamayı çalıştırın:

   ```bash
   dotnet run --project ContactsAPI/ContactsAPI.csproj
   ```

Varsayılan geliştirme adresleri:

- HTTP: `http://localhost:5135`
- HTTPS: `https://localhost:7228`

Development ortamında Swagger/OpenAPI arayüzü uygulama çalışırken `/swagger` adresinden, OpenAPI tanımı ise `/openapi/v1.json` adresinden erişilebilir.

## API Endpoint'leri

| Method | Endpoint | Açıklama |
|---|---|---|
| `GET` | `/api/Contacts/GetContacts` | Tüm kişileri listeler. |
| `GET` | `/api/Contacts/GetContact/{id}` | ID ile kişi getirir. |
| `POST` | `/api/Contacts/AddContact` | Yeni kişi oluşturur. |
| `PUT` | `/api/Contacts/UpdateContact/{id}` | ID ile kişi bilgilerini günceller. |
| `DELETE` | `/api/Contacts/DeleteContact/{id}` | ID ile kişi siler. |

### Örnek İstek Gövdesi

`POST /api/Contacts/AddContact` ve `PUT /api/Contacts/UpdateContact/{id}` için:

```json
{
  "fullName": "Ayşe Yılmaz",
  "email": "ayse.yilmaz@example.com",
  "phoneNumber": 5551234567,
  "address": "İstanbul, Türkiye"
}
```

Başarılı işlemlerde kişi bilgileri JSON formatında döndürülür. Bulunamayan kayıtlar için API `404 Not Found` yanıtı verir.

## Veritabanı

Uygulama varsayılan olarak aşağıdaki LocalDB veritabanı bağlantısını kullanır:

```text
Server=(localdb)\\MSSQLLocalDB;database=ContactsDatabase;integrated security=true;Trusted_Connection=True;MultipleActiveResultSets=true
```

Veritabanı modeli `ContactsAPIDbContext` üzerinden yönetilir. Şema değişiklikleri `Migrations` klasöründeki Entity Framework Core migration dosyalarıyla takip edilir.

## Geliştirme Notları

- Swagger/OpenAPI yalnızca `Development` ortamında etkinleştirilir.
- Hassas bağlantı bilgilerini kaynak koduna eklemek yerine kullanıcı sırları veya ortam değişkenleri kullanılması önerilir.
- Yeni veritabanı değişikliklerinden sonra migration oluşturup veritabanını güncelleyin.

```bash
dotnet ef migrations add <MigrationName> --project ContactsAPI/ContactsAPI.csproj
dotnet ef database update --project ContactsAPI/ContactsAPI.csproj
```

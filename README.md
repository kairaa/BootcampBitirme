
# Erciyes Bootcamp - Final Projesi

Classroom üzerinde verilen gereksinimlere göre oluşturulan bir projedir.

## Uygulamayı Ayağa Kaldırma

Uygulamayı ayağa kaldırırken öncelikle **appsettings.json** dosyasındaki **ConnectionStrings** ksımına ilgili ConnectionString aşağıdaki şekilde eklenmeli.
```
"ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=aspnet-AuthDenemeBilmemKac;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;"
  }
```

Sonrasında migration eklenerek veri tabanında tablolar oluşturulur.

## Admin Bilgileri

Uygulama ayağa kaldırılırken iki admin kullanıcısı ve bir normal kullanıcı eklenmiştir.

#### Kullanıcı Bilgileri


| Rol | Mail     | Şifre                |
| :-------- | :------- | :------------------------- |
| `Admin` | `admin@mail.com` | Adm1nPassword. |
| `Admin` | `admin2@mail.com` | admin2Password! |
| `User` | `user@mail.com` | Us3rPassword. |

Bu bilgiler değiştirilmek istenirse Data klasörünün altındaki Configuration klasöründeki UserConfiguration sınıfından değiştirilebilir.

## Eksiklikler ve Geliştirilmesi Gerekenler

Öncelikle proje tek bir proje olarak oluşturulmuştur. Bundan dolayı **Mvc** adındaki proje tüm işlemleri içermektedir. Bu da **Single Responsibility** ilkesine aykırı bir yaklaşımdır. Bunun önüne geçmek için projede Katmanlı Mimari benimsenebilir. 

Diğer bir eksiklik ise proje gerçekleştirilirken bazı verileri aktarmak için **Cookie**'ler kullanılmıştır. Bu Cookie'lerin silinmesi durumunda bazı işlemleri gerçekleştirirken sorunlar meydana gelebilmektedir.

Diğer bir sorun ise arayüzlerle alakalıdır. Arayüzler geliştirilirken sadece temel işlemleri gerçekleştirmek için tasarlanış olup herhangi bir estetik kaygı güdülmemiştir. 


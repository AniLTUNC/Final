Kullanılan Teknolojiler;
Generic Repository Pattern, Entity Framework ve .NET

Projede EntityLayer katmanında entityleri yani veritbanı tabloları ve bunların propertyleri tanımlı.
DataAccessLayer katmanında veri tabanı bağlantısı UniveraFinalProjectContext içinde yapıldı GenericRepository ve IRepository bu katmanda bulunuyor.
BusinessLayer katmanında methodlar yazıldı yine bu katmandaki ValidationRules sınıfında ekleme kuralları yazıldı.
UniveraFinalProject UI kısmı burada controller ve view kısımları yazıldı ayrıca admin için role belirleme işlemş roles klasörü altında kısmında yapıldı.

Proje çalışınca ilk açılan sayfa admin sayfasıdır kullanıcı olarak giriş yapmak için aşağıdaki kullanıcı kısmına tıklamak gerekir proje de admn yalnızca veritabanından eklenirken user her UserLogin ekranında kayıt ol kısmından eklenebilir. 

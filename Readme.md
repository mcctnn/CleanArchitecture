# 2025 Yýlý Clean Architecture Setup

Bu repoda, 2025 yýlý için projelerimizde baþlangýç olarak kullanabileceðiniz modern ve modüler bir Clean Architecture yapýsý sunulmaktadýr.


## Proje Ýçeriði

### Mimari Yapý
- **Architectural Pattern**: Clean Architecture
- **Design Patterns**:
  - Result Pattern
  - Repository Pattern
  - CQRS Pattern
  - UnitOfWork Pattern

### Kullanýlan Kütüphaneler
- **MediatR**: CQRS ve mesajlaþma iþlemleri için.
- **TS.Result**: Standart sonuç modellemeleri için.
- **Mapster**: Nesne eþlemeleri için.
- **FluentValidation**: Doðrulama iþlemleri için.
- **TS.EntityFrameworkCore.GenericRepository**: Genel amaçlý repository iþlemleri için.
- **EntityFrameworkCore**: ORM (Object-Relational Mapping) için.
- **OData**: Sorgulama ve veri eriþiminde esneklik saðlamak için.
- **Scrutor**: Dependency Injection yönetimi ve dinamik servis kaydý için.
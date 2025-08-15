# API Endpoint Sözlüğü

Bu doküman ISKI.SARS API'sinde mevcut olan HTTP endpointlerinin kapsamlı bir listesini sunar. Her bir satır HTTP metodu, yol, yetki gereksinimi ve temel açıklamayı içerir.

## Auth (`/api/Auth`)
- **POST** `/api/Auth/register` — Yeni kullanıcı kaydı; gövde `RegisterDto`, anonim erişim.
- **POST** `/api/Auth/login` — Kullanıcı girişi; gövde `LoginDto`, anonim erişim.
- **POST** `/api/Auth/refresh-token` — Access token yenileme; gövde `RefreshTokenDto`, anonim erişim.

## Users (`/api/Users`)
- **POST** `/api/Users` — Kullanıcı oluştur; gövde `CreateUserCommand`, rol: Admin.
- **PUT** `/api/Users` — Kullanıcı güncelle; gövde `UpdateUserCommand`, roller: Admin veya Operator.
- **DELETE** `/api/Users/{id}` — Kullanıcı sil; yol parametresi `id` (Guid), rol: Admin.
- **GET** `/api/Users/{id}` — Kullanıcı getir; yol parametresi `id` (Guid), roller: Admin veya Operator.
- **GET** `/api/Users` — Kullanıcı listesini getir; sorgu `GetUserListQuery`, rol: Admin.
- **PUT** `/api/Users/change-password` — Şifre değiştir; gövde `ChangePasswordCommand`, roller: Admin veya Operator.

## Logs (`/api/Logs`)
- **POST** `/api/Logs` — Log oluştur; gövde `CreateLogCommand`, rol: Admin.
- **PUT** `/api/Logs` — Log güncelle; gövde `UpdateLogCommand`, rol: Admin.
- **DELETE** `/api/Logs/{id}` — Log sil; yol parametresi `id` (int), rol: Admin.
- **GET** `/api/Logs/{id}` — Log getir; yol parametresi `id` (int), rol: Admin.
- **GET** `/api/Logs` — Log listesini getir; sorgu `GetLogListQuery`, rol: Admin.

## ArchiveTags (`/api/ArchiveTags`)
- **POST** `/api/ArchiveTags` — Arşiv etiketi oluştur; gövde `CreateArchiveTagCommand`, rol: Admin.
- **PUT** `/api/ArchiveTags` — Arşiv etiketi güncelle; gövde `UpdateArchiveTagCommand`, rol: Admin.
- **DELETE** `/api/ArchiveTags/{id}` — Arşiv etiketi sil; yol parametresi `id` (int), rol: Admin.
- **GET** `/api/ArchiveTags/{id}` — Arşiv etiketi getir; yol parametresi `id` (int), roller: Admin veya Operator.
- **POST** `/api/ArchiveTags/list` — Arşiv etiketleri listele; sorgu `PageRequest`, gövde isteğe bağlı `DynamicQuery`, roller: Admin veya Operator.

## InstantValues (`/api/InstantValues`)
- **POST** `/api/InstantValues` — Anlık değer oluştur; gövde `CreateInstantValueCommand`, rol: Admin.
- **GET** `/api/InstantValues/{timestamp}` — Zaman damgasına göre değer getir; yol parametresi `timestamp` (DateTime), roller: Admin veya Operator.
- **POST** `/api/InstantValues/list` — Anlık değerleri listele; sorgu `PageRequest`, gövde isteğe bağlı `DynamicQuery`, roller: Admin veya Operator.

## ReportTemplates (`/api/ReportTemplates`)
- **POST** `/api/ReportTemplates` — Rapor şablonu oluştur; gövde `CreateReportTemplateCommand`, rol: Admin.
- **PUT** `/api/ReportTemplates` — Rapor şablonu güncelle; gövde `UpdateReportTemplateCommand`, rol: Admin.
- **DELETE** `/api/ReportTemplates/{id}` — Rapor şablonu sil; yol parametresi `id` (int), yetki belirtilmemiş.
- **GET** `/api/ReportTemplates/{id}` — Rapor şablonunu getir; yol parametresi `id` (int), sorgu `userId` (Guid), roller: Admin veya Operator.
- **POST** `/api/ReportTemplates/list` — Rapor şablonlarını listele; sorgu `PageRequest` ve `userId` (Guid), gövde isteğe bağlı `DynamicQuery`, roller: Admin veya Operator.

## ReportTemplateArchiveTags (`/api/ReportTemplateArchiveTags`)
- **POST** `/api/ReportTemplateArchiveTags` — İlişki oluştur; gövde `CreateReportTemplateArchiveTagCommand`, rol: Admin.
- **DELETE** `/api/ReportTemplateArchiveTags/{id}` — İlişki sil; yol parametresi `id` (int), rol: Admin.
- **GET** `/api/ReportTemplateArchiveTags/{id}` — İlişki getir; yol parametresi `id` (int), roller: Admin veya Operator.
- **POST** `/api/ReportTemplateArchiveTags/list` — İlişkileri listele; sorgu `PageRequest`, gövde isteğe bağlı `DynamicQuery`, roller: Admin veya Operator.

## UserOperationClaims (`/api/UserOperationClaims`)
- **POST** `/api/UserOperationClaims` — Kullanıcı yetkisi ekle; gövde `CreateUserOperationClaimCommand`, rol: Admin.
- **PUT** `/api/UserOperationClaims` — Kullanıcı yetkisi güncelle; gövde `UpdateUserOperationClaimCommand`, rol: Admin.
- **DELETE** `/api/UserOperationClaims/{id}` — Kullanıcı yetkisi sil; yol parametresi `id` (int), rol: Admin.
- **GET** `/api/UserOperationClaims` — Kullanıcı yetkilerini listele; sorgu `GetUserOperationClaimListQuery`, rol: Admin.
- **GET** `/api/UserOperationClaims/user/{userId}` — Belirli kullanıcının yetkilerini getir; yol parametresi `userId` (Guid), rol: Admin.
- **GET** `/api/UserOperationClaims/{id}` — Kullanıcı yetkisi getir; yol parametresi `id` (int), rol: Admin.

## OperationClaims (`/api/OperationClaims`)
- **POST** `/api/OperationClaims` — Yetki oluştur; gövde `CreateOperationClaimCommand`, rol: Admin.
- **PUT** `/api/OperationClaims` — Yetki güncelle; gövde `UpdateOperationClaimCommand`, rol: Admin.
- **DELETE** `/api/OperationClaims/{id}` — Yetki sil; yol parametresi `id` (int), rol: Admin.
- **GET** `/api/OperationClaims/{id}` — Yetki getir; yol parametresi `id` (int), rol: Admin.
- **GET** `/api/OperationClaims` — Yetkileri listele; sorgu `GetOperationClaimListQuery`, rol: Admin.

## Dashboard (`/api/Dashboard`)
- **GET** `/api/Dashboard` — Sistem istatistiklerini getir; roller: Admin veya Operator.
- **GET** `/api/Dashboard/metrics` — Sistem metriklerini getir; roller: Admin veya Operator.

## SystemSettings (`/api/SystemSettings`)
- **GET** `/api/SystemSettings` — Sistem ayarlarını getir; roller: Admin veya Operator.
- **PUT** `/api/SystemSettings` — Sistem ayarlarını yaz; gövde `WriteSystemSettingCommand`, rol: Admin.

## Opc (`/api/Opc`)
- **POST** `/api/Opc/connect` — OPC UA sunucusuna bağlan; sorgu `endpoint` (string).
- **GET** `/api/Opc/read` — Düğüm oku; sorgu `nodeId` (string).
- **POST** `/api/Opc/write` — Düğüm yaz; sorgu `nodeId` ve `value` (string).
- **GET** `/api/Opc/browse` — Alt düğümleri listele; isteğe bağlı sorgu `nodeId`.
- **GET** `/api/Opc/tree` — Düğüm ağacını getir; isteğe bağlı sorgu `nodeId`.
- **GET** `/api/Opc/discover` — Ağ üzerindeki OPC UA sunucularını keşfet; isteğe bağlı sorgu `networkPrefix` ve `port`.
- **POST** `/api/Opc/disconnect` — Bağlantıyı kes.


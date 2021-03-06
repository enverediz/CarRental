using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi.";
        public static string CarDeleted = "Araba silindi.";
        public static string CarUpdated = "Araba guncellendi.";
        public static string CarNameInvalid = "Araba ismi gecersiz.";
        public static string MaintenanceTime = "Sistem suan bakimda.";
        public static string CarsListed = "Arabalar listelendi.";
        public static string CarNotDelivered = "Arac henuz teslim edilmedi.";
        public static string BrandsListed = "Markalar listelendi.";
        public static string UsersListed = "Kullanicilar listelendi.";
        public static string CarImagesListed = "Araba resimleri listelendi.";
        public static string ColorsListed = "Renkler listelendi.";
        public static string CustomersListed = "Musteriler listelendi.";
        public static string RentalsListed = "Kiralama islemleri listelendi.";
        public static string BrandDeleted = "Marka silindi.";
        public static string BrandUpdated = "Marka guncellendi.";
        public static string CarImageDeleted = "Arac resmi silindi.";
        public static string CarImageUpdated = "Arac resmi guncellendi.";
        public static string ColorDeleted = "Renk silindi.";
        public static string ColorUpdated = "Renk guncellendi.";
        public static string CustomerDeleted = "Musteri silindi.";
        public static string CustomerUpdated = "Musteri guncellendi.";
        public static string RentalDeleted = "Kiralama islemi silindi.";
        public static string RentalUpdated = "Kiralama islemi guncellendi.";
        public static string UserDeleted = "Kullanici silindi.";
        public static string UserUpdated = "Kullanici guncellendi.";
        public static string DailyPriceInvalid = "Gunluk fiyat gecersiz.";
        public static string ImageCountOfCarImageError = "Bir arabanın en fazla 5 resmi olabilir.";
        public static string AuthorizationDenied = "Yetkiniz yok!";
        public static string UserRegistered = "Kayit basarili.";
        public static string UserNotFound = "Kullanici bulunamadi!";
        public static string PasswordError = "Parola hatasi!";
        public static string SuccessfulLogin = "Giris basarili.";
        public static string UserAlreadyExists = "Bu isimde bir kullanici mevcut!";
        public static string AccessTokenCreated = "Token olusturuldu.";
    }
}

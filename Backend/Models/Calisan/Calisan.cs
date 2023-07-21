using FinagotechCalisanlar.Data.App;
using FinagotechCalisanlar.Data.Calisan;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace FinagotechCalisanlar.Models.Calisan
{
    public class Calisan : ICalisan
    {
        private static readonly List<DataCalisan> calisanlar = new List<DataCalisan> {
            new DataCalisan() { 
                Id = 1, Ad = "Grace", Soyad = "Stewart", EPosta = "grace@outlook.com", Telefon = "605-720-4765", Cinsiyet = "Kadın", Yas = 68, 
                Konum = new DataCalisanAdres(){
                    Adres = "42581 Water Street.", Adres2 = "", Ilce = "Harrisburg", Sehir = "Pennsylvania"
                } 
            },
            new DataCalisan() {
                Id = 2, Ad = "Sophia", Soyad = "Kelly", EPosta = "s_kelly@gmail.com", Telefon = "229-922-3456", Cinsiyet = "Kadın", Yas = 69,
                Konum = new DataCalisanAdres(){
                    Adres = "863 Hillside Drive", Adres2 = "Unit 86", Ilce = "Crestline", Sehir = "California"
                }
            },
            new DataCalisan() {
                Id = 3, Ad = "Benjamin", Soyad = "Allen", EPosta = "b.allen@live.com", Telefon = "816-754-6514", Cinsiyet = "Erkek", Yas = 23,
                Konum = new DataCalisanAdres(){
                    Adres = "995 2nd Street", Adres2 = "", Ilce = "Winston Salem", Sehir = "North Carolina"
                }
            },
            new DataCalisan() {
                Id = 4, Ad = "Aaron", Soyad = "Howard", EPosta = "a_w_howard@outlook.com", Telefon = "228-038-6370", Cinsiyet = "Erkek", Yas = 75,
                Konum = new DataCalisanAdres(){
                    Adres = "509 Beech Street", Adres2 = "", Ilce = "Alexandria", Sehir = "Ohio"
                }
            },
            new DataCalisan() {
                Id = 5, Ad = "Lauren", Soyad = "Adams", EPosta = "laurenadams@hotmail.com", Telefon = "781-137-4454", Cinsiyet = "Kadın", Yas = 67,
                Konum = new DataCalisanAdres(){
                    Adres = "243 Lincoln Avenue", Adres2 = "Apt 173", Ilce = "Utica", Sehir = "Mississippi"
                }
            },
            new DataCalisan() {
                Id = 6, Ad = "Zachary", Soyad = "Gonzales", EPosta = "zacharygonzales@ymail.com", Telefon = "927-762-8858", Cinsiyet = "Erkek", Yas = 39,
                Konum = new DataCalisanAdres(){
                    Adres = "6943 River Road", Adres2 = "", Ilce = "Conehatta", Sehir = "Mississippi"
                }
            },
            new DataCalisan() {
                Id = 7, Ad = "Daniel", Soyad = "Phillips", EPosta = "daniel_phillips@aol.com", Telefon = "563-693-7490", Cinsiyet = "Erkek", Yas = 52,
                Konum = new DataCalisanAdres(){
                    Adres = "222 Elm Avenue", Adres2 = "Unit 1615", Ilce = "Chester", Sehir = "Arkansas"
                }
            },
            new DataCalisan() {
                Id = 8, Ad = "Melissa", Soyad = "Scott", EPosta = "mscott@ymail.com", Telefon = "763-954-0671", Cinsiyet = "Kadın", Yas = 29,
                Konum = new DataCalisanAdres(){
                    Adres = "33 Delaware Avenue", Adres2 = "", Ilce = "Scottsbluff", Sehir = "Nebraska"
                }
            },
            new DataCalisan() {
                Id = 9, Ad = "Hannah", Soyad = "Edwards", EPosta = "hredwards@gmail.com", Telefon = "689-810-5330", Cinsiyet = "Kadın", Yas = 44,
                Konum = new DataCalisanAdres(){
                    Adres = "34 Williams Street", Adres2 = "", Ilce = "South Orange", Sehir = "New Jersey"
                }
            },
            new DataCalisan() {
                Id = 10, Ad = "Heather", Soyad = "Roberts", EPosta = "heather_roberts@outlook.com", Telefon = "973-826-3802", Cinsiyet = "Kadın", Yas = 51,
                Konum = new DataCalisanAdres(){
                    Adres = "49424 New Street", Adres2 = "", Ilce = "Keene", Sehir = "New York"
                }
            },
            new DataCalisan() {
                Id = 11, Ad = "David", Soyad = "Carter", EPosta = "decarter@rocketmail.com", Telefon = "925-662-4640", Cinsiyet = "Erkek", Yas = 30,
                Konum = new DataCalisanAdres(){
                    Adres = "606 Heather Lane", Adres2 = "", Ilce = "Amherst", Sehir = "Massachusetts"
                }
            },
            new DataCalisan() {
                Id = 12, Ad = "Lauren", Soyad = "Bell", EPosta = "la_bell@ymail.com", Telefon = "857-754-1442", Cinsiyet = "Kadın", Yas = 48,
                Konum = new DataCalisanAdres(){
                    Adres = "3 2nd Street East", Adres2 = "", Ilce = "Lake Butter", Sehir = "Florida"
                }
            },
            new DataCalisan() {
                Id = 13, Ad = "Jose", Soyad = "Allen", EPosta = "jose@hotmail.com", Telefon = "731-176-8671", Cinsiyet = "Erkek", Yas = 37,
                Konum = new DataCalisanAdres(){
                    Adres = "63 Hillside Drive", Adres2 = "", Ilce = "Troy Grove", Sehir = "Illinois"
                }
            },
            new DataCalisan() {
                Id = 14, Ad = "Taylor", Soyad = "Washington", EPosta = "taylor.washington@ymail.com", Telefon = "620-074-9451", Cinsiyet = "Kadın", Yas = 42,
                Konum = new DataCalisanAdres(){
                    Adres = "9881 Front Street", Adres2 = "", Ilce = "Watauga", Sehir = "Tennessee"
                }
            },
        };

        public AppResponse<bool> Add(DataCalisan data)
        {
            try
            {
                data.Id = calisanlar.Count + 1;
                calisanlar.Add(data);
                return AppResponse<bool>.Success(true, "Ekleme işlemi başarılı");
            }
            catch (Exception ex)
            {
                return AppResponse<bool>.Error("Ekleme sırasında sorun oluştu: " + ex.Message);
            }
        }

        public AppResponse<bool> Save(DataCalisan data)
        {
            try
            {
                var findIndex = calisanlar.FindIndex(c => c.Id == data.Id);
                if (findIndex == -1)
                    return AppResponse<bool>.Error("Kayıt bulunamadı");

                calisanlar[findIndex] = data;
                return AppResponse<bool>.Success(true, "Kaydetme işlemi başarılı");
            }
            catch (Exception ex)
            {
                return AppResponse<bool>.Error("Kaydetme sırasında sorun oluştu:" + ex.Message);
            }
        }

        public AppResponse<bool> Delete(long id)
        {
            try
            {
                var findIndex = calisanlar.FindIndex(c => c.Id == id);
                if (findIndex == -1)
                    return AppResponse<bool>.Error("Kayıt bulunamadı");

                calisanlar.Remove(calisanlar[findIndex]);
                return AppResponse<bool>.Success(true, "Silme işlemi başarılı");
            }
            catch (Exception ex)
            {
                return AppResponse<bool>.Error("Silme sırasında sorun oluştu: " + ex.Message);
            }
        }

        public AppResponse<DataCalisan> Get(long id)
        {
            try
            {
                var findIndex = calisanlar.FindIndex(c => c.Id == id);
                if (findIndex == -1)
                    return AppResponse<DataCalisan>.Error("Kayıt bulunamadı, " + "ID:" + id);

                return AppResponse<DataCalisan>.Success(calisanlar[findIndex], "ID:" + id);
            }
            catch (Exception ex)
            {
                return AppResponse<DataCalisan>.Error("Kaydın alınması sırasında sorun oluştu: " + ex.Message);
            }
        }

        public AppResponse<PaginationData<DataCalisan>> ListPagination(int pageNumber, int limit = 10)
        {
            var descOrder = calisanlar.OrderByDescending(c => c.Id).ToList();
            int offset = 0;
            if (pageNumber > 1)
            {
                offset = (pageNumber - 1) * limit;
            }
            var result = descOrder.Skip(offset).Take(limit).ToList();
            var pagination = new PaginationData<DataCalisan>(result, descOrder.Count, limit, pageNumber);
            return AppResponse<PaginationData<DataCalisan>>.Success(pagination);
        }

    }
}

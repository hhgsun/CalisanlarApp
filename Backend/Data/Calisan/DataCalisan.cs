namespace FinagotechCalisanlar.Data.Calisan
{
    public class DataCalisan
    {
        public long Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int Yas { get; set; }
        public string Cinsiyet { get; set; }
        public string EPosta { get; set; }
        public string Telefon { get; set; }
        public DataCalisanAdres Konum { get; set; }
    }
}

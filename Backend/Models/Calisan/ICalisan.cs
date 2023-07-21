using FinagotechCalisanlar.Data.App;
using FinagotechCalisanlar.Data.Calisan;

namespace FinagotechCalisanlar.Models.Calisan
{
    public interface ICalisan
    {
        AppResponse<bool> Add(DataCalisan data);
        AppResponse<bool> Save(DataCalisan data);
        AppResponse<bool> Delete(long id);
        AppResponse<DataCalisan> Get(long id);
        AppResponse<PaginationData<DataCalisan>> ListPagination(int pageNumber, int limit);
    }
}

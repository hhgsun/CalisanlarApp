using FinagotechCalisanlar.Data.App;
using FinagotechCalisanlar.Data.Calisan;
using FinagotechCalisanlar.Models.Calisan;
using Microsoft.AspNetCore.Mvc;

namespace FinagotechCalisanlar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalisanlarController : ControllerBase
    {
        private readonly ICalisan _calisan;

        public CalisanlarController(ICalisan calisan)
        {
            _calisan = calisan;
        }

        [HttpGet("{id}")]
        public AppResponse<DataCalisan> Get(long id)
        {
            return _calisan.Get(id);
        }

        [HttpGet]
        public AppResponse<PaginationData<DataCalisan>> Index(int offset, int limit)
        {
            return _calisan.ListPagination(offset, limit);
        }

        [HttpPost]
        public AppResponse<bool> Add(DataCalisan calisan)
        {
            return _calisan.Add(calisan);
        }

        [HttpPut]
        public AppResponse<bool> Save(DataCalisan calisan)
        {
            return _calisan.Save(calisan);
        }

        [HttpDelete]
        public AppResponse<bool> Delete(long id)
        {
            return _calisan.Delete(id);
        }
    }
}

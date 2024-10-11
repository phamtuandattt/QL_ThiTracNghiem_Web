using Microsoft.AspNetCore.Mvc;
using QL_ThiTracNghiem_WebApi.BLL.IServices.IKhoaServices;
using QL_ThiTracNghiem_WebApi.BLL.Services.KhoaServices;
using QL_ThiTracNghiem_WebAPI.DAL.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QL_ThiTracNghiem_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhoaController : ControllerBase
    {
        private readonly IKhoaServices _khoaServices;

        public KhoaController(IKhoaServices khoaServices)
        {
            _khoaServices = khoaServices;
        }

        // GET: api/<KhoaController>
        [HttpGet]
        public ActionResult<IEnumerable<Khoa>> Get()
        {
            var lst = _khoaServices.GetAll();
            if (!lst.Any())
            {
                return NotFound(new ApiResponse
                {
                    status = HttpStatusCode.NotFound + "",
                    message = "no available !",
                    data = ""
                });
            }
            return Ok(new ApiResponse
            {
                status = HttpStatusCode.OK + "",
                message = "success",
                data = JsonConvert.SerializeObject(lst)
            });
        }

        // GET api/<KhoaController>/5
        [HttpGet("{makhoa}")]
        public ActionResult Get(string makhoa)
        {
            if (!_khoaServices.ItemExists(makhoa))
            {
                var errorrResponse = new ApiResponse
                {
                    status = HttpStatusCode.NotFound + "",
                    message = "not found",
                    data = ""
                };
                return BadRequest(errorrResponse);
            }

            return Ok(new ApiResponse
            {
                status = HttpStatusCode.OK + "",
                message = "success",
                data = JsonConvert.SerializeObject(_khoaServices.Get(makhoa))
            });
        }

        // POST api/<KhoaController>
        [HttpPost]
        public ActionResult Post([FromBody] KhoaRequestDto khoa)
        {
            if (khoa.TenKhoa == null || khoa.TenKhoa == "")
            {
                return BadRequest(new ApiResponse
                {
                    status = HttpStatusCode.NotFound + "",
                    message = "Invalid TenKhoa data",
                    data = null
                });
            }
            _khoaServices.Insert(new Khoa { Tenkhoa = khoa.TenKhoa });
            try
            {
                _khoaServices.Savechange();
            }
            catch (DbUpdateException)
            {

            }
            return Ok(new ApiResponse
            {
                status = HttpStatusCode.NoContent + "",
                message = "success",
                data = ""
            });
        }

        // PUT api/<KhoaController>/5
        [HttpPut("{makhoa}")]
        public ActionResult Put(string makhoa, [FromBody] KhoaRequestDto khoa)
        {
            if (!_khoaServices.ItemExists(makhoa) || string.IsNullOrEmpty(khoa.TenKhoa))
            {
                var errorrResponse = new ApiResponse
                {
                    status = HttpStatusCode.NotFound + "",
                    message = "Khoa not found",
                    data = ""
                };
                return NotFound(errorrResponse);
            }
            var item = _khoaServices.Get(makhoa);
            item.Tenkhoa = khoa.TenKhoa;
            _khoaServices.Update(item);
            try
            {
                _khoaServices.Savechange();
            }
            catch (DbUpdateException)
            {

            }
            return Ok(new ApiResponse
            {
                status = HttpStatusCode.OK + "",
                message = "success",
                data = JsonConvert.SerializeObject(item)
            });
        }

        // DELETE api/<KhoaController>/5
        [HttpDelete("{makhoa}")]
        public ActionResult Delete(string makhoa)
        {
            if (!_khoaServices.ItemExists(makhoa))
            {
                return NotFound(new ApiResponse
                {
                    status = HttpStatusCode.NotFound + "",
                    message = "Khoa not found",
                    data = ""
                });
            }
            _khoaServices.Delete(makhoa);
            try
            {
                _khoaServices.Savechange();
            }
            catch (DbUpdateException)
            {

            }
            return Ok(new ApiResponse
            {
                status = HttpStatusCode.NoContent + "",
                message = "success",
                data = ""
            });
        }
    }
}



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using QL_ThiTracNghiem_WebAPI.DAL.Models;

namespace QL_ThiTracNghiem_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChucVuController : ControllerBase
    {
        private readonly IChucVuServices _chucVuServices;

        public ChucVuController(IChucVuServices chucVuServices)
        {
            _chucVuServices = chucVuServices;
        }

        // GET: api/<ChucVuController>
        [HttpGet]
        public ActionResult<IEnumerable<Chucvu>> Get()
        {
            var lst = _chucVuServices.chucvus();
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

        // GET api/<ChucVuController>/5
        [HttpGet("{id}")]
        public ActionResult<Chucvu> Get(int id)
        {
            if (!_chucVuServices.ItemExists(id))
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
                data = JsonConvert.SerializeObject(_chucVuServices.chucvu(id))
            });
        }

        // POST api/<ChucVuController>
        [HttpPost]
        public ActionResult<Chucvu> Post([FromBody] ChucVuRequestDto chucVu)
        {
            if (chucVu.TenChucVu == null)
            {
                return BadRequest(new ApiResponse
                {
                    status = HttpStatusCode.NotFound + "",
                    message = "Invalid chuvu data",
                    data = null
                });
            }
            var cV = new Chucvu() { Tenchucvu = chucVu.TenChucVu };
            _chucVuServices.insert(cV);
            try
            {
                _chucVuServices.savechange();
            }
            catch (DbUpdateException)
            {

            }

            return NoContent();
        }

        // PUT api/<ChucVuController>/5
        [HttpPut("{id}")]
        public ActionResult<Chucvu> Put(int id, [FromBody] ChucVuRequestDto chucvu)
        {
            if (!_chucVuServices.ItemExists(id))
            {
                var errorrResponse = new ApiResponse
                {
                    status = HttpStatusCode.NotFound + "",
                    message = "ChucVu not found",
                    data = ""
                };
                return NotFound(errorrResponse);
            }
            var item = _chucVuServices.chucvu(id);
            item.Tenchucvu = chucvu.TenChucVu;
            _chucVuServices.update(item);
            try
            {
                _chucVuServices.savechange();
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

        // DELETE api/<ChucVuController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            //var item = _chucVuServices.chucvu(id);
            if (!_chucVuServices.ItemExists(id))
            {
                return NotFound(new ApiResponse
                {
                    status = HttpStatusCode.NotFound + "",
                    message = "ChucVu not found",
                    data = ""
                });
            }
            _chucVuServices.delete(id);
            try
            {
                _chucVuServices.savechange();
            }
            catch (DbUpdateException)
            {

            }
            return NoContent();
        }
    }
}


using QL_ThiTracNghiem_WebApi.BLL.IServices.ILopHocServices;
using QL_ThiTracNghiem_WebAPI.Common;

namespace QL_ThiTracNghiem_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LopHocController : ControllerBase
    {
        private readonly ILopHocServices _services;
        public LopHocController(ILopHocServices services)
        {
            _services = services;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Lophoc>> Get()
        {
            var lst = _services.GetAll();
            if (!lst.Any())
            {
                return NotFound(new ApiResponse()
                {
                    status = HttpStatusCode.NotFound + "",
                    message = ApiResponseMessage.NO_AVAILABLE,
                    data = ""
                });
            }

            return Ok(new ApiResponse()
            {
                status = HttpStatusCode.OK + "",
                message = ApiResponseMessage.SUCCESS,
                data = JsonConvert.SerializeObject(lst)
            });
        }

        [HttpGet("{malop}")]
        public ActionResult Get(string malop)
        {
            if (!_services.ItemExists(malop))
            {
                var errorrResponse = new ApiResponse
                {
                    status = HttpStatusCode.NotFound + "",
                    message = ApiResponseMessage.NOT_FOUND,
                    data = ""
                };
                return BadRequest(errorrResponse);
            }

            return Ok(new ApiResponse
            {
                status = HttpStatusCode.OK + "",
                message = ApiResponseMessage.SUCCESS,
                data = JsonConvert.SerializeObject(_services.Get(malop))
            });
        }

        [HttpPost]
        public ActionResult Post([FromBody] LopHocRequestDto lop)
        {
            if (string.IsNullOrEmpty(lop.MaLop) || string.IsNullOrEmpty(lop.MaKhoa))
            {
                return BadRequest(new ApiResponse
                {
                    status = HttpStatusCode.NotFound + "",
                    message = ApiResponseMessage.INVALID_OBJECT,
                    data = null
                });
            }
            //_services.Insert(lop);
            try
            {
                _services.SaveChanges();
            }
            catch (DbUpdateException)
            {

            }
            return Ok(new ApiResponse
            {
                status = HttpStatusCode.NoContent + "",
                message = ApiResponseMessage.SUCCESS,
                data = ""
            });
        }

    }
}

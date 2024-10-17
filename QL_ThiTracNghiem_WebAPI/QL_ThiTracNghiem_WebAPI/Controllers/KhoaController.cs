using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QL_ThiTracNghiem_WebApi.BLL.Dtos;
using QL_ThiTracNghiem_WebApi.BLL.IServices.IKhoaServices;
using QL_ThiTracNghiem_WebApi.BLL.Services.KhoaServices;
using QL_ThiTracNghiem_WebAPI.Common;
using QL_ThiTracNghiem_WebAPI.DAL.Models;
using QL_ThiTracNghiem_WebAPI.Models.RequestDto.KhoaRequestDto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QL_ThiTracNghiem_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhoaController : ControllerBase
    {
        private readonly IKhoaServices _khoaServices;
        private readonly IMapper mapper;

        public KhoaController(IKhoaServices khoaServices, IMapper mapper)
        {
            _khoaServices = khoaServices;
            this.mapper = mapper;
        }

        // GET: api/<KhoaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var lst = await _khoaServices.GetAllAsync();
            if (!lst.Any())
            {
                return NotFound(new ApiResponse
                {
                    status = HttpStatusCode.NotFound + "",
                    message = ApiResponseMessage.NOT_FOUND,
                    data = ""
                });
            }
            return Ok(new ApiResponse
            {
                status = HttpStatusCode.OK + "",
                message = ApiResponseMessage.SUCCESS,
                data = JsonConvert.SerializeObject(lst)
            });
        }

        // GET api/<KhoaController>/5
        [HttpGet("{makhoa}")]
        public async Task<IActionResult> Get(string makhoa)
        {
            if (!await _khoaServices.ItemExists(makhoa))
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
                data = JsonConvert.SerializeObject(await _khoaServices.GetByIdAsync(makhoa))
            });
        }

        // POST api/<KhoaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] KhoaRequestDto khoa)
        {
            if (khoa.TenKhoa == null || khoa.TenKhoa == "")
            {
                return BadRequest(new ApiResponse
                {
                    status = HttpStatusCode.NotFound + "",
                    message = ApiResponseMessage.INVALID_OBJECT,
                    data = null
                });
            }
            
            try
            {
                var item = mapper.Map<KhoaDto>(khoa);
                await _khoaServices.AddAsync(item);
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

        // PUT api/<KhoaController>/5
        [HttpPut("{makhoa}")]
        public async Task<IActionResult> Put(string makhoa, [FromBody] KhoaRequestDto khoa)
        {
            if (!await _khoaServices.ItemExists(makhoa) || string.IsNullOrEmpty(khoa.TenKhoa))
            {
                var errorrResponse = new ApiResponse
                {
                    status = HttpStatusCode.NotFound + "",
                    message = ApiResponseMessage.NOT_FOUND,
                    data = ""
                };
                return NotFound(errorrResponse);
            }

            try
            {
                var itemDto = mapper.Map<KhoaDto>(khoa);
                await _khoaServices.UpdateAsync(makhoa, itemDto);
            }
            catch (DbUpdateException)
            {

            }
            return Ok(new ApiResponse
            {
                status = HttpStatusCode.OK + "",
                message = "success",
                data = ""
            });
        }

        // DELETE api/<KhoaController>/5
        [HttpDelete("{makhoa}")]
        public async Task<IActionResult> Delete(string makhoa)
        {
            if (!await _khoaServices.ItemExists(makhoa))
            {
                return NotFound(new ApiResponse
                {
                    status = HttpStatusCode.NotFound + "",
                    message = ApiResponseMessage.NOT_FOUND,
                    data = ""
                });
            }
            
            try
            {
                await _khoaServices.DeleteAsync(makhoa);
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

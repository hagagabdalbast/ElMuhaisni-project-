using ElMuhaisni.BL.DTO;
using ElMuhaisni.BL.DTO.LastNews;
using ElMuhaisni.BL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElMuhaisni.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly ILastNewRepo lastNewRepo;

        public NewsController(ILastNewRepo lastNewRepo)
        {
            this.lastNewRepo = lastNewRepo;
        }


        [HttpPost]
        public IActionResult Create(CreateLastNewDTO newDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dept = lastNewRepo.Create(newDTO);
                    return Ok(dept);
                }
                return BadRequest(new ApiResponse<string>("Not Created", "News Not Created", false, 400));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<string>(ex.InnerException?.Message, "News Not Created", false, 400));

            }
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            try
            {
                var lastNews = lastNewRepo.GetAll();
                return Ok(lastNews);
            }
            catch (Exception)
            {
                return NotFound(new ApiResponse<string>("Not Found", "Data Not Found", false, 404));
            }
        }


        [HttpGet("GetById/{id:int}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var lastNews = lastNewRepo.GetById(id);
                return Ok(lastNews);
            }
            catch (Exception)
            {
                return NotFound(new ApiResponse<string>("Not Found", "Data Not Found", false, 404));
            }
        }

        
        [HttpPut("EditByid/{id:int}")]
        public IActionResult Edit(int id, UpdateLastNewDTO newDTO)
        {
            try
            {
                var lastNews = lastNewRepo.Edit(id, newDTO);
                return Ok(lastNews);
            }
            catch (Exception)
            {
                return BadRequest(new ApiResponse<string>("Not Updated", "News Not Updated", false, 400));

            }

        }


        [HttpDelete("Delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                lastNewRepo.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<string>("Not Deleted", "News Not Deleted", false, 400));
            }
        }
    }
}

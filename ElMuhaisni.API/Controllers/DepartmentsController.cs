using ElMuhaisni.BL.DTO;
using ElMuhaisni.BL.DTO.Department;
using ElMuhaisni.BL.Interfaces;
using ElMuhaisni.BL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace ElMuhaisni.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRepo departmentRepo;

        public DepartmentsController(IDepartmentRepo departmentRepo)
        {
            this.departmentRepo = departmentRepo;
        }


        [HttpPost]
        public IActionResult Create(CreateDepartmentDTO departmentDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dept = departmentRepo.Create(departmentDTO);
                    return Ok(dept);
                }
                return BadRequest(new ApiResponse<string>("Not Created", "Department Not Created", false, 400));

            }
            catch (Exception)
            {
                return BadRequest(new ApiResponse<string>("Not Created", "Department Not Created", false, 400));

            }
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            try
            {
                var depts = departmentRepo.GetAll();
                return Ok(depts);
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
                var depts = departmentRepo.GetById(id);
                return Ok(depts);
            }
            catch (Exception)
            {
                return NotFound(new ApiResponse<string>("Not Found", "Data Not Found", false, 404));
            }
        }

        [HttpGet("GetByName/{name:alpha}")]
        public IActionResult GetByName(string name)
        {
            try
            {
                var depts = departmentRepo.GetByName(name);
                return Ok(depts);
            }
            catch (Exception)
            {
                return NotFound(new ApiResponse<string>("Not Found", "Data Not Found", false, 404));

            }
        }

        [HttpPut("EditByid/{id:int}")]
        public IActionResult EditDepartment(int id,DepartmentDTO departmentDTO)
        {
            try
            {
                var depts = departmentRepo.EditDepartment(id, departmentDTO);
                return Ok(depts);
            }
            catch (Exception)
            {
                return BadRequest(new ApiResponse<string>("Not Updated", "Department Not Updated", false, 400));
            }

        }


        [HttpDelete("Delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                departmentRepo.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<string>("Not Deleted", "Department Not Deleted", false, 400));

            }
        }


    }
}

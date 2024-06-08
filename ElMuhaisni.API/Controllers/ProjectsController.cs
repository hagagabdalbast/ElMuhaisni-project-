using ElMuhaisni.BL.DTO;
using ElMuhaisni.BL.DTO.Project;
using ElMuhaisni.BL.Interfaces;
using ElMuhaisni.BL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElMuhaisni.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectRepo projectRepo;

        public ProjectsController(IProjectRepo projectRepo)
        {
            this.projectRepo = projectRepo;
        }

        [HttpPost]
        public IActionResult AddNewProject(CreatProjectDTO projectDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var project = projectRepo.Create(projectDTO);
                    return Ok(project);
                }
                return BadRequest(new ApiResponse<string>("Not Created", "Project Not Created", false, 400));

            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<string>(ex.InnerException?.Message, "Project Not Created", false, 400));

            }
        }


        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            try
            {
                var depts = projectRepo.GetAll();
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
                var depts = projectRepo.GetById(id);
                return Ok(depts);
            }
            catch (Exception)
            {
                return NotFound(new ApiResponse<string>("Not Found", "Data Not Found", false, 404));

            }
        }

        [HttpPut("Edit/{id:int}")]
        public IActionResult Update(int id, UpdateProjectDTO updateDepartmentDTO)
        {
            try
            {
                var project = projectRepo.Edit(id, updateDepartmentDTO);
                return Ok(project);
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
                projectRepo.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<string>("Not Deleted", "Project Not Deleted", false, 400));

            }
        }


    }
}

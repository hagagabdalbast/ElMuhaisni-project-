using ElMuhaisni.BL.DTO;
using ElMuhaisni.BL.DTO.Contact;
using ElMuhaisni.BL.Interfaces;
using ElMuhaisni.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElMuhaisni.API.Controllers
{
   
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepo contactRepo;
        

        public ContactsController(IContactRepo contactRepo)
        {
            this.contactRepo = contactRepo;
            
        }


        [HttpPost("Create")]
        public IActionResult Create(CreateContactDTO contactDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dept = contactRepo.Create(contactDTO);
                    return Ok(dept);
                }
                return BadRequest(new ApiResponse<string>("Not Created", "Contact Not Created", false, 400));
            }
            catch (Exception)
            {
                return BadRequest(new ApiResponse<string>("Not Created", "Contact Not Created", false, 400));
            }
        }
        
         

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            try
            {
                var contacts = contactRepo.GetAll();
                return Ok(contacts);
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
                var contact = contactRepo.GetById(id);
                return Ok(contact);
            }
            catch (Exception)
            {
                return NotFound(new ApiResponse<string>("Not Found", "Data Not Found", false, 404));
            }
        }

    }

}


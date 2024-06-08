using ElMuhaisni.BL.DTO;
using ElMuhaisni.BL.DTO.Contact;
using ElMuhaisni.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElMuhaisni.BL.Interfaces
{
    public interface IContactRepo
    {
        //Task<IEnumerable<ContactUs>> GetAllAsync();
        //Task<ContactUs> GetByIdAsync(int id);
        //Task<ContactUs> AddAsync(ContactUs contactUs);
        //Task<ContactUs> UpdateAsync(ContactUs contactUs);
        //Task DeleteAsync(int id);


        //ApiResponse<Task> AddContactUsAsync(ContactUs contact);
        ApiResponse<List<ContactDTO>> GetAll();
        ApiResponse<string> Create(CreateContactDTO newDTO);
        ApiResponse<ContactDTO> GetById(int id);
    }
}

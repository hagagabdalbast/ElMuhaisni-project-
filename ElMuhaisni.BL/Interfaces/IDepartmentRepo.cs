using ElMuhaisni.BL.DTO;
using ElMuhaisni.BL.DTO.Department;
using ElMuhaisni.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElMuhaisni.BL.Interfaces
{
    public interface IDepartmentRepo
    {
        ApiResponse<List<DepartmentDTO>> GetAll();
        ApiResponse<DepartmentDTO> GetById(int id);
        ApiResponse<DepartmentDTO> GetByName(string name);
        ApiResponse<string> EditDepartment(int id,DepartmentDTO newDepartment);
        ApiResponse<string> Create(CreateDepartmentDTO departmentDto);

        ApiResponse<string> Delete(int id);
    }
}

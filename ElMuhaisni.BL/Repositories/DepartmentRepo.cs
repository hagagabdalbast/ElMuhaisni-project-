using ElMuhaisni.BL.DTO;
using ElMuhaisni.BL.DTO.Department;
using ElMuhaisni.BL.Interfaces;
using ElMuhaisni.DAL.Context;
using ElMuhaisni.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElMuhaisni.BL.Repositories
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly ElMuhaisniContext context;

        public DepartmentRepo(ElMuhaisniContext context)
        {
            this.context = context;
        }

        public ApiResponse<string> Create(CreateDepartmentDTO departmentDto)
        {
            var department = new Department
            {
                Name = departmentDto.Name,
                Description = departmentDto.Description
            };

            context.Departments.Add(department);
            context.SaveChanges();

            return new ApiResponse<string>("Created", "Department Created", true, 201);
        }

        public ApiResponse<List<DepartmentDTO>> GetAll()
        {
            var departments = context.Departments.Select(d => new DepartmentDTO
            {
                Id = d.Id,
                Name = d.Name,
                Description = d.Description
            }).ToList();


            return new ApiResponse<List<DepartmentDTO>>(departments, "Date Returned", true, 200);
        }

        public ApiResponse<DepartmentDTO> GetById(int id)
        {
            var department = context.Departments.Where(d => d.Id == id).Select(d => new DepartmentDTO
            {
                Id = d.Id,
                Name = d.Name,
                Description = d.Description
            }).FirstOrDefault();


            return new ApiResponse<DepartmentDTO>(department, "Date Returned", true, 200);
        }

        public ApiResponse<DepartmentDTO> GetByName(string name)
        {
            var department = context.Departments.Where(d => d.Name == name).Select(d => new DepartmentDTO
            {
                Id = d.Id,
                Name = d.Name,
                Description = d.Description
            }).FirstOrDefault();

            return new ApiResponse<DepartmentDTO>(department, "Date Returned", true, 200);
        }

        public ApiResponse<string> EditDepartment(int id, DepartmentDTO newDepartment)
        {
            var oldDepartment = context.Departments.Where(d => d.Id == id).FirstOrDefault();

            oldDepartment.Name = newDepartment.Name;
            oldDepartment.Description = newDepartment.Description;

            context.SaveChanges();

            return new ApiResponse<string>("Updated", "Department Updated", true, 200);

        }

        public ApiResponse<string> Delete(int id)
        {
            var deletedDepartment = context.Departments.Find(id);

            context.Departments.Remove(deletedDepartment);

            context.SaveChanges();

            return new ApiResponse<string>("Deleted", "lastNew Deleted", true, 200);
        }
    }
}

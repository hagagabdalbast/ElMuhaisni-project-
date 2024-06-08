using ElMuhaisni.BL.DTO;
using ElMuhaisni.BL.DTO.Project;
using ElMuhaisni.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElMuhaisni.BL.Interfaces
{
    public interface IProjectRepo
    {

        ApiResponse<List<ProjectDTO>> GetAll();
        ApiResponse<ProjectDTO> GetById(int id);
        ApiResponse<string> Create(CreatProjectDTO projectDto);
        
        ApiResponse<string> Edit(int id, UpdateProjectDTO updateProjectDTO);
        ApiResponse<string> Delete(int id);
    }
}

using ElMuhaisni.BL.DTO;
using ElMuhaisni.BL.DTO.LastNews;
using ElMuhaisni.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElMuhaisni.BL.Interfaces
{
    public interface ILastNewRepo
    {
        ApiResponse<List<LastNewDTO>> GetAll();
        ApiResponse<LastNewDTO> GetById(int id);
        ApiResponse<string> Create(CreateLastNewDTO newDTO);
        ApiResponse<string> Edit(int id, UpdateLastNewDTO newDTO);
        ApiResponse<string> Delete(int id);
    }
}

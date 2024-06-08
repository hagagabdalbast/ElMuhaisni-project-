using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElMuhaisni.BL.DTO
{
    public class ApiResponse<T>
    {
        public ApiResponse(T data, string message, bool success, int? code)
        {
            Data = data;
            Message = message;
            Success = success; 
            Code = code;
        }

        public T Data { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
        public int? Code { get; set; }
    }
}

using ElMuhaisni.BL.DTO;
using ElMuhaisni.BL.DTO.Project;
using ElMuhaisni.BL.Interfaces;
using ElMuhaisni.DAL.Context;
using ElMuhaisni.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ElMuhaisni.BL.Repositories
{
    public class ProjectRepo : IProjectRepo
    {
        private readonly ElMuhaisniContext context;

        public ProjectRepo(ElMuhaisniContext context)
        {
            this.context = context;
        }

        public ApiResponse<List<ProjectDTO>> GetAll()
        {
            var projects = context.Projects.Include(d => d.Department).Include(p => p.Attachments).Select(p => new ProjectDTO
            {
                Id = p.Id,
                Title = p.Title,
                Description = p.Description,
                Phone = p.Phone,
                //Photo = p.Photo,
                StartDate = p.StartDate,
                EndDate = p.EndDate,
                DepartmentName = p.Department.Name,
                DepartmentId = p.DepartmentId,
                PhotoUrls = p.Attachments.Select(a => a.PhotoUrl).ToList()
            }).ToList();


            return new ApiResponse<List<ProjectDTO>>(projects, "Date returned", true, 200);
        }

        public ApiResponse<ProjectDTO> GetById(int id)
        {
            var project = context.Projects.Include(d => d.Department).Include(p => p.Attachments).Where(p => p.Id == id).Select(p => new ProjectDTO
            {
                Id = p.Id,
                Title = p.Title,
                Description = p.Description,
                Phone = p.Phone,
                //Photo = p.Photo,
                StartDate = p.StartDate,
                EndDate = p.EndDate,
                DepartmentName = p.Department.Name,
                DepartmentId = p.DepartmentId,
                PhotoUrls = p.Attachments.Select(a => a.PhotoUrl).ToList()
            }).FirstOrDefault();


            return new ApiResponse<ProjectDTO>(project, "Date returned", true, 200);
        }

        public ApiResponse<string> Create(CreatProjectDTO projectDto)
        {
            var newProject = new Project
            {
                Title = projectDto.Title,
                Description = projectDto.Description,
                Phone = projectDto.Phone,
                //Photo = projectDto.Photo,
                StartDate = projectDto.StartDate,
                EndDate = projectDto.EndDate,
                DepartmentId=projectDto.DepartmentId
            };

            context.Projects.Add(newProject);

            context.SaveChanges();

            foreach (var photo in projectDto.Photos)
            {
                var projectPhoto = new Attachment
                {
                    PhotoUrl =  SavePhoto(photo),
                    //Project = newProject,
                    ProjectId = newProject.Id
                };
                newProject.Attachments.Add(projectPhoto);
            }

            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Log the inner exception
                Console.WriteLine($"Inner exception: {ex.InnerException?.Message}");
                throw;

            }

            return new ApiResponse<string>("Created", "Project Created", true, 201);

            
        }

        private string SavePhoto(IFormFile photo)
        {
            // Save the photo to a file storage (e.g., local file system, Azure Blob Storage, etc.)
            // and return the URL or file path
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(photo.FileName);
            var filePath = Path.Combine("wwwroot", "Images", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                photo.CopyToAsync(stream);
            }

            return $"/Images/{fileName}";
        }

        public ApiResponse<string> Edit(int id, UpdateProjectDTO newProject)
        {
            var oldProject = context.Projects.Where(d => d.Id == id).FirstOrDefault();

            oldProject.Title = newProject.Title;
            oldProject.Description = newProject.Description;
            oldProject.Phone = newProject.Phone;
            //oldProject.Photo = newProject.Photo;
            oldProject.StartDate = newProject.StartDate;
            oldProject.EndDate = newProject.EndDate;
            oldProject.DepartmentId = newProject.DepartmentId;

            context.SaveChanges();

            return new ApiResponse<string>("Updated", "Project Updated", true, 200); ;

        }

        public ApiResponse<string> Delete(int id)
        {
            var deletedProject = context.Projects.Find(id);

            context.Projects.Remove(deletedProject);

            context.SaveChanges();

            return new ApiResponse<string>("Deleted", "lastNew Deleted", true, 200);
        }
    }
}

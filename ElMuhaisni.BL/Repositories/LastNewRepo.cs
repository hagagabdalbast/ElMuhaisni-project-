using ElMuhaisni.BL.DTO;
using ElMuhaisni.BL.DTO.LastNews;
using ElMuhaisni.BL.DTO.Project;
using ElMuhaisni.BL.Interfaces;
using ElMuhaisni.DAL.Context;
using ElMuhaisni.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElMuhaisni.BL.Repositories
{
    public class LastNewRepo : ILastNewRepo
    {
        private readonly ElMuhaisniContext context;

        public LastNewRepo(ElMuhaisniContext context)
        {
            this.context = context;
        }

        public ApiResponse<List<LastNewDTO>> GetAll()
        {
            var lastNews = context.LastNews.Select(p => new LastNewDTO
            {
                Id = p.Id,
                Title = p.Title,
                Description = p.Description,
                //Photo = p.Photo,
                PhotoUrls = p.Attachments.Select(a => a.PhotoUrl).ToList()

            }).ToList();


            return new ApiResponse<List<LastNewDTO>>(lastNews, "Data Returned", true, 200);
        }

        public ApiResponse<LastNewDTO> GetById(int id)
        {
            var lastNew = context.LastNews.Where(l => l.Id == id).Select(p => new LastNewDTO
            {
                Id = p.Id,
                Title = p.Title,
                Description = p.Description,
                // Photo = p.Photo,
                PhotoUrls = p.Attachments.Select(a => a.PhotoUrl).ToList(),

            }).FirstOrDefault();


            return new ApiResponse<LastNewDTO>(lastNew, "Data Returned", true, 200);
        }

        public ApiResponse<string> Create(CreateLastNewDTO newDTO)
        {
            var lastNew = new LastNew
            {
                Title = newDTO.Title,
                Description = newDTO.Description
                // Photo = newDTO.Photo,
            };

            context.LastNews.Add(lastNew);
            context.SaveChanges(); // Save to generate the Id for the new LastNews

            foreach (var photo in newDTO.Photos)
            {
                var LastNewPhoto = new Attachment
                {
                    PhotoUrl = SavePhoto(photo),
                    LastNewId = lastNew.Id // Correctly assign the LastNewId
                };
                context.Attachments.Add(LastNewPhoto); // Add the attachment directly to the context
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

            return new ApiResponse<string>("Created", "LastNew Created", true, 201);
        }

        private string SavePhoto(IFormFile photo)
        {
            // Save the photo to a file storage (e.g., local file system, Azure Blob Storage, etc.)
            // and return the URL or file path
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(photo.FileName);
            var filePath = Path.Combine("wwwroot", "Images", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                photo.CopyTo(stream);
            }

            return $"/Images/{fileName}";
        }



        public ApiResponse<string> Edit(int id, UpdateLastNewDTO newDTO)
        {
            var oldNews = context.LastNews.Where(d => d.Id == id).FirstOrDefault();

            oldNews.Title = newDTO.Title;
            oldNews.Description = newDTO.Description;            
            //oldNews.Photo = newDTO.Photo;
           
            context.SaveChanges();

            return new ApiResponse<string>("Updated", "lastNew Updated", true, 200);
        }

        public ApiResponse<string> Delete(int id)
        {
            var deletedNews = context.LastNews.Find(id);

            context.LastNews.Remove(deletedNews);

            context.SaveChanges();

            return new ApiResponse<string>("Deleted", "lastNew Deleted", true, 200);
        }
    }
}

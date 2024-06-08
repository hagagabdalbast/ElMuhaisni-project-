using ElMuhaisni.BL.DTO;
using ElMuhaisni.BL.DTO.Contact;
using ElMuhaisni.BL.DTO.LastNews;
using ElMuhaisni.BL.Interfaces;
using ElMuhaisni.DAL.Context;
using ElMuhaisni.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ElMuhaisni.BL.Repositories
{

    public class ContactRepo : IContactRepo
    {

        private readonly ElMuhaisniContext context;
        private readonly IConfiguration _configuration;

        public ContactRepo(ElMuhaisniContext context, IConfiguration configuration)
        {
            this.context = context;
        }

        

        public ApiResponse<string> Create(CreateContactDTO contactDTO)
        {
            var contact = new ContactUs
            {
                Name = contactDTO.Name,
                Description = contactDTO.Description,
                Email = contactDTO.Email,
            };

            context.ContactUs.Add(contact);
            context.SaveChanges();

            //SendEmailNotification(contact);

            return new ApiResponse<string>("Created", "contact Created", true, 201);
        }

        //private void SendEmailNotification(ContactUs contact)
        //{
        //    var emailSettings = _configuration.GetSection("EmailSettings");

        //    var smtpClient = new SmtpClient
        //    {
        //        Host = emailSettings["SmtpHost"],
        //        Port = int.Parse(emailSettings["SmtpPort"]),
        //        EnableSsl = bool.Parse(emailSettings["EnableSsl"]),
        //        Credentials = new NetworkCredential(
        //            emailSettings["SmtpUsername"],
        //            emailSettings["SmtpPassword"])
        //    };

        //    var message = new MailMessage
        //    {
        //        From = new MailAddress(emailSettings["FromEmail"]),
        //        To = { new MailAddress(emailSettings["ToEmail"]) },
        //        Subject = "New Contact Created",
        //        Body = $"A new contact has been created: {contact.Description}"
        //    };

        //    smtpClient.SendMailAsync(message);
        //}
    

    public ApiResponse<List<ContactDTO>> GetAll()
        {
            var contacts = context.ContactUs.Select(p => new ContactDTO
            {
                Id = p.Id,
                Email = p.Email,
                Description = p.Description,
                Name = p.Name,

            }).ToList();


            return new ApiResponse<List<ContactDTO>>(contacts, "Data Returned", true, 200);
        }

        public ApiResponse<ContactDTO> GetById(int id)
        {
            var contact = context.ContactUs.Where(c => c.Id == id).Select(p => new ContactDTO
            {
                Id = p.Id,
                Email = p.Email,
                Description = p.Description,
                Name = p.Name,

            }).FirstOrDefault();


            return new ApiResponse<ContactDTO>(contact, "Date Returned", true, 200);

        }
    }
}


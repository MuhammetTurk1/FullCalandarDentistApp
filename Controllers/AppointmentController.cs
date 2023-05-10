using DentistCalendar.Data;
using DentistCalendar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DentistCalendar.Controllers
{
    public class AppointmentController : Controller
    {
        ApplicationDbContext _context;

        public JsonResult GetAppointments()
        {
            var model = _context.Appointments
                .Include(x => x.User).Select(x => new AppointmentViewModel()
                {
                    Id = x.Id,
                    Dentist = x.User.Name + " " + x.User.Surname,
                    PatientName = x.PatientName,
                    PatientSurname = x.PatientSurname,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Description = x.Description,
                    Color = x.User.Color,
                    UserId = x.User.Id
                });

            return Json(model);
        }


        public JsonResult GetAppointmentsByDentist(string userId = "")
        {
            var model = _context.Appointments.Where(x => x.User.Id == userId)
                .Include(x => x.User).Select(x => new AppointmentViewModel()
                {
                    Id = x.Id,
                    Dentist = x.User.Name + " " + x.User.Surname,
                    PatientName = x.PatientName,
                    PatientSurname = x.PatientSurname,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Description = x.Description,
                    Color = x.User.Color,
                    UserId = x.User.Id
                });

            return Json(model);
        }


    }
}

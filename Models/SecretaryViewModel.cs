using DentistCalendar.Data.Entity;

namespace DentistCalendar.Models
{
    public class SecretaryViewModel
    {
        public AppUser User { get; set; }
        public IEnumerable<AppUser> Dentists { get; set; }
    }
}